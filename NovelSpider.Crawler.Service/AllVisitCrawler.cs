using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using NovelSpider.Crawler.IService;
using NovelSpider.Framework.Http;
using NovelSpider.Framework.Log;

namespace NovelSpider.Crawler.Service
{
    public class AllVisitCrawler: IAllVisitCrawler
    {
        private Log4NetHelper Loger = new Log4NetHelper(typeof(AllVisitCrawler));
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
            foreach (HtmlNode novelNode in novelNodes)
            {
                string novelName = novelNode.InnerHtml;
                string novelLinkPath = novelNode.Attributes["href"].Value;
                Console.WriteLine(novelName);
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
