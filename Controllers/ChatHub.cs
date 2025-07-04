using LogistikaApi.DBContext;
using LogistikaApi.Model;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace LogistikaApi.Controllers
{
    public class ChatHub : Hub
    {
        private readonly ContextDB _context;

        public ChatHub(ContextDB context)
        {
            _context = context;
        }

        // Подгрузка всей истории сообщений при подключении
        public async Task LoadGlobalHistory()
        {
            var messages = await _context.Message
                .Include(m => m.Sender)
                .OrderBy(m => m.SentAt)
                .Select(m => new
                {
                    m.SenderId,
                    SenderName = m.Sender.Username, // Убедись, что это поле есть
                    m.Text,
                    m.SentAt
                })
                .ToListAsync();

            await Clients.Caller.SendAsync("ReceiveGlobalHistory", messages);
        }

        // Отправка нового сообщения в общий чат
        public async Task SendGlobalMessage(string message, int senderId, string senderName)
        {
            var msg = new Message
            {
                SenderId = senderId,
                Text = message,
                SentAt = DateTime.UtcNow
            };

            _context.Message.Add(msg);
            await _context.SaveChangesAsync();

            await Clients.All.SendAsync("ReceiveGlobalMessage", message, senderId, senderName, msg.SentAt);
        }
    }
}
