using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpiderForFCSS.Model.EnumModel;

namespace SpiderForFCSS.Model
{
    public abstract class BaseModel
    {
        public long Id { get; set; }
        public long CreateUser { get; set; } = 0;
        public DateTime CreateTime { get; set; } = DateTime.Now;
        public DateTime? ModifyTime { get; set; }
        public long? ModifyUser { get; set; }
        public DataStateFCCS StateFccs { get; set; } = DataStateFCCS.NotDeleted;

    }
}
