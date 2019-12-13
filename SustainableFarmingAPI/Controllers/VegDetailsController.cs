using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SustainableFarmingAPI.Data;
using SustainableFarmingAPI.Model;

namespace SustainableFarmingAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class VegDetailsController : ControllerBase
    {
        private readonly VegDetailContext _context;
        public VegDetailsController(VegDetailContext vegDetailContext)
        {
            _context = vegDetailContext;
        }
        [HttpGet]
        public ActionResult<List<VegDetail>> GetAll() =>
          _context.VegdetailInfo.ToList();
        [HttpGet("{id}")]
        public async Task<ActionResult<VegDetail>> GetById(long id)
        {
            var vegDetailContext = await _context.VegdetailInfo.FindAsync(id);
            if (vegDetailContext == null)
            {
                return NotFound();
            }
            return vegDetailContext;
        }



        [HttpPost]
        public async Task<ActionResult<VegDetail>> Create(VegDetail vegDetailContext)
        {
            _context.VegdetailInfo.Add(vegDetailContext);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = vegDetailContext.Id }, vegDetailContext);
        }



        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, VegDetail vegDetailContext)
        {
            if (id != vegDetailContext.Id)
            {
                return BadRequest();
            }

            _context.Entry(vegDetailContext).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }




        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var vegDetailContext = await _context.VegdetailInfo.FindAsync(id);

            if (vegDetailContext == null)
            {
                return NotFound();
            }

            _context.VegdetailInfo.Remove(vegDetailContext);
            await _context.SaveChangesAsync();

            return NoContent();
        }



        




    }
}