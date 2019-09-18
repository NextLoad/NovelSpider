namespace SpiderForFCSS.Model
{
    /// <summary>
    /// 区域实体
    /// </summary>
    public class Area:BaseModel
    {
        /// <summary>
        /// 区域名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 区域上级Id
        /// </summary>
        public long? ParentId { get; set; }
    }
}