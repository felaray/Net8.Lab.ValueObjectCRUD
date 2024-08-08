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
        public async Task<IActionResult> GetJob()
        {
            var result = await _context.Job.Select(c => new
            {
                c.Id,
                c.Title,
                item = new
                {
                    c.ItemWorkTypeId,
                    c.ItemWorkTypeName,
                    c.ItemWorkItemId,
                    c.ItemDescription,
                }
            }).ToListAsync();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Job>> PostJob(string title, int typeId, int workItemId)
        {
            var item = await _context.WorkItem.Include(c => c.WorkType).FirstOrDefaultAsync(x => x.Id == workItemId && x.WorkTypeId == typeId);

            if (item == null)
            {
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

        [HttpPut("{id}")]
        public async Task<IActionResult> PutJob(int id, string title, int typeId, int workItemId)
        {
            var job = await _context.Job.FindAsync(id);
            if (job == null)
            {
                return NotFound($"Job with id {id} not found");
            }

            var item = await _context.WorkItem.Include(c => c.WorkType).FirstOrDefaultAsync(x => x.Id == workItemId && x.WorkTypeId == typeId);

            if (item == null)
            {
                return NotFound($"WorkItem with id {workItemId} and typeId {typeId} not found");
            }

            job.Title = title;
            job.Item = new WorkItemValue(item.Id, item.Description, item.WorkTypeId, item.WorkType.Name);

            try
            {
                await _context.SaveChangesAsync();
                var result = await _context.Job.Select(c => new
                {
                    c.Id,
                    c.Title,
                    item = new
                    {
                        c.ItemWorkTypeId,
                        c.ItemWorkTypeName,
                        c.ItemWorkItemId,
                        c.ItemDescription,
                    }
                }).SingleAsync(x => x.Id == id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }
    }
}
