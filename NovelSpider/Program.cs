using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NovelSpider.Crawler.IService;
using NovelSpider.Crawler.Service;
using NovelSpider.Framework.Http;

namespace NovelSpider
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //string html = HttpHelper.DownloadHtml("https://www.23us.so/top/allvisit_1.html").Result;
                //string html = HttpHelper.DownloadHtml("https://www.baidu.com").Result;
                IAllVisitCrawler allVisitCrawler = new AllVisitCrawler();
                allVisitCrawler.Crawl(@"https://www.23us.so/top/allvisit_1.html");
                Console.WriteLine("ok");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
            Console.ReadKey();
        }
    }
}
