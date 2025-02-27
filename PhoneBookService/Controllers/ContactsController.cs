using Microsoft.AspNetCore.Mvc;
using PhoneBookService.Entities;

namespace PhoneBookService.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private static readonly List<Contact> _phoneBook = new List<Contact>
        {
            new Contact
            {
                PhoneNumber = "01-1111111",
                Name = "John Doe",
                Address = "No 1 Bev Hills"
            },
            new Contact
            {
                PhoneNumber = "01-2222222",
                Name = "Jane Doe",
                Address = "No 2 Bev Hills"
            },
            new Contact
            {
                PhoneNumber = "01-3333333",
                Name = "Joe Soap",
                Address = "No 3 Bev Hills"
            },
        };

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Contact>), StatusCodes.Status200OK)]
        public IEnumerable<Contact> GetContacts()
        {
            var contacts = _phoneBook.OrderBy(c => c.Name);

            return contacts;
        }

        [HttpGet("number/{phoneNumber}")]
        [ProducesResponseType(typeof(Contact), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetContactByPhoneNumber(string phoneNumber)
        {
            var contact = _phoneBook
                .FirstOrDefault(c => c.PhoneNumber.ToUpper() == phoneNumber.ToUpper());

            if (contact == null)
            {
                return NotFound();
            }

            return Ok(contact);
        }

        [HttpGet("name/{name}")]
        [ProducesResponseType(typeof(Contact), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IEnumerable<Contact> GetContactsByName(string name)
        {
            var contacts = _phoneBook
                .Where(c => c.Name.ToUpper() == name.ToUpper());

            return contacts;
        }
    }
}
