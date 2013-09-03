<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="prescriptioninfodetails.aspx.cs" Inherits="Webdev_Assignment2.Entities.prescriptioninfodetails" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../Stylesheet/prescriptioninfo.css" rel="stylesheet" />
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></asp:ToolkitScriptManager>

    <asp:FormView ID="DoctorFormView" class="bs-example form-horizontal" runat="server"
        CellPadding="4" DataSourceID="LinqDataSource1" ForeColor="#333333" Width="999px" DataKeyNames="Id">
        <ItemTemplate>
            <asp:Label ID="Label5" class="LabelSiteSite" runat="server" Text="PRESCRIPTION INFO DETAILS" Font-Bold="False"></asp:Label>
            <table id="tabledetails" class="table table-striped table-bordered table-hover" >
            <tr>
                <td class="details_info"><b>Id:</b></td>
                <td class="details_info">
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Id") %>' /></td>
            </tr>
            <tr>
                <td class="details_info"><b>Drug Name:</b></td>
                <td class="details_info">
                    <asp:Label ID="Label4" runat="server" Text='<%# Eval("Drug.Name") %>' /></td>

            </tr>
            <tr>
                <td class="details_info"><b>Quantity:</b></td>
                <td class="details_info">
                    <asp:Label ID="NameLabel" runat="server" Text='<%# Bind("Quantity") %>' /></td>

            </tr>
            <tr>
                <td class="details_info"><b>Dose Per Day:</b></td>
                <td class="details_info">
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("DosePerDay") %>' /></td>

            </tr>
            <tr>
                <td class="details_info"><b>Special Instruction:</b></td>
                <td class="details_info">
                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("SpecialInstruction") %>' /></td>

            </tr>

            </table>
            <asp:Button ID="back_button" class="back_buttons btn btn-warning" runat="server" Text="Back" Width="106px" OnClick="back_button_Click"></asp:Button></td>
        </ItemTemplate>
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
    </asp:FormView>
    <asp:LinqDataSource ID="LinqDataSource1" runat="server" ContextTypeName="Webdev_Assignment2.DataBaseServerDataContext" EntityTypeName="" TableName="PrescriptionDetails" Where="Id == @Id">
        <WhereParameters>
            <asp:QueryStringParameter Name="Id" QueryStringField="id" Type="Int32" />
        </WhereParameters>
    </asp:LinqDataSource>

</asp:Content>
