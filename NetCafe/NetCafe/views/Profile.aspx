<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="NetCafe.views.Profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ProfilePage" runat="server">
        <form>
            <table  id="content-table" align ="center">
                <tr>
                    <td>Password:</td><td class="col-md-2"></td><td> <input type="text" value=""/></td>
                </tr>
                <tr>
                    <td>Name:</td><td class="col-md-2"></td><td> <input type="text" value=""/></td>
                </tr>

                <tr>
                    <td>ID:</td><td class="col-md-2"></td><td> <input type="text" value=""/></td>
                </tr>
                <tr>
                    <td>Birthday:</td><td class="col-md-2"></td><td> <input type="text" value=""/></td>
                </tr>

                <tr>
                    <td>Address:</td><td class="col-md-2"></td><td> <input type="text" value=""/></td>
                </tr>
                <tr>
                    <td>Phone:</td><td class="col-md-2"></td><td> <input type="text" value=""/></td>
                </tr>
                <tr>
                    <td>Balance:</td><td class="col-md-2"></td><td> <input type="text" value="" disabled=""/></td>
                </tr>

            </table></br>
                   <button type="button" class="btn btn-primary">Save</button>
                   <button type="button" class="btn btn-primary" onclick="window.history.go(-1)">Back</button>
        </form>
</asp:Content>