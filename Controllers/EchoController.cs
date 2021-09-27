using System.IO;
using System.Text;
using Microsoft.AspNetCore.Mvc;

namespace EchoServer.Controllers
{
    [Route("")] // Match if nothing
    [Route("{**:regex(\\w)}")] // Match if anything 
    public class EchoController : ControllerBase
    {
        public IActionResult Echo()
        {
            // Method, Path and Protocol
            var builder = new StringBuilder();
            builder.Append(Request.Method).Append(' '); // Method
            builder.Append(Request.Path.Value); // Path
            if (Request.QueryString.HasValue)
                builder.Append(Request.QueryString);    // Query 
            builder.Append(' ');
            builder.Append(Request.Protocol); // Protocol

            // Headers
            foreach (var (key, value) in Request.Headers)
            {
                builder.AppendLine();
                builder.Append(key).Append(' ');
                builder.Append(value);
            }

            // Body
            var body = new StreamReader(Request.Body).ReadToEndAsync().Result;
            if (!string.IsNullOrWhiteSpace(body)) // Don't print if empty
            {
                builder.AppendLine().AppendLine();
                builder.Append(body);
            }

            return Ok(builder.ToString());
        }
    }
}