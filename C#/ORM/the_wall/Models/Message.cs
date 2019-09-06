using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
namespace the_wall.Models
{
    public class Message
    {
        [Key]
        public int MessageId {get;set;}

        [Required(ErrorMessage="Message cannot be blank.")]
        public string Text {get;set;}

        public int UserId {get;set;}
        public User Creator {get;set;}

        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;

        public List<Comment> Comments {get;set;}

    }
}