<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="NetCafe.views.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="RegisterPage" runat="server">
        <form>
            <table id="content-table" align="center">
                <tr>
                    <td>UserID:</td><td class="col-md-2"></td> <td> <input type="text" value=""/></td>
                </tr>

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

            </table></br>
                   <button type="button" class="btn btn-primary">Register</button>
                   <button type="button" class="btn btn-primary" onclick="window.history.go(-1)">Back</button>
        </form>
</asp:Content>