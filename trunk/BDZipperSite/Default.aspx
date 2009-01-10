<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title>BDZipper</title>
	<link href="bdzipper.css" rel="stylesheet" type="text/css" />
</head>
<body>
	<div id="PageContainer">
	<div id="PageContent">
	<form id="form1" runat="server">
	<div id="header">
	    <h3>BDZipper</h3>
	</div>
	<div id="fhead" runat="server">
	</div>
	<div id="ihead">
		<%
			Response.Write("Raw URL: " + Request.RawUrl  + "<br />");
			Response.Write("Application Path: " + Request.ApplicationPath + "<br />");
			Response.Write("URL: " + Request.Url  + "<br />");
            Response.Write("MapPath: " + Server.MapPath("~/") + "<br />");        
			//Response.Write("URL Referrer" + Request.UrlReferrer.ToString() + "<br />");
		%>
	</div>
	<asp:Label id="lblOut" runat="server"></asp:Label>
	<div id="msgBox"></div>
	<asp:Button id="Button1" runat="server" Text="Get Checked" />
	<asp:LinkButton id="btnHome" runat="server" Text="Home" OnClick="btnHome_Click" />
	<div id="filelist">
		<asp:CheckBoxList ID="cblFiles" runat="server">

		</asp:CheckBoxList>
	</div>
	<div id="footer">
	
	</div>
	</form>
	</div>
	</div>
</body>
</html>
