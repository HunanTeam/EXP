using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Exp.Study.Mvc.Models.Test
{
    public class TestModel : BaseIdentityModel
    {
        [Required]
        [Display(Name = "姓名")]
        public string Name { get; set; }
        [Display(Name = "年龄")]
        public int Age { get; set; }
        public bool Deleted { get; set; }

        public int[] Ids { get; set; }
    }

    public class MyClass
    {
        public string Name { get; set; }
    }
}