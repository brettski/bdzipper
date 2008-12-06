using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DirectoryInfo dirinfo;
        string curDir = string.Empty;
        string gotoDir = string.Empty;

        if (!IsPostBack)
        {
            curDir = BDZipper.Site.SessionManager.StartDirectory;
            dirinfo = new DirectoryInfo(curDir);
            if (!dirinfo.Exists)
            {
                lblOut.Text = string.Format("Current Directory doesn't exist: {0} <br />", curDir);
                lblOut.CssClass = "error";
                
            }
            else
            {
                foreach (DirectoryInfo di2 in dirinfo.GetDirectories())
                {
                    // We are forming a lot of business logic around the list items, this is why
                    // this need to be moved into a class to build it.
                    cblFiles.Items.Add(new ListItem("<a href='?sd=" + di2.Name + "'>" + di2.Name + "</a>", "d$" + di2.Name));
                }
                foreach (FileInfo fi2 in dirinfo.GetFiles())
                {
                    cblFiles.Items.Add(new ListItem(fi2.Name, "f$" + fi2.Name));
                }
            }
        }
        else
        {
            lblOut.Text = "";
            foreach (ListItem li in cblFiles.Items)
            {
                if (li.Selected)
                {
                    lblOut.Text += li.Value + "<br />";
                   
                }

            }

        }
    }
}
