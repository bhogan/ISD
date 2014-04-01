<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Teams.aspx.vb" Inherits="Teams" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:SqlDataSource ID="sdsTeam" runat="server" 
            ConnectionString="<%$ ConnectionStrings:TeamConnection %>" 
            InsertCommand="CreateTeam" InsertCommandType="StoredProcedure" 
            SelectCommand="ReadTeam" SelectCommandType="StoredProcedure" 
            UpdateCommand="UpdateTeam" UpdateCommandType="StoredProcedure">
            <InsertParameters>
                <asp:Parameter Name="Sport" Type="String" />
                <asp:Parameter Name="Active" Type="Boolean" />
                <asp:Parameter Name="Gender" Type="String" />
                <asp:Parameter Name="Description" Type="String" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="TeamID" Type="Int32" />
                <asp:Parameter Name="Sport" Type="String" />
                <asp:Parameter Name="Gender" Type="String" />
                <asp:Parameter Name="Description" Type="String" />
                <asp:Parameter Name="Active" Type="Boolean" />
            </UpdateParameters>
        </asp:SqlDataSource>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
            AllowSorting="True" AutoGenerateColumns="False" DataSourceID="sdsTeam" 
            DataKeyNames="TeamID">
            <Columns>
                <asp:CommandField ShowEditButton="True" />
                <asp:BoundField DataField="TeamID" HeaderText="TeamID" SortExpression="TeamID" 
                    InsertVisible="False" ReadOnly="True" Visible="False" />
                <asp:BoundField DataField="Sport" HeaderText="Sport" 
                    SortExpression="Sport" />
                <asp:BoundField DataField="Gender" HeaderText="Gender" 
                    SortExpression="Gender" />
                <asp:BoundField DataField="Description" HeaderText="Description" 
                    SortExpression="Description" />
                <asp:CheckBoxField DataField="Active" HeaderText="Active" 
                    SortExpression="Active" />
            </Columns>
        </asp:GridView>
    
    </div>
    </form>
</body>
</html>
