using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Exp.Tool
{
    public class CollectionHelper
    {

        public delegate T GetPropertyValue<T>();
        public delegate void SetPropertyValue<T>(T Value);
        private static ConcurrentDictionary<string, Delegate> myDelegateCache = new ConcurrentDictionary<string, Delegate>();

        public static GetPropertyValue<T> CreateGetPropertyValueDelegate<TSource, T>(TSource obj, string propertyName)
        {
            string key = string.Format("Delegate-GetProperty-{0}-{1}", typeof(TSource).FullName, propertyName);
            GetPropertyValue<T> result = (GetPropertyValue<T>)myDelegateCache.GetOrAdd(
                key,
                newkey =>
                {
                    return Delegate.CreateDelegate(typeof(GetPropertyValue<T>), obj, typeof(TSource).GetProperty(propertyName).GetGetMethod());
                }
                );

            return result;
        }
        public static SetPropertyValue<T> CreateSetPropertyValueDelegate<TSource, T>(TSource obj, string propertyName)
        {
            string key = string.Format("Delegate-SetProperty-{0}-{1}", typeof(TSource).FullName, propertyName);
            SetPropertyValue<T> result = (SetPropertyValue<T>)myDelegateCache.GetOrAdd(
               key,
               newkey =>
               {
                   return Delegate.CreateDelegate(typeof(SetPropertyValue<T>), obj, typeof(TSource).GetProperty(propertyName).GetSetMethod());
               }
               );

            return result;
        }
        private CollectionHelper()
        {
        }
        public static List<T> Distinct<T>(IList<T> list)
        {
            List<T> list1 = new List<T>();
            foreach (T obj in list)
            {
                if (!list1.Contains(obj))
                    list1.Add(obj);
            }
            return list1;
        }
        public static DataTable ConvertTo<T>(IList<T> list)
        {
            DataTable table = CreateTable<T>();
            Type entityType = typeof(T);

            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(entityType);


            foreach (T item in list)
            {
                DataRow row = table.NewRow();

                foreach (PropertyDescriptor prop in properties)
                {
                    object val = prop.GetValue(item);
                    if (val != null)
                        row[prop.Name] = val;
                }

                table.Rows.Add(row);
            }

            return table;
        }

        public static IList<T> ConvertTo<T>(IList<DataRow> rows)
        {
            IList<T> list = null;

            if (rows != null)
            {
                list = new List<T>();

                foreach (DataRow row in rows)
                {
                    T item = CreateItem<T>(row);
                    list.Add(item);
                }
            }

            return list;
        }

        public static IList<T> ConvertTo<T>(DataTable table)
        {
            if (table == null)
            {
                return null;
            }

            List<DataRow> rows = new List<DataRow>();

            foreach (DataRow row in table.Rows)
            {
                rows.Add(row);
            }

            return ConvertTo<T>(rows);
        }
        //TODO:可以优化
        public static T CreateItem<T>(DataRow row)
        {
            T obj = default(T);

            if (row != null)
            {
                obj = Activator.CreateInstance<T>();


                foreach (DataColumn column in row.Table.Columns)
                {
                    object value = row[column.ColumnName];

                    PropertyInfo prop = obj.GetType().GetProperty(column.ColumnName);
                    try
                    {

                        if (value != DBNull.Value && prop != null)
                            prop.SetValue(obj, value, null);
                    }
                    catch
                    {
                        // You can log something here
                        throw;
                    }
                }
            }

            return obj;
        }

        public static DataTable CreateTable<T>()
        {
            Type entityType = typeof(T);
            DataTable table = new DataTable(entityType.Name);
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(entityType);

            foreach (PropertyDescriptor prop in properties)
            {
                if (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                {
                    NullableConverter converter = new NullableConverter(prop.PropertyType);
                    table.Columns.Add(prop.Name, converter.UnderlyingType);
                }
                else
                    table.Columns.Add(prop.Name, prop.PropertyType);
            }

            return table;
        }
    }
}
