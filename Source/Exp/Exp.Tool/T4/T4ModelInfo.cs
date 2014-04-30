using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Linq;
namespace Exp.Tool.T4
{
    /// <summary>
    /// T4实体模型信息类
    /// </summary>
    public class T4ModelInfo
    {
        /// <summary>
        /// 获取是否使用模块文件夹
        /// </summary>
        public bool UseModuleDir { get; private set; }

        /// <summary>
        /// 获取模型所在模块名称
        /// </summary>
        public string ModuleName { get; private set; }

        /// <summary>
        /// 获取模型名称
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// 获取模型描述
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// 主键类型
        /// </summary>
        public Type KeyType { get; set; }

        /// <summary>
        /// 主键类型名称
        /// </summary>
        public string KeyTypeName { get; set; }

        public IEnumerable<PropertyInfo> Properties { get; private set; }

        public T4ModelInfo(Type modelType, bool useModuleDir = false)
        {
            var @namespace = modelType.Namespace;
            if (@namespace == null)
            {
                return;
            }
            UseModuleDir = useModuleDir;
            if (UseModuleDir)
            {
                var index = @namespace.LastIndexOf('.') + 1;
                ModuleName = @namespace.Substring(index, @namespace.Length - index);
            }

            Name = modelType.Name;
            PropertyInfo keyProp = modelType.GetProperty("Id");
            KeyType = keyProp.PropertyType;
            KeyTypeName = KeyType.Name;

            var descAttributes = modelType.GetCustomAttributes(typeof(DescriptionAttribute), true);
            Description = descAttributes.Length == 1 ? ((DescriptionAttribute)descAttributes[0]).Description : Name;

            List<Type> sysTypeNameList = new List<Type>();
            sysTypeNameList.Add(typeof(int));
            sysTypeNameList.Add(typeof(decimal));
            sysTypeNameList.Add(typeof(double));
            sysTypeNameList.Add(typeof(DateTime));
            sysTypeNameList.Add(typeof(string));
            sysTypeNameList.Add(typeof(bool));
            sysTypeNameList.Add(typeof(int?));
            sysTypeNameList.Add(typeof(decimal?));
            sysTypeNameList.Add(typeof(double?));
            sysTypeNameList.Add(typeof(DateTime?));
            sysTypeNameList.Add(typeof(string));
            sysTypeNameList.Add(typeof(bool?));
      
            Properties = modelType.GetProperties(BindingFlags.Instance|BindingFlags.Public).Where(c=> sysTypeNameList.Contains(c.PropertyType));
        }
    }
}
