using Microsoft.Extensions.DependencyInjection;

namespace chore.Controllers;

[ApiController]
[Route("api/chores")]
public class ChoresController : ControllerBase
{

  private readonly ChoresService _choresService;

  public ChoresController(ChoresService choresService)
  {
    _choresService = choresService;
  }


  [HttpGet("test")]
  public ActionResult<string> TestGet()
  {
    return Ok("API WORKS!");
  }

  [HttpGet]
  public ActionResult<List<Chore>> GetAllChores()
  {
    try
    {
      List<Chore> chores = _choresService.GetAllChores();

      return Ok(chores);
    }
    catch (Exception error)
    {

      return BadRequest(error.Message);
    }
  }

  [HttpGet("{choreId}")]
  public ActionResult<Chore> GetChoreById(int choreId)
  {
    try
    {
      Chore chore = _choresService.GetChoreById(choreId);
      return Ok(chore);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);

    }
  }

  [HttpPost]
  public ActionResult<Chore> CreateChore([FromBody] Chore choreData)
  {
    try
    {
      Chore chore = _choresService.CreateChore(choreData);
      return Ok(chore);
    }
    catch (Exception error)
    {

      return BadRequest(error.Message);
    }
  }


  [HttpDelete("{choreId}")]
  public ActionResult<string> ClearChore(int choreId)
  {
    try
    {
      string message = _choresService.ClearChore(choreId);
      return Ok(message);
    }
    catch (Exception exception)
    {

      return BadRequest(exception.Message);
    }
  }

  // [HttpPut("{choreId}")]
  // public ActionResult<Chore> UpdateChore([FromBody] Chore choreData, int choreId)
  // {
  //   try
  //   {
  //     Chore chore = _choresService.UpdateChore(choreData, choreId);
  //     return Ok(chore);
  //   }
  //   catch (Exception exception)
  //   {

  //     return BadRequest(exception.Message);
  //   }
  // }

}
