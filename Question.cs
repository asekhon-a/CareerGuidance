using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Text { get; set; } // Question text
        public List<string> Options { get; set; } // Answer choices

        public Question()
        {
            Options = new List<string>();
        }
    }
}