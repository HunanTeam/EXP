using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exp.Study.EF6.Data.Entites
{
    public class Address : BaseEntity
    {
        public Address()
        {

        }
        public int ProvinceId { get; set; }
        public int CityId { get; set; }
        public int DistrictId { get; set; }
        public string Address1 { get; set; }
        public string Phone { get; set; }
        public string Tel { get; set; }
        public string ZipCode { get; set; }
        public DateTime CreateTime { get; set; }


    }
}