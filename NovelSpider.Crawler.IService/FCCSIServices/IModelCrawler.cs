using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovelSpider.Crawler.IService.FCCSIServices
{
    public interface IModelCrawler
    {
        void Crawler(string url);
    }
}
