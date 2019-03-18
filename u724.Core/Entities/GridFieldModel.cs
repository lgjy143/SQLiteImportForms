using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace u724.Core.Entities
{
    /// <summary>
    /// 实体类GridFieldModel 表 HYGRID_GridField
    /// </summary>
    [DataContract]
    [Table("HYGRID_GridField")]
    public class GridFieldModel
    {
        #region 构造函数
        public GridFieldModel()
        { }
        #endregion

        #region 属性
        /// <summary>
        /// 主键（18位）
        /// </summary>
        [DataMember]
        public string FieldID { get; set; }
        /// <summary>
        /// 表格配置表主键
        /// </summary>
        [DataMember]
        public string Auid { get; set; }
        /// <summary>
        /// 字段中文名称
        /// </summary>
        [DataMember]
        public string ChName { get; set; }
        /// <summary>
        /// 字段英文名称
        /// </summary>
        [DataMember]
        public string EnName { get; set; }
        /// <summary>
        /// 宽度
        /// </summary>
        [DataMember]
        public int Width { get; set; }
        /// <summary>
        /// 是否排序
        /// </summary>
        [DataMember]
        public bool IsSort { get; set; }
        /// <summary>
        /// 水平对齐方式
        /// </summary>
        [DataMember]
        public EnumAlign Align { get; set; }
        /// <summary>
        /// 列标题对齐方式
        /// </summary>
        [DataMember]
        public EnumAlign AlignHeader { get; set; }
        /// <summary>
        /// 列标题文字颜色
        /// </summary>
        [DataMember]
        public string HeaderTextColor { get; set; }
        /// <summary>
        /// 数据类型
        /// </summary>
        [DataMember]
        public EnumDatatype Datatype { get; set; }
        /// <summary>
        /// 小数位数
        /// </summary>
        [DataMember]
        public int DecimalNum { get; set; }
        /// <summary>
        /// 是否千分号分隔显示
        /// </summary>
        [DataMember]
        public bool IsThousandSeparat { get; set; }
        /// <summary>
        /// 是否超链接
        /// </summary>
        [DataMember]
        public bool IsHyperlink { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        [DataMember]
        public int FieldSort { get; set; }
        /// <summary>
        /// 是否以图片显示
        /// </summary>
        [DataMember]
        public bool IsImage { get; set; }
        /// <summary>
        /// 隐藏、显示方式
        /// </summary>
        [DataMember]
        public EnumHide IsHide { get; set; }
        /// <summary>
        /// 编辑方式
        /// </summary>
        [DataMember]
        public EnumEditType EditType { get; set; }
        /// <summary>
        /// 是否统计
        /// </summary>
        [DataMember]
        public bool IsSum { get; set; }
        /// <summary>
        /// 下拉列表字典
        /// </summary>
        [DataMember]
        public string ddlID { get; set; }
        /// <summary>
        /// 掩码表达式
        /// </summary>
        [DataMember]
        public string ColFormula { get; set; }
        /// <summary>
        /// 是否可空
        /// </summary>
        [DataMember]
        public bool EmptyEnable { get; set; }
        /// <summary>
        /// ext 的Renderer函数
        /// </summary>
        [DataMember]
        public string RendererFunc { get; set; }
        /// <summary>
        /// 是否根据规则创建
        /// </summary>
        public bool IsRuleCreate { get; set; }
        /// <summary>
        /// 字段允许输入的最大长度
        /// </summary>
        public int FieldMaxLen { get; set; }
        /// <summary>
        /// 统计行显示的文本
        /// </summary>
        public string SumText { get; set; }
        /// <summary>
        /// 数值类型
        /// </summary>
        public EnumNumberType NumberType { get; set; }

        /// <summary>
        /// 是否固定列起点
        /// </summary>
        public bool IsSplt { get; set; }
        /// <summary>
        /// 验证表达式
        /// </summary>
        [DataMember]
        public string Expression { get; set; }
        /// <summary>
        /// 验证提示消息
        /// </summary>
        [DataMember]
        public string ValidationMsg { get; set; }
        /// <summary>
        /// 选择器-选择函数
        /// </summary>
        [DataMember]
        public string SelectFunc { get; set; }
        /// <summary>
        /// 选择器-自动填充函数
        /// </summary>
        [DataMember]
        public string AutoFillFunc { get; set; }

        /// <summary>
        /// 数值编辑框-改变函数
        /// </summary>
        public string ChangeFunc { get; set; }
        /// <summary>
        /// 日期格式  例  yyyy-MM-dd|min.data.2000-1-1|max.col.colEnName    yyyy-MM-dd|-|-  yyyy-MM-dd|min.data.2000-1-1|-
        /// </summary>
        public string DateFormt { get; set; }
        /// <summary>
        /// 是否简单查询
        /// </summary>
        [DataMember]
        public bool IsSimpleSearch { get; set; }
        /// <summary>
        /// 枚举Dll
        /// </summary>
        [DataMember]
        public string AssemblyDLL { get; set; }
        #endregion

        public enum EnumNumberType
        {
            /// <summary>
            /// 无
            /// </summary>
            [Description("无")]
            nonn = 0,
            /// <summary>
            /// 数量类
            /// </summary>
            [Description("数量类")]
            count = 1,
            /// <summary>
            /// 金额类
            /// </summary>
            [Description("金额类")]
            money = 2,
            /// <summary>
            /// 单价类
            /// </summary>
            [Description("单价类")]
            price = 3,
            /// <summary>
            /// 税率
            /// </summary>
            [Description("税率")]
            tax,
            /// <summary>
            /// 折扣率
            /// </summary>
            [Description("折扣率")]
            discountRate,
            /// <summary>
            /// 汇率
            /// </summary>
            [Description("汇率")]
            exchangeRate,
            /// <summary>
            /// 单位转换率
            /// </summary>
            [Description("单位转换率")]
            unitConversion,
            /// <summary>
            /// EAS单价
            /// </summary>
            [Description("EAS单价")]
            EASPrice,
            /// <summary>
            /// 整数
            /// </summary>
            [Description("整数")]
            IntegerRate
        }

        /// <summary>
        /// 枚举：隐藏、显示方式
        /// </summary>
        public enum EnumHide
        {
            /// <summary>
            /// 显示
            /// </summary>
            [Description("显示")]
            G_false = 1,
            /// <summary>
            /// 绝对显示
            /// </summary>
            [Description("绝对显示")]
            G_absShow = 2,
            /// <summary>
            /// 隐藏
            /// </summary>
            [Description("隐藏")]
            G_true = 3,
            /// <summary>
            /// 绝对隐藏
            /// </summary>
            [Description("绝对隐藏")]
            G_absHide = 4
        }

        /// <summary>
        /// 枚举：对齐方式
        /// </summary>
        public enum EnumAlign
        {
            /// <summary>
            /// 左对齐
            /// </summary>
            [Description("左对齐")]
            left = 1,
            /// <summary>
            /// 居中
            /// </summary>
            [Description("居中")]
            center = 2,
            /// <summary>
            /// 右对齐
            /// </summary>
            [Description("右对齐")]
            right = 3
        }
        /// <summary>
        /// 数据类型枚举
        /// </summary>
        public enum EnumDatatype
        {
            /// <summary>
            /// 字符串
            /// </summary>
            [Description("字符串")]
            G_string = 1,
            /// <summary>
            /// 整型
            /// </summary>
            [Description("整型")]
            G_int = 2,
            /// <summary>
            /// 浮点型
            /// </summary>
            [Description("浮点型")]
            G_double = 3,
            /// <summary>
            /// 布尔类型
            /// </summary>
            [Description("布尔类型")]
            G_bool = 4,
            /// <summary>
            /// 日期
            /// </summary>
            [Description("日期")]
            G_date = 5,
            /// <summary>
            /// 时间
            /// </summary>
            [Description("时间")]
            G_datetime = 6
        }
        /// <summary>
        /// 枚举：编辑方式
        /// </summary>
        public enum EnumEditType
        {
            /// <summary>
            /// 文本框
            /// </summary>
            [Description("文本框")]
            Edit = 1,
            /// <summary>
            /// 多行文本
            /// </summary>
            [Description("多行文本")]
            MultiLineEdit = 2,
            /// <summary>
            /// 复选框
            /// </summary>
            [Description("复选框")]
            Checkbox = 3,
            /// <summary>
            /// 下拉列表
            /// </summary>
            [Description("下拉列表")]
            Droplist = 4,
            /// <summary>
            /// 不编辑
            /// </summary>
            [Description("不编辑")]
            NoEdit = 5,
            /// <summary>
            /// 按钮文本框
            /// </summary>
            [Description("自定义触发")]
            EditWithButton = 6,
            /// <summary>
            ///数值编辑
            /// </summary>
            [Description("数值编辑")]
            EditWithScript = 7,
            /// <summary>
            /// 日期
            /// </summary>
            [Description("日期")]
            Date = 8
        }
    }

    public enum EnumSearchType
    {
        [Description("=")]
        equal = 1,
        [Description("Like")]
        like = 2,
        [Description("Between")]
        Between = 3
    }
}
