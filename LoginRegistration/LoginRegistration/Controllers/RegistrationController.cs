using LoginRegistration.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace LoginRegistration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
    public class RegistrationController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public RegistrationController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpPost]
        [Route("registration")]
        public string registration(Registration registration)
        {

            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("UserCon").ToString());
            SqlCommand cmd = new SqlCommand("INSERT INTO Registration(FirstName,LastName,Email,UserName,Password,IsActive) VALUES ('" + registration.FirstName + "','" + registration.LastName + "', '" + registration.Email + ",'" + registration.UserName + "','" + registration.Password + "','" + registration.IsActive + "')", con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i > 0)
            {
                return "Registered Successfully";
            }
            else
            {
                return " Error";
            }

        }

        private string GetDebuggerDisplay()
        {
            return ToString();
        }
    }
}
    

    /*[HttpPost]
    [Route("login")]
    public string Login (Registration registration)
    {



        object _configuration = null;
        SqlConnection con = new SqlConnection(_configuration.GetConnectionString("UserCon").ToString());
        SqlDataAdapter da = new SqlDataAdapter("SELECT*FROM Registration WHERE UserName='" + registration.UserName + "' AND Password ='" + registration.Password + "' AND IsActive=1", con);
        DataTable dt = new DataTable();
        da.Fill(dt);
        if(dt.Rows.Count>0)
        {
            return "login Succesfully ";
        }
        else
        {
            return "Invalid User";
        }
    }
       
    

}
    */