<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="tanvir.aspx.cs" Inherits="crudeoperation.tanvir" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="background-position:center">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <div style="width:1000px; min-height:750px;font:100 ;border:1px solid green;margin:1px auto;font-family:Cambria;background-color:#6f5050;" >
      <h1>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Player Information</h1>
        
      <span>Click Here To Display<a href="reportdisplay.aspx" style="color:green"><b>Report</b> </a></span> 
        <asp:HiddenField ID="hfid" runat="server" />

      
        <div>
        <table style="margin-left:200px;text-align:right" >
            <tr>
                <td >
                    <asp:Label ID="Label1" runat="server" Text="Country Name :" ></asp:Label>
                </td>
                <td colspan="2">
                    <asp:TextBox ID="txtcname" runat="server"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Player Name :" ></asp:Label>
                </td>
                <td colspan="2">
                    <asp:TextBox ID="txtpname" runat="server"></asp:TextBox>
                </td>
            </tr>
              <tr>
                <td>
                    <asp:Label ID="Label3" runat="server" Text="Player Age :"></asp:Label>
                </td>
                <td colspan="2">
                    <asp:TextBox ID="txtage" runat="server"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td>
                    <asp:Label ID="Label5" runat="server" Text="Game Type :"></asp:Label>
                </td>
                <td colspan="2">
                    <asp:TextBox ID="txttype" runat="server"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td>
                    <asp:Label ID="Label6" runat="server" Text="Player Status :"></asp:Label>
                </td>
                <td colspan="2">
                    <asp:TextBox ID="txtstatus" runat="server"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td>
                    <asp:Label ID="Label7" runat="server" Text="Player Role :"></asp:Label>
                </td>
                <td colspan="2">
                    <asp:TextBox ID="txtrole" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label8" runat="server" Text="Major Team :"></asp:Label>
                </td>
                <td colspan="2">
                    <asp:TextBox ID="txtteam" runat="server"></asp:TextBox>
                </td>
            </tr>


           

             </table>


          </div>
        <div>
            <br />
        <table style="width: 453px; margin-left: 258px">
            
             <tr>
                <td>
                   
                </td>
                <td colspan="2">
                    <asp:Button ID="btnsave" runat="server" Text="Save" OnClick="btnsave_Click"  />
                    <asp:Button ID="btncleare" runat="server" Text="Clear" OnClick="btncleare_Click" />
                    <asp:Button ID="btndelete" runat="server" Text="Delete" OnClick="btndelete_Click" />
                    <asp:Button ID="btnupdate" runat="server" Text="Update" OnClick="btnupdate_Click" />
                </td>
            </tr>
       
            <tr>
                <td>
                   
                </td>
                <td colspan="2">
                    <asp:Label ID="lblsuccess" Width="436px" Font-Italic="true"  runat="server" Font-Bold="True"  ForeColor="Black"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                   
                </td>
                <td colspan="2">
                    <asp:Label ID="lblerroe" runat="server" Text=""  Font-Bold="true" ForeColor="Red"></asp:Label>
                </td>
            </tr>
        </table>  
            </div>
        <br />
        <div> 
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="2" Width="885px"  style="margin-left: 57px" ForeColor="Black" GridLines="None" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px">

            <AlternatingRowStyle BackColor="PaleGoldenrod" />

            <Columns>
                <asp:BoundField DataField="Country_name" HeaderText="Country_name" />
                 <asp:BoundField DataField="Player_name" HeaderText="Player_name" />
                 <asp:BoundField DataField="Player_age" HeaderText="Player_age" />
                <asp:BoundField DataField="Game_Type" HeaderText="Game_Type" />
                  <asp:BoundField DataField="Player_Status" HeaderText="Player_Status" />
                     <asp:BoundField DataField="Player_Role" HeaderText="Player_Role" />
                    <asp:BoundField DataField="Major_Team" HeaderText="Major_Team" />

                 
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" 
                            CommandArgument='<%#Eval("Cid")%>' OnClick="viewButton1_Click">View</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>         

            </Columns>
           
            <FooterStyle BackColor="Tan" />
            <HeaderStyle BackColor="Tan" Font-Bold="True" />
            <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
            <SortedAscendingCellStyle BackColor="#FAFAE7" />
            <SortedAscendingHeaderStyle BackColor="#DAC09E" />
            <SortedDescendingCellStyle BackColor="#E1DB9C" />
            <SortedDescendingHeaderStyle BackColor="#C2A47B" />
           
        </asp:GridView>
            </div>
            
    </div>
    </form>
</body>
</html>
