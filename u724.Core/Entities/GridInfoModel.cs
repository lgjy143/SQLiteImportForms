using System.ComponentModel;
using System.Runtime.Serialization;

namespace u724.Core.Entities
{
    /// <summary>
    /// 实体类GridInfoModel 表 HYGRID_GRIDINFO
    /// </summary>
    [DataContract]
    public class GridInfoModel
    {
        #region 构造函数
        public GridInfoModel() { }
        #endregion

        #region 属性
        /// <summary>
        /// 主键（32guid）
        /// </summary>
        [DataMember]
        public string Auid { get; set; }
        /// <summary>
        /// 表格名称
        /// </summary>
        [DataMember]
        public string GridName { get; set; }
        /// <summary>
        /// 表格主键
        /// </summary>
        [DataMember]
        public string GridKey { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [DataMember]
        public string Remark { get; set; }
        /// <summary>
        /// 所属模块系统
        /// </summary>
        [DataMember]
        public string ModuleID { get; set; }
        /// <summary>
        /// 关联的数据库表名称
        /// </summary>
        [DataMember]
        public string TableName { get; set; }
        /// <summary>
        /// 数据库连接
        /// </summary>
        [DataMember]
        public EnumDbConStr TableConName { get; set; }
        /// <summary>
        /// Sql语句
        /// </summary>
        [DataMember]
        public string CommandText { get; set; }

        /// <summary>
        /// 是否为选择器列表
        /// </summary>
        [DataMember]
        public bool IsST { get; set; }
        /// <summary>
        /// 主列
        /// </summary>
        [DataMember]
        public string MainColId { get; set; }

        /// <summary>
        /// 列表类型
        /// </summary>
        [DataMember]
        public EnumGridType GridType { get; set; }
        #endregion

        /// <summary>
        /// 列表类型
        /// </summary>
        public enum EnumGridType
        {
            /// <summary>
            /// 数据列表
            /// </summary>
            [Description("数据列表")]
            list = 1,
            /// <summary>
            /// 明细列表
            /// </summary>
            [Description("明细列表")]
            detail = 2
        }

        public enum EnumDbConStr
        {
            /// <summary>
            /// OA主库
            /// </summary>
            [Description("OA主库")]
            OAconnectionString = 1,
            /// <summary>
            /// 渠道库
            /// </summary>
            [Description("渠道库")]
            SaleConnectionString = 2,
            /// <summary>
            /// ERP
            /// </summary>
            [Description("ERP")]
            HYERPConnectionString = 3,

            /// <summary>
            /// 自来水
            /// </summary>
            [Description("自来水")]
            HYWaterConnectionString = 4,
            /// <summary>
            /// B2C
            /// </summary>
            [Description("B2C")]
            B2CConnectionString = 16,

            /// <summary>
            /// 物业管理系统
            /// </summary>
            [Description("物业管理系统")]
            PropertyConnectionString = 17,

            /// <summary>
            /// EAS系统
            /// </summary>
            [Description("EAS系统")]
            EASConnectionString = 18,

            /// <summary>
            /// 女装定制系统
            /// </summary>
            [Description("女装定制系统")]
            HYClothConnectionString = 25,

            /// <summary>
            /// 购尚分销系统
            /// </summary>
            [Description("购尚分销系统")]
            HYDistConnectionString = 26


        }
    }
}
