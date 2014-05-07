﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace Exp.Study.NewLifeDo.Entity
{
    /// <summary></summary>
    [Serializable]
    [DataObject]
    [Description("")]
    [BindIndex("PK_User", true, "Id")]
    [BindRelation("Id", true, "Sys_Address", "Sys_UserId")]
    [BindTable("Sys_User", Description = "", ConnName = "MSSQL", DbType = DatabaseType.SqlServer)]
    public partial class User : IUser
    {
        #region 属性
        private Int32 _Id;
        /// <summary></summary>
        [DisplayName("Id")]
        [Description("")]
        [DataObjectField(true, true, false, 10)]
        [BindColumn(1, "Id", "", null, "int", 10, 0, false)]
        public virtual Int32 Id
        {
            get { return _Id; }
            set { if (OnPropertyChanging(__.Id, value)) { _Id = value; OnPropertyChanged(__.Id); } }
        }

        private Guid _Guid;
        /// <summary></summary>
        [DisplayName("Guid")]
        [Description("")]
        [DataObjectField(false, false, false, 16)]
        [BindColumn(2, "Guid", "", null, "uniqueidentifier", 0, 0, false)]
        public virtual Guid Guid
        {
            get { return _Guid; }
            set { if (OnPropertyChanging(__.Guid, value)) { _Guid = value; OnPropertyChanged(__.Guid); } }
        }

        private String _Name;
        /// <summary></summary>
        [DisplayName("Name")]
        [Description("")]
        [DataObjectField(false, false, false, 100)]
        [BindColumn(3, "Name", "", null, "nvarchar(100)", 0, 0, true)]
        public virtual String Name
        {
            get { return _Name; }
            set { if (OnPropertyChanging(__.Name, value)) { _Name = value; OnPropertyChanged(__.Name); } }
        }

        private String _Pwd;
        /// <summary></summary>
        [DisplayName("Pwd")]
        [Description("")]
        [DataObjectField(false, false, false, 128)]
        [BindColumn(4, "Pwd", "", null, "nvarchar(128)", 0, 0, true)]
        public virtual String Pwd
        {
            get { return _Pwd; }
            set { if (OnPropertyChanging(__.Pwd, value)) { _Pwd = value; OnPropertyChanged(__.Pwd); } }
        }

        private Int32 _PwdFormatId;
        /// <summary></summary>
        [DisplayName("PwdFormatId")]
        [Description("")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(5, "PwdFormatId", "", null, "int", 10, 0, false)]
        public virtual Int32 PwdFormatId
        {
            get { return _PwdFormatId; }
            set { if (OnPropertyChanging(__.PwdFormatId, value)) { _PwdFormatId = value; OnPropertyChanged(__.PwdFormatId); } }
        }

        private String _PwdSalt;
        /// <summary></summary>
        [DisplayName("PwdSalt")]
        [Description("")]
        [DataObjectField(false, false, true, 200)]
        [BindColumn(6, "PwdSalt", "", null, "nvarchar(200)", 0, 0, true)]
        public virtual String PwdSalt
        {
            get { return _PwdSalt; }
            set { if (OnPropertyChanging(__.PwdSalt, value)) { _PwdSalt = value; OnPropertyChanged(__.PwdSalt); } }
        }

        private Boolean _Active;
        /// <summary></summary>
        [DisplayName("Active")]
        [Description("")]
        [DataObjectField(false, false, true, 1)]
        [BindColumn(7, "Active", "", null, "bit", 0, 0, false)]
        public virtual Boolean Active
        {
            get { return _Active; }
            set { if (OnPropertyChanging(__.Active, value)) { _Active = value; OnPropertyChanged(__.Active); } }
        }

        private DateTime _CreatedOnUtc;
        /// <summary></summary>
        [DisplayName("CreatedOnUtc")]
        [Description("")]
        [DataObjectField(false, false, false, 3)]
        [BindColumn(8, "CreatedOnUtc", "", null, "datetime", 3, 0, false)]
        public virtual DateTime CreatedOnUtc
        {
            get { return _CreatedOnUtc; }
            set { if (OnPropertyChanging(__.CreatedOnUtc, value)) { _CreatedOnUtc = value; OnPropertyChanged(__.CreatedOnUtc); } }
        }

        private Boolean _Deleted;
        /// <summary></summary>
        [DisplayName("Deleted")]
        [Description("")]
        [DataObjectField(false, false, false, 1)]
        [BindColumn(9, "Deleted", "", null, "bit", 0, 0, false)]
        public virtual Boolean Deleted
        {
            get { return _Deleted; }
            set { if (OnPropertyChanging(__.Deleted, value)) { _Deleted = value; OnPropertyChanged(__.Deleted); } }
        }
        #endregion

        #region 获取/设置 字段值
        /// <summary>
        /// 获取/设置 字段值。
        /// 一个索引，基类使用反射实现。
        /// 派生实体类可重写该索引，以避免反射带来的性能损耗
        /// </summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        public override Object this[String name]
        {
            get
            {
                switch (name)
                {
                    case __.Id : return _Id;
                    case __.Guid : return _Guid;
                    case __.Name : return _Name;
                    case __.Pwd : return _Pwd;
                    case __.PwdFormatId : return _PwdFormatId;
                    case __.PwdSalt : return _PwdSalt;
                    case __.Active : return _Active;
                    case __.CreatedOnUtc : return _CreatedOnUtc;
                    case __.Deleted : return _Deleted;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case __.Id : _Id = Convert.ToInt32(value); break;
                    case __.Guid : _Guid = (Guid)value; break;
                    case __.Name : _Name = Convert.ToString(value); break;
                    case __.Pwd : _Pwd = Convert.ToString(value); break;
                    case __.PwdFormatId : _PwdFormatId = Convert.ToInt32(value); break;
                    case __.PwdSalt : _PwdSalt = Convert.ToString(value); break;
                    case __.Active : _Active = Convert.ToBoolean(value); break;
                    case __.CreatedOnUtc : _CreatedOnUtc = Convert.ToDateTime(value); break;
                    case __.Deleted : _Deleted = Convert.ToBoolean(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得字段信息的快捷方式</summary>
        public partial class _
        {
            ///<summary></summary>
            public static readonly Field Id = FindByName(__.Id);

            ///<summary></summary>
            public static readonly Field Guid = FindByName(__.Guid);

            ///<summary></summary>
            public static readonly Field Name = FindByName(__.Name);

            ///<summary></summary>
            public static readonly Field Pwd = FindByName(__.Pwd);

            ///<summary></summary>
            public static readonly Field PwdFormatId = FindByName(__.PwdFormatId);

            ///<summary></summary>
            public static readonly Field PwdSalt = FindByName(__.PwdSalt);

            ///<summary></summary>
            public static readonly Field Active = FindByName(__.Active);

            ///<summary></summary>
            public static readonly Field CreatedOnUtc = FindByName(__.CreatedOnUtc);

            ///<summary></summary>
            public static readonly Field Deleted = FindByName(__.Deleted);

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }

        /// <summary>取得字段名称的快捷方式</summary>
        partial class __
        {
            ///<summary></summary>
            public const String Id = "Id";

            ///<summary></summary>
            public const String Guid = "Guid";

            ///<summary></summary>
            public const String Name = "Name";

            ///<summary></summary>
            public const String Pwd = "Pwd";

            ///<summary></summary>
            public const String PwdFormatId = "PwdFormatId";

            ///<summary></summary>
            public const String PwdSalt = "PwdSalt";

            ///<summary></summary>
            public const String Active = "Active";

            ///<summary></summary>
            public const String CreatedOnUtc = "CreatedOnUtc";

            ///<summary></summary>
            public const String Deleted = "Deleted";

        }
        #endregion
    }

    /// <summary>接口</summary>
    public partial interface IUser
    {
        #region 属性
        /// <summary></summary>
        Int32 Id { get; set; }

        /// <summary></summary>
        Guid Guid { get; set; }

        /// <summary></summary>
        String Name { get; set; }

        /// <summary></summary>
        String Pwd { get; set; }

        /// <summary></summary>
        Int32 PwdFormatId { get; set; }

        /// <summary></summary>
        String PwdSalt { get; set; }

        /// <summary></summary>
        Boolean Active { get; set; }

        /// <summary></summary>
        DateTime CreatedOnUtc { get; set; }

        /// <summary></summary>
        Boolean Deleted { get; set; }
        #endregion

        #region 获取/设置 字段值
        /// <summary>获取/设置 字段值。</summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        Object this[String name] { get; set; }
        #endregion
    }
}