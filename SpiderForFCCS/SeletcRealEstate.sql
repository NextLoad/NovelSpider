select [Price] as '����',
		[Unit]  as '��λ'
      ,[RecordTime] as '��¼ʱ��' ,
      a.Name as '����',
      te.Name as '����',
       r.Name as '¥������',  
       t.name as '��ҵ��˾', 
      d.name as '������',
      BuildingArea as '�������', 
      FloorArea as 'ռ�����', 
      GreeningRate as '�̻���', 
      PlotRatio as '�ݻ���', 
      HandoverDate as '��������', 
      OpeningDate as '��������',
       HousingStructure As '���ݽṹ', 
       PropertyRightLimit as '��Ȩ����', 
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