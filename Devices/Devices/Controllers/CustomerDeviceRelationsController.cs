using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Devices;
using Devices.Models;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Http.Extensions;
using System.Net.Http;

namespace Devices.Controllers
{
    [Produces("application/json")]
    [Route("api/CustomerDeviceRelations")]
    public class CustomerDeviceRelationsController : Controller
    {
        // GET: api/CustomerAndDevice
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/CustomerAndDevice/5
        [HttpGet("{id}")]
        public CustomerDeviceRelations Get(int id)
        {
            DeviceAndCustomerDefitions a = new DeviceAndCustomerDefitions();
            CustomerDeviceRelations temp = a.ReturnRelations(id);
            return temp;
        }
        
        // POST: api/CustomerAndDevice
        [HttpPost]
        public HttpResponseMessage Post([FromBody]CustomerDeviceRelations value)
        {
            DeviceAndCustomerDefitions temp = new DeviceAndCustomerDefitions();
            int id = temp.NewRelations(value);
            HttpResponseMessage res = new HttpResponseMessage(System.Net.HttpStatusCode.Created);
            Regex x = new Regex(@"(\/CustomerAndDevice)");
            res.Headers.Location = new Uri(x.Replace(Request.GetDisplayUrl(), "/CustomerAndDevice/" + id.ToString()));
            return res;
        }
        
        // PUT: api/CustomerAndDevice/5
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
