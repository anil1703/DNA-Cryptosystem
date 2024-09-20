<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ViewMessage.aspx.cs" Inherits="ViewMessage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table align="center" border="1" style ="color :White;" cellpadding="10px"  width ="80%" >
        <tr>
            <th colspan="2">
                 <h1 style ="font-size :x-large ;text-align :center ;">
                    Verification</h1>
            </th>
        </tr>
        <tr>
            <td style="text-align: right">
                User Name</td>
            <td style="text-align: left">
                <asp:TextBox ID="TextBox1" runat="server" Font-Bold="False" ReadOnly="True" ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="text-align: right">
                Decryption Key</td>
            <td>
                <asp:TextBox ID="TextBox2" runat="server" Font-Bold="False" ></asp:TextBox>
            </td>
        </tr>
       <%-- <tr>
            <td style="text-align: right">
                Validation Code</td>
            <td>
                <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            </td>
        </tr>--%>
        <tr>
            <td colspan="2" style="text-align: center">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:LinkButton ID="LinkButton1" runat="server" Font-Bold="True" 
                    OnClick="LinkButton1_Click">Verify</asp:LinkButton>
                &nbsp;&nbsp;&nbsp;
                </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: center">
                <asp:Label ID="Label1" runat="server" Font-Bold="False" Text="Label"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>

