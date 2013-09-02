<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="druggroupdetails.aspx.cs" Inherits="Webdev_Assignment2.Entities.druggroupdetails" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../Stylesheet/druggroup.css" rel="stylesheet" />
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></asp:ToolkitScriptManager>
    <asp:FormView ID="DoctorFormView" class="bs-example form-horizontal" runat="server"
        CellPadding="4" DataSourceID="LinqDataSource1" ForeColor="#333333" Width="999px">
        <ItemTemplate>
            <asp:Label ID="Label1" class="LabelSite" runat="server" Text="DRUG GROUP DETAILS" Font-Bold="False"></asp:Label>
            <table id="tabledetails" class="table table-striped table-bordered table-hover" >
            <tr>
                <td class="details_info"><b>Id:</b></td>
                <td class="details_info">
                    <asp:Label ID="IdLabel" runat="server" Text='<%# Bind("Id") %>' /></td>
            </tr>
            <tr>
                <td class="details_info"><b>GroupName:</b></td>
                <td class="details_info">
                    <asp:Label ID="NameLabel" runat="server" Text='<%# Bind("GroupName") %>' /></td>

            </tr>
            </table>
                <asp:Button ID="back_button" class="back_buttons btn btn-warning" runat="server" Text="Back" Width="106px" OnClick="back_button_Click"></asp:Button></td>
        </ItemTemplate>
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
    </asp:FormView>
    <asp:LinqDataSource ID="LinqDataSource1" runat="server" ContextTypeName="Webdev_Assignment2.DataBaseServerDataContext" EntityTypeName="" TableName="DrugGroups" Select="new (Id, GroupName)" Where="Id == @Id">
        <WhereParameters>
            <asp:QueryStringParameter Name="Id" QueryStringField="id" Type="Int32" />
        </WhereParameters>
    </asp:LinqDataSource>

</asp:Content>
