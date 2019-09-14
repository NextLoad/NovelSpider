using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NovelSpider.Crawler.IService.DatabaseIServices;
using NovelSpider.DTO;
using NovelSpider.Model;

namespace NovelSpider.Crawler.Service.DatabaseServices
{
    public class NoverService : INovelService
    {
        public IEnumerable<Novel> GetAll()
        {
            using (NovelDbContext ctx = new NovelDbContext())
            {
                BaseService<Novel> service = new BaseService<Novel>(ctx);
                return service.GetAll().ToList();
            }
        }

        public long AddNew(NovelDTO novelDTO)
        {
            Novel novel = new Novel();
            novel.Name = novelDTO.Name;
            novel.Author = novelDTO.Author;
            novel.ContentLength = novelDTO.ContentLength;
            novel.DetailLinkPath = novelDTO.DetailLinkPath;
            novel.LastUpdateTime = novelDTO.LastUpdateTime;
            novel.NovelStatus = novelDTO.NovelStatus;
            novel.NovelType = novelDTO.NovelType;
            novel.NumberOfFavorites = novel.NumberOfFavorites;
            using (NovelDbContext ctx = new NovelDbContext())
            {
                BaseService<Novel> service = new BaseService<Novel>(ctx);
                var model = service.GetAll().Where(n => n.Name == novelDTO.Name).FirstOrDefault();
                if (model == null)
                {
                    ctx.Novels.Add(novel);
                    ctx.SaveChanges();
                }
                else
                {
                    novel = model;
                }
                
            }
            return novel.Id;
        }

        public Novel QueryByLink(string linkPath)
        {
            using (NovelDbContext ctx = new NovelDbContext())
            {
                BaseService<Novel> service = new BaseService<Novel>(ctx);
                return service
                    .GetAll()
                    .FirstOrDefault(n => n.DetailLinkPath.Equals(linkPath, StringComparison.InvariantCultureIgnoreCase));
            }
        }
    }
}
