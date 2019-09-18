using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HtmlAgilityPack;
using NovelSpider.Crawler.IService.FCCSIServices;
using NovelSpider.Framework.Http;

namespace NovelSpider.Crawler.Service.FCCSServices
{
    public class BriefCrawler : IBriefCrawler
    {
        private IList<string> briefList;
        public IList<string> BriefList => briefList;

        public void Crawler(string url)
        {
            briefList = new List<string>();
            string briefHtml = HttpHelper.DownloadHtml(url).Result;
            HtmlDocument briefDoc = new HtmlDocument();
            briefDoc.LoadHtml(briefHtml);

            string briefXPath = "//*[@class='infoTable2']/dl";
            HtmlNodeCollection dlNodes = briefDoc.DocumentNode.SelectNodes(briefXPath);
            foreach (HtmlNode dlNode in dlNodes)
            {
                briefList.Add(Regex.Replace(dlNode.InnerText, @"[\s]", ""));
            }

            string briefIntruXPath = "//*[@class='conWrap_y2']";
            HtmlNode divNode = briefDoc.DocumentNode.SelectSingleNode(briefIntruXPath);
            if (divNode != null)
            {
                briefList.Add($"楼盘简介：{divNode.InnerText}");
            }
        }
    }
}
