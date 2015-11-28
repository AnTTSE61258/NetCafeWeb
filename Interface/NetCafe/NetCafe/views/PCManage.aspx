<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="PCManage.aspx.cs" Inherits="NetCafe.views.PCManage" %>
<asp:Content ID="Content7" ContentPlaceHolderID="PCManagePage" runat="server">

    <table align="center" border="1" style="text-align:center" class="table" id="OrderTable" contenteditable="false">

        <button onclick="window.location.href='PCInfo.aspx'; return false;">Manage PC(s)</button>
        <thead>
            <tr>
                <th class="panel-heading">PC.No</th>
                <th class="panel-heading">Status</th>
                <th class="panel-heading">Price</th>
                <th class="panel-heading">Description</th>
            
            </tr>
        </thead>
        <tbody>
            <div id="table-content">
        <tr>
            <td id="UserID">TriPM</td>
            <td id="txtPCID${orderid}">1</td>
            <td> <input id="txtStatus${orderid}" disabled="disabled" type="text" style="width:100px;" value="Ordered"/></td>
            <td> <input id="txtStart${orderid}" disabled="disabled" type="text" style="width:140px;" value="12:00 28/12/2016"/></td>
            <td> <input id ="txtEnd${orderid}" disabled="disabled" type="text" style="width:140px;" value="14:00 28/12/2016"></td>
            <td>2:00</td>
             <td> <input id ="txtCost${orderid}" disabled="disabled" type="text"  style="width:50px;" value="5k" /></td>
            <td>1:45</td>
           
            <td class="options"><div class="dropdown" >
		                                <button type="button" class="btn btn-default dropdown-toggle" data-toggle="dropdown"
		                                    title="Action" id="menu1">
		                                    Options<span class="fa fa-caret-left"></span>
		                                </button>
		                                <ul class="dropdown-menu" role="menu" aria-labelledby="menu1"
		                                    style="left: 100%; top: -4px;">	
                                            	
									        <li><a href="#"
		                                        title="Edit Order" onclick="btnEdit('${orderid}')"
		                                        class="btn btn-default search-dropdown" style="text-align:left"><span
		                                            class="glyphicon glyphicon-plus" aria-hidden="true"></span>Edit Order</a></li>
                                            <li><a href="addTeamMember?projectCode=${item.projectcode}"
		                                        title="Remove Order" onclick="btnRemove('${orderid}')"
		                                        class="btn btn-default search-dropdown" style="text-align:left"><span
		                                            class="glyphicon glyphicon-plus" aria-hidden="true"></span>Remove Order</a></li>
		                                    <li><a href="PCInfo.aspx"
		                                        title="Edit PC Info" onclick="window.location.href='PCInfo.aspx"
		                                        class="btn btn-default search-dropdown" style="text-align:left"><span
		                                            class="glyphicon glyphicon-plus" aria-hidden="true"></span>PC Info</a></li>
                                        </ul></div></td>
            
        </tr>
        <tr>
            <td id="UserID">TriPM</td>
            <td id="txtPCID${orderid}">2</td>
            <td><input id="txtStatus${orderid}" disabled="disabled" type="text" style="width:100px;" value="Free"/></td>
            <td><input id="txtStart${orderid}" disabled="disabled"  style="width:140px;" type="text"/></td>
            <td> <input id ="txtEnd${orderid}" disabled="disabled" style="width:140px;" type="text"/></td>
            <td></td>
             <td> <input id ="txtCost${orderid}" disabled="disabled"  style="width:50px;" type="text" value="10k"/></td>
            <td></td>
            
            <td class="options"><div class="dropdown" >
		                                <button type="button" class="btn btn-default dropdown-toggle" data-toggle="dropdown"
		                                    title="Action" id="menu1">
		                                    Options<span class="fa fa-caret-left"></span>
		                                </button>
		                                <ul class="dropdown-menu" role="menu" aria-labelledby="menu1"
		                                    style="left: 100%; top: -4px;">	
                                            	
									        <li><a href="#"
		                                        title="Edit Order" onclick="btnEdit('${orderid}')"
		                                        class="btn btn-default search-dropdown" style="text-align:left"><span
		                                            class="glyphicon glyphicon-plus" aria-hidden="true"></span>Add Order</a></li>
                                            <li><a href="addTeamMember?projectCode=${item.projectcode}"
		                                        title="Remove Order" onclick="btnRemove('${orderid}')"
		                                        class="btn btn-default search-dropdown" style="text-align:left"><span
		                                            class="glyphicon glyphicon-plus" aria-hidden="true"></span>Remove Order</a></li>
		                                    <li><a href="PCInfo.aspx"
		                                        title="Edit PC Info" onclick="window.location.href='PCInfo.aspx"
		                                        class="btn btn-default search-dropdown" style="text-align:left"><span
		                                            class="glyphicon glyphicon-plus" aria-hidden="true"></span>PC Info</a></li>
                                        </ul></div>
                </td>
        </tr>
        <tr>
            <td id="UserID"></td>
            <td id="txtPCID${orderid}">3</td>
            <td> <input id="txtStatus${orderid}" disabled="disabled" type="text" style="width:100px;" value="Out of Order"/></td>
            <td> <input id="txtStart${orderid}" disabled="disabled" style="width:140px;" type="text"/></td>
            <td <input id ="txtEnd${orderid}" disabled="disabled" style="width:140px;"  type="text"/></td>
            <td></td>
             <td> <input id ="txtCost${orderid}" disabled="disabled"  style="width:50px;" value="3k"/></td>
            <td></td>
            
            <td class="options"><div class="dropdown" >
		                                <button type="button" class="btn btn-default dropdown-toggle" data-toggle="dropdown"
		                                    title="Action" id="menu1">
		                                    Options<span class="fa fa-caret-left"></span>
		                                </button>
		                                <ul class="dropdown-menu" role="menu" aria-labelledby="menu1"
		                                    style="left: 100%; top: -4px;">	
                                            	
									        <li><a href="#"
		                                        title="Edit Order" onclick="btnEdit('${orderid}')"
		                                        class="btn btn-default search-dropdown" style="text-align:left"><span
		                                            class="glyphicon glyphicon-plus" aria-hidden="true"></span>Edit Order</a></li>
                                            <li><a href="addTeamMember?projectCode=${item.projectcode}"
		                                        title="Remove Order" onclick="btnRemove('${orderid}')"
		                                        class="btn btn-default search-dropdown" style="text-align:left"><span
		                                            class="glyphicon glyphicon-plus" aria-hidden="true"></span>Remove Order</a></li>
		                                    <li><a href="PCInfo.aspx"
		                                        title="Edit PC Info" onclick="window.location.href='PCInfo.aspx"
		                                        class="btn btn-default search-dropdown" style="text-align:left"><span
		                                            class="glyphicon glyphicon-plus" aria-hidden="true"></span>PC Info</a></li>
		                                    
                                        </ul></div></td>
        </tr>
            </div>
            </tbody>
    </table>
            <button type="button" class="btn btn-primary" onclick="window.history.go(0)">Refresh</button>
            <button type="button" class="btn btn-primary" onclick="window.history.go(-1)">Back</button>


</asp:Content>
