using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class QuestionnaireViewModel
    {
        public List<Question> Questions { get; set; }
        public List<Response> Responses { get; set; }

        public QuestionnaireViewModel()
        {
            Questions = new List<Question>();
            Responses = new List<Response>();
        }
    }
}