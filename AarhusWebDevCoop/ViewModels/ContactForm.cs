using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AarhusWebDevCoop.ViewModels
{
    public class ContactForm
    {
        [Required]
        public string Name { set; get; }
        [Required]
        [EmailAddress(ErrorMessage = "Please provide your e-mail")]
        public string Email { set; get; }
        [Required]
        public string Subject { set; get; }
        [Required]
        public string Message { set; get; }

    }
}