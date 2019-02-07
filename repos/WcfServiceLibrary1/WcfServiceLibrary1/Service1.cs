using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace WcfServiceLibrary1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-VKTSVTO; Database=InventoryMVC;User id=sa; Password=123");
        public List<Student> GetData()
        {
            List<Student> li = new List<Student>();
            con.Open();
            SqlCommand sc= new SqlCommand("Select * from Sales", con);
            SqlDataReader sa = sc.ExecuteReader();
            
            while (sa.Read())
            {
                Student std= new Student();
                std.Id =Convert.ToInt32(sa["Id"].ToString());
                std.Name= sa["Name"].ToString();
                std.Quantity = sa["Quantity"].ToString();
                li.Add(std);
            }
            con.Close();


            return li;
        }

        public string insert(int Id,string Name, string Status, string category, int price, int cid,int Quantity)
        {
            SqlCommand sc = new SqlCommand("insert into Sales values("+Id+",'"+Name+"','"+category+"','"+Quantity+"','"+price+"','"+cid+"')", con);
            con.Open();
           var a = sc.ExecuteNonQuery();
            con.Close();
            return a.ToString();
            //throw new NotImplementedException();
        }

        

            }
}
