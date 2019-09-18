using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NovelSpider.Crawler.IService;
using NovelSpider.Crawler.Service;
using NovelSpider.Framework.Http;
using NovelSpider.Framework.Log;

namespace NovelSpider
{
    class Program
    {
        private static Log4NetHelper Loger = new Log4NetHelper(typeof(AllVisitCrawler));
        static void Main(string[] args)
        {
            try
            {
                //using (NovelDbContext ctx = new NovelDbContext())
                //{
                //    ctx.Database.Create();
                //}
                //string html = HttpHelper.DownloadHtml("https://www.23us.so/top/allvisit_1.html").Result;
                //string html = HttpHelper.DownloadHtml("https://www.baidu.com").Result;
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                IAllVisitCrawler allVisitCrawler = new AllVisitCrawler();
                allVisitCrawler.Crawl(@"https://www.23us.so/top/allvisit_7.html");
                stopwatch.Stop();
                Console.WriteLine($"全部小说已经下载完成，总耗时{stopwatch.Elapsed.Days}天{stopwatch.Elapsed.Hours}小时{stopwatch.Elapsed.Minutes}分钟{stopwatch.Elapsed.Milliseconds}秒");
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
