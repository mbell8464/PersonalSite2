using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PersonalSite2.UI.MVC.Models;
using System.Net.Mail; //Added for most email functionality
using System.Net;

namespace PersonalSite2.UI.MVC.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        //[Authorize]
        public ActionResult Resume()
        {
            ViewBag.Message = "Your resume page.";

            return View();
        }



        [HttpGet]
        public ActionResult Links()
        {
            ViewBag.Message = "Your links page.";
            return View();
        }

        [HttpGet]
        public ActionResult Projects()
        {
            ViewBag.Message = "Your projects page.";

            return View();
        }


        //CONTACT FUNCTIONALITY

        //GET
        [HttpGet]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }//end Contact GET

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Contact(ContactViewModel cvm)
        {
            if (!ModelState.IsValid)
            {
                //send them back to the form and pass the object (cvm) they created to the view
                //this will restore the info they typed in the textboxes so they don't have to type it again
                return View(cvm);
            }

            //create string for message
            string emailBody = $"You have received an email from {cvm.Name} with a subject of {cvm.Subject}. Please respond to {cvm.Email} with your response to the following message: <br/><br/> {cvm.Message}";

            //create MailMessage Object
            MailMessage msg = new MailMessage
            (
                //FROM
                "no-reply@mbelldevelops.com",
                //TO(Where the message is sent)
                "Michael.Bell21@outlook.com",
                //Subject
                "email from mbelldevelops.com",
                //Body
                emailBody
            );


            //customize MailMessage Object
            msg.IsBodyHtml = true;
            //msg.CC.Add("example@email.com");
            //msg.ReplyToList.Add(cvm.Email); //respond to the sender's email instead of our smartasp.net email
            //msg.Priority = MailPriority.High;


            //create SmtpClient - allows the email to actually be sent
            SmtpClient client = new SmtpClient("mail.mbelldevelops.com");

            //credentials
            client.Credentials = new NetworkCredential("no-reply@mbelldevelops.com", "ExamplePassword");//this password does not work
            client.Port = 8889;


            //attempt to send email
            try
            {
                //attempt to send the email
                client.Send(msg);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = $"Sorry, something went wrong. Error message: {ex.Message}<br/>{ex.StackTrace}";
                return View(cvm);
            }

            return View("EmailConfirmation", cvm);


        }//end Contact POST





    }//end HomeController
}
