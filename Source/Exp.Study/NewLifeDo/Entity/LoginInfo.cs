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
    [BindIndex("PK_Sys_LoginInfo", true, "Id")]
    [BindTable("Sys_LoginInfo", Description = "", ConnName = "MSSQL", DbType = DatabaseType.SqlServer)]
    public partial class LoginInfo : ILoginInfo
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

        private Int32 _UserId;
        /// <summary></summary>
        [DisplayName("UserId")]
        [Description("")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(2, "UserId", "", null, "int", 10, 0, false)]
        public virtual Int32 UserId
        {
            get { return _UserId; }
            set { if (OnPropertyChanging(__.UserId, value)) { _UserId = value; OnPropertyChanged(__.UserId); } }
        }

        private String _LoginIpAddress;
        /// <summary></summary>
        [DisplayName("LoginIpAddress")]
        [Description("")]
        [DataObjectField(false, false, false, 50)]
        [BindColumn(3, "LoginIpAddress", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String LoginIpAddress
        {
            get { return _LoginIpAddress; }
            set { if (OnPropertyChanging(__.LoginIpAddress, value)) { _LoginIpAddress = value; OnPropertyChanged(__.LoginIpAddress); } }
        }

        private DateTime _CreateOnUtc;
        /// <summary></summary>
        [DisplayName("CreateOnUtc")]
        [Description("")]
        [DataObjectField(false, false, false, 3)]
        [BindColumn(4, "CreateOnUtc", "", null, "datetime", 3, 0, false)]
        public virtual DateTime CreateOnUtc
        {
            get { return _CreateOnUtc; }
            set { if (OnPropertyChanging(__.CreateOnUtc, value)) { _CreateOnUtc = value; OnPropertyChanged(__.CreateOnUtc); } }
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
                    case __.UserId : return _UserId;
                    case __.LoginIpAddress : return _LoginIpAddress;
                    case __.CreateOnUtc : return _CreateOnUtc;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case __.Id : _Id = Convert.ToInt32(value); break;
                    case __.UserId : _UserId = Convert.ToInt32(value); break;
                    case __.LoginIpAddress : _LoginIpAddress = Convert.ToString(value); break;
                    case __.CreateOnUtc : _CreateOnUtc = Convert.ToDateTime(value); break;
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
            public static readonly Field UserId = FindByName(__.UserId);

            ///<summary></summary>
            public static readonly Field LoginIpAddress = FindByName(__.LoginIpAddress);

            ///<summary></summary>
            public static readonly Field CreateOnUtc = FindByName(__.CreateOnUtc);

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }

        /// <summary>取得字段名称的快捷方式</summary>
        partial class __
        {
            ///<summary></summary>
            public const String Id = "Id";

            ///<summary></summary>
            public const String UserId = "UserId";

            ///<summary></summary>
            public const String LoginIpAddress = "LoginIpAddress";

            ///<summary></summary>
            public const String CreateOnUtc = "CreateOnUtc";

        }
        #endregion
    }

    /// <summary>接口</summary>
    public partial interface ILoginInfo
    {
        #region 属性
        /// <summary></summary>
        Int32 Id { get; set; }

        /// <summary></summary>
        Int32 UserId { get; set; }

        /// <summary></summary>
        String LoginIpAddress { get; set; }

        /// <summary></summary>
        DateTime CreateOnUtc { get; set; }
        #endregion

        #region 获取/设置 字段值
        /// <summary>获取/设置 字段值。</summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        Object this[String name] { get; set; }
        #endregion
    }
}