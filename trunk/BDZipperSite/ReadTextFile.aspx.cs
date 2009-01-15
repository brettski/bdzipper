using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.IO;

public partial class ReadTextFile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (null == DeterminePostBackMode())
        {
            string curdir = BDZipper.Site.SessionManager.CurrentDirectory;
            string filename = Request.Form["filename"];
            int charLength = 512;

            if (Directory.Exists(curdir + filename))
            {
                int fc = Directory.GetFiles(curdir + filename).Length;
                int dc = Directory.GetDirectories(curdir + filename).Length;
                string o = string.Format("<p><strong>{0}</strong> is a directory which contains {1} direcorie(s) and {2} file(s).</p>", filename, dc, fc);
                Response.Write(o);
            }
            else
            {
                try
                {
                    using (StreamReader sr = new StreamReader(curdir + filename))
                    {
                        char[] stub = new char[charLength];
                        sr.Read(stub, 0, charLength);
                        Response.Write("<p>Reading from: " + filename + "</p>");
                        for (int i = 0; i < charLength && '\0' != stub[i]; i++)
                        {
                            Response.Write(Server.HtmlEncode(stub[i].ToString()));
                        }
                    }
                }
                catch
                {
                    Response.Write("<p>Error Reading File!</p>");
                }
            }
        }
        else
            //Response.Write(DeterminePostBackMode());
            Response.Write("x");
    }
}
