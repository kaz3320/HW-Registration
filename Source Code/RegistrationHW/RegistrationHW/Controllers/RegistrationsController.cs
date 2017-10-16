using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RegistrationAPI.DbOps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RegistrationAPI.Controllers
{
    public class RegistrationsController : ApiController
    {
        [HttpGet]
        public string GetReport()
        {
            var reportData = new DapperArgs();

            var data = reportData.GetUsers();

            return JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        public string AddUser([FromBody] JObject jsonData)
        {
            var reportData = new DapperArgs();

            var success = reportData.Insert(jsonData);

            if (success)
            {
                return "1";
            }

            return "0";
        }
    }
}