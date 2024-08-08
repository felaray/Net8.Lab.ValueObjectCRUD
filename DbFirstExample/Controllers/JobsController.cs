using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DbFirstExample.Data;
using DbFirstExample.Models;
using DbFirstExample.ValueObject;

namespace DbFirstExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        private readonly DbFirstExampleContext _context;

        public JobsController(DbFirstExampleContext context)
        {
            _context = context;
        }

        // GET: api/Jobs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Job>>> GetJob()
        {
            var result = await _context.Job.ToListAsync();
            return result;
        }

        [HttpPost]
        public async Task<ActionResult<Job>> PostJob(string title,int typeId,int workItemId)
        {
            var item = await _context.WorkItem.Include(c=>c.WorkType).FirstOrDefaultAsync(x => x.Id == workItemId && x.WorkTypeId == typeId);

            if (item == null) {
                return NotFound();
            }

            var job = new Job
            {
                Title = title,
                Item = new WorkItemValue(item.Id, item.Description, item.WorkTypeId, item.WorkType.Name)
            };
            _context.Job.Add(job);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetJob", new { id = job.Id }, job);
        }
    }
}
