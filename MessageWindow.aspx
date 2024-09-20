<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MessageWindow.aspx.cs" Inherits="MessageWindow" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table align="center" border="1" width="80%" style ="color :White ;" cellpadding="10px"  >
        <tr>
            <th colspan="2">
             <h1 style ="font-size :x-large ;text-align :center ;">
                    Message Window</h1>
            </th>
        </tr>
        <tr>
            <td style="text-align: right">
                UserName</td>
            <td style="text-align: left">
                <asp:TextBox ID="TextBox1" runat="server" Font-Bold="False" ></asp:TextBox>
            </td>
        </tr>
         <tr>
            <td colspan="2" style="text-align: center">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:LinkButton ID="LinkButton1" runat="server" Font-Bold="True" 
                    OnClick="LinkButton1_Click">View</asp:LinkButton>
                &nbsp;&nbsp;&nbsp;
                </td>
        </tr>
        <tr>
            <td style="text-align: right">
                <asp:Image ID="Image1" runat="server" Height="200px" Width="200px" Visible ="false"  />
            </td>
            <td>
                <asp:TextBox ID="TextBox2" runat="server" Height="51px" TextMode="MultiLine" 
                    Visible="False"></asp:TextBox>
                <br />
                <asp:Image ID="Image2" runat="server" Height="200px" Width="200px" 
                    Visible="False" />
                <br />
                <%--<embed id="e1" runat ="server" height="200" visible="False" width="200"  src ="~\temp1\myfile.wav"></embed>--%>
              <embed id='e1' src ="temp1\myfile.wav" runat="server" name='mediaPlayer' type='application/x-mplayer2'   displaysize='4' autosize='-1' bgcolor='darkblue' showcontrols='false' showtracker='-1' showdisplay='0' showstatusbar='0' videoborder3d='0' width='350' height='250'  designtimesp='5311' loop='false' visible ="false" />
           
                <br />
               <%-- <embed id="e2" runat ="server" height="200" visible="False" width="200" src ="~\temp1\myfile.avi" >
           </embed>--%>

             <%--<embed id='e2' src ="temp1\myfile.avi" runat="server" name='mediaPlayer' type='application/x-mplayer2'   displaysize='4' autosize='-1' bgcolor='darkblue' showcontrols='false' showtracker='-1' showdisplay='0' showstatusbar='0' videoborder3d='0' width='350' height='250'  designtimesp='5311' loop='false' visible ="false" />--%>
            <%--  <video id='e2' src ="temp1\myfile.mp4" runat="server"  width='350' height='250' controls > </video> --%>
              <video id="e2" runat="server" src="<%#avifile%>"   width="300" height="300" visible="false" controls autoplay  />
            
                </td>
            <br />
        </tr>
       
        <tr>
            <td colspan="2" style="text-align: center">
                <asp:Label ID="Label1" runat="server" Font-Bold="False" Text="Label"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>

