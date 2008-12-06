using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace BDZipper.Site
{
    /// <summary>
    /// This class maintains all session variables for us instead of putting them 
    /// individually in the session.
    /// </summary>
    public static class SessionManager
    {

        # region Private Constants
        // Define string constant for each property.  We use the constant to call the session variable
        // easier not to make mistakes this way.
        // I think for simplicity, we will use the same key string in the web.config AppSettings as
        // we do for the session variable.  This way we can use the same constant for both!
        private const string startDirectory = "StartDirectory";

        # endregion


        //HttpContext.Current.Session["brett"] = "me"
        /// <summary>
        /// The starting direcory for the application
        /// </summary>
        public static string StartDirectory
        {
            get
            {
                if (null == HttpContext.Current.Session[startDirectory])
                {
                    return ConfigurationManager.AppSettings[startDirectory];
                }
                else
                {
                    return (string)HttpContext.Current.Session[startDirectory];
                }
            }
            set
            {
                HttpContext.Current.Session[startDirectory] = value;
            }
        }
    }
}
