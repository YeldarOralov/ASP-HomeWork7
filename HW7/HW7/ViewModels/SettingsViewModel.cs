using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HW7.ViewModels
{
    public class SettingsViewModel
    {
        [Required]
        public string Login { get; set; }

        [Required]
        public Guid RoleId { get; set; }
    }
}