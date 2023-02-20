using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers;

public class ActivitiesController : BaseApiController
{
    private readonly DataContext _context;
    
    public ActivitiesController(DataContext context)
    {
        _context = context;
    }
    
    [HttpGet] // GET api/Activity
    public async Task<ActionResult<List<Activity>>> Get()
    {
        return Ok(await _context.Activities.ToListAsync());
    }

    [HttpGet("{id:guid}")] // GET api/Activity/5
    public async Task<ActionResult<Activity>> Get(Guid id)
    {
        return await _context.Activities.FindAsync(id);
    }

}