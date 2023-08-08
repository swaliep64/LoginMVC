using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LoginMVC.Models;
using System.Data.SqlClient;                   //This is mandatory to use in controller class //

namespace LoginMVC.Controllers
{
    public class AccountController : Controller
    {
        SqlConnection con = new SqlConnection(); //creating object for connection string to connect sql
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;

        // GET: Account
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        void ConnectionString()
        {
            con.ConnectionString = "data source=localhost\\SQLEXPRESS; database=test1; integrated security=True;";


        }



        [HttpPost]
        public ActionResult Verify(Account acc)   //Creating object of Model Class "Account" 
        
        {
            ConnectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "select * from users where username= '"+acc.Name+"' and password='"+acc.Password+"' ";
            dr = com.ExecuteReader();
            if (dr.Read())
            {
                con.Close();
                return View("Create");

            }

            else
            {
                con.Close();
                return View("Error");

            }
            
            
        }
    }
}