using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Newtonsoft.Json;
using StoreApp.Models;

namespace StoreApp.Controllers
{
    public static class ControllerExtensions
    {

        public static void SetMessage(this Controller controller, string msg  ,  Models.MessageType type)
        {
            controller.TempData["MessageInfo"] = JsonConvert.SerializeObject(new MessageInfo() { Name = "Updated Successfully!", Type = Models.MessageType.Success });
        }
    }
}
