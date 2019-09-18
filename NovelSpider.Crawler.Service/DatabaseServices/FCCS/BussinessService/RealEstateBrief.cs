using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpiderForFCCS.DTO;

namespace NovelSpider.Crawler.Service.DatabaseServices.FCCS.BussinessService
{
    public class RealEstateBrief
    {
        public RealEstateDTO Analysis(IList<string> briefList)
        {
            RealEstateDTO realEstateDto = new RealEstateDTO();
            foreach (string brief in briefList)
            {
                string[] briefSplit = brief.Split('：');
                switch (briefSplit[0])
                {
                    case "区域所属":
                        realEstateDto.AreaName = briefSplit[1];
                        break;
                    case "交房日期":
                        realEstateDto.HandoverDate = briefSplit[1];
                        break;
                    case "开发商":
                        realEstateDto.DeveloperName = briefSplit[1];
                        break;
                    case "物业公司":
                        realEstateDto.TenementCompanyName = briefSplit[1];
                        break;
                    case "得房率":
                        //realEstateDto. = briefSplit[1];
                        break;
                    case "绿化率":
                        realEstateDto.GreeningRate = briefSplit[1];
                        break;
                    case "建筑面积":
                        realEstateDto.BuildingArea = briefSplit[1];
                        break;
                    case "占地面积":
                        realEstateDto.FloorArea = briefSplit[1];
                        break;
                    case "容积率":
                        realEstateDto.PlotRatio = briefSplit[1];
                        break;
                    case "房屋结构":
                        realEstateDto.HousingStructure = briefSplit[1];
                        break;
                    case "产权年限":
                        realEstateDto.PropertyRightLimit = briefSplit[1];
                        break;
                    case "工程进度":
                        //areaName = briefSplit[1];
                        break;
                    case "总户数":
                        realEstateDto.HouseCount = briefSplit[1];
                        break;
                    case "总栋数":
                        realEstateDto.BuildingCount = briefSplit[1];
                        break;
                    case "售楼热线":
                        realEstateDto.SalesHotline = briefSplit[1];
                        break;
                    case "开盘日期":
                        realEstateDto.OpeningDate = briefSplit[1];
                        break;
                    case "售楼地址":
                        realEstateDto.SalesAddress = briefSplit[1];
                        break;
                    case "楼盘地址":
                        realEstateDto.Address = briefSplit[1];
                        break;
                    case "车库说明":
                        realEstateDto.Carport = briefSplit[1];
                        break;
                    case "交通状况":
                        //areaName = briefSplit[1];
                        break;
                    case "售楼许可证号":
                        realEstateDto.SalesPermitNumber = briefSplit[1];
                        break;
                    case "楼盘简介":
                        realEstateDto.Introduction = briefSplit[1];
                        break;

                }
            }
            return realEstateDto;
        }
    }
}
