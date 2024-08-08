using Microsoft.AspNetCore.Mvc;
using CodeFirstExample.Data;
using CodeFirstExample.Services;

namespace CodeFirstExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        private readonly CodeFirstExampleContext _context;
        private readonly IJobServices _jobServices;

        public JobsController(CodeFirstExampleContext context, IJobServices jobServices)
        {
            _context = context;
            _jobServices = jobServices;
        }

        // POST: api/Job
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostJob(string title, int? workItemId)
        {
            try
            {
                await _jobServices.PostJob(title, workItemId);
                var result = await _jobServices.GetLast();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutJob(int id, int? workItemId)
        {
            try
            {
                await _jobServices.PutJob(id, workItemId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetJobs()
        {
            try
            {
                var jobs = await _jobServices.GetJobs();
                return Ok(jobs);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


    }
}
