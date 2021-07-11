using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Text;

namespace Nibo.Util.IO
{
    public class Reader: IReader
    {
        public string ReadFile(IFormFile file)
        {
            var result = new StringBuilder();
            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                while (reader.Peek() >= 0)
                    result.AppendLine(reader.ReadLine());
            }
            return result.ToString();
        }
    }
}
