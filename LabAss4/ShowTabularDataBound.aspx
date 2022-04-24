<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowTabularDataBound.aspx.cs" Inherits="LabAss4.ShowTabularDataBound" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>GridView</h1>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="username" DataSourceID="SqlDataSource1">
                <Columns>
                    <asp:BoundField DataField="username" HeaderText="username" ReadOnly="True" SortExpression="username" />
                    <asp:BoundField DataField="password" HeaderText="password" SortExpression="password" />
                </Columns>
            </asp:GridView>
        </div>
        <div>
            <h1>DataList</h1>
            <asp:DataList ID="DataList1" runat="server" DataKeyField="username" DataSourceID="SqlDataSource1">
                <ItemTemplate>
                    username:
                    <asp:Label ID="usernameLabel" runat="server" Text='<%# Eval("username") %>' />
                    <br />
                    password:
                    <asp:Label ID="passwordLabel" runat="server" Text='<%# Eval("password") %>' />
                    <br />
<br />
                </ItemTemplate>
            </asp:DataList>
        </div>
        <div>
            <h1>DetailsView</h1>
            <asp:DetailsView ID="DetailsView1" runat="server" Height="50px" Width="125px" AutoGenerateRows="False" DataKeyNames="username" DataSourceID="SqlDataSource1">
                <Fields>
                    <asp:BoundField DataField="username" HeaderText="username" ReadOnly="True" SortExpression="username" />
                    <asp:BoundField DataField="password" HeaderText="password" SortExpression="password" />
                </Fields>
            </asp:DetailsView>
        </div>
        <div>
            <h1>FormView</h1>
            <asp:FormView ID="FormView1" runat="server" DataKeyNames="username" DataSourceID="SqlDataSource1">
                <EditItemTemplate>
                    username:
                    <asp:Label ID="usernameLabel1" runat="server" Text='<%# Eval("username") %>' />
                    <br />
                    password:
                    <asp:TextBox ID="passwordTextBox" runat="server" Text='<%# Bind("password") %>' />
                    <br />
                    <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="更新" />
                    &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="取消" />
                </EditItemTemplate>
                <InsertItemTemplate>
                    username:
                    <asp:TextBox ID="usernameTextBox" runat="server" Text='<%# Bind("username") %>' />
                    <br />
                    password:
                    <asp:TextBox ID="passwordTextBox" runat="server" Text='<%# Bind("password") %>' />
                    <br />
                    <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="插入" />
                    &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="取消" />
                </InsertItemTemplate>
                <ItemTemplate>
                    username:
                    <asp:Label ID="usernameLabel" runat="server" Text='<%# Eval("username") %>' />
                    <br />
                    password:
                    <asp:Label ID="passwordLabel" runat="server" Text='<%# Bind("password") %>' />
                    <br />

                </ItemTemplate>
            </asp:FormView>
        </div>
        <div>
            <h1>Repeater</h1>
            <asp:Repeater ID="Repeater1" runat="server" DataSourceID="SqlDataSource1">
                <ItemTemplate>
                    <%#Eval("username")%>
                    <i>--></i>
                    <%#Eval("password")%>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <div>
            <h1>ListView</h1>
            <asp:ListView ID="ListView1" runat="server" DataSourceID="SqlDataSource1">
                <ItemTemplate>
                    <%#Eval("username")%>
                    <i>--></i>
                    <%#Eval("password")%>
                </ItemTemplate>
            </asp:ListView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString3 %>" ProviderName="<%$ ConnectionStrings:ConnectionString3.ProviderName %>" SelectCommand="SELECT * FROM logon"></asp:SqlDataSource>
        </div>
    </form>
</body>
</html>
