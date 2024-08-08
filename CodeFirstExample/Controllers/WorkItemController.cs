using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CodeFirstExample.Services;

namespace CodeFirstExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkItemController : ControllerBase
    {
        private readonly IWorkItemService _workItemService;

        public WorkItemController(IWorkItemService workItemService)
        {
            _workItemService = workItemService;
        }

        [HttpGet]
        public async Task<IActionResult> GetWorkItems()
        {
            try
            {
                var workItems = await _workItemService.GetWorkItems();
                return Ok(workItems);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostWorkItem(string description, int workTypeId)
        {
            try
            {
                await _workItemService.PostWorkItem(description, workTypeId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutWorkItem(int id, string description, int workTypeId)
        {
            try
            {
                await _workItemService.PutWorkItem(id, description, workTypeId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
