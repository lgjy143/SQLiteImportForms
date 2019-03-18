using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace u724.Core.Entities
{
    /// <summary>
    /// 实体类GridDetailBtnModel 表 HYGRID_GridDetailBtn
    /// </summary>
    [DataContract]
    [Table("HYGRID_GridDetailBtn")]
    public class GridDetailBtnModel
    {
        #region 构造函数
        public GridDetailBtnModel() { }

        #endregion

        #region 属性
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string BtnID { get; set; }
        /// <summary>
        /// 表格配置表主键
        /// </summary>
        [DataMember]
        public string Auid { get; set; }
        /// <summary>
        /// 按钮名称
        /// </summary>
        [DataMember]
        public string BtnName { get; set; }
        /// <summary>
        /// 按钮冒泡信息
        /// </summary>
        [DataMember]
        public string BtnTitle { get; set; }
        /// <summary>
        /// 按钮图片
        /// </summary>
        [DataMember]
        public string BtnImage { get; set; }
        /// <summary>
        /// 按钮触发函数
        /// </summary>
        [DataMember]
        public string FuncName { get; set; }
        /// <summary>
        /// 按钮性质
        /// </summary>
        [DataMember]
        public EnumBtnNature BtnNature { get; set; }
        /// <summary>
        /// 查看时是否显示按钮
        /// </summary>
        [DataMember]
        public bool IsLookShow { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        [DataMember]
        public int Sort { get; set; }

        /// <summary>
        /// 要进行权限控制的模块编号或功能编号
        /// </summary>
        [DataMember]
        public string ModuleID { get; set; }

        /// <summary>
        /// 控制类型：1功能控制  2模块控制
        /// </summary>
        [DataMember]
        public EnumFuncOrModule FuncOrModule { get; set; }
        #endregion

        /// <summary>
        /// 控制类型
        /// </summary>
        public enum EnumFuncOrModule
        {
            /// <summary>
            /// 功能控制=1
            /// </summary>
            [Description("功能控制")]
            functionT = 1,
            /// <summary>
            /// 模块控制=2
            /// </summary>
            [Description("模块控制")]
            moduleT = 2
        }

        /// <summary>
        /// 按钮性质枚举
        /// </summary>
        public enum EnumBtnNature : int
        {
            /// <summary>
            /// 无
            /// </summary>
            [Description("无")]
            none = 0,
            /// <summary>
            /// 新增
            /// </summary>
            [Description("新增")]
            add = 1,
            /// <summary>
            /// 删除
            /// </summary>
            [Description("删除")]
            del = 2,
            /// <summary>
            /// 清空
            /// </summary>
            [Description("清空")]
            clearAll = 3,
            /// <summary>
            /// 移动行
            /// </summary>
            [Description("移动行")]
            move = 4,

            /// <summary>
            /// 插入行
            /// </summary>
            [Description("插入行")]
            insert = 5
        }

    }
}
