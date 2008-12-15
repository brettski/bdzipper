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
        BDZipper.BDZipper bdz;

        if (!IsPostBack)
        {
            bdz = new BDZipper.BDZipper(BDZipper.Site.SessionManager.StartDirectory);
            dirinfo = bdz.CurrentDirectory;
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
                string sd = BDZipper.Site.RequestManager.sd;
                if ("" != sd)
                    if ("d$$" == sd) // Go to parent directory
                        bdz.ChangeToParentDirectory();
                    else if (bdz.CheckIfSubDirInCurrentDir(sd))
                        if (!bdz.ChangeToSubDirectory(sd))
                        {
                            lblOut.Text = string.Format("Error changing to subdirectory {0}.  Returning to previous directory.<br />", sd);
                            lblOut.CssClass = "error";
                        }
                BDZipper.Site.SessionManager.StartDirectory = bdz.CurrentDirectoryString;
                //TODO: need to get back to were we where.

                //if (true)
                //{ }

                //BDZipper.BDZipper bdz = new BDZipper.BDZipper(dirinfo);
                //Dictionary<string,string> il = new Dictionary<string,string>();
                //cblFiles.DataSource = bdz.get
                cblFiles.DataSource = bdz.GetItemListValues();
                cblFiles.DataTextField = "Text";
                cblFiles.DataValueField = "Value";
                cblFiles.DataBind();
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
