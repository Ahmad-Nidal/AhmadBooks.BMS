using AhmadBooks.BMS.Groups;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace AhmadBooks.BMS.Web.ViewModels.Groups
{
    public class UpdateGroupViewModel
    {
        [HiddenInput]
        [Required]
        public Guid Id { get; set; }

        [Required]
        [StringLength(GroupConsts.MaxNameLength)]
        public string Name { get; set; }
    }
}