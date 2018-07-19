using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Devices;
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
        // GET: api/Device
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Device/5
        [HttpGet("{id}")]
        public Device Get(int id)
        {
            DeviceAndCustomerDefitions a = new DeviceAndCustomerDefitions();
            Device temp = a.ReturnDevice(id);
            return temp;
        }

        // POST: api/Device
        [HttpPost]
        public HttpResponseMessage Post([FromBody]Device value)
        {
            DeviceAndCustomerDefitions temp = new DeviceAndCustomerDefitions();
            int id =temp.NewDevice(value);
            HttpResponseMessage res= new HttpResponseMessage(System.Net.HttpStatusCode.Created);
            //    regex=> .*\/Device\/([0-9]*) DEVİCEDAN SONRA GELEN KISMI DEĞİŞTİRME
            Regex x = new Regex(@"(\/Device)");
            res.Headers.Location = new Uri(x.Replace(Request.GetDisplayUrl(), "/Device/" + id.ToString()));
            return res;
        }

        // PUT: api/Device/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
