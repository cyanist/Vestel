using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Devices.Models;
using System.Data.SqlClient;
using Devices.Controllers;


namespace Devices
{
    public class DeviceAndCustomerDefitions
    {

        public System.Data.SqlClient.SqlConnection conn;
        public DeviceAndCustomerDefitions()

        {
            string myConnectionString = "Data Source=DESKTOP-OO8SH3F\\SQLEXPRESS;Initial Catalog=DevicesAndCustomersdb;Integrated Security=True";
            try
            {

                conn = new System.Data.SqlClient.SqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {

            }


        }

        //Device Functions


        public int NewDevice(Device device)
        {
            string sqlString = "INSERT INTO Device (Type,Name,UUID,MAC) VALUES('" + device.Type + "','" + device.Name + "','" + device.UUID + "','" + device.MAC + "')";
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(sqlString, conn);
            cmd.ExecuteNonQuery();
            System.Data.SqlClient.SqlDataReader reader = null;
            sqlString = "SELECT MAX(ID) FROM Device";
            cmd = new System.Data.SqlClient.SqlCommand(sqlString, conn);
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                int id = reader.GetInt32(0);
                return id;
            }

            else

                return -1;

        }

        public Device ReturnDevice(int id)
        {
            Device a = new Device();
            System.Data.SqlClient.SqlDataReader reader = null;
            string strSQL = "SELECT * FROM Device WHERE id = " + id.ToString();
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(strSQL, conn);
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                a.ID = reader.GetInt32(0);
                a.Type = reader.GetString(1);
                a.Name = reader.GetString(2);
                a.UUID = reader.GetString(3);
                a.MAC = reader.GetString(4);
                return a;
            }
            else return null;
        }


        // Customer Functions

        public int NewCustomer(Customer custom)
        {
            string sqlString = "INSERT INTO Customer (Email,FirstName,LastName,Age,PhoneNumber) VALUES('" + custom.Email + "','" + custom.FirstName + "','" + custom.LastName + "'," + custom.Age + "," + custom.PhoneNumber + ")";
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(sqlString, conn);
            cmd.ExecuteNonQuery();
            System.Data.SqlClient.SqlDataReader reader = null;
            sqlString = "SELECT MAX(ID) FROM Customer";
            cmd = new System.Data.SqlClient.SqlCommand(sqlString, conn);
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                int id = reader.GetInt32(0);
                return id;
            }
            else
                return -1;

        }

        public Customer ReturnCustomer(int id)
        {
            Customer a = new Customer();
            System.Data.SqlClient.SqlDataReader reader = null;
            string strSQL = "SELECT * FROM Customer WHERE id = " + id.ToString();
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(strSQL, conn);

            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                a.ID = reader.GetInt32(0);
                a.Email = reader.GetString(1);
                a.FirstName = reader.GetString(2);
                a.LastName = reader.GetString(3);
                a.Age = reader.GetInt32(4);
                a.PhoneNumber = reader.GetInt32(4);
                return a;
            }
            else return null;
        }



        //Customer And Device Relationships

        public int NewRelations(CustomerDeviceRelations custom)
        {
            string sqlString = "INSERT INTO CustomerDeviceRelations (Customer_ID,Device_ID) VALUES(" + custom.Customer_ID + "," + custom.Device_ID + ")";
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(sqlString, conn);
            cmd.ExecuteNonQuery();
            System.Data.SqlClient.SqlDataReader reader = null;
            sqlString = "SELECT MAX(ID) FROM CustomerDeviceRelations";
            cmd = new System.Data.SqlClient.SqlCommand(sqlString, conn);
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                int id = reader.GetInt32(0);
                return id;
            }

            else

                return -1;
        }

        public CustomerDeviceRelations ReturnRelations(int id)
        {
            CustomerDeviceRelations a = new CustomerDeviceRelations();
            System.Data.SqlClient.SqlDataReader reader = null;
            string strSQL = "SELECT * FROM CustomerDeviceRelations WHERE id = " + id.ToString();
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(strSQL, conn);
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                a.ID = reader.GetInt32(0);
                a.Customer_ID = reader.GetInt32(1);
                a.Device_ID = reader.GetInt32(2);
                return a;
            }
            else return null;
        }


    }
}
