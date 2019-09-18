using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using NovelSpider.Crawler.IService.DatabaseIServices.FCCS;
using SpiderForFCCS.BusinessModel;
using SpiderForFCCS.DTO;
using SpiderForFCSS.Model;

namespace NovelSpider.Crawler.Service.DatabaseServices.FCCS.BussinessService
{
    public class RealEstatePriceAnaly
    {
        private ITenementService tenementService = new TenementService();
        public RealEstatePriceDTO PriceAnalysis(string priceStr)
        {
            Regex regex = new Regex(@"\d+");
            RealEstatePriceDTO realEstatePriceDTO = new RealEstatePriceDTO();
            string[] priceSplit = priceStr.Split(':');
            //表示售价待定
            if (priceSplit.Length <= 1)
            {
                realEstatePriceDTO.Price = null;
                realEstatePriceDTO.TenementId = null;
            }
            else
            {
                long tenementId = 0;
                //物业类型Id
                if (!tenementService.IsExists(priceSplit[0].Replace("备案价", "")))
                {
                    tenementId = tenementService.AddNew(priceSplit[0].Replace("备案价", ""));
                }
                else
                {
                    tenementId = tenementService.GetByName(priceSplit[0].Replace("备案价", "")).Value;
                }
                realEstatePriceDTO.Price = Convert.ToDouble(regex.Match(priceSplit[1]).Groups[0].Value);
                realEstatePriceDTO.TenementId = tenementId;
            }

            return realEstatePriceDTO;
        }
        public RealEstatePriceDTO PriceAnalysis(PriceTrend priceTrend)
        {
            Regex regex = new Regex(@"\d+");
            RealEstatePriceDTO realEstatePriceDTO = new RealEstatePriceDTO();

            long tenementId = 0;
            //物业类型Id
            if (!tenementService.IsExists(priceTrend.TenementName))
            {
                tenementId = tenementService.AddNew(priceTrend.TenementName);
            }
            else
            {
                tenementId = tenementService.GetByName(priceTrend.TenementName).Value;
            }
            realEstatePriceDTO.Price = Convert.ToDouble(regex.Match(priceTrend.Price).Groups[0].Value);
            realEstatePriceDTO.TenementId = tenementId;
            realEstatePriceDTO.RecordTime = priceTrend.RecordTime == DateTime.MinValue ? DateTime.Now : priceTrend.RecordTime;
            return realEstatePriceDTO;
        }
    }
}
