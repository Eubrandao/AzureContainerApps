using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Queue;
using ProductPurchaseApi.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace ProductPurchaseApi.Controllers
{
    [ApiController]
    [Route("api/purchases")]
    public class ProductPurchaseController : ControllerBase
    {
        private readonly CloudQueueClient _queueClient;

        public ProductPurchaseController()
        {
         
            var storageAccount = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=lab2containeres;AccountKey=PtWdk1v698ZRyNBzplg17wGkZnHEP4YiICvuY94yAOGiGCHSXaw10FCwPUlMOLRngU5PDi7nJ/av+ASttUUNCA==;EndpointSuffix=core.windows.net");
            _queueClient = storageAccount.CreateCloudQueueClient();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductPurchase([FromBody] ProductPurchase purchase)
        {
            // Validação manual dos dados
            if (string.IsNullOrWhiteSpace(purchase.Produto))
            {
                return BadRequest("ProductName é obrigatório.");
            }

            if (purchase.Valor <= 0)
            {
                return BadRequest("Valor deve ser maior que zero.");
            }

            if (purchase.Quantidade <= 0)
            {
                return BadRequest("Quantidade deve ser maior que zero.");
            }

            //Criando os produtos na fila do Azure Storage
            var queue = _queueClient.GetQueueReference("product");

          
            var message = new CloudQueueMessage(Newtonsoft.Json.JsonConvert.SerializeObject(purchase));

            
            await queue.AddMessageAsync(message);
            return CreatedAtAction(nameof(GetProductPurchase), new { id = purchase.Data }, purchase);

        }

        [HttpGet("{id}")]
        public IActionResult GetProductPurchase(DateTime id)
        {
           //Apenas para demonstração
            return Ok($"Compra com ID {id} não encontrada.");
        }
    }
}
