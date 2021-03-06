/****** Script for SelectTopNRows command from SSMS  ******/
SELECT r.Name as '楼盘名称'
      ,ht.[Name] as '户型名称'
      ,[Area] as '面积'
      , te.Name as '类型'
      ,[RoomCount] as '室'
      ,[HallCount] as '厅'
      ,[ToiletCount] as '卫'
      ,[BalconyCount] as '阳台'
      ,case when [Status]=1 then '在售' when [Status]=2 then '预售' when [Status]=4 then '售罄' end as '状态'
  FROM [FCCSSpider].[dbo].[T_HouseType] as ht left join dbo.T_RealEstate as r
  on ht.RealEstateId = r.Id left join dbo.T_Tenement as te 
  on ht.[TenementId] = te.id order by r.Name