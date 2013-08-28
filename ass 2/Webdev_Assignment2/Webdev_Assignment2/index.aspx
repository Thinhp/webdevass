<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Webdev_Assignment2.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Welcome to virtual hospital</title>
    <link href="Stylesheet/index.css" rel="stylesheet" type="text/css"/>
</head>
<body>
    <form id="form1" runat="server">
        <div id="LoginForm">
            <asp:Login ID="LoginForm1" runat="server" OnAuthenticate="LoginForm1_Authenticate" BackColor="#99FF66" BorderColor="#00CC99" BorderPadding="4" BorderStyle="Dotted" BorderWidth="1px" Font-Names="Verdana" Font-Size="0.9em" ForeColor="#333333" Height="199px" Width="273px" FailureText="Wrong username or password. Please try again.">
                <InstructionTextStyle Font-Italic="True" ForeColor="Black" />
                <LoginButtonStyle BackColor="White" BorderColor="#507CD1" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#284E98" />
                <TextBoxStyle Font-Size="0.8em" />
                <TitleTextStyle BackColor="#009933" Font-Bold="True" Font-Size="0.9em" ForeColor="White" />
            </asp:Login>
        </div>
    
            
    
    </form>
</body>
</html>
