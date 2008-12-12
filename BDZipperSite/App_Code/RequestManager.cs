using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BDZipper.Site
{
    /// <summary>
    /// Used to read all GET variables used on site.  Will take care of all checks to ensure they
    /// are safe.
    /// </summary>
    public static class RequestManager
    {

        # region constants
        private const string subDir = "sd";

        # endregion

        public static string sd
        {
            get
            {
                string rValue = HttpContext.Current.Request[subDir];
                if (rValue != null)
                    return rValue;
                else
                    return "";
            }
        }
    }
}