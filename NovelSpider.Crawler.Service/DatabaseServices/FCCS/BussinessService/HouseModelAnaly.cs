using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using SpiderForFCCS.BusinessModel;
using SpiderForFCCS.DTO;
using SpiderForFCSS.Model.EnumModel;

namespace NovelSpider.Crawler.Service.DatabaseServices.FCCS.BussinessService
{
    public class HouseModelAnaly
    {
        public HouseTypeDTO HouseModelAnalysis(HouseModelInfo houseModel)
        {
            HouseTypeDTO houseTypeDto = new HouseTypeDTO();
            houseTypeDto.Name = houseModel.HouseTypeName;
            Regex regex = new Regex(@"\d+");
            houseTypeDto.Area = Convert.ToDouble(regex.Match(houseModel.Area).Groups[0].Value);
            regex = new Regex(@"\d");
            MatchCollection matchCollection = regex.Matches(houseModel.HouseTypeDesc);
            if (matchCollection.Count > 0)
            {
                houseTypeDto.RoomCount = Convert.ToInt32(matchCollection[0].Value);
            }

            if (matchCollection.Count > 1)
            {
                houseTypeDto.HallCount = Convert.ToInt32(matchCollection[1].Value);
            }
            if (matchCollection.Count > 2)
            {
                houseTypeDto.ToiletCount = Convert.ToInt32(matchCollection[2].Value);
            }

            if (matchCollection.Count > 3)
            {
                houseTypeDto.BalconyCount = Convert.ToInt32(matchCollection[3].Value);
            }

            switch (houseModel.HouseTypeStatus)
            {
                case "在售":
                    houseTypeDto.Status = HouseTypeStatus.OnSale;
                    break;
                case "待售":
                    houseTypeDto.Status = HouseTypeStatus.PreSale;
                    break;
                case "售完":
                    houseTypeDto.Status = HouseTypeStatus.SellOut;
                    break;
            }

            return houseTypeDto;
        }
    }
}
