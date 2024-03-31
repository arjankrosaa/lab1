using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace RentalApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private static List<User> users = new List<User>
            {
                new User
                {
                    Id = 1,
                    Name = "arjan",
                    Age = 19,
                    City = "Ferizaj"
                },
                new User
                {
                    Id = 2,
                    Name = "ermal",
                    Age = 20,
                    City = "Ferizaj"
                }
            };

        [HttpGet]
        [Route("getUsers")]
        public ActionResult<IEnumerable<User>> GetUser()
        {
            

            return Ok(users); // Return the list of users
        }





        [HttpGet]
        [Route("getUser")]
        public ActionResult<IEnumerable<User>> GetUser(int id)
        {
            var user = users.Find(x => x.Id == id);
            if (user == null)
                return BadRequest("No user found!");


            return Ok(users); //return by id
        }





        [HttpPost]
        [Route("addUser")]
        public ActionResult<IEnumerable<User>> AddUser(User request)
        {
            users.Add(request);

            return Ok(users); //add
        }





        [HttpPut]
        [Route("uptadeUser")]
        public ActionResult<IEnumerable<User>> UptadeUser(User request)
        {
            var user = users.Find(x => x.Id == request.Id);
            if (user == null)
                return BadRequest("No user found!");
           user.Name = request.Name;
            user.Age = request.Age;
            user.City = request.City;

            return Ok(users); //uptade
        }




        [HttpDelete]
        [Route("deleteUser")]
        public ActionResult<IEnumerable<User>> DeleteUser(int id)
        {
            var user = users.Find(x => x.Id == id);
            if (user == null)
                return BadRequest("No user found!");

           users.Remove(user);
            return Ok(users); //uptade
        }



    }
}