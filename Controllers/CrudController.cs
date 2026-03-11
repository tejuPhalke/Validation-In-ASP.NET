using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using validationmethod.Models;

namespace validationmethod.Controllers
{
    public class CrudController : Controller
    {
        // GET: Crud
        public ActionResult UserForm()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UserForm(User u1)
        {
            string path = "Data Source=DESKTOP-Q7QAKP8\\SQLEXPRESS;Initial Catalog=HrManagement;Integrated Security=True";

            SqlConnection con = new SqlConnection(path);
            con.Open();
            string query = "Insert into Usertable values(" + u1.Id + ",'" + u1.name + "','" + u1.email + "','" + u1.password + "','" + u1.Cpassword + "','" + u1.phone + "')";
            SqlCommand cmd = new SqlCommand(query, con);

            cmd.ExecuteNonQuery();

            return RedirectToAction("ShowData");
        }

        public ActionResult ShowData()
        {
            string path = "Data Source=DESKTOP-Q7QAKP8\\SQLEXPRESS;Initial Catalog=HrManagement;Integrated Security=True";
            SqlConnection con = new SqlConnection(path);
            con.Open();
            string query = "SELECT Id, Name, Email, Password, Cpassword, Mobileno FROM Usertable";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            List<User> userList = new List<User>();
            while (reader.Read())
            {
                User u1 = new User();
                u1.Id = Convert.ToInt32(reader["Id"]);
                u1.name = reader["Name"].ToString();
                u1.email = reader["Email"].ToString();
                u1.password = reader["Password"].ToString();
                u1.Cpassword = reader["Cpassword"].ToString();
                u1.phone = reader["Mobileno"].ToString();
                userList.Add(u1);
            }

            return View(userList);
        }

        public ActionResult Edit(int Id)
        {
            string path = "Data Source=DESKTOP-Q7QAKP8\\SQLEXPRESS;Initial Catalog=HrManagement;Integrated Security=True";
            SqlConnection con = new SqlConnection(path);
            con.Open();
            string query = "Select *from Usertable where id=" + Id + " ";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();

            User u1 = new User();
            if (reader.Read())
            {
                u1.Id = Convert.ToInt32(reader["Id"]);
                u1.name = reader["Name"].ToString();
                u1.email = reader["Email"].ToString();
                u1.password = reader["Password"].ToString();
                u1.Cpassword = reader["Cpassword"].ToString();
                u1.phone = reader["Mobileno"].ToString();
            }
            return View(u1);
        }
        [HttpPost]
        public ActionResult Update(User u1)
        {
            string path = "Data Source=DESKTOP-Q7QAKP8\\SQLEXPRESS;Initial Catalog=HrManagement;Integrated Security=True";
            SqlConnection con = new SqlConnection(path);
            con.Open();
            string query = "Update Usertable set Name='" + u1.name + "',Email='" + u1.email + "',Password='" + u1.password + "',Cpassword='" + u1.Cpassword + "',Mobileno='" + u1.phone + "' where Id=" + u1.Id + " ";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            return RedirectToAction("ShowData");
        }

        public ActionResult Delete(int Id)
        {
            string path = "Data Source=DESKTOP-Q7QAKP8\\SQLEXPRESS;Initial Catalog=HrManagement;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(path))
            {
                string query = "DELETE FROM Usertable WHERE Id='"+Id+"'";
                SqlCommand cmd = new SqlCommand(query, con);
              

                con.Open();
                cmd.ExecuteNonQuery();
            }

            return RedirectToAction("ShowData");
        }
    }
}