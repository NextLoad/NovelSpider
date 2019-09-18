using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HtmlAgilityPack;
using NovelSpider.Crawler.IService.FCCSIServices;
using NovelSpider.Framework.Http;
using SpiderForFCCS.BusinessModel;

namespace NovelSpider.Crawler.Service.FCCSServices
{
    public class NewHouseCrawler : INewHouseCrawler
    {
        private Dictionary<string, NewHouseInfo> newHouseDic = new Dictionary<string, NewHouseInfo>();

        public Dictionary<string, NewHouseInfo> NewHouseDic => newHouseDic;

        public void Crawler(string url)
        {
            string newHouseHtml = HttpHelper.DownloadHtml(url).Result;
            HtmlDocument newHouseDoc = new HtmlDocument();
            newHouseDoc.LoadHtml(newHouseHtml);
            string realEstateXPath = "//*[@class='listWrap1']/ul/li";
            HtmlNodeCollection realEstates = newHouseDoc.DocumentNode.SelectNodes(realEstateXPath);
            if (realEstates == null || realEstates.Count <= 0)
            {
                return;
            }
            Regex regexForrealEstateId = new Regex(@"[\d]+");

            foreach (HtmlNode realEstate in realEstates)
            {
                IList<string> priceList = new List<string>();
                var info1Node = realEstate.SelectSingleNode("div/div[@class='info1']");
                var aNode = info1Node.SelectSingleNode("div/a[@class='tit']");
                //楼盘详情链接
                string realEstateLink = aNode.Attributes["href"].Value;
                //楼盘名称
                string realEstateName = aNode.InnerHtml;

                string realEstateId = regexForrealEstateId.Match(realEstateLink).Groups[0].Value;

                var info2Node = realEstate.SelectSingleNode("div/div[@class='info2']");
                var priceNodes = info2Node.SelectNodes("div[@class='price1']");
                
                foreach (HtmlNode priceNode in priceNodes)
                {
                    string priceText = Regex.Replace(priceNode.InnerText, @"[\s]", "");

                    priceList.Add(priceText);

                }
                newHouseDic.Add(realEstateId, new NewHouseInfo { Name = realEstateName, DetailLinkPath = realEstateLink, PriceDic = priceList });

            }

            //获取下一页的楼盘信息
            Regex regex = new Regex(@"[\d]+");
            int pageNum = Convert.ToInt32(regex.Match(url).Groups[0].Value);
            Crawler(Regex.Replace(url, @"[\d]+", (++pageNum).ToString()));

        }
    }
}
