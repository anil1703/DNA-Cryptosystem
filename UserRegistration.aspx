<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="UserRegistration.aspx.cs" Inherits="UserRegistration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table border="1" align="center" style ="color :White;" width="80%" cellpadding ="10px">
<tr>
<th colspan ="2">
  <h1 style ="font-size :x-large ;text-align :center ;">User Registration</h1>
</th>
</tr>
<tr>
<td style ="text-align :right ;">UserID</td>
<td>

    <asp:TextBox ID="TextBox1" runat="server" ReadOnly="True"></asp:TextBox>

</td>
</tr>

<tr>
<td style ="text-align :right ;">Enter Name</td>
<td>

    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>

</td>
</tr>

<tr>
<td style ="text-align :right ;">MobileNo</td>
<td>

    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>

</td>
</tr>

<tr>
<td style ="text-align :right ;">EMailID</td>
<td>

    <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>

</td>
</tr>

<tr>
<td style ="text-align :right ;">Security Question</td>
<td>

    <asp:DropDownList ID="DropDownList1" runat="server">
        <asp:ListItem>Select</asp:ListItem>
        <asp:ListItem>Favourite Color?</asp:ListItem>
        <asp:ListItem>Favourite Food?</asp:ListItem>
        <asp:ListItem>First Mobile Model?</asp:ListItem>
        <asp:ListItem>Best Friend Name?</asp:ListItem>
    </asp:DropDownList>

</td>
</tr>

<tr>
<td style ="text-align :right ;">Security Answer</td>
<td>

    <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>

</td>
</tr>

<tr>
<td style ="text-align :right ;">Designation</td>
<td>

    <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>

</td>
</tr>

<tr>
<td style ="text-align :right ;">Registration Date</td>
<td>

    <asp:TextBox ID="TextBox7" runat="server" ReadOnly="True"></asp:TextBox>

</td>
</tr>

<tr>
<td style ="text-align :right ;">Photo</td>
<td>

    <asp:FileUpload ID="FileUpload1" runat="server" />
    <br />
    <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click" 
        Font-Bold="True">View</asp:LinkButton>
    <asp:HiddenField ID="HiddenField1" runat="server" />
    <br />
    <asp:Image ID="Image1" runat="server" Height="100px" Width="100px" />

</td>
</tr>

<tr>
<td style ="text-align :right ;">UserName</td>
<td>

    <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>

</td>
</tr>

<tr>
<td style ="text-align :right ;">Password</td>
<td>

    <asp:TextBox ID="TextBox9" runat="server" TextMode="Password"></asp:TextBox>

</td>
</tr>

<tr>
<td style ="text-align :right ;">Confirm Password</td>
<td>

    <asp:TextBox ID="TextBox10" runat="server" TextMode="Password"></asp:TextBox>

    <asp:CompareValidator ID="CompareValidator1" runat="server" 
        ControlToCompare="TextBox9" ControlToValidate="TextBox10" 
        ErrorMessage="CompareValidator" ForeColor="Red">Password Mismatched</asp:CompareValidator>

</td>
</tr>

<tr>
<td style ="text-align :center ;" colspan="2">
    <asp:LinkButton ID="LinkButton2" runat="server" onclick="LinkButton2_Click" 
        Font-Bold="True">Register</asp:LinkButton>
&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:LinkButton ID="LinkButton3" runat="server" onclick="LinkButton3_Click" 
        Font-Bold="True">Clear</asp:LinkButton>
    </td>
</tr>

<tr>
<td style ="text-align :center ;" colspan="2">
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    </td>
</tr>

</table>
</asp:Content>

