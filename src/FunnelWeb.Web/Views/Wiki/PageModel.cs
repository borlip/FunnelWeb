﻿using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using FunnelWeb.Model;
using FunnelWeb.Model.Strings;
using FunnelWeb.Web.Application.Mvc;

namespace FunnelWeb.Web.Views.Wiki
{
    public class PageModel
    {
        public PageModel()
        {
            
        }

        public PageModel(PageName page, Entry entry, bool isPriorVersion)
        {
            Page = page;
            Entry = entry;
            IsPriorVersion = isPriorVersion;
        }

        public bool IsPriorVersion { get; set; }
        public PageName Page { get; set; }
        public Entry Entry { get; set; }

        [DisplayName("Name")]
        [Required]
        [StringLength(50)]
        [HintSize(HintSize.Medium)]
        public string CommenterName { get; set; }

        [StringLength(200)]
        [DisplayName("Blog URL")]
        [HintSize(HintSize.Medium)]
        [ValidUrl(ErrorMessage = "Please enter a valid URL that starts with http:// or https://. Not required.")]
        public string CommenterBlog { get; set; }

        [DisplayName("E-mail")]
        [StringLength(100)]
        [DataType(DataType.EmailAddress)]
        [HintSize(HintSize.Medium)]
        [RegularExpression("^[A-Za-z0-9._%+-]+@([A-Za-z0-9-]+\\.)+([A-Za-z0-9]{2,4}|museum)$", ErrorMessage = "Please enter a valid email address")]
        [Description("Used for your <a href=\"http://en.gravatar.com/\">gravatar</a>. Not required. Will not be public. ")]
        public string CommenterEmail { get; set; }

        [Required]
        [StringLength(2000)]
        [DataType("Markdown")]
        [Description("Posting code? Indent it by four spaces to make it look nice. Learn more about <a href=\"http://daringfireball.net/projects/markdown/syntax\">Markdown</a>.")]
        public string Comments { get; set; }
    }
}