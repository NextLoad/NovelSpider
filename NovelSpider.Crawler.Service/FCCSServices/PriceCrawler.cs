using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using NovelSpider.Crawler.IService.FCCSIServices;
using NovelSpider.Framework.Http;
using SpiderForFCCS.BusinessModel;

namespace NovelSpider.Crawler.Service.FCCSServices
{
    public class PriceCrawler : IPriceCrawler
    {
        private IList<PriceTrend> priceTrends;
        public IList<PriceTrend> PriceTrends => priceTrends;
        public void Crawler(string url)
        {
            this.priceTrends = new List<PriceTrend>();
            string priceHtml = HttpHelper.DownloadHtml(url).Result;
            HtmlDocument priceDoc = new HtmlDocument();
            priceDoc.LoadHtml(priceHtml);

            string priceTablePath = "//*[@class='coltable mb28']";
            HtmlNodeCollection priceTableNodes = priceDoc.DocumentNode.SelectNodes(priceTablePath);
            if (priceTableNodes == null)
            {
                return;
            }

            var priceTableNode = priceTableNodes.Last();
            if (priceTableNode == null)
            {
                return;
            }

            var trNodes = priceTableNode.SelectNodes("tr");
            if (trNodes == null)
            {
                return;
            }

            if (trNodes[0].SelectNodes("th").Count == 4)
            {
                for (int i = 1; i < trNodes.Count; i++)
                {
                    PriceTrend priceTrend = new PriceTrend();
                    priceTrend.RecordTime = Convert.ToDateTime(trNodes[i].SelectNodes("td")[0].InnerHtml);
                    priceTrend.TenementName = trNodes[i].SelectNodes("td")[1].InnerHtml;
                    priceTrend.Price = trNodes[i].SelectNodes("td")[2].InnerHtml;
                    priceTrend.PriceDesc = trNodes[i].SelectNodes("td")[3].InnerHtml;
                    this.priceTrends.Add(priceTrend);
                }
            }
            else
            {
                for (int i = 1; i < trNodes.Count; i++)
                {
                    PriceTrend priceTrend = new PriceTrend();
                    priceTrend.TenementName = trNodes[i].SelectNodes("td")[0].InnerHtml;
                    priceTrend.Price = trNodes[i].SelectNodes("td")[1].InnerHtml;
                    priceTrend.PriceDesc = trNodes[i].SelectNodes("td")[2].InnerHtml;
                    this.priceTrends.Add(priceTrend);
                }
            }
        }

    }
}
