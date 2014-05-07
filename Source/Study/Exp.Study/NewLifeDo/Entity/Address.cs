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
    [BindIndex("PK_Sys_Address2", true, "Id")]
    [BindIndex("IX_Sys_Address_Sys_UserId", false, "Sys_UserId")]
    [BindRelation("Sys_UserId", false, "Sys_User", "Id")]
    [BindTable("Sys_Address", Description = "", ConnName = "MSSQL", DbType = DatabaseType.SqlServer)]
    public partial class Address : IAddress
    {
        #region 属性
        private Int32 _Id;
        /// <summary></summary>
        [DisplayName("Id")]
        [Description("")]
        [DataObjectField(true, false, false, 10)]
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
        [BindColumn(2, "Sys_UserId", "", null, "int", 10, 0, false)]
        public virtual Int32 UserId
        {
            get { return _UserId; }
            set { if (OnPropertyChanging(__.UserId, value)) { _UserId = value; OnPropertyChanged(__.UserId); } }
        }

        private String _FirstName;
        /// <summary></summary>
        [DisplayName("FirstName")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(3, "FirstName", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String FirstName
        {
            get { return _FirstName; }
            set { if (OnPropertyChanging(__.FirstName, value)) { _FirstName = value; OnPropertyChanged(__.FirstName); } }
        }

        private String _LastName;
        /// <summary></summary>
        [DisplayName("LastName")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(4, "LastName", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String LastName
        {
            get { return _LastName; }
            set { if (OnPropertyChanging(__.LastName, value)) { _LastName = value; OnPropertyChanged(__.LastName); } }
        }

        private String _Email;
        /// <summary></summary>
        [DisplayName("Email")]
        [Description("")]
        [DataObjectField(false, false, true, 100)]
        [BindColumn(5, "Email", "", null, "nvarchar(100)", 0, 0, true)]
        public virtual String Email
        {
            get { return _Email; }
            set { if (OnPropertyChanging(__.Email, value)) { _Email = value; OnPropertyChanged(__.Email); } }
        }

        private String _Company;
        /// <summary></summary>
        [DisplayName("Company")]
        [Description("")]
        [DataObjectField(false, false, true, 100)]
        [BindColumn(6, "Company", "", null, "nvarchar(100)", 0, 0, true)]
        public virtual String Company
        {
            get { return _Company; }
            set { if (OnPropertyChanging(__.Company, value)) { _Company = value; OnPropertyChanged(__.Company); } }
        }

        private Int32 _CountryId;
        /// <summary></summary>
        [DisplayName("CountryId")]
        [Description("")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(7, "CountryId", "", null, "int", 10, 0, false)]
        public virtual Int32 CountryId
        {
            get { return _CountryId; }
            set { if (OnPropertyChanging(__.CountryId, value)) { _CountryId = value; OnPropertyChanged(__.CountryId); } }
        }

        private Int32 _StateProvinceId;
        /// <summary></summary>
        [DisplayName("StateProvinceId")]
        [Description("")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(8, "StateProvinceId", "", null, "int", 10, 0, false)]
        public virtual Int32 StateProvinceId
        {
            get { return _StateProvinceId; }
            set { if (OnPropertyChanging(__.StateProvinceId, value)) { _StateProvinceId = value; OnPropertyChanged(__.StateProvinceId); } }
        }

        private Int32 _CityId;
        /// <summary></summary>
        [DisplayName("CityId")]
        [Description("")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(9, "CityId", "", null, "int", 10, 0, false)]
        public virtual Int32 CityId
        {
            get { return _CityId; }
            set { if (OnPropertyChanging(__.CityId, value)) { _CityId = value; OnPropertyChanged(__.CityId); } }
        }

        private String _Address1;
        /// <summary></summary>
        [DisplayName("Address1")]
        [Description("")]
        [DataObjectField(false, false, true, 500)]
        [BindColumn(10, "Address1", "", null, "nvarchar(500)", 0, 0, true)]
        public virtual String Address1
        {
            get { return _Address1; }
            set { if (OnPropertyChanging(__.Address1, value)) { _Address1 = value; OnPropertyChanged(__.Address1); } }
        }

        private String _ZipPostalCode;
        /// <summary></summary>
        [DisplayName("ZipPostalCode")]
        [Description("")]
        [DataObjectField(false, false, false, 50)]
        [BindColumn(11, "ZipPostalCode", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String ZipPostalCode
        {
            get { return _ZipPostalCode; }
            set { if (OnPropertyChanging(__.ZipPostalCode, value)) { _ZipPostalCode = value; OnPropertyChanged(__.ZipPostalCode); } }
        }

        private String _PhoneNumber;
        /// <summary></summary>
        [DisplayName("PhoneNumber")]
        [Description("")]
        [DataObjectField(false, false, false, 50)]
        [BindColumn(12, "PhoneNumber", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String PhoneNumber
        {
            get { return _PhoneNumber; }
            set { if (OnPropertyChanging(__.PhoneNumber, value)) { _PhoneNumber = value; OnPropertyChanged(__.PhoneNumber); } }
        }

        private String _MobileNumber;
        /// <summary></summary>
        [DisplayName("MobileNumber")]
        [Description("")]
        [DataObjectField(false, false, false, 50)]
        [BindColumn(13, "MobileNumber", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String MobileNumber
        {
            get { return _MobileNumber; }
            set { if (OnPropertyChanging(__.MobileNumber, value)) { _MobileNumber = value; OnPropertyChanged(__.MobileNumber); } }
        }

        private String _FaxNumber;
        /// <summary></summary>
        [DisplayName("FaxNumber")]
        [Description("")]
        [DataObjectField(false, false, false, 50)]
        [BindColumn(14, "FaxNumber", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String FaxNumber
        {
            get { return _FaxNumber; }
            set { if (OnPropertyChanging(__.FaxNumber, value)) { _FaxNumber = value; OnPropertyChanged(__.FaxNumber); } }
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
                    case __.FirstName : return _FirstName;
                    case __.LastName : return _LastName;
                    case __.Email : return _Email;
                    case __.Company : return _Company;
                    case __.CountryId : return _CountryId;
                    case __.StateProvinceId : return _StateProvinceId;
                    case __.CityId : return _CityId;
                    case __.Address1 : return _Address1;
                    case __.ZipPostalCode : return _ZipPostalCode;
                    case __.PhoneNumber : return _PhoneNumber;
                    case __.MobileNumber : return _MobileNumber;
                    case __.FaxNumber : return _FaxNumber;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case __.Id : _Id = Convert.ToInt32(value); break;
                    case __.UserId : _UserId = Convert.ToInt32(value); break;
                    case __.FirstName : _FirstName = Convert.ToString(value); break;
                    case __.LastName : _LastName = Convert.ToString(value); break;
                    case __.Email : _Email = Convert.ToString(value); break;
                    case __.Company : _Company = Convert.ToString(value); break;
                    case __.CountryId : _CountryId = Convert.ToInt32(value); break;
                    case __.StateProvinceId : _StateProvinceId = Convert.ToInt32(value); break;
                    case __.CityId : _CityId = Convert.ToInt32(value); break;
                    case __.Address1 : _Address1 = Convert.ToString(value); break;
                    case __.ZipPostalCode : _ZipPostalCode = Convert.ToString(value); break;
                    case __.PhoneNumber : _PhoneNumber = Convert.ToString(value); break;
                    case __.MobileNumber : _MobileNumber = Convert.ToString(value); break;
                    case __.FaxNumber : _FaxNumber = Convert.ToString(value); break;
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
            public static readonly Field FirstName = FindByName(__.FirstName);

            ///<summary></summary>
            public static readonly Field LastName = FindByName(__.LastName);

            ///<summary></summary>
            public static readonly Field Email = FindByName(__.Email);

            ///<summary></summary>
            public static readonly Field Company = FindByName(__.Company);

            ///<summary></summary>
            public static readonly Field CountryId = FindByName(__.CountryId);

            ///<summary></summary>
            public static readonly Field StateProvinceId = FindByName(__.StateProvinceId);

            ///<summary></summary>
            public static readonly Field CityId = FindByName(__.CityId);

            ///<summary></summary>
            public static readonly Field Address1 = FindByName(__.Address1);

            ///<summary></summary>
            public static readonly Field ZipPostalCode = FindByName(__.ZipPostalCode);

            ///<summary></summary>
            public static readonly Field PhoneNumber = FindByName(__.PhoneNumber);

            ///<summary></summary>
            public static readonly Field MobileNumber = FindByName(__.MobileNumber);

            ///<summary></summary>
            public static readonly Field FaxNumber = FindByName(__.FaxNumber);

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
            public const String FirstName = "FirstName";

            ///<summary></summary>
            public const String LastName = "LastName";

            ///<summary></summary>
            public const String Email = "Email";

            ///<summary></summary>
            public const String Company = "Company";

            ///<summary></summary>
            public const String CountryId = "CountryId";

            ///<summary></summary>
            public const String StateProvinceId = "StateProvinceId";

            ///<summary></summary>
            public const String CityId = "CityId";

            ///<summary></summary>
            public const String Address1 = "Address1";

            ///<summary></summary>
            public const String ZipPostalCode = "ZipPostalCode";

            ///<summary></summary>
            public const String PhoneNumber = "PhoneNumber";

            ///<summary></summary>
            public const String MobileNumber = "MobileNumber";

            ///<summary></summary>
            public const String FaxNumber = "FaxNumber";

        }
        #endregion
    }

    /// <summary>接口</summary>
    public partial interface IAddress
    {
        #region 属性
        /// <summary></summary>
        Int32 Id { get; set; }

        /// <summary></summary>
        Int32 UserId { get; set; }

        /// <summary></summary>
        String FirstName { get; set; }

        /// <summary></summary>
        String LastName { get; set; }

        /// <summary></summary>
        String Email { get; set; }

        /// <summary></summary>
        String Company { get; set; }

        /// <summary></summary>
        Int32 CountryId { get; set; }

        /// <summary></summary>
        Int32 StateProvinceId { get; set; }

        /// <summary></summary>
        Int32 CityId { get; set; }

        /// <summary></summary>
        String Address1 { get; set; }

        /// <summary></summary>
        String ZipPostalCode { get; set; }

        /// <summary></summary>
        String PhoneNumber { get; set; }

        /// <summary></summary>
        String MobileNumber { get; set; }

        /// <summary></summary>
        String FaxNumber { get; set; }
        #endregion

        #region 获取/设置 字段值
        /// <summary>获取/设置 字段值。</summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        Object this[String name] { get; set; }
        #endregion
    }
}