using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpiderForFCCS.BusinessModel
{
    public class PriceTrend
    {
        public string TenementName { get; set; }
        public DateTime RecordTime { get; set; }
        public string PriceDesc { get; set; }
        public string Price { get; set; }
    }
}
