<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="DWEFormsWeb.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <table>
            <tr>
                <td style="width:20%"><asp:DropDownList ID="TableList" runat="server" Height="16px" Width="197px">
            </asp:DropDownList></td>
                <td><asp:Button ID="DataBind" runat="server" OnClick="DataBind_Click" Text="Data" /></td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:GridView ID="DataGridView" runat="server">
                    </asp:GridView>

                </td>
            </tr>


        </table>
            
            
            
        
        <asp:TextBox ID="counter" runat="server"></asp:TextBox>
        <asp:Button ID="NextButton" runat="server" Text="Button" />
        <asp:Button ID="LastPageButton" runat="server" Text="Button" />
        <asp:TextBox ID="OfCounter" runat="server"></asp:TextBox>
        <asp:Button ID="FirstPageButton" runat="server" Text="Button" />
        <asp:Button ID="PreviousButton" runat="server" Text="Button" />
            
            
            
        
    </form>
</body>
</html>
