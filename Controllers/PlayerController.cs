using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class PlayerController : Controller
{
    private readonly PlayerDB _playerDB;

    public PlayerController(PlayerDB playerDB)
    {
        _playerDB = playerDB;

    }


    //Get all players
    [HttpGet]
    public JsonResult Get()
    {
        return Json(_playerDB);
    }

    ////get api/players/name
    [HttpGet("{name}")]
    public JsonResult Get(string name)
    {
        Player player = _playerDB[name];

        return Json(player);
    }


    [HttpPost]
    public JsonResult Post([FromBody] Player player)
    {
        _playerDB.Add(player.Name, player);
        return Json(_playerDB);
    }


    [HttpPut("{name}")]
    public JsonResult Put(string name, string newName)
    {
        Player player;
        if (_playerDB.TryGetValue(name, out player))
        {
            
            _playerDB.Remove(player.Name);
            _playerDB.Add(newName, new Player() { Name = newName});
            return Json(name + " Was updated to " + newName);
        }
        else
        {
            return Json($"{name} not found");
        }
    }


    [HttpDelete("{name}")]
    public JsonResult Delete(string name)
    {

        Player player;
        //for ikke at få fejl når den ikke kan finde det i databasen
        if (_playerDB.TryGetValue(name, out player))
        {
            _playerDB.Remove(player.Name);
            return Json($"{name} was deleted");
        }
        else
        {
            return Json(name + " Was not found");
        }

    }

 
}

