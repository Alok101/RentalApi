using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Rental.API.Infrastructures;
using Rental.API.Model;
using Rental.API.ViewModels;

namespace Rental.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AccountController : ControllerBase
    {
        private readonly ILogger<AccountController> _logger;
        private readonly RentalDbContext context;
        public AccountController(RentalDbContext rentalDbContext,ILogger<AccountController> logger)
        {
            _logger = logger;
            context = rentalDbContext;
        }

        // GET: api/Account
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Account/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Account
        [HttpPost]
        [Route("Register")]
        public async void Registration([FromBody] UserViewModel userModel)
        {
            if (userModel != null)
            {
                Users user = new Users
                {
                    SsouserId = userModel.SsouserId,
                    FirstName = userModel.FirstName,
                    LastName = userModel.LastName,
                    Email = userModel.Email,
                    PhoneNumber = userModel.PhoneNumber,
                    CreatedBy = userModel.SsouserId,
                    CreatedOn = userModel.CreatedOn,
                    Status = userModel.Status
                };
                context.Users.Add(user);
               await context.SaveChangesAsync();
            }
        }

        // PUT: api/Account/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
