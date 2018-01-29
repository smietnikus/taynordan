<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="studentdatabase.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    </head>
<body>
        
            <form id="form1" runat="server">
            <asp:GridView ID="GridView1" runat="server" Width="609px" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" AutoGenerateSelectButton="True" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" OnRowDataBound="GridView1_RowDataBound" AllowSorting="True" OnSorting="GridView1_Sorting" AllowPaging="True" AutoGenerateColumns="False" OnPageIndexChanging="GridView1_PageIndexChanging">
                <Columns>
                    <asp:BoundField DataField="Studentid" HeaderText="Roll Number" SortExpression="Studentid" />
                    <asp:BoundField DataField="Firstname" HeaderText="First Name" SortExpression="Firstname" FooterText="TEST" />
                    <asp:BoundField DataField="Lastname" HeaderText="Last Name" SortExpression="Lastname" />
                </Columns>
                <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />             
                <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NextPreviousFirstLast" NextPageText="Next" PageButtonCount="4" PreviousPageText="Previous" />
                <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#FFF1D4" />
                <SortedAscendingHeaderStyle BackColor="#B95C30" />
                <SortedDescendingCellStyle BackColor="#F1E5CE" />
                <SortedDescendingHeaderStyle BackColor="#93451F" />
            </asp:GridView>
      
         
   
                
         
   
                <asp:TextBox ID="txtSortHidden" runat="server"></asp:TextBox>
      
         
   
                
         
   
                <p>
                    <asp:Label ID="Label1" runat="server" Text="Id"></asp:Label>
                    <asp:TextBox ID="Sid" runat="server"></asp:TextBox>
                </p>
                <p>
                    <asp:Label ID="Label2" runat="server" Text="Firstname"></asp:Label>
                    <asp:TextBox ID="Firstname" runat="server" Width="212px"></asp:TextBox>
                </p>
                <asp:Label ID="Label3" runat="server" Text="Lastname"></asp:Label>
                <asp:TextBox ID="Lastname" runat="server" style="margin-top: 6px" Width="172px"></asp:TextBox>
                <p>
                    <asp:Label ID="Label4" runat="server" Text="Homenumber"></asp:Label>
                    <asp:TextBox ID="Homenumber" runat="server" Width="165px"></asp:TextBox>
                </p>
                <p>
                    <asp:Label ID="Label5" runat="server" Text="Mobile"></asp:Label>
                    <asp:TextBox ID="Mobile" runat="server" Width="208px"></asp:TextBox>
                </p>
                <p>
                    <asp:Label ID="Label6" runat="server" Text="Email"></asp:Label>
                    <asp:TextBox ID="Email" runat="server" Width="423px"></asp:TextBox>
                </p>
                <p>
                    <asp:Button ID="Button1" runat="server" Height="38px" Text="Submit" Width="124px" OnClick="Button1_Click" />
                    &nbsp;
                    &nbsp;
                    </p>
            </form>
         
   
    
    </body>
</html>
