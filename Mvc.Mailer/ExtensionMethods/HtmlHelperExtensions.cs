﻿using System.Web.Mvc;
using System;
using System.Web;
using System.Text;

namespace Mvc.Mailer
{
    public static class HtmlHelperExtensions
    {
        /// <summary>
        /// Produces the tag for inline image
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="contentId">e.g. logo</param>
        /// <param name="alt">e.g. Company Logo</param>
        /// <returns><img src="cid:logo" alt="Company Logo"/></returns>
        public static string InlineImage(this HtmlHelper htmlHelper, string contentId, string alt = "")
        {
            return String.Format("<img src=\"cid:{0}\" alt=\"{1}\"/>", contentId, alt);
        }
    }
}
