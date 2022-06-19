﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hotels.DataAccess.Data;
using Hotels.Models.Models;
using Hotels.Models.Dtos.City;
using AutoMapper;

namespace Hotels.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CitiesController : ControllerBase
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public CitiesController(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    // GET: api/Cities
    [HttpGet]
    public async Task<ActionResult<IEnumerable<City>>> GetCities()
    {
        if (_context.Cities is null)
        {
            return NotFound();
        }
        return await _context.Cities.ToListAsync();
    }

    // GET: api/Cities/5
    [HttpGet("{id}")]
    public async Task<ActionResult<City>> GetCity(int id)
    {
        if (_context.Cities is null)
        {
            return NotFound();
        }
        var city = await _context.Cities.FindAsync(id);

        if (city is null)
        {
            return NotFound();
        }

        return city;
    }

    // PUT: api/Cities/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutCity(int id, City city)
    {
        if (id != city.Id)
        {
            return BadRequest();
        }

        _context.Entry(city).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!CityExists(id))
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

    // POST: api/Cities
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<City>> PostCity(CreateCityDto createCity)
    {
        if (_context.Cities is null)
        {
            return Problem("Entity set 'DataContext.Cities'  is null.");
        }

        var city = _mapper.Map<City>(createCity);

        _context.Cities.Add(city);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetCity", new { id = city.Id }, city);
    }

    // DELETE: api/Cities/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCity(int id)
    {
        if (_context.Cities is null)
        {
            return NotFound();
        }
        var city = await _context.Cities.FindAsync(id);
        if (city is null)
        {
            return NotFound();
        }

        _context.Cities.Remove(city);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool CityExists(int id)
    {
        return (_context.Cities?.Any(e => e.Id == id)).GetValueOrDefault();
    }
}