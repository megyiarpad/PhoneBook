using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PhoneRestApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public IEnumerable<Phone> GetAll()
        {
            
            var users = context.PhoneItems;
            return users;
        }

        [HttpGet("{ID}")]
        public Phone Get(int ID)
        {
            
            var users = context.PhoneItems.Find(ID);
            return users;
        }
        [HttpPost]
        public Phone Create(PhoneDTO newPhone)
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
