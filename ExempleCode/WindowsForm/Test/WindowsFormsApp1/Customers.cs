using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1
{
    public class Customers
    {
        private const String SERVER = "localhost";
        private const String DATABASE = "managment";
        private const String UID = "root";
        private const String PASSWORD = "";
        private static MySqlConnection dbCo;

        public int CustNo { get; private set; }
        public String Name { get; private set; }
        public String Adress { get; private set; }
        public String Phone { get; private set; }
        public String Email { get; private set; }
        public String WebSite { get; private set; }

        private Customers(int c_no, String n, String a, String p, String e, String w)
        {
            CustNo = c_no;
            Name = n;
            Adress = a;
            Phone = p;
            Email = e;
            WebSite = w;
        }

        public static void InitializeDB()
        {
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            builder.Server = SERVER;
            builder.Database = DATABASE;
            builder.UserID = UID;
            builder.Password = PASSWORD;

            String conString = builder.ToString(); // ********

            builder = null;

            Console.WriteLine(conString); // ********

            dbCo = new MySqlConnection(conString);

            Application.ApplicationExit += (sender, arg) =>
            {
                if (dbCo != null)
                {
                    dbCo.Dispose();
                    dbCo = null;
                }
            };
        }

        public static List<Customers> GetCustomers()
        {
            List<Customers> customers = new List<Customers>();

            String query = "SELECT * FROM customers";

            MySqlCommand cmd = new MySqlCommand(query, dbCo);

            dbCo.Open();

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int c_no = (int)reader["customer_no"];
                String name = reader["customer_name"].ToString();
                String adress  = reader["adress1"].ToString();
                String phone = reader["phone"].ToString();
                String email = reader["email"].ToString();
                String website = reader["webSite"].ToString();

                Customers c = new Customers(c_no, name, adress, phone, email, website);

                customers.Add(c);
            }

            reader.Close();

            dbCo.Close();

            return customers;
        }

        public static Customers Add(int c_no, String n, String a, String p, String e, String w)
        {
            String query = string.Format("INSERT INTO customers(customer_no, customer_name, adress1, phone, email, website)" +
                                            " VALUE('{0}','{1}','{2}','{3}','{4}','{5}')", c_no, n, a, p, e, w);

            MySqlCommand cmd = new MySqlCommand(query, dbCo);

            dbCo.Open();

            cmd.ExecuteNonQuery();

            Customers customer = new Customers(c_no, n, a, p, e, w);

            dbCo.Close();

            return customer;
        }

        public void Delete()
        {
            String query = string.Format("DELETE FROM customers WHERE customer_no = {0}", CustNo);

            MySqlCommand cmd = new MySqlCommand(query, dbCo);

            dbCo.Open();
            cmd.ExecuteNonQuery();
            dbCo.Close();


        }

        public void Update(string n, string a, string p, string e, string w)
        {
            String query = string.Format("UPDATE customers SET" +
                                        " customer_name='{1}', adress1='{2}', phone='{3}', email='{4}', website='{5}'" +
                                        " WHERE customer_no={0}", CustNo, n, a, p, e, w);

            MySqlCommand cmd = new MySqlCommand(query, dbCo);

            dbCo.Open();
            cmd.ExecuteNonQuery();
            dbCo.Close();
        }
    }
}
