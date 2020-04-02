using System;
using System.Threading.Tasks;
using DatingApp.API.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ValuesController: ControllerBase
    {
        private readonly DataContext _dbContext;

        public ValuesController(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        [AllowAnonymous]
        //GET api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var values = await _dbContext.Values.ToListAsync();
            return Ok(values);

        }

        [AllowAnonymous]
        //GET api/values/2
        [HttpGet("{id}")]
        public async Task<IActionResult> GetValue(int id)
        {
            var value = await _dbContext.Values.FirstOrDefaultAsync(x=>x.Id==id);
            if (value==null)
            {
                return NotFound(@"ID = {"+Convert.ToString(id)+"} is not found" );
            }
            return Ok(value);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}