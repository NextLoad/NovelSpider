using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovelSpider.Crawler.IService.DatabaseIServices.FCCS
{
    public interface ITenementService
    {
        long AddNew(string name);
        bool IsExists(string name);
        bool IsExists(long id);/// <summary>
        /// 获取Id
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        long? GetByName(string name);
    }
}
