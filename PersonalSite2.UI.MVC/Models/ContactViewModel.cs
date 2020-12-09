using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations; // added for validation

namespace PersonalSite2.UI.MVC.Models
{
    public class ContactViewModel
    {
        [Required(ErrorMessage = "* Name is required")]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]//this makes sure that it is a correctly formatted email
        public string Email { get; set; }

        public string Subject { get; set; }

        [Required(ErrorMessage = " * Message is required")]
        [UIHint("MultilineText")]//change from a single line textbox to multiline
        public string Message { get; set; }
    }
}