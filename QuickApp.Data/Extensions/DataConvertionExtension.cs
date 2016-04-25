using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace QuickApp.Data.Extensions
{
    public static class DataConvertionExtension
    {
        #region 内部私有方法

        /// <summary>
        /// DataReader转换为数据实体
        /// </summary>
        /// <typeparam name="T">数据实体</typeparam>
        /// <param name="dr">DataReader</param>
        /// <returns></returns>
        private static T FillEntityFromDataReader<T>(IDataReader dr)
        {
            T entity = Activator.CreateInstance<T>();
            int count = dr.FieldCount;
            for (int i = 0; i < count; i++)
            {
                string fieldName = dr.GetName(i);
                object fieldValue = dr[fieldName];
                PropertyInfo property = entity.GetType().GetProperty(fieldName, BindingFlags.GetProperty | BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);
                //如果DataReader读取出来的数据库字段在实体中没有对应的字段属性则跳出当前，继续读下一个字段
                if (property == null)
                {
                    continue;
                }
                Type propertyType = property.PropertyType;
                if (fieldValue != DBNull.Value)
                {
                    if (propertyType.IsEnum)
                    {
                        int value = 0;
                        if (fieldValue.GetType().FullName.Equals("System.Boolean")) //如果数据表字段值为bit类型,则先转换为int类型
                        {
                            bool tempValue = (bool)fieldValue;
                            value = tempValue ? 1 : 0;
                        }
                        else
                        {
                            value = int.Parse(fieldValue.ToString());
                        }
                        property.SetValue(entity, Enum.Parse(propertyType, value.ToString(), true), null);
                    }
                    else if (propertyType.IsGenericType && propertyType.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
                    {
                        property.SetValue(entity, ChangeType(fieldValue, System.Nullable.GetUnderlyingType(propertyType)), null);
                    }
                    else
                    {
                        property.SetValue(entity, ChangeType(fieldValue, propertyType), null);
                    }
                }
            }
            return entity;
        }

        #endregion

        #region 添加SQL参数扩展方法

        /// <summary>
        /// 添加多个参数
        /// </summary>
        /// <param name="cmd">SQL命令</param>
        /// <param name="param">参数</param>
        public static void AddParams(this DbCommand cmd, params object[] param)
        {
            foreach (object p in param)
            {
                AddParam(cmd, p);
            }
        }

        /// <summary>
        /// 添加单个参数
        /// </summary>
        /// <param name="cmd">SQL命令</param>
        /// <param name="param">参数</param>
        public static void AddParam(this DbCommand cmd, object param)
        {
            DbParameter parameter = cmd.CreateParameter();
            parameter.ParameterName = string.Format("@{0}", cmd.Parameters.Count);
            if (param == null)
            {
                parameter.Value = DBNull.Value;
            }
            else if (param.GetType() == typeof(DateTime) && DateTime.Parse(param.ToString()) == DateTime.MinValue)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = param;
            }
            cmd.Parameters.Add(parameter);
        }

        #endregion

        #region IDataReader转换成Dictionary扩展方法

        /// <summary>
        /// 扩展方法,DataReader转换成泛型实体集合
        /// </summary>
        /// <typeparam name="T">泛型实体对象约束</typeparam>
        /// <param name="dr">DataReader</param>
        /// <returns>泛型实体集合</returns>
        public static IList<T> DataReaderToList<T>(this IDataReader dr)
        {
            IList<T> entities = new List<T>();
            while (dr.Read())
            {
                T entity = FillEntityFromDataReader<T>(dr);
                if (entity != null)
                {
                    entities.Add(entity);
                }
            }
            return entities;
        }

        /// <summary>
        /// 扩展方法,DataReader转换成实体对象
        /// </summary>
        /// <typeparam name="T">实体对象约束</typeparam>
        /// <param name="dr">DataReader</param>
        /// <returns>实体对象</returns>
        public static T DataReaderToModel<T>(this IDataReader dr)
        {
            T entity = default(T);
            if (dr.Read())
            {
                entity = FillEntityFromDataReader<T>(dr);
            }
            return entity;
        }

        /// <summary>
        /// 实体转换成字典
        /// </summary>
        /// <param name="entity">数据实体</param>
        /// <returns></returns>
        public static IDictionary<string, object> ToDictionary(this object entity)
        {
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            PropertyInfo[] properties = entity.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.GetProperty | BindingFlags.IgnoreCase);

            foreach (PropertyInfo property in properties)
            {
                string propertyName = property.Name;
                object value = property.GetValue(entity, null);

                dictionary.Add(propertyName, value);
            }

            return dictionary;

        }

        static object ChangeType(object value, Type type)
        {
            if (value == null && type.IsGenericType) return Activator.CreateInstance(type);
            if (value == null) return null;
            if (type == value.GetType()) return value;
            if (type.IsEnum)
            {
                if (value is string)
                    return Enum.Parse(type, value as string);
                else
                    return Enum.ToObject(type, value);
            }
            if (!type.IsInterface && type.IsGenericType)
            {
                Type innerType = type.GetGenericArguments()[0];
                object innerValue = ChangeType(value, innerType);
                return Activator.CreateInstance(type, new object[] { innerValue });
            }
            if (value is string && type == typeof(Guid))
            {
                return new Guid(value as string);
            }
            if (value is Guid && type == typeof(string))
            {
                return value.ToString();
            }
            if (value is string && type == typeof(Version))
            {
                return new Version(value as string);
            }
            if (!(value is IConvertible))
            {
                return value;
            }
            return Convert.ChangeType(value, type);
        }

        #endregion
    }
}
