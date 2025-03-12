using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SvarkaGameApp.Shared.Interfaces;
using SvarkaGameApp.Shared.Models;

namespace SvarkaGameApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TableController : ControllerBase
    {
        private readonly ITableService _tableService;

        public TableController(ITableService tableService)
        {
            _tableService = tableService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTables()
        {
            var tables = await _tableService.GetAllTablesAsync();
            return Ok(tables);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTable([FromBody] TableCreateRequest request)
        {
            var newTable = await _tableService.CreateTableAsync(request.Name, request.IsPrivate);
            return Ok(newTable);
        }

        [HttpPost("/api/tables/{tableId}/join")]
        public async Task<IActionResult> JoinTable([FromBody] JoinTableRequest request)
        {
            var success = await _tableService.JoinTableAsync(request.TableId, request.PlayerName);
            if (success)
                return Ok();
            else
                return BadRequest("Failed to join table.");
        }
    }

    public class TableCreateRequest
    {
        public string Name { get; set; }
        public bool IsPrivate { get; set; }
    }

    public class JoinTableRequest
    {
        public string TableId { get; set; }
        public string PlayerName { get; set; }
    }
}
