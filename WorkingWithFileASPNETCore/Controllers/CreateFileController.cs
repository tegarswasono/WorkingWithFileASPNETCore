using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkingWithFileASPNETCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreateFileController : ControllerBase
    {
        private readonly IWebHostEnvironment _env;
        public CreateFileController(IWebHostEnvironment env)
        {
            _env = env;
        }

        [HttpGet]
        public ActionResult Get()
        {
            using (MemoryStream stream = new MemoryStream())
            {
                StreamWriter objstreamwriter = new StreamWriter(stream);
                objstreamwriter.Write("This is the content");
                objstreamwriter.Flush();
                objstreamwriter.Close();
                return File(stream.ToArray(), "text/plain", "file.txt");
            }
        }

        [HttpGet("SaveOnServer")]
        public ActionResult SaveOnServer()
        {
            var path = Path.Combine(_env.ContentRootPath, @"Files\" + "MyTest.txt");
            using (FileStream fs = System.IO.File.Create(path))
            {
                byte[] content = new UTF8Encoding(true).GetBytes("Hello World");
                fs.Write(content, 0, content.Length);
            }
            return Ok("Sukses Bosku Coba Lihat di Folder Server");
        }
    }
}
