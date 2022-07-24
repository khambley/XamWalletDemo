using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using XamWalletDemo;

namespace XamWalletDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly DataContext _context;

        public MembersController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Members
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MemberInfo>>> GetMemberInfo()
        {
            return await _context.MemberInfo.ToListAsync();
        }

        // GET: api/Members/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MemberInfo>> GetMemberInfo(int id)
        {
            var memberInfo = await _context.MemberInfo.FindAsync(id);

            if (memberInfo == null)
            {
                return NotFound();
            }

            return memberInfo;
        }

        // PUT: api/Members/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMemberInfo(int id, MemberInfo memberInfo)
        {
            if (id != memberInfo.Id)
            {
                return BadRequest();
            }

            _context.Entry(memberInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MemberInfoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Members
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<MemberInfo>> PostMemberInfo(MemberInfo memberInfo)
        {
            _context.MemberInfo.Add(memberInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMemberInfo", new { id = memberInfo.Id }, memberInfo);
        }

        // DELETE: api/Members/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MemberInfo>> DeleteMemberInfo(int id)
        {
            var memberInfo = await _context.MemberInfo.FindAsync(id);
            if (memberInfo == null)
            {
                return NotFound();
            }

            _context.MemberInfo.Remove(memberInfo);
            await _context.SaveChangesAsync();

            return memberInfo;
        }

        private bool MemberInfoExists(int id)
        {
            return _context.MemberInfo.Any(e => e.Id == id);
        }
    }
}
