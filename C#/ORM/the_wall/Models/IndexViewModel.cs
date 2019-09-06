using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
namespace the_wall.Models
{
    public class IndexViewModel
    {
        public Message NewMessage {get;set;}
        public Comment NewComment {get;set;}
    }
}