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
    [Route("api/Customer")]
    public class CustomerController : Controller
    {
        // GET: api/Customer
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Customer/5
        [HttpGet("{id}")]
        public Customer Get(int id)
        {
            DeviceAndCustomerDefitions a = new DeviceAndCustomerDefitions();
            Customer temp = a.ReturnCustomer(id);
            return temp;
        }
        
        // POST: api/Customer
        [HttpPost]
        public HttpResponseMessage Post([FromBody]Customer value)
        {
            DeviceAndCustomerDefitions temp = new DeviceAndCustomerDefitions();
            int id = temp.NewCustomer(value);
            HttpResponseMessage res = new HttpResponseMessage(System.Net.HttpStatusCode.Created);
            Regex x = new Regex(@"(\/Customer)");
            res.Headers.Location = new Uri(x.Replace(Request.GetDisplayUrl(), "/Customer/" + id.ToString()));
            return res;
        }
        
        // PUT: api/Customer/5
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
