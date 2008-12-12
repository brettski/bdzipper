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
            // Get current Directory from session or web.config, make sure it exists.  
            
            if (!dirinfo.Exists)
            {
                lblOut.Text = string.Format("Current Directory doesn't exist: {0} <br />", curDir);
                lblOut.CssClass = "error";
                
            }
            else
            {
                // Since the currentDirectory does exist lets check to see if 'sd' is in the 
                // url.
                
                //if (true)
                //{ }
                //foreach (DirectoryInfo di2 in dirinfo.GetDirectories())
                //{
                //    // We are forming a lot of business logic around the list items, this is why
                //    // this need to be moved into a class to build it.
                //    cblFiles.Items.Add(new ListItem("<a href='?sd=" + di2.Name + "'>" + di2.Name + "</a>", "d$" + di2.Name));
                //}
                //foreach (FileInfo fi2 in dirinfo.GetFiles())
                //{
                //    cblFiles.Items.Add(new ListItem(fi2.Name, "f$" + fi2.Name));
                //}
                BDZipper.BDZipper bdz = new BDZipper.BDZipper(dirinfo);
                //Dictionary<string,string> il = new Dictionary<string,string>();
                foreach (KeyValuePair<string,string> itemlist in bdz.GetItemListValues())
                {
                    cblFiles.Items.Add(new ListItem(itemlist.Value, itemlist.Key));
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
