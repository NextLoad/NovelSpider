using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NovelSpider.Crawler.IService.DatabaseIServices.FCCS;
using NovelSpider.Crawler.IService.FCCSIServices;
using NovelSpider.Crawler.Service;
using NovelSpider.Crawler.Service.DatabaseServices.FCCS;
using NovelSpider.Crawler.Service.DatabaseServices.FCCS.BussinessService;
using NovelSpider.Crawler.Service.FCCSServices;
using NovelSpider.Framework.Log;
using SpiderForFCCS.BusinessModel;
using SpiderForFCCS.DTO;

namespace SpiderForFCCS
{
    class Program
    {
        private static Log4NetHelper logger = new Log4NetHelper(typeof(Program));
        static void Main(string[] args)
        {
            //using (FCCSDbContext ctx = new FCCSDbContext())
            //{
            //    ctx.Database.Create();
            //}
            try
            {

                INewHouseCrawler newHouseCrawler = new NewHouseCrawler();
                newHouseCrawler.Crawler("http://jx.fccs.com/newhouse/search/p1.html");

                IBriefCrawler briefCrawler = new BriefCrawler();
                var newHouseInfos = (newHouseCrawler as NewHouseCrawler).NewHouseDic;
                foreach (KeyValuePair<string, NewHouseInfo> keyValuePair in newHouseInfos)
                {
                    briefCrawler.Crawler(keyValuePair.Value.DetailLinkPath.Replace("index", "brief"));
                    //briefCrawler.Crawler("http://jx.fccs.com/newhouse/3444789/brief.html");
                    newHouseInfos[keyValuePair.Key].BriefList = (briefCrawler as BriefCrawler).BriefList;
                }
                System.Threading.Thread.Sleep(3 * 60 * 1000);
                IModelCrawler modelCrawler = new ModelCrawler();
                foreach (KeyValuePair<string, NewHouseInfo> keyValuePair in newHouseInfos)
                {
                    modelCrawler.Crawler(keyValuePair.Value.DetailLinkPath.Replace("index", "model"));
                    //modelCrawler.Crawler("http://jx.fccs.com/newhouse/3444789/model.html");
                    newHouseInfos[keyValuePair.Key].HouseModelInfos = (modelCrawler as ModelCrawler).HouseModelInfos;
                }
                System.Threading.Thread.Sleep(3*60*1000);
                IPriceCrawler priceCrawler = new PriceCrawler();
                foreach (KeyValuePair<string, NewHouseInfo> keyValuePair in newHouseInfos)
                {
                    priceCrawler.Crawler(keyValuePair.Value.DetailLinkPath.Replace("index", "price"));
                    //priceCrawler.Crawler("http://jx.fccs.com/newhouse/3444789/price.html");
                    newHouseInfos[keyValuePair.Key].PriceTrends = (priceCrawler as PriceCrawler).PriceTrends;
                }

                string fileExt = String.Format(DateTime.Now.ToString("yyyyMMdd"));
                File.WriteAllText($@"C:/FCSS{fileExt}.Json", JsonConvert.SerializeObject(newHouseInfos));

                IAreaService areaService = new AreaService();
                IDeveloperService developerService = new DeveloperService();
                IHouseTypeService houseTypeService = new HouseTypeService();
                IRealEstatePriceService realEstatePriceService = new RealEstatePriceService();
                IRealEstateService realEstateService = new RealEstateService();
                ITenementCompanyService tenementCompanyService = new TenementCompanyService();
                ITenementService tenementService = new TenementService();

                //var newHouseInfos = JsonConvert.DeserializeObject<Dictionary<string, NewHouseInfo>>(File.ReadAllText(@"C:/FCSS.Json"));
                foreach (KeyValuePair<string, NewHouseInfo> newHouseInfo in newHouseInfos)
                {
                    {
                        //楼盘Id
                        //long realEstateId = 0;
                        //if (!realEstateService.IsExistis(newHouseInfo.Value.Name))
                        //{
                        //    //realEstateId = realEstateService.AddNew(realEstateDto);
                        //}
                        //else
                        //{
                        //    realEstateId = realEstateService.GetByName(newHouseInfo.Value.Name);
                        //    //realEstateService.UpdateEstate(realEstateId, realEstateDto.LinkPath);
                        //}

                        //RealEstatePriceAnaly realEstatePriceAnaly = new RealEstatePriceAnaly();
                        //foreach (var priceTrend in newHouseInfo.Value.PriceTrends)
                        //{
                        //    RealEstatePriceDTO realEstatePriceDTO = realEstatePriceAnaly.PriceAnalysis(priceTrend);
                        //    realEstatePriceService.AddNew(realEstateId, realEstatePriceDTO.TenementId, realEstatePriceDTO.Price,
                        //        realEstatePriceDTO.Unit, realEstatePriceDTO.RecordTime);
                        //}


                        //foreach (var houseModel in newHouseInfo.Value.HouseModelInfos)
                        //{
                        //    HouseModelAnaly houseModelAnaly = new HouseModelAnaly();
                        //    HouseTypeDTO houseTypeDto = houseModelAnaly.HouseModelAnalysis(houseModel);
                        //    houseTypeDto.RealEstateId = realEstateId;
                        //    long tenementId = 0;
                        //    //物业类型Id
                        //    if (!tenementService.IsExists(houseModel.TenementName))
                        //    {
                        //        tenementId = tenementService.AddNew(houseModel.TenementName);
                        //    }
                        //    else
                        //    {
                        //        tenementId = tenementService.GetByName(houseModel.TenementName).Value;
                        //    }
                        //    houseTypeDto.TenementId = tenementId;
                        //    if (!houseTypeService.IsExistis(realEstateId, tenementId, houseModel.HouseTypeName, houseTypeDto.RoomCount))
                        //    {
                        //        houseTypeService.AddNew(houseTypeDto);
                        //    }

                        //}
                    }
                    RealEstateBrief realEstateBrief = new RealEstateBrief();
                    RealEstateDTO realEstateDto = realEstateBrief.Analysis(newHouseInfo.Value.BriefList);
                    realEstateDto.Name = newHouseInfo.Value.Name;
                    realEstateDto.LinkPath = newHouseInfo.Value.DetailLinkPath;
                    if (!string.IsNullOrEmpty(realEstateDto.AreaName))
                    {
                        if (!areaService.IsExists(realEstateDto.AreaName))
                        {
                            realEstateDto.AreaId = areaService.AddNew(realEstateDto.AreaName, 1);
                        }
                        else
                        {
                            realEstateDto.AreaId = areaService.GetByName(realEstateDto.AreaName).Value;
                        }
                    }

                    if (!string.IsNullOrEmpty(realEstateDto.DeveloperName))
                    {
                        if (!developerService.IsExists(realEstateDto.DeveloperName))
                        {
                            realEstateDto.DeveloperId = developerService.AddNew(realEstateDto.DeveloperName);
                        }
                        else
                        {
                            realEstateDto.DeveloperId = developerService.GetByName(realEstateDto.DeveloperName).Value;
                        }
                    }

                    if (!string.IsNullOrEmpty(realEstateDto.TenementCompanyName))
                    {
                        if (!tenementCompanyService.IsExists(realEstateDto.TenementCompanyName))
                        {
                            realEstateDto.TenementCompanyId =
                                tenementCompanyService.AddNew(realEstateDto.TenementCompanyName);
                        }
                        else
                        {
                            realEstateDto.TenementCompanyId =
                                tenementCompanyService.GetByName(realEstateDto.TenementCompanyName).Value;
                        }
                    }

                    //楼盘Id
                    long realEstateId = 0;
                    if (!realEstateService.IsExistis(realEstateDto.Name))
                    {
                        realEstateId = realEstateService.AddNew(realEstateDto);
                    }
                    else
                    {
                        realEstateId = realEstateService.GetByName(realEstateDto.Name);
                        realEstateService.UpdateEstate(realEstateId, realEstateDto.LinkPath);
                    }

                    foreach (var houseModel in newHouseInfo.Value.HouseModelInfos)
                    {
                        HouseModelAnaly houseModelAnaly = new HouseModelAnaly();
                        HouseTypeDTO houseTypeDto = houseModelAnaly.HouseModelAnalysis(houseModel);
                        houseTypeDto.RealEstateId = realEstateId;
                        long tenementId = 0;
                        //物业类型Id
                        if (!tenementService.IsExists(houseModel.TenementName))
                        {
                            tenementId = tenementService.AddNew(houseModel.TenementName);
                        }
                        else
                        {
                            tenementId = tenementService.GetByName(houseModel.TenementName).Value;
                        }
                        houseTypeDto.TenementId = tenementId;
                        if (!houseTypeService.IsExistis(realEstateId, tenementId, houseModel.HouseTypeName, houseTypeDto.RoomCount))
                        {
                            houseTypeService.AddNew(houseTypeDto);
                        }

                    }

                    RealEstatePriceAnaly realEstatePriceAnaly = new RealEstatePriceAnaly();
                    foreach (var priceTrend in newHouseInfo.Value.PriceTrends)
                    {
                        RealEstatePriceDTO realEstatePriceDTO = realEstatePriceAnaly.PriceAnalysis(priceTrend);
                        realEstatePriceService.AddNew(realEstateId, realEstatePriceDTO.TenementId, realEstatePriceDTO.Price,
                            realEstatePriceDTO.Unit, realEstatePriceDTO.RecordTime);
                    }
                    foreach (string priceInfo in newHouseInfo.Value.PriceDic)
                    {
                        RealEstatePriceDTO realEstatePriceDTO = realEstatePriceAnaly.PriceAnalysis(priceInfo);
                        realEstatePriceService.AddNew(realEstateId, realEstatePriceDTO.TenementId, realEstatePriceDTO.Price,
                            realEstatePriceDTO.Unit, DateTime.Now);
                    }

                }

                Console.WriteLine("ok");

            }
            catch (Exception ex)
            {
                logger.Error("异常", ex);
                Console.WriteLine(ex.Message);
            }
            Console.Read();
        }
    }
}
