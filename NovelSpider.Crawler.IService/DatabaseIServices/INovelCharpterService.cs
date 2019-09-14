using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NovelSpider.Model;

namespace NovelSpider.Crawler.IService.DatabaseIServices
{
    public interface INovelCharpterService
    {
        long AddNew(long novelId,int charpterNum,string charpterLinkPath);
        NovelCharpter QueryByLink(string charpterLinkPath);
    }
}
