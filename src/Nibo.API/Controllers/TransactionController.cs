using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nibo.Application.Interfaces;
using Nibo.Domain.DTO;
using Nibo.Domain.Entity;
using Nibo.Util.Parser;
using Nibo.Util.Parser.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nibo.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;
        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpPost]
        public async Task<bool> Import([FromForm(Name = "files")] List<IFormFile> files)
        {
            DocumentParser parser = new DocumentParser();

            IEnumerable<Util.Parser.Models.TransactionBank> transactions = files.SelectMany(f => parser.Parse(f));

            return await _transactionService.ImportAsync(transactions);
        }

        [HttpGet]
        public async Task<IEnumerable<TransactionDTO>> GetAll()
        {
            return await _transactionService.GetAllAsync();
        }
    }
}
