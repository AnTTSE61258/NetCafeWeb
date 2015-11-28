<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="PCInfo.aspx.cs" Inherits="NetCafe.views.PCInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PCInfoPage" runat="server">
        <form>
            <table  id="content-table" align="center">
                <tr>
                    <td>PC.No:</td><td class="col-md-2"></td><td> <input type="text" value="" disabled=""/></td>
                </tr>
                
                    <td>Status:</td><td class="col-md-2"></td><td> <input type="text" value="" disabled=""/></td>
                
            </table></br>
                    Descripsion</br><br />
            <textarea disabled="" style="resize: none;overflow:auto">I7 Q3650 GT660m</textarea>
            </br></br>
                   <button type="button" class="btn btn-primary">Save</button>
                   <button type="button" class="btn btn-primary">Modify(if supervisor)</button>
                   <button type="button" class="btn btn-primary" onclick="window.history.go(-1)">Back</button>
        </form>
</asp:Content>