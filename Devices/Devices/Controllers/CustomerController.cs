using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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

        // GET: api/Customer/5
        [HttpGet("{id}")]
        public Customer Get(int id)
        {
            DeviceAndCustomerFunctions a = new DeviceAndCustomerFunctions();
            Customer temp = a.ReturnCustomer(id);
            return temp;
        }
        
        // POST: api/Customer
        [HttpPost]
        public HttpResponseMessage Post([FromBody]Customer value)
        {
            DeviceAndCustomerFunctions temp = new DeviceAndCustomerFunctions();
            int id = temp.NewCustomer(value);
            HttpResponseMessage res = new HttpResponseMessage(System.Net.HttpStatusCode.Created);
            Regex x = new Regex(@"(\/Customer)");
            res.Headers.Location = new Uri(x.Replace(Request.GetDisplayUrl(), "/Customer/" + id.ToString()));
            return res;
        }
               
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            DeviceAndCustomerFunctions a = new DeviceAndCustomerFunctions();
            a.DeleteCustomer(id);
        }
    }
}
