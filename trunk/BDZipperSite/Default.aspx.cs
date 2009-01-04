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
            if (string.Empty == BDZipper.Site.SessionManager.CurrentDirectory)
            {
                bdz = new BDZipper.BDZipper(BDZipper.Site.SessionManager.StartDirectory);
            }
            else
            {
                bdz = new BDZipper.BDZipper(BDZipper.Site.SessionManager.CurrentDirectory);
            }
            dirinfo = bdz.CurrentDirectory;
            // Get current Directory from session or web.config, make sure it exists.  
            if (!dirinfo.Exists)
            {
                lblOut.Text = string.Format("Current Directory doesn't exist: {0} <br />", bdz.CurrentDirectoryString);
                lblOut.CssClass = "error";
            }
            else
            {
                // Since the currentDirectory does exist lets check to see if 'sd' is in the 
                // url.
                string sd = BDZipper.Site.RequestManager.sd;
                if ("" != sd)
                    if ("d$$" == sd) // Go to parent directory
                    {
                        bdz.ChangeToParentDirectory();
                        fhead.InnerHtml = bdz.DirectoryAccessResult(bdz.CurrentDirectory.FullName);
                    }
                    else if (bdz.CheckIfSubDirInCurrentDir(sd))
                    {
                        if (!bdz.ChangeToChildDirectory(sd))
                        {
                            lblOut.Text = string.Format("Error changing to subdirectory {0}.  Returning to previous directory.<br />", sd);
                            lblOut.CssClass = "error";
                        }
                        fhead.InnerHtml = bdz.DirectoryAccessResult(bdz.CurrentDirectory.FullName);
                    }
                BDZipper.Site.SessionManager.CurrentDirectory  = bdz.CurrentDirectoryString;
                //TODO: need to get back to were we where.

                //if (true)
                //{ }

                //BDZipper.BDZipper bdz = new BDZipper.BDZipper(dirinfo);
                //Dictionary<string,string> il = new Dictionary<string,string>();
                //cblFiles.DataSource = bdz.get
                try
                {
                    cblFiles.DataSource = bdz.GetItemListValues();
                    cblFiles.DataTextField = "Text";
                    cblFiles.DataValueField = "Value";
                    cblFiles.DataBind();
                }
                catch (UnauthorizedAccessException)
                {
                    fhead.InnerHtml  += string.Format("aspx Cannot Access folder or file! Error<br />");
                }
                catch (Exception e1)
                { fhead.InnerHtml += " from aspx: " + e1.ToString(); }
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
    public void btnHome_Click(object sender, System.EventArgs e)
    {
        // Clear out current Dir so we get new value
        BDZipper.Site.SessionManager.CurrentDirectory = string.Empty;
        Response.Redirect("~/");
    }
}
