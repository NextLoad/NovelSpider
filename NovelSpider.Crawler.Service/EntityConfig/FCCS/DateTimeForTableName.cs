using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovelSpider.Crawler.Service.EntityConfig.FCCS
{
    public static class DateTimeForTableName
    {
        public static string TableNameSuffix { get; set; } = DateTime.Now.ToString("yyyyMMdd");
    }
}
