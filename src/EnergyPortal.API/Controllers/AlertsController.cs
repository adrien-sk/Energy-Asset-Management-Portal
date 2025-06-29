using Microsoft.AspNetCore.Mvc;

namespace EnergyPortal.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AlertsController : ControllerBase
{
	// GET: api/<AlertsController>
	[HttpGet]
	public IEnumerable<string> Get()
	{
		return new string[] { "value1", "value2" };
	}

	// GET api/<AlertsController>/5
	[HttpGet("{id}")]
	public string Get(int id)
	{
		return "value";
	}

	// POST api/<AlertsController>
	[HttpPost]
	public void Post([FromBody] string value)
	{
	}

	// PUT api/<AlertsController>/5
	[HttpPut("{id}")]
	public void Put(int id, [FromBody] string value)
	{
	}

	// DELETE api/<AlertsController>/5
	[HttpDelete("{id}")]
	public void Delete(int id)
	{
	}
}
