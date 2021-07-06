using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PhoneRestApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



/*
var users = context.PhoneItems.Skip((phoneParameter.PageNumber - 1) * phoneParameter.PageSize)
                .Take(phoneParameter.PageSize)
                .ToList();





 */
namespace PhoneRestApi.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class PhoneController : ControllerBase
    {

        private readonly ILogger<PhoneController> _logger;
        private readonly PhoneContext context = new PhoneContext();

        public PhoneController(ILogger<PhoneController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public PhoneDTO GetAll([FromQuery]PhoneParameter phoneParameter)
        {
            var empObj = new PhoneDTO();
            var users = Helpers.PagedList<Phone>.ToPagedList(context.PhoneItems,
                phoneParameter.PageNumber,
                phoneParameter.PageSize);
            empObj.Phones = users;
            empObj.TotalCount = users.TotalCount;
            var metadata = new
            {
                users.TotalCount,
                users.PageSize,
                users.CurrentPage,
                users.TotalPages,
                users.HasNext,
                users.HasPrevious
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

            _logger.LogInformation($"Returned {users.TotalCount} owners from database.");

            return empObj;
            
        }

        [HttpGet("{ID}")]
        public Phone Get(int ID)
        {
            
            var users = context.PhoneItems.Find(ID);
            return users;
        }
        [HttpPost]
        public Phone Create(Phone newPhone)
        {

            var phone = context.Add(new Phone
            {
                FirstName = newPhone.FirstName,
                LastName = newPhone.LastName,
                PhoneNumber = newPhone.PhoneNumber
            });
            context.SaveChanges();
            return phone.Entity;
        }

        [HttpDelete]
        public ActionResult<Phone> Delete(int delPhone)
        {

            var phone = context.PhoneItems.Find(delPhone);
            if(phone != null)
            {
                context.PhoneItems.Remove(phone);
            } else
            {
               return NotFound();
            }
            context.SaveChanges();
            return Ok();
        }

        [HttpPatch]
        public ActionResult<Phone> Patch(Phone newPhone)
        {
            var phone = context.PhoneItems.Find(newPhone.ID);
            if (phone != null)
            {
                phone.FirstName = newPhone.FirstName;
                phone.LastName = newPhone.LastName;
                phone.PhoneNumber = newPhone.PhoneNumber;
            }
            else
            {
                return NotFound();
            }
            context.SaveChanges();
            return Ok();
        }
    }
}
