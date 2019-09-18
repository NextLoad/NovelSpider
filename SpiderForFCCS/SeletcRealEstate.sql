select [Price] as '单价',
		[Unit]  as '单位'
      ,[RecordTime] as '记录时间' ,
      a.Name as '区域',
      te.Name as '类型',
       r.Name as '楼盘名称',  
       t.name as '物业公司', 
      d.name as '开发商',
      BuildingArea as '建筑面积', 
      FloorArea as '占地面积', 
      GreeningRate as '绿化率', 
      PlotRatio as '容积率', 
      HandoverDate as '交房日期', 
      OpeningDate as '开盘日期',
       HousingStructure As '房屋结构', 
       PropertyRightLimit as '产权年限', 
       HouseCount, 
       BuildingCount,
        SalesHotline, 
        SalesAddress, 
        [Address], 
       SalesPermitNumber, 
       Carport, 
       Introduction 
       from [T_RealEstatePrice] as p left join
       dbo.T_RealEstate as r on p.[RealEstateId] = r.Id left join
       dbo.T_TenementCompany as t on r.tenementCompanyId = t.Id left join 
       dbo.T_Developer as d on r.DeveloperId = d.id left join 
       dbo.T_Tenement as te on p.[TenementId] = te.Id left join 
       dbo.T_Area as a on r.AreaId = a.Id
       order by r.Name