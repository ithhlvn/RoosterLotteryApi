/********************************************************************************/
/* COPYRIGHT 										                            */
/* Authors reserve all rights even in the event of industrial property rights.  */
/* Authors reserve all rights of disposal such as copying and passing			*/
/* on to third parties. 										                */
/*													                            */
/* Description : Create StoreProcedures-Helper                                            */
/*													                            */
/* Developers : LanHH, Vietnam                                                  */
/* -----------------------------------------------------------------------------*/
/* History 											                            */
/*													                            */
/* Started on : 01 May 2024  							                        */
/* Revision : 1.0.0.0 									  	                    */
/* Changed by :     									                        */
/* Change date :                                                                */
/* Changes : 								                                    */
/* Reasons :  										                            */
/********************************************************************************/
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace ImEmr.Provider.StoreProcedures
{
    public static class SPHelper
    {
        public static T GetItem<T>(DataRow dr, bool isCheckCanWriteAndName = false)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if ((isCheckCanWriteAndName == false && pro.Name == column.ColumnName) ||
                        (isCheckCanWriteAndName == true && pro.CanWrite == true && pro.Name?.ToLower()?.Trim() == column.ColumnName?.ToLower()?.Trim()))
                    {
                        if (dr[column.ColumnName] != DBNull.Value)
                            pro.SetValue(obj, dr[column.ColumnName], null);
                    }
                    continue;
                }
            }
            return obj;
        }


        public static List<T> ConvertDataTable<T>(DataTable dt, bool isCheckCanWriteAndName = false)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row, isCheckCanWriteAndName);
                data.Add(item);
            }
            return data;
        }

        public static DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);
            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            if (Props.Length == 0)
            {
                dataTable.Columns.Add("Id");
            }
            else
            {
                foreach (PropertyInfo prop in Props)
                {
                    //Setting column names as Property names
                    dataTable.Columns.Add(prop.Name);
                }
            }

            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }

            //put a breakpoint here and check datatable
            return dataTable;
        }
    }
}
