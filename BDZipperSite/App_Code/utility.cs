using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BDZipper;

namespace BDZipper.Site
{
    /// <summary>
    /// DBZipper site utility class
    /// </summary>
    public class utility
    {

        public utility()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        /// <summary>
        /// Verify value is actually an int
        /// </summary>
        /// <param name="s"></param>
        /// <returns>Same value if clean</returns>
        public static string sanitize_int(string s)
        {
            try{ 
                int s1 = Convert.ToInt32(s);
                //int s2 = 
            }
            catch (Exception e)
            {
                //throw new Exception "Not an int value as expected on GET!";
                throw new Exception("Not as int value as expected on GET!");
            }


            return "";
        }
    }
}