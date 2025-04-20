using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using System.Collections;
using static System.Diagnostics.Activity;

namespace College_Management_DataAccess.Common
{
    public class CommonHelper
    {
        //private IConfiguration _configuration { get; }
        private static IConfiguration _configuration;
        string sqlConnectionStaring = "";
        static string sqlConnectionStaringSys = "";
        public CommonHelper(IConfiguration configuration)
        {
            _configuration = configuration;
            sqlConnectionStaring = _configuration.GetConnectionString("DefaultConnection");
            sqlConnectionStaringSys = _configuration.GetConnectionString("DefaultConnection");
        }

        public static T ConvertDataTable<T>(DataTable dt)
        {
            if (dt == null || dt.Rows.Count == 0)
                return default;

            string json = JsonConvert.SerializeObject(dt);
            T obj = JsonConvert.DeserializeObject<T>(json);
            return obj;
        }

        //public static string ConvertDataTable(DataTable dt)
        //{
        //    //List<T> data = new List<T>();

        //    //var json = JsonConvert.SerializeObject(dt);
        //    //if (typeof(string).Name != "List 1")
        //    //{
        //    //    json = json.TrimStart('[').TrimEnd(']');
        //    //}
        //    //var obj = JsonConvert.DeserializeObject<string>(json, new JsonSerializerSettings
        //    //{
        //    //     DefaultValueHandling = DefaultValueHandling.Include,
        //    //     NullValueHandling = NullValueHandling.Ignore,

        //    //});
        //    //return obj;




        //    //List<T> data = new List<T>();
        //    //foreach (DataRow row in dt.Rows)
        //    //{
        //    //    T item = GetItem<T>(row);
        //    //    data.Add(item);
        //    //}
        //    //return data;
        //}
        private static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                        pro.SetValue(obj, dr[column.ColumnName], null);
                    else
                        continue;
                }
            }
            return obj;
        }
        public static string GetVisitorIPAddress(bool GetLan = false)
        {
            //   GetLan = false;
            var visitorIPAddress = "0.0.0.0";//HttpContext.Connection.RemoteIpAddress.ToString();
            //var visitorIPAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            return visitorIPAddress;
        }

        public static string GetDetailsTableQry(object request,string HashTableName)
        {
            var result = ((IEnumerable)request).Cast<object>().ToList();

            string CandidateInfo_Str = " select * INTO ##"+ HashTableName + " from ( select  ";
            int countRows = 1;
            foreach (object item in result)
            {
                if (item == null) continue;
                foreach (PropertyInfo property in item.GetType().GetProperties())
                {
                    var Key = property.Name;
                    var Value = property.GetValue(item, null);
                    CandidateInfo_Str += "''" + AvoidSQLInjection_Char(Value.ToString()) + "'' as ''" + Key + "'',";
                }
                if (CandidateInfo_Str != "")
                {
                    CandidateInfo_Str = CandidateInfo_Str.Remove(CandidateInfo_Str.Length - 1, 1);
                }

                if (countRows < result.Count)
                {
                    CandidateInfo_Str += " union all select ";
                }
                countRows++;
            }
            CandidateInfo_Str += " ) table1";

            return CandidateInfo_Str;
        }

        public static string AvoidSQLInjection_Char(string str)
        {
            str = str.Trim();
            str = str.Replace("'", "");
            str = str.Replace("==", "=");
            return str;
        }
    }
}
