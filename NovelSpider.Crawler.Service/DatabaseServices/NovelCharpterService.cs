using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NovelSpider.Crawler.IService.DatabaseIServices;
using NovelSpider.Model;

namespace NovelSpider.Crawler.Service.DatabaseServices
{
    public class NovelCharpterService: INovelCharpterService
    {
        public long AddNew(long novelId,int charpterNum, string charpterLinkPath)
        {
            NovelCharpter novelCharpter = new NovelCharpter();
            novelCharpter.CharpterNum = charpterNum;
            novelCharpter.CharpterLinkPath = charpterLinkPath;
            novelCharpter.NovelId = novelId;
            using (NovelDbContext ctx = new NovelDbContext())
            {
                ctx.NovelCharpters.Add(novelCharpter);
                ctx.SaveChanges();
            }

            return novelCharpter.Id;

        }

        public NovelCharpter QueryByLink(string charpterLinkPath)
        {
            using (NovelDbContext ctx = new NovelDbContext())
            {
                BaseService<NovelCharpter> service = new BaseService<NovelCharpter>(ctx);
                return service
                    .GetAll()
                    .FirstOrDefault(n => n.CharpterLinkPath.Equals(charpterLinkPath, StringComparison.InvariantCultureIgnoreCase));
            }
        }
    }
}
