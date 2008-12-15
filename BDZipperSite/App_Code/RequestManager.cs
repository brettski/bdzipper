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
        /// <summary>
        /// URL Param, Subdirectory (sd). Read Only.
        /// </summary>
        public static string sd
        {
            get
            {
                //return GetQueryStingParameter(subDir);
                string rValue = HttpContext.Current.Request[subDir];
                if (rValue != null)
                    return rValue;
                else
                    return "";
            }
        }

        private static string GetQueryStingParameter(string param)
        {
            if (null != HttpContext.Current.Request[param])
                return HttpContext.Current.Request[param];
            else
                return "";

        }
    }
}