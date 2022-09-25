using Domain.Contracts.DomainService;
using Domain.Entities;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.JsonPatch.Adapters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microservice.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemVentaController : ControllerBase
    {
        private readonly IDSItemVenta _dsItemVenta;

        private readonly ILogger<ItemVentaController> _logger;

        public ItemVentaController(ILogger<ItemVentaController> logger, IDSItemVenta dsItemVenta)
        {
            _logger = logger;
            _dsItemVenta = dsItemVenta;
        }

        [HttpGet]
        public async Task<IEnumerable<ItemVenta>> Get()
        {
            return await _dsItemVenta.Get();
        }

        [HttpGet("{id:int}")]
        public async Task<ItemVenta> Get(int id)
        {
            return (await _dsItemVenta.Get(b => b.Id == id)).FirstOrDefault();
        }

        [HttpPost]
        public async Task<ActionResult<ItemVenta>> Post(ItemVenta ItemVenta)
        {
            return await _dsItemVenta.Insert(ItemVenta);
        }

        [HttpPut]
        public ActionResult<ItemVenta> Put(ItemVenta ItemVenta)
        {
            return _dsItemVenta.Modify(ItemVenta);
        }

        [HttpDelete]
        public ActionResult Delete(ItemVenta ItemVenta)
        {
            _dsItemVenta.Delete(ItemVenta);

            return Ok();
        }

        [HttpPatch("{id:int}")]
        public async Task<ActionResult<ItemVenta>> JsonPatchForDynamic(int id, [FromBody] JsonPatchDocument patch)
        {
            var originalItemVenta = (await _dsItemVenta.Get(b => b.Id == id)).FirstOrDefault();

            if (originalItemVenta == null) return NotFound();

            patch.ApplyTo(originalItemVenta, (IObjectAdapter)ModelState);

            return _dsItemVenta.Modify(originalItemVenta);
        }
    }
}
