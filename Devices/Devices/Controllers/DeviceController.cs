using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
using Devices.Models;
using System.Net.Http;
using Microsoft.AspNetCore.Http.Extensions;

namespace Devices.Controllers
{
    [Produces("application/json")]
    [Route("api/Device")]
    public class DeviceController : Controller
    {
        // GET: api/Device/5
        [HttpGet("{id}")]
        public Device Get(int id)
        {
            DeviceAndCustomerFunctions a = new DeviceAndCustomerFunctions();
            Device temp = a.ReturnDevice(id);
            return temp;
        }

        // POST: api/Device
        [HttpPost]
        public HttpResponseMessage Post([FromBody]Device value)
        {
            DeviceAndCustomerFunctions temp = new DeviceAndCustomerFunctions();
            int id =temp.NewDevice(value);
            HttpResponseMessage res= new HttpResponseMessage(System.Net.HttpStatusCode.Created);
            //    regex=> .*\/Device\/([0-9]*) DEVİCEDAN SONRA GELEN KISMI DEĞİŞTİRME
            Regex x = new Regex(@"(\/Device)");
            res.Headers.Location = new Uri(x.Replace(Request.GetDisplayUrl(), "/Device/" + id.ToString()));
            return res;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            DeviceAndCustomerFunctions a = new DeviceAndCustomerFunctions();
            a.DeleteDevice(id);
        }
    }
}
