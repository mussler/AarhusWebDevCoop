using AarhusWebDevCoop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Mvc;
using Umbraco.Core.Models;

namespace AarhusWebDevCoop.Controllers
{
    public class ContactFormSurfaceController : SurfaceController
    {   
        public ActionResult Index()
        {
            return PartialView("ContactForm", new ContactForm());
        }

        [HttpPost]
        public ActionResult HandleFormSubmit(ContactForm model)
        {
            if (!ModelState.IsValid) { return CurrentUmbracoPage(); }

            // Mail Sending
            // MailMessage message = new MailMessage();
            //message.To.Add("mussler@gmail.com");
            //message.Subject = model.Subject;
            //message.From = new MailAddress(model.Email, model.Name);
            //message.Body = model.Message;
            //using (SmtpClient smtp = new SmtpClient())
            //{
            //    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            //    smtp.UseDefaultCredentials = false;
            //    smtp.EnableSsl = true;
            //    smtp.Host = "smtp.gmail.com";
            //    smtp.Port = 587;
            //    smtp.Credentials = new System.Net.NetworkCredential("mussler@gmail.com", "xxxxxxxxxxxxxxxxx");
            //    smtp.EnableSsl = true;
            //    // send mail
            //    smtp.Send(message);
            //    TempData["success"] = true;

            //}


            IContent comment = Services.ContentService.CreateContent(model.Subject, CurrentPage.Id, "message");            comment.SetValue("senderName", model.Name);            comment.SetValue("email", model.Email);            comment.SetValue("subject", model.Subject);            comment.SetValue("message", model.Message);            Services.ContentService.Save(comment);            TempData["success"] = true;
            return RedirectToCurrentUmbracoPage();
        }
    }

}