using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterChef.TagHelpers
{
    public class EmailTagHelper : TagHelper
    {
        public string MailTo { get; set; }
        const string Domain = "MasterChef.com.br";
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";
            var address = $"{MailTo}@{Domain}";

            output.Attributes.SetAttribute("href", $"mailto:{address}");
            output.Content.SetContent(address);
        }
    }
}
