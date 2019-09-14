using NovelSpider.DTO;
using NovelSpider.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovelSpider.Crawler.IService.DatabaseIServices
{
    public interface INovelService
    {
        IEnumerable<Novel> GetAll();
        long AddNew(NovelDTO novel);
        Novel QueryByLink(string linkPath);
    }
}
