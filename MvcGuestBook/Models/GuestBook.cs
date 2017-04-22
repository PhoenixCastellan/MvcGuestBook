using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcGuestBook.Models
{
    public class GuestBook
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Abstract{get;set;}
    }
}