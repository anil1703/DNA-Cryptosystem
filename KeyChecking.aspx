<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="KeyChecking.aspx.cs" Inherits="KeyChecking" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table align="center" border="1" width="80%" style ="color :White ;" cellpadding="10px"   >
        <tr>
            <th colspan="2">
                <h1 style ="font-size :x-large ;text-align :center ;">
&nbsp;Secret Key Verification</h1>
            </th>
        </tr>
        <tr>
            <td style="text-align: right" >
                User Name</td>
            <td >
                <asp:TextBox ID="TextBox1" runat="server" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="text-align: right" >
                Secret Key</td>
            <td>
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="text-align: center" colspan="2">
             <span style="float:right;">
                &nbsp;<asp:HyperLink ID="HyperLink1" runat="server" 
                    NavigateUrl="~/GetOfflineSecretKey.aspx" Font-Bold="True">Get Key</asp:HyperLink>
                    </span>
&nbsp;
                <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click" 
                    Font-Bold="True">Verify</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td style="text-align: center" colspan="2">
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>

