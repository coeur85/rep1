<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="_repItemRepter.ascx.vb" Inherits="rep1._repItemRepter" %>
<%@ Register Src="~/_UserControls/_repItem.ascx" TagPrefix="uc1" TagName="_repItem" %>




               <asp:Repeater ID="rep_rep" runat="server"  >
                    <ItemTemplate>
                        
                        <uc1:_repItem runat="server" id="_repItem" isHQ='<%#isHqBranch %>'  BranchID='<%#Bind("BrID") %>'
                            ItemName='<%#Bind("repItemName") %>'  Oncb_branchChanged="_repItem_cb_branchChanged" Oncb_repItemChanged="_repItem_cb_repItemChanged"  />
                    </ItemTemplate>
              
                   
               </asp:Repeater>


