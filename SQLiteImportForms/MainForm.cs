using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Common;
using System.Data.Entity;
using System.Data.SQLite;
using Dapper;
using System.Net;
using System.IO;
using System.Reflection;
using Autofac;
using u724.Core.Entities;
using System.Runtime.Serialization.Formatters.Binary;

namespace SQLiteImportForms
{
    public partial class MainForm : Form
    {
        public Autofac.IContainer IOCManager { get; set; }
        public MainForm()
        {
            InitializeComponent();

            #region Autofac build

            var builder = new ContainerBuilder();

            builder.RegisterAssemblyTypes(Assembly.LoadFrom("u724.Core.dll")).Where(t => t.Name.EndsWith("Model"));

            IOCManager = builder.Build();

            #endregion

            LoadForm();
        }

        public void LoadForm()
        {
            txtBak.Text = @"D:\2019\SourceCode\SQLiteImportForms\clothconfig_20190314134040031.bak";

            txtSQLite.Text = @"D:\2019\SourceCode\SQLiteImportForms\GridDB_SQLite";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var gridInfoModel = IOCManager.Resolve<GridInfoModel>();
            gridInfoModel.GridName = "1";
            var gridInfoModel2 = IOCManager.Resolve<GridInfoModel>();
            gridInfoModel2.GridName = "2";

            DataSet ds = null;

            using (var fs = new FileStream(txtBak.Text, FileMode.Open))
            {
                byte[] buffer = new byte[fs.Length];
                fs.Read(buffer, 0, Convert.ToInt32(fs.Length));
                fs.Close();

                ds = ResolveDataSet(buffer);
            }

            if (ds == null && ds.Tables.Count < 1)
            {

            }


            return;

            if (string.IsNullOrEmpty(txtSQLite.Text))
            {
                MessageBox.Show("SQLite为空.");
                return;
            }

            var sqliteConnStr = new SQLiteConnectionStringBuilder() { DataSource = txtSQLite.Text, Version = 3 };

            using (var dh = new DapperHelper(sqliteConnStr.ToString(), ConnectionFactory.DatabaseType.Sqlite))
            {
                var dt = dh.QueryDataTable(" select * from hygrid_gridinfo ");
            }


            //     /// <summary>    
            //     /// 实体转换辅助类    
            //     /// </summary>    
            //public class ModelConvertHelper<T> where T : new()
            //{
            //    public static IList<T> ConvertToModel(DataTable dt)
            //    {
            //        // 定义集合    
            //        IList<T> ts = new List<T>();

            //        // 获得此模型的类型   
            //        Type type = typeof(T);
            //        string tempName = "";

            //        foreach (DataRow dr in dt.Rows)
            //        {
            //            T t = new T();
            //            // 获得此模型的公共属性      
            //            PropertyInfo[] propertys = t.GetType().GetProperties();
            //            foreach (PropertyInfo pi in propertys)
            //            {
            //                tempName = pi.Name;  // 检查DataTable是否包含此列    

            //                if (dt.Columns.Contains(tempName))
            //                {
            //                    // 判断此属性是否有Setter      
            //                    if (!pi.CanWrite) continue;

            //                    object value = dr[tempName];
            //                    if (value != DBNull.Value)
            //                        pi.SetValue(t, value, null);
            //                }
            //            }
            //            ts.Add(t);
            //        }
            //        return ts;
            //    }
            //}




            //using (var dp = new DapperHelper())
            //{
            //    //var tran = dp.TranStart();
            //    //var obj = new USER() { FID = "test222", FNAME = "test", FCREATETIME = DateTime.Now, FREALNAME = "t" };
            //    ////事务回滚
            //    //var insert = dp.Insert(obj, tran);
            //    //var user2 = dp.Get<USER>("test222", tran);
            //    //Assert.IsTrue(user2 != null);
            //    //tran.Rollback();
            //    //var user3 = dp.Get<USER>("test222");
            //    //Assert.IsTrue(user3 == null);
            //    ////事务提交
            //    //tran = dp.TranStart();
            //    //insert = dp.Insert(obj, tran);
            //    //Assert.IsTrue(user2 != null);
            //    //tran.Commit();
            //    //user3 = dp.Get<USER>("test222");
            //    //Assert.IsTrue(user3 != null);
            //    ////删除测试数据
            //    //bool isdel = dp.Delete(obj);
            //    //Assert.IsTrue(isdel);
            //}




            ////Sqlite使用事务批量操作 极大的提高速度
            //DateTime starttime = DateTime.Now;
            //using (SQLiteConnection con = new SQLiteConnection(connStr))
            //{
            //    con.Open();
            //    DbTransaction trans = con.BeginTransaction();//开始事务     
            //    SQLiteCommand cmd = new SQLiteCommand(con);
            //    try
            //    {
            //        cmd.CommandText = "INSERT INTO MyTable(username,useraddr,userage) VALUES(@a,@b,@c)";
            //        for (int n = 0; n < 100000; n++)
            //        {
            //            cmd.Parameters.Add(new SQLiteParameter("@a", DbType.String)); //MySql 使用MySqlDbType.String
            //            cmd.Parameters.Add(new SQLiteParameter("@b", DbType.String)); //MySql 引用MySql.Data.dll
            //            cmd.Parameters.Add(new SQLiteParameter("@c", DbType.String));
            //            cmd.Parameters["@a"].Value = "张三" + n;
            //            cmd.Parameters["@b"].Value = "深圳" + n;
            //            cmd.Parameters["@c"].Value = 10 + n;
            //            cmd.ExecuteNonQuery();
            //        }
            //        trans.Commit();//提交事务  
            //        DateTime endtime = DateTime.Now;
            //        MessageBox.Show("插入成功，用时" + (endtime - starttime).TotalMilliseconds);

            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.Message);
            //    }
            //}
        }

