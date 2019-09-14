using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NovelSpider.Model.EnumModel;

namespace NovelSpider.Model
{
    public abstract class BaseModel
    {
        public long Id { get; set; }
        public long CreateUser { get; set; } = 0;
        public DateTime CreateTime { get; set; } = DateTime.Now;
        public DateTime? ModifyTime { get; set; }
        public long? ModifyUser { get; set; }
        public DataState State { get; set; } = DataState.NotDeleted;

    }
}
