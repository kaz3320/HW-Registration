using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace RegistrationHW.Models
{
    public class Response
    {
        public HttpStatusCode Status { get; set; }
        public string JsonData { get; set; }
        public string Message { get; set; }

        public Response() { }

        public Response(HttpStatusCode status, string jsonData, string message)
        {
            Status = status;
            JsonData = jsonData;
            Message = message;
        }
    }
}