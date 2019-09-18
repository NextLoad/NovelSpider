using System;
using System.Collections.Generic;
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
    public class ModelCrawler : IModelCrawler
    {
        private IList<HouseModelInfo> houseModelInfos;
        public IList<HouseModelInfo> HouseModelInfos => houseModelInfos;
        public void Crawler(string url)
        {
            houseModelInfos = new List<HouseModelInfo>();
            string modelHtml = HttpHelper.DownloadHtml(url).Result;
            HtmlDocument modelDoc = new HtmlDocument();
            modelDoc.LoadHtml(modelHtml);

            string modelXPath = "//*[@class='list_hx list_y2']/ul/li";
            HtmlNodeCollection liNodes = modelDoc.DocumentNode.SelectNodes(modelXPath);
            if (liNodes != null)
                foreach (HtmlNode liNode in liNodes)
                {
                    var py1Node = liNode.SelectSingleNode("div[@class='py1']");

                    var py2Node = liNode.SelectSingleNode("div[@class='py2']");
                    var houseModelInfo = new HouseModelInfo
                    {
                        HouseTypeName = Regex.Replace(py1Node.ChildNodes[1].InnerHtml, @"\s", ""),
                        TenementName = Regex.Replace(py1Node.ChildNodes[3].InnerHtml, @"\s", ""),
                        HouseTypeStatus = Regex.Replace(py1Node.ChildNodes[5].InnerHtml, @"\s", ""),
                        HouseTypeDesc = Regex.Replace(py2Node.ChildNodes[0].InnerHtml, @"\s", ""),
                        Area = Regex.Replace(py2Node.ChildNodes[2].InnerHtml, @"\s", ""),
                    };
                    houseModelInfos.Add(houseModelInfo);
                }
        }
    }
}
