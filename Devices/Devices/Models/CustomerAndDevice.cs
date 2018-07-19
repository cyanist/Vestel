using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Devices.Models
{
    public class Customer
    {
        public int ID { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public int PhoneNumber { get; set; }
    }

    public class Device
    {
        public int ID { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string UUID { get; set; }
        public string MAC { get; set; }
    }

    public class CustomerDeviceRelations
    {
        public int ID { get; set; }
        public int Customer_ID { get; set; }
        public int Device_ID { get; set; }
    }
}