        private DataSet ResolveDataSet(byte[] buffer)
        {
            var ds = new DataSet();

            var ms = new MemoryStream(buffer);
            //产生二进制序列化格式,序列化成对象
            var obj = new BinaryFormatter().Deserialize(ms);
            if (obj == null) return ds;

            if (obj is DataSet) return (DataSet)obj;

            return ds;
        }

        private void TestWebRequest()
        {
            WebRequest request = WebRequest.Create("http://localhost:22398/PieceWage/Svc/PieceWageHandler.ashx?Action=WriteRegCropOne");
            // Set the Method property of the request to POST.  
            request.Method = "POST";
            // Create POST data and convert it to a byte array.  
            //string postData = "{'StorageOrgID':'7yd4JU+sSauG8dw+WKw1E8znrtQ=','AdminOrgID':'kL1gEImbSa+wIJHKJIbQCsznrtQ=','GoodsID':'s1MNaYBhAWLgQwoABgsBYkQJ5/A=','ColorID':'kDiYG3ohT8yx96LT4nmAmAvG9C4=','WorkDate':'2019-03-15 15:30:39.000000','OrderNo':'1','UniqueCode':'1','PersonID':'1EVV9Z5bSPm5tLyVD/2qd4Dvfe0=','StyleOPID':'Tr3BAdt9RQ+DC+ZktZMJwkoe0xg=','SizeID':'','Qty':'2'}";

            //string postData1 = "StorageOrgID=7yd4JU+sSauG8dw+WKw1E8znrtQ=&AdminOrgID=7yd4JU+sSauG8dw+WKw1E8znrtQ=";

            var dic = new Dictionary<string, string>();
            dic.Add("StorageOrgID", "7yd4JU+sSauG8dw+WKw1E8znrtQ=");
            var postData = "";
            foreach (var item in dic)
            {
                postData += string.Format("&{0}={1}", item.Key, item.Value);
            }


            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            // Set the ContentType property of the WebRequest.  
            request.ContentType = "application/x-www-form-urlencoded";
            //request.ContentType = "application/json";
            // Set the ContentLength property of the WebRequest.  
            request.ContentLength = byteArray.Length;
            // Get the request stream.  
            Stream dataStream = request.GetRequestStream();
            // Write the data to the request stream.  
            dataStream.Write(byteArray, 0, byteArray.Length);
            // Close the Stream object.  
            dataStream.Close();
            // Get the response.  
            WebResponse response = request.GetResponse();
            // Display the status.  
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);
            // Get the stream containing content returned by the server.  
            dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.  
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.  
            string responseFromServer = reader.ReadToEnd();
            // Display the content.  
            Console.WriteLine(responseFromServer);
            // Clean up the streams.  
            reader.Close();
            dataStream.Close();
            response.Close();

