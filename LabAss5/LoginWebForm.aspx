<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginWebForm.aspx.cs" Inherits="LabAss5.LoginWebForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:Label ID="lblCaption" runat="server" Font-Bold="True" Font-Italic="True" Font-Names="Georgia" Text="Please log on"></asp:Label>
        <p>
            <asp:Label ID="Label1" runat="server" Text="username"></asp:Label>
            <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUsername" ErrorMessage="Invalid Username"></asp:RequiredFieldValidator>
        </p>
        <p>
            <asp:Label ID="Label2" runat="server" Text="password"></asp:Label>
            <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPassword" ErrorMessage="Invalid Password"></asp:RequiredFieldValidator>
        </p>
        <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="submit" />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="username" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:BoundField DataField="username" HeaderText="username" ReadOnly="True" SortExpression="username" />
                <asp:BoundField DataField="password" HeaderText="password" SortExpression="password" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:lab5 %>" ProviderName="<%$ ConnectionStrings:lab5.ProviderName %>" SelectCommand="SELECT * FROM logon"></asp:SqlDataSource>
    </form>
</body>
</html>
