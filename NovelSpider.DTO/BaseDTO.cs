using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovelSpider.DTO
{
    public abstract class BaseDTO
    {
        public long Id { get; set; }
        public long CreateUser { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? ModifyTime { get; set; }
        public long? ModifyUser { get; set; }
    }
}
