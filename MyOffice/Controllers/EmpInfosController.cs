using MyOffice.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Azure.Core;

namespace MyOffice.Controllers
{
    [Route("api/empinfo")]
    [ApiController]
    public class EmpInfosController : ControllerBase
    {
        private readonly EmpInfoContext _empInfoContext;
        public EmpInfosController(EmpInfoContext empInfoContext)
        {
            _empInfoContext = empInfoContext;
        }

        // Get : /api/empinfo/list
        [HttpGet("list")]
        public async Task<ActionResult<IEnumerable<EmpInfo>>> GetEmpInfos()
        {
            if (_empInfoContext == null)
            {
                return NotFound();
            }
            return await _empInfoContext.EmpInfos.ToListAsync();
        }

        // Get : /api/empinfo/details/{id}
        [HttpGet("details/{id:int}")]
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

        // Post : /api/empinfo/create
        [HttpPost("create")]
        public async Task<ActionResult<EmpInfo>> PostEmpInfo([FromBody] EmpInfo empInfo)
        {
            if (empInfo == null)
            {
                return BadRequest("Invalid input.");
            }
            _empInfoContext.EmpInfos.Add(empInfo);
            await _empInfoContext.SaveChangesAsync();
            //return Ok(empInfo);
            return Ok(new { code = 200, message = "Employee info created successfully." });
        }

        // Put : /api/empinfo/update/{id}
        [HttpPut("update/{id:int}")]
        public async Task<IActionResult> PutEmpInfo(int id, [FromBody] EmpInfo empInfo)
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
            //return NoContent();
            return Ok(new { code = 200, message = "Employee info updated successfully." });
        }

        private bool EmpInfoExists(long id)
        {
            return (_empInfoContext.EmpInfos?.Any(empinfo => empinfo.Id == id)).GetValueOrDefault();
        }

        // Delete : /api/empinfo/delete/{id}
        [HttpDelete("delete/{id:int}")]
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
            //return NoContent();
            return Ok(new { code = 200, message = "Employee info deleted successfully." });
        }
    }
}