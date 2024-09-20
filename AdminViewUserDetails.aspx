<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AdminViewUserDetails.aspx.cs" Inherits="AdminViewUserDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table align="center" border="1" style ="color :White; " cellpadding="10px" width="80%"  >
        <tr>
            <th>
              
                 <h1 style ="font-size :x-large ;text-align :center ;">
                    View
                    User Details</h1>
            
            </th>
        </tr>
        <tr>
            <th>
                
                <center>
                    <asp:GridView ID="GridView1" runat="server" 
                    AutoGenerateColumns="False" PageSize="5" DataKeyNames="uname" 
                        onrowcommand="GridView1_RowCommand" BackColor="#CCCCCC" 
                        BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" 
                        CellSpacing="2" ForeColor="Black" EmptyDataText="Record Not Found" 
                        Width="361px">
                    <Columns >
                             <asp:ButtonField Text ="Delete" HeaderText ="Delete User" CommandName ="DU" 
                            ItemStyle-ForeColor ="#516C00" >
<ItemStyle ForeColor="Red"  ></ItemStyle>
                        </asp:ButtonField>
                    <asp:BoundField DataField ="uname" HeaderText ="UserName" />
                    <asp:BoundField DataField ="EMailID" HeaderText ="EMailID" />
                    <asp:ButtonField Text ="ViewStatus" HeaderText ="Status" CommandName ="ss" 
                            ItemStyle-ForeColor ="#516C00" >
<ItemStyle ForeColor="Red"  ></ItemStyle>
                        </asp:ButtonField>

                        
                    </Columns>
                        
                    <FooterStyle BackColor="#CCCCCC" />
                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                    <RowStyle BackColor="White" />
                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#808080" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#383838" />
                </asp:GridView></center>
            
            </th>
        </tr>
        <tr>
            <th>
                
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            
            </th>
        </tr>
        </table> 
</asp:Content>

