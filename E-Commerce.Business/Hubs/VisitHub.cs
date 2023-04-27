using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Business.Hubs
{
    public class VisitHub : Hub
    {
        private static Dictionary<string, string> ClientsGroupDictionary = new();

        private IHttpContextAccessor _httpContextAccessor;

        public VisitHub(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public override async Task OnConnectedAsync()
        {
            string productInStockId = _httpContextAccessor.HttpContext.Request.Query["productId"];

            ClientsGroupDictionary.Add(Context.ConnectionId,productInStockId);

            await Groups.AddToGroupAsync(this.Context.ConnectionId, productInStockId);

            await SendMessage(productInStockId, GetClientCountInGroup(productInStockId));
        }

        public async Task SendMessage(string groupname, int connectionCounter)
        {
            await Clients.Group(groupname).SendAsync("ReceiveMessage", connectionCounter);
        }

        private int GetClientCountInGroup(string groupname) => 
            ClientsGroupDictionary.Values.Where(x => x.Equals(groupname)).Count();

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            string groupname = ClientsGroupDictionary.FirstOrDefault(x => x.Key.Equals(Context.ConnectionId)).Value;

            ClientsGroupDictionary.Remove(Context.ConnectionId);

            await SendMessage(groupname, GetClientCountInGroup(groupname));
            
            await base.OnDisconnectedAsync(exception);
        }
    }
}
