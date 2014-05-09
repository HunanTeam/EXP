using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using ExpApp.Domain.Models.Sys;
namespace ExpApp.Services
{
    public partial class TestService:CoreServiceBase,ITestService
    {
        public TestService() : base(null) { }
        public void Insert()
        {
            User user = new User();
            
        }
    }
}
