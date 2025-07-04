using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogistikaApi.Model
{
    public class Message
    {
        [Key]
        public int Id { get; set; }

        public int SenderId { get; set; }
        [ForeignKey("SenderId")]
        public User Sender { get; set; }
        public string Text { get; set; }
        public DateTime SentAt { get; set; }
    }
}
