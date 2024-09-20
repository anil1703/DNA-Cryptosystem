<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br /><br /><br /><table align="center" border="1" width="80%"  style ="color :White ;" cellpadding="10px">
        <tr>
            <th colspan="2">
               
              <h1 style ="font-size :x-large ;text-align :center ;">
                     User
                     Login</h1>
             
            </th>
        </tr>
        <tr>
            <td style="text-align: right">
                UserName</td>
            <td style="text-align: left">
                <asp:TextBox ID="TextBox1" runat="server" Font-Bold="False" ></asp:TextBox></td>
        </tr>
        <tr>
            <td style="text-align: right">
                Password</td>
            <td>
                <asp:TextBox ID="TextBox2" runat="server" Font-Bold="False" 
                    TextMode="Password" ></asp:TextBox></td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: center">
                &nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:LinkButton ID="LinkButton1" runat="server" Font-Bold="True" 
                    OnClick="LinkButton1_Click">Login</asp:LinkButton>
                &nbsp;&nbsp;&nbsp;
                <span style ="float:right ;">
                <asp:HyperLink ID="HyperLink1" runat="server" Font-Bold="True" 
                    NavigateUrl="~/UserRegistration.aspx">New Registration</asp:HyperLink></span>
                </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: center">
                <asp:Label ID="Label1" runat="server" Font-Bold="False" Text="Label"></asp:Label>
           <%--   <embed id='e1' src="temp1/myfile.avi" runat="server" name='mediaPlayer'></embed>--%>             
                </td>
        </tr>
    </table><br /><br /><br /><br /><br />
</asp:Content>



