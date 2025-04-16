using MyOffice.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Azure.Core;

namespace MyOffice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpInfosController : ControllerBase
    {
        private readonly EmpInfoContext _empInfoContext;
        public EmpInfosController(EmpInfoContext empInfoContext)
        {
            _empInfoContext = empInfoContext;
        }

        // Get : api/EmpInfos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmpInfo>>> GetEmpInfos()
        {
            if (_empInfoContext == null)
            {
                return NotFound();
            }
            return await _empInfoContext.EmpInfos.ToListAsync();
        }

        // Get : api/EmpInfos/2
        [HttpGet("Id")]
        public async Task<ActionResult<EmpInfo>> GetEmpInfo(int id)
        {
            if (_empInfoContext == null)
            {
                return NotFound();
            }
            var empinfo = await _empInfoContext.EmpInfos.FindAsync(id);
            if (empinfo == null)
            {
                return NotFound();
            }
            return empinfo;
        }

        // Post : api/EmpInfos
        [HttpPost]
        public async Task<ActionResult<EmpInfo>> PostEmpInfo(EmpInfo empInfo)
        {
            _empInfoContext.EmpInfos.Add(empInfo);
            await _empInfoContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetEmpInfo), new { id = empInfo.Id });
        }

        // Put : api/EmpInfos/2
        [HttpPut]
        public async Task<ActionResult<EmpInfo>> PutEmpInfo(int id, EmpInfo empInfo)
        {
            if (id != empInfo.Id)
            {
                return BadRequest();
            }
            _empInfoContext.Entry(empInfo).State = EntityState.Modified;
            try
            {
                await _empInfoContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpInfoExists(id)) { return NotFound(); }
                else { throw; }
            }
            return NoContent();
        }

        private bool EmpInfoExists(long id)
        {
            return (_empInfoContext.EmpInfos?.Any(empinfo => empinfo.Id == id)).GetValueOrDefault();
        }

        // Delete : api/EmpInfos/2
        [HttpDelete("{id}")]
        public async Task<ActionResult<EmpInfo>> DeleteEmpInfo(int id)
        {
            if (_empInfoContext.EmpInfos is null)
            {
                return NotFound();
            }
            var empinfo = await _empInfoContext.EmpInfos.FindAsync(id);
            if (empinfo is null)
            {
                return NotFound();
            }
            _empInfoContext.EmpInfos.Remove(empinfo);
            await _empInfoContext.SaveChangesAsync();
            return NoContent();
        }
    }
}
