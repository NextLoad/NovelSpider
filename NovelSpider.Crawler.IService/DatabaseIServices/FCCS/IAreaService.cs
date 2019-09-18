using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovelSpider.Crawler.IService.DatabaseIServices.FCCS
{
    public interface IAreaService
    {
        /// <summary>
        /// 添加区域
        /// </summary>
        /// <param name="name"></param>
        /// <param name="parentId"></param>
        /// <returns></returns>
        long AddNew(string name,long? parentId);
        /// <summary>
        /// 是否存在区域
        /// </summary>
        /// <param name="name">区域名称</param>
        /// <returns></returns>
        bool IsExists(string name);
        /// <summary>
        /// 是否存在区域
        /// </summary>
        /// <param name="id">区域Id</param>
        /// <returns></returns>
        bool IsExists(long id);

        /// <summary>
        /// 获取Id
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        long? GetByName(string name);
    }
}
