<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="NetCafe.views.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="LoginPage" runat="server">        
        <form >
            <table  id="content-table" align ="center">
                <tr>
                    <td>UserID:</td><td class="col-md-2"></td><td> <input type="text" value=""/></td>
                </tr>
                <tr>
                    <td>Password:</td><td class="col-md-2"></td><td> <input type="text" value=""/></td>
                </tr>
            </table>
            <a href="#">Holy sh*t I forgot my password<a></br></br>
                   <button type="button" class="btn btn-primary">Login</button>
                   <button type="button" class="btn btn-primary" onclick="window.history.go(-1)">Back</button>
        </form>
</asp:Content>