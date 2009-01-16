<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title>BDZipper</title>
    <link href="css/bdzipper.css" rel="stylesheet" type="text/css" />
    <link href="css/bdzipper.css" rel="stylesheet" type="text/css" />
	<script language="javascript" type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.2.6/jquery.min.js"></script>
    <script src="js/jquery.hoverIntent.minified.js" type="text/javascript"></script>
    <script src="js/Default_jq.js" type="text/javascript"></script>
</head>
<body>
	<div id="PageContainer">
	<div id="PageContent">
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
	<form id="form1" runat="server">
	<asp:label id="lblOut" runat="server"></asp:label>
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
