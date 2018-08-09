using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Devices.Models;
using System.Data.SqlClient;
using Devices.Controllers;


namespace Devices
{
    public class DeviceAndCustomerFunctions
    {

        public System.Data.SqlClient.SqlConnection conn;
        public DeviceAndCustomerFunctions()

        {
            string myConnectionString = "Data Source=DESKTOP-OO8SH3F\\SQLEXPRESS;Initial Catalog=DevicesAndCustomersdb;User ID=Asd;Password=1234;";
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


        public int NewDevice(Device custom)
        {
            string sqlString = "INSERT INTO Device (Type,Name,UUID,MAC) VALUES(@type,@name,@uuid,@mac)";
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(sqlString, conn);
            cmd.Parameters.AddWithValue("@type", custom.Type);
            cmd.Parameters.AddWithValue("@name", custom.Name);
            cmd.Parameters.AddWithValue("@uuid", custom.UUID);
            cmd.Parameters.AddWithValue("@mac", custom.MAC);
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
            string strSQL = "SELECT * FROM Device WHERE ID = @id";
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(strSQL, conn);
            cmd.Parameters.AddWithValue("@id", id);
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

        public void DeleteDevice(int id)
        {
            string strSQL = "DELETE FROM Device WHERE ID = @id";
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(strSQL, conn);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }

        // Customer Functions

        public int NewCustomer(Customer custom)
        {
            string sqlString = "INSERT INTO Customer (Email,FirstName,LastName,Age,PhoneNumber) VALUES(@email,@fname,@lname,@age,@phnumber)";
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(sqlString, conn);
            cmd.Parameters.AddWithValue("@email", custom.Email);
            cmd.Parameters.AddWithValue("@fname", custom.FirstName);
            cmd.Parameters.AddWithValue("@lname", custom.LastName);
            cmd.Parameters.AddWithValue("@age", custom.Age);
            cmd.Parameters.AddWithValue("@phnumber", custom.PhoneNumber);
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
            string strSQL = "SELECT * FROM Customer WHERE ID = @id";
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(strSQL, conn);
            cmd.Parameters.AddWithValue("@id", id);

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

        public void DeleteCustomer(int id)
        {
            string strSQL = "DELETE FROM Customer WHERE ID = @id";
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(strSQL, conn);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }

        //Customer And Device Relationships

        public int NewRelations(CustomerDeviceRelations custom)
        {
            string sqlString = "INSERT INTO CustomerDeviceRelations (Customer_ID,Device_ID) VALUES( @Customer_id , @Device_id)";
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(sqlString, conn);
            cmd.Parameters.AddWithValue("@Customer_id", custom.Customer_ID);
            cmd.Parameters.AddWithValue("@Device_id", custom.Device_ID);
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

            string strSQL = "SELECT * FROM CustomerDeviceRelations WHERE ID = @id";
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(strSQL, conn);
            cmd.Parameters.AddWithValue("@id", id);

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

        public void DeleteRelations(int id)
        {
            string strSQL = "DELETE FROM CustomerDeviceRelations WHERE ID = @id";
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(strSQL, conn);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }
    }
}
