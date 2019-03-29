using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webcoreapi.Models;

namespace webcoreapi.Controllers
{
    [Route("api/[controller]")]
    public class AllStudentsController : Controller
    {
        [HttpGet]
        public JsonResult GetAllStudent()
        {
           
            return new JsonResult(StudentDataStore.Current.Students);

            var temp = new JsonResult(StudentDataStore.Current.Students);
            temp.StatusCode = 200;
            return temp;
        }

        [HttpGet("{id}")]
        public IActionResult GetStudent(int id)
        {


             var returnstudent = StudentDataStore.Current.Students.FirstOrDefault(x => x.id == id);
            if(returnstudent == null)
            {
                return NotFound();
            }
            return Ok(returnstudent);

        }
        [HttpPost]
        public IActionResult PostStudent([FromBody] Student item)
        {
            StudentDataStore.Current.Students.Add(item);
            return CreatedAtRoute("GetStudent", new { id = item.id }, item);
        }
        [HttpPut("{id}")]
        public IActionResult PutStudent(int id , [FromBody] Student item)
        {
            if(item == null)
            {
                return BadRequest();
            }
            if(item.Name==null & item.Address == null)
            {
                return BadRequest();
                
            }
            var data = StudentDataStore.Current.Students.FirstOrDefault(i => i.id == id);
            if (data == null)
            {
                return NotFound();
            }
            data.Name = item.Name;
            data.Address = item.Address;
            data.Number = item.Number;
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            var data = StudentDataStore.Current.Students.FirstOrDefault(i => i.id == id);
            if (data == null)
            {
                return NotFound();
            }
            StudentDataStore.Current.Students.Remove(data);
            return NoContent();

        }

    }
}

