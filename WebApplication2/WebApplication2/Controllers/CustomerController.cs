using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        CustomerDB1Context db = new CustomerDB1Context();
        [HttpGet]


        public IEnumerable<Tb1> get()
        {
            return db.Tb1s;
        }
        [HttpPost]
        public IActionResult post(Tb1 customer)
        {
            db.Tb1s.Add(customer);
            db.SaveChanges();
            return Ok(new { status = "your record is added suceessfully" });
        }
        [HttpPut]
        public IActionResult put(Tb1 customer)
        {
            db.Tb1s.Update(customer);
            db.SaveChanges();
            return Ok(new { status = "your record is updated suceessfully" });
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var customer = db.Tb1s.Where(x => x.Id == id).FirstOrDefault();
            db.Tb1s.Remove(customer);
            db.SaveChanges();
            return Ok(new { status = "your record is deleted suceessfully" });
        }
    }
}