            MessageBox.Show(responseFromServer);
        }

        public void Post(string url, string jsonParam, string encode)
        {
            var request = WebRequest.Create(url) as HttpWebRequest;
            request.Method = "post";
            request.ContentType = "application/json;charset=" + encode.ToUpper();
        }

        /// <summary>
        /// 批量插入Person数据，返回影响行数
        /// </summary>
        /// <param name="persons"></param>
        /// <returns>影响行数</returns>
        //public static int Insert(List<Person> persons)
        //{
        //    using (IDbConnection connection = new SqlConnection(connectionString))
        //    {
        //        return connection.Execute("insert into Person(Name,Remark) values(@Name,@Remark)", persons);
        //    }
        //}


        //public interface IBatcherProvider
        //{
        //}

        //public class ServiceContext
        //{
        //    public IDatabase Database { get; internal set; }


        //}
        //public interface IDatabase
        //{
        //    object Provider { get; set; }
        //}

        //public sealed class SQLiteBatcher : IBatcherProvider
        //{
        //    /// <summary>
        //    /// 获取或设置提供者服务的上下文。
        //    /// </summary>
        //    public ServiceContext ServiceContext { get; set; }

        //    /// <summary>
        //    /// 将 <see cref="DataTable"/> 的数据批量插入到数据库中。
        //    /// </summary>
        //    /// <param name="dataTable">要批量插入的 <see cref="DataTable"/>。</param>
        //    /// <param name="batchSize">每批次写入的数据量。</param>
        //    public void Insert(DataTable dataTable, int batchSize = 10000)
        //    {
        //        Checker.ArgumentNull(dataTable, "dataTable");
        //        if (dataTable.Rows.Count == 0)
        //        {
        //            return;
        //        }
        //        using (var connection = ServiceContext.Database.CreateConnection())
        //        {
        //            DbTransaction transcation = null;
        //            try
        //            {
        //                connection.TryOpen();
        //                transcation = connection.BeginTransaction();
        //                using (var command = ServiceContext.Database.Provider.DbProviderFactory.CreateCommand())
        //                {
        //                    if (command == null)
        //                    {
        //                        throw new BatcherException(new ArgumentException("command"));
        //                    }
        //                    command.Connection = connection;

        //                    command.CommandText = GenerateInserSql(ServiceContext.Database, dataTable);
        //                    if (command.CommandText == string.Empty)
        //                    {
        //                        return;
        //                    }

        //                    var flag = new AssertFlag();
        //                    dataTable.EachRow(row =>
        //                    {
        //                        var first = flag.AssertTrue();
        //                        ProcessCommandParameters(dataTable, command, row, first);
        //                        command.ExecuteNonQuery();
        //                    });
        //                }
        //                transcation.Commit();
        //            }
        //            catch (Exception exp)
        //            {
        //                if (transcation != null)
        //                {
        //                    transcation.Rollback();
        //                }
        //                throw new BatcherException(exp);
        //            }
        //            finally
        //            {
        //                connection.TryClose();
        //            }
        //        }
        //    }

        //    private void ProcessCommandParameters(DataTable dataTable, DbCommand command, DataRow row, bool first)
        //    {
        //        for (var c = 0; c < dataTable.Columns.Count; c++)
        //        {
        //            DbParameter parameter;
        //            //首次创建参数，是为了使用缓存
        //            if (first)
        //            {
        //                parameter = ServiceContext.Database.Provider.DbProviderFactory.CreateParameter();
        //                parameter.ParameterName = dataTable.Columns[c].ColumnName;
        //                command.Parameters.Add(parameter);
        //            }
        //            else
        //            {
        //                parameter = command.Parameters[c];
        //            }
        //            parameter.Value = row[c];
        //        }
        //    }

        //    /// <summary>
        //    /// 生成插入数据的sql语句。
        //    /// </summary>
        //    /// <param name="database"></param>
        //    /// <param name="table"></param>
        //    /// <returns></returns>
        //    private string GenerateInserSql(IDatabase database, DataTable table)
        //    {
        //        var syntax = database.Provider.GetService<ISyntaxProvider>();
        //        var names = new StringBuilder();
        //        var values = new StringBuilder();
        //        var flag = new AssertFlag();
        //        table.EachColumn(column =>
        //        {
        //            if (!flag.AssertTrue())
        //            {
        //                names.Append(",");
        //                values.Append(",");
        //            }
        //            names.Append(DbUtility.FormatByQuote(syntax, column.ColumnName));
        //            values.AppendFormat("{0}{1}", syntax.ParameterPrefix, column.ColumnName);
        //        });
        //        return string.Format("INSERT INTO {0}({1}) VALUES ({2})", DbUtility.FormatByQuote(syntax, table.TableName), names, values);
        //    }


        //}
    }
}
