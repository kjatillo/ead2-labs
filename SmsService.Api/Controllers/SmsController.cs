using Microsoft.AspNetCore.Mvc;
using SmsService.Api.Entities;

namespace SmsService.Api.Controllers;

[Produces("application/json")]
[Route("api/[controller]")]
[ApiController]
public class SmsController : ControllerBase
{
    private const string LOG_FILE = "log.txt";

    [HttpPost]
    [ProducesResponseType(typeof(ShortMessage), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult SendMessage([FromBody] ShortMessage sms)
    {
        if (ModelState.IsValid)
        {
            Log($"Receiver: {sms.Receiver} | Sender: {sms.Sender} | Message: {sms.Message}");

            return Ok(new { Status = "Success", Message = "Message sent!" });
        }

        return BadRequest();
    }

    private static void Log(string logDetail)
    {
        using (StreamWriter stream = new StreamWriter(LOG_FILE, append: true))
        {
            stream.Write(logDetail);
            stream.WriteLine($" | Timestamp: {DateTime.Now}");
            stream.Close();
        }
    }
}
