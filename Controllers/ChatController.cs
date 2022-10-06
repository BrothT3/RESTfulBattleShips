using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class ChatController : Controller
{
    private readonly ChatLogDB chatLog;

    public ChatController(ChatLogDB chatLog)
    {
        this.chatLog = chatLog;
       
    }

    [HttpGet]
    public JsonResult Get()
    {
        //return Json(chatLog.Last());
        if (chatLog.Count > 1)
        {
            return Json(chatLog.Last());
        }
        else
        {
            return Json("Chatlog is empty");         
        }

    }

    [HttpPost("message")]
    public JsonResult Post([FromBody] Chat chat)
    {
        chatLog.Add(chat);
        return Json(chat);


    }


    [HttpDelete]
    public JsonResult Delete()
    {
        chatLog.Clear();
        return Json("Log has been cleared");
    }
}

