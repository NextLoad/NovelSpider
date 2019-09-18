using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NovelSpider.Framework.ModelDtoTrans
{
    public class ModelDtoTransHelper
    {
        public static TDTO ModelToDTO<TModel, TDTO>(TModel tModel) where TDTO : class, new()
        {
            Type dtoType = typeof(TDTO);
            Type modleType = typeof(TModel);
            TDTO dto = new TDTO();
            foreach (PropertyInfo property in dtoType.GetProperties())
            {
                // 要转换的类型的属性值
                object propertyValue = modleType.GetProperty(property.Name)?.GetValue(tModel);
                property.SetValue(dto, propertyValue);
            }

            return dto;

        }
        public static TModel DTOToModel<TDTO, TModel>(TDTO dto) where TModel : class, new()
        {
            Type dtoType = typeof(TDTO);
            Type modleType = typeof(TModel);
            TModel modle = new TModel();
            foreach (PropertyInfo property in modleType.GetProperties())
            {
                //要转换的类型的属性值
                object propertyValue = dtoType.GetProperty(property.Name)?.GetValue(dto);
                property.SetValue(modle, propertyValue);
            }

            return modle;

        }
    }
}
