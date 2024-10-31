using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class QuestionnaireController : Controller
    {
        // GET: Questionnaire
        public ActionResult QUESTION()
        {
            // Create sample questions
            var viewModel = new QuestionnaireViewModel
            {
                Questions = new List<Question>
        {
            new Question { Id = 1, Text = "What subjects do you enjoy the most?", Options = new List<string> { "Math", "Science", "EGD", "Life Science", "Accounting", "History" } },
            new Question { Id = 2, Text = "What type of activities do you prefer?", Options = new List<string> { "Analytical Problem Solving", "Creative Designing", "Helping Others", } },
            new Question { Id = 3, Text = "What type of work environment do you prefer?", Options = new List<string> { "Office", "Outdoors", "Remote", "Lab" }}

        }
            };

            // Initialize Responses with the same number of questions
            foreach (var question in viewModel.Questions)
            {
                viewModel.Responses.Add(new Response { QuestionId = question.Id });
            }

            return View(viewModel);
        }


        [HttpPost]
        public ActionResult QUESTION(QuestionnaireViewModel viewModel)
        {
            // Reinitialize Responses if needed
            if (viewModel.Responses == null || viewModel.Responses.Count != viewModel.Questions.Count)
            {
                viewModel.Responses = new List<Response>();
                foreach (var question in viewModel.Questions)
                {
                    viewModel.Responses.Add(new Response { QuestionId = question.Id });
                }
            }

           

            return View(viewModel);
        }

        public ActionResult CalculateCareer()
        {
            // Create sample questions
            var viewModel = new QuestionnaireViewModel
            {
                Questions = new List<Question>
        {
            new Question { Id = 1, Text = "What subjects do you enjoy the most?", Options = new List<string> { "Math", "Science", "EGD", "Life Science", "Accounting", "History"} },
            new Question { Id = 2, Text = "What type of activities do you prefer?", Options = new List<string> { "Analytical Problem Solving", "Creative Designing", "Helping Others", } },
            new Question { Id = 3, Text = "What type of work environment do you prefer?", Options = new List<string> { "Office", "Outdoors", "Remote", "Lab" }}

        }
            };

            // Initialize Responses with the same number of questions
            foreach (var question in viewModel.Questions)
            {
                viewModel.Responses.Add(new Response { QuestionId = question.Id });
            }

            return View(viewModel);
        }



        [HttpPost]
        public ActionResult Answers(List<string> answers)
        {
            string redirectUrl;
            

            if (answers.Contains("Math") || answers.Contains("Analytical Problem Solving") || answers.Contains("Office"))
            {
                redirectUrl = Url.Action("Results", new { career = "Engineer, Data Analyst, or Accountant" });
            }
            else if (answers.Contains("Science") || answers.Contains("Helping Others") || answers.Contains("Lab"))
            {
                redirectUrl = Url.Action("Results", new { career = "Biologist, Medical Researcher, or Pharmacist" });
            }
            else if (answers.Contains("EGD") || answers.Contains("Creative Designing") || answers.Contains("Office"))
            {
                redirectUrl = Url.Action("Results", new { career = "Architect, Graphic Designer, or Civil Engineer" });
            }
            else if (answers.Contains("History") || answers.Contains("Helping Others"))
            {
                redirectUrl = Url.Action("Results", new { career = "Law, Teacher, Journalism , Social services" });
            }
            else if(answers.Contains("Life Science"))
            {
                redirectUrl = Url.Action("Results", new { career = "Healthcare (e.g., nursing, doctor, therapist) or Environmental science or Social work, Psychology or Education (biology teacher)" });
            }
            else
            {
                redirectUrl = Url.Action("Results", new {career = "Accounting or Finance or Auditing or Business management or Economics " });
            }
            // Return the redirect URL as plain text
            return Content(redirectUrl);
           
        }



        // Results Page
        public ActionResult Results(string career)
        {
            ViewBag.RecommendedCareer = career;
            return View();
        }
    }
}