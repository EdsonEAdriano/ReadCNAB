using Microsoft.AspNetCore.Mvc;
using ReadCNAB.Models;
using ReadCNAB.Repository;
using ReadCNAB.Repository.Transaction;

namespace ReadCNAB.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CNABController : ControllerBase
    {
        private ICNABRepository _cnabRepository;
        private ITranRepository _tranRepository;

        public CNABController(ICNABRepository cnabRepository, ITranRepository tranRepository)
        {
            _cnabRepository = cnabRepository;
            _tranRepository = tranRepository;
        }


        [HttpPost]
        public async Task<IActionResult> InsertCNAB(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("Nenhum arquivo foi enviado.");
            }

            if (!Path.GetFileName(file.FileName).Contains(".txt"))
            {
                return BadRequest("Arquivo não permitido.");
            }

            try
            {

                using (var reader = new StreamReader(file.OpenReadStream()))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = await reader.ReadLineAsync();
                        var record = ParseCNABRecord(line);
                        if (record != null)
                        {
                            _cnabRepository.Add(record);
                        }
                    }
                }

                return Ok("Transações salvas com sucesso!");
            }
            catch (Exception e)
            {
                Console.WriteLine($"ERROR MESSAGE: {e.Message}");
                return BadRequest($"Erro gravar informações do arquivo. ERROR MESSAGE: {e.Message}");
            }

        }


        private CNABModel ParseCNABRecord(string line)
        {
            int tranType = int.Parse(line.Substring(0, 1));

            // Get date
            string year = line.Substring(1, 4);
            string month = line.Substring(5, 2);
            string day = line.Substring(7, 2);

            // Format date
            string dateFormated = year + "-" + month + "-" + day;
            DateOnly date = DateOnly.Parse(dateFormated);

            double value = double.Parse(line.Substring(9, 10)) / 100;
            long cpf = long.Parse(line.Substring(19, 11));
            string card = line.Substring(30, 12);

            // Format time
            string hour = line.Substring(42, 2);
            string min = line.Substring(44, 2);
            string sec = line.Substring(46, 2);

            string formatTime = hour + ":" + min + ":" + sec; 

            TimeOnly time = TimeOnly.Parse(formatTime);
            string ownerName = line.Substring(48, 14);
            string storeName = line.Substring(62);

            CNABModel record = new CNABModel();
            record.TranType = tranType;
            record.Date = date;
            record.Value = value;
            record.CPF = cpf;
            record.Card = card;
            record.Time = time;
            record.OwnerName = ownerName;
            record.StoreName = storeName;

            return record;
        }

        [HttpGet("GetTransaction")]
        public IActionResult GetTransaction()
        {
            var transactions = _cnabRepository.Get();

            return Ok(transactions);
        }

        [HttpGet("GetTranTypes")]
        public IActionResult GetTranTypes()
        {
            var transactions = _tranRepository.Get();

            return Ok(transactions);
        }
    }
}
