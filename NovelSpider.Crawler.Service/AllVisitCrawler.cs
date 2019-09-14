using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Microsoft.SqlServer.Server;
using NovelSpider.Crawler.IService;
using NovelSpider.Crawler.IService.DatabaseIServices;
using NovelSpider.Crawler.Service.DatabaseServices;
using NovelSpider.DTO;
using NovelSpider.Framework.Http;
using NovelSpider.Framework.Log;

namespace NovelSpider.Crawler.Service
{
    public class AllVisitCrawler : IAllVisitCrawler
    {
        private Log4NetHelper Loger = new Log4NetHelper(typeof(AllVisitCrawler));
        private INovelService novelService = new NoverService();
        private INovelCharpterService novelCharpterService = new NovelCharpterService();
        public void Crawl(string url)
        {
            Int32.TryParse(Path.GetFileNameWithoutExtension(url.Split('_')[1]), out int curPage);
            //1.下载需要爬取的页面
            string html = HttpHelper.DownloadHtml(url).Result;

            //2.加载html内容
            HtmlAgilityPack.HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(html);

            //3获取总页数
            string pagestatesPath = "//*[@id='pagestats']";
            HtmlNode pagestateNode = doc.DocumentNode.SelectSingleNode(pagestatesPath);
            Int32.TryParse(pagestateNode.InnerHtml.Split('/')[1], out int pageCount);
            if (curPage >= pageCount)
            {
                return;
            }
            //4获取当前页面中小说名称的节点
            string novelPath = "//*[@id='content']/dd/table/tr/td[1]/a";
            HtmlNodeCollection novelNodes = doc.DocumentNode.SelectNodes(novelPath);
            //Regex regex = new Regex("");
            int index = 0;
            int novelNum = 0;
            var lastModel = novelService.GetAll().OrderByDescending(n => n.Id).FirstOrDefault();
            foreach (HtmlNode novelNode in novelNodes)
            {
                try
                {
                    novelNum++;
                    NovelDTO novelDTO = new NovelDTO();
                    novelDTO.Name = novelNode.InnerHtml;
                    novelDTO.DetailLinkPath = novelNode.Attributes["href"].Value;
                    var model = novelService.QueryByLink(novelDTO.DetailLinkPath);
                    if (model != null && lastModel.Name != model.Name)
                    {
                        continue;
                    }
                    string floaderPath = $@"C:/顶点小说/{novelDTO.Name}";
                    if (!Directory.Exists(floaderPath))
                    {
                        Directory.CreateDirectory(floaderPath);
                    }
                    //else
                    //{
                    //    floaderPath = $"{floaderPath}{++index}";
                    //    Directory.CreateDirectory(floaderPath);
                    //}


                    //小说详情页htnml
                    string novelDetailHtml = HttpHelper.DownloadHtml(novelDTO.DetailLinkPath).Result;
                    HtmlDocument detailDoc = new HtmlDocument();
                    detailDoc.LoadHtml(novelDetailHtml);
                    //小说类别
                    string novelTypePath = "//*[@id='at']/tr[1]/td[1]/a";
                    HtmlNode novelTypeNode = detailDoc.DocumentNode.SelectSingleNode(novelTypePath);
                    novelDTO.NovelType = novelTypeNode.InnerHtml;
                    //小说作者
                    string novelAuthorPath = "//*[@id='at']/tr[1]/td[2]";
                    HtmlNode novelAuthorNode = detailDoc.DocumentNode.SelectSingleNode(novelAuthorPath);
                    novelDTO.Author = novelAuthorNode.InnerHtml;
                    //小说状态
                    string novelStatusPath = "//*[@id='at']/tr[1]/td[3]";
                    HtmlNode novelStatusNode = detailDoc.DocumentNode.SelectSingleNode(novelStatusPath);
                    novelDTO.NovelStatus = novelStatusNode.InnerHtml;
                    //小说收藏数
                    string novelNumberOfFavoritesPath = "//*[@id='at']/tr[2]/td[1]";
                    HtmlNode novelNumberOfFavoritesNode = detailDoc.DocumentNode.SelectSingleNode(novelNumberOfFavoritesPath);
                    novelDTO.NumberOfFavorites = Int32.Parse(Regex.Replace(novelNumberOfFavoritesNode.InnerHtml, @"[^0-9]+", ""));
                    //小说全文长度
                    string novelContentLengthPath = "//*[@id='at']/tr[2]/td[2]";
                    HtmlNode novelContentLengthNode = detailDoc.DocumentNode.SelectSingleNode(novelContentLengthPath);
                    novelDTO.ContentLength = Int32.Parse(Regex.Replace(novelContentLengthNode.InnerHtml, @"[^0-9]+", ""));
                    //小说最后更新时间
                    string novelLastUpdateTimePath = "//*[@id='at']/tr[2]/td[3]";
                    HtmlNode novelLastUpdateTimeNode = detailDoc.DocumentNode.SelectSingleNode(novelLastUpdateTimePath);
                    novelDTO.LastUpdateTime = Convert.ToDateTime(novelLastUpdateTimeNode.InnerHtml.Replace("&nbsp;", ""));

                    //小说信息入库
                    long novelId = novelService.AddNew(novelDTO);
                    //小说的总章节
                    string novelCharpterLinkPath = "//*[@id='content']/dd/div/p/a[1]";
                    HtmlNode novelCharpterLinkNode = detailDoc.DocumentNode.SelectSingleNode(novelCharpterLinkPath);
                    string charpterLink = novelCharpterLinkNode.Attributes["href"].Value;

                    //小说章节详情页htnml
                    string novelCharpterDetailHtml = HttpHelper.DownloadHtml(charpterLink).Result;
                    HtmlDocument charpterDetailDoc = new HtmlDocument();
                    charpterDetailDoc.LoadHtml(novelCharpterDetailHtml);
                    //小说各章节链接地址
                    string novelCharpterDetailLinkPath = "//*[@id='at']/tr/td/a";
                    HtmlNodeCollection charpterNodes =
                        charpterDetailDoc.DocumentNode.SelectNodes(novelCharpterDetailLinkPath);
                    int charpterNum = 0;
                    foreach (HtmlNode charpterNode in charpterNodes)
                    {
                        try
                        {
                            charpterNum++;
                            //章节名称
                            string charpterName = charpterNode.InnerHtml;
                            //章节详细链接
                            string charpterDetailLink = charpterNode.Attributes["href"].Value;
                            var charpterModel = novelCharpterService.QueryByLink(charpterDetailLink);
                            if (charpterModel != null)
                            {
                                continue;
                            }
                            long charpterId = novelCharpterService.AddNew(novelId, charpterNum, charpterDetailLink);

                            //章节html内容
                            string charpterHtml = HttpHelper.DownloadHtml(charpterDetailLink).Result;
                            HtmlDocument charpterDoc = new HtmlDocument();
                            charpterDoc.LoadHtml(charpterHtml);

                            string charpterContentPath = "//*[@id='contents']";
                            HtmlNode charpteContentrNode = charpterDoc.DocumentNode.SelectSingleNode(charpterContentPath);
                            //小说章节内容
                            string content = charpteContentrNode.InnerHtml.Replace("&nbsp;", " ").Replace("<br>", "\r");
                            File.AppendAllText($"{floaderPath}/{charpterName}.txt", content);
                            Console.WriteLine($"正在下载第{novelNum}本小说，小说名称：{novelDTO.Name}的第{charpterNum}章的内容");
                        }
                        catch (Exception ex)
                        {
                            Loger.Error("下载章节出错", ex);
                        }


                    }
                }
                catch (Exception ex)
                {
                    Loger.Error("访问页面出错", ex);
                }
            }
            Crawl(GetNewUrl(url));
        }

        private string GetNewUrl(string url)
        {
            string[] urlString = url.Split('_');
            Int32.TryParse(Path.GetFileNameWithoutExtension(urlString[1]), out int curPage);
            string newUrl = $"{urlString[0]}_{++curPage}{Path.GetExtension(urlString[1])}";
            return newUrl;
        }
    }
}
