using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace DAL
{
    //DAL Message model
    public class Message
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public String Text { get; set; }
        public int? TimesToShow { get; set; }
        [Required]
        public String HashLink { get; set; }
        [Required]
        public DateTime TimeToDelete { get; set; }

        public Message()
        { }

        public Message(int id, string text, int? timesToShow, string hashLink, DateTime timeToDelete)
        {
            Id = id;
            Text = text;
            TimesToShow = timesToShow;
            HashLink = hashLink;
            TimeToDelete = timeToDelete;
        }
    }
}
