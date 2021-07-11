using Microsoft.AspNetCore.Http;

namespace Nibo.Util.IO
{
    public interface IReader
    {
        string ReadFile(IFormFile file);
    }
}
