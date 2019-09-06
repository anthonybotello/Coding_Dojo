using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
namespace the_wall.Models
{
    public class Comment
    {
        [Key]
        public int CommentId {get;set;}

        [Required(ErrorMessage="Comment cannot be blank.")]
        public string Text {get;set;}

        public int UserId {get;set;}
        public User User {get;set;}

        public int MessageId {get;set;}
        public Message Message {get;set;}
        
        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;
    }
}