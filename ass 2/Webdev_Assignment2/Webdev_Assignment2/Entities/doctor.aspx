<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="doctor.aspx.cs" Inherits="Webdev_Assignment2.Entities.doctor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../Stylesheet/doctor.css" rel="stylesheet" />
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <div id="doctorfield">

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div id="doctorsearchfield">
                    <asp:Button ID="SearchButton" class="AllSearchButtons" runat="server" Text="Search" OnClick="SearchButton_Click" />&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                    <asp:TextBox ID="SearchField" class="AllSearchFields" runat="server"></asp:TextBox>
                </div>
                <br />
                <asp:UpdateProgress ID="UpdateProgress1" class="AllUpdateProgresses" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                    <ProgressTemplate>
                        <img src="../Image/ajax-loader.gif" style="width: 147px; height: 18px" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
                <asp:GridView ID="GridView1" class="AllGridViews" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" 
                    CellPadding="4" DataKeyNames="Id" DataSourceID="LinqDataSource1" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Width="652px" >
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" SortExpression="Id" InsertVisible="False" />
                        <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                        <asp:BoundField DataField="Dob" HeaderText="Dob" SortExpression="Dob" />
                        <asp:BoundField DataField="Licensenumber" HeaderText="Licensenumber" SortExpression="Licensenumber" />
                        <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
                        <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                    </Columns>
                    <EditRowStyle BackColor="#7C6F57" />
                    <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#E3EAEB" />
                    <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F8FAFA" />
                    <SortedAscendingHeaderStyle BackColor="#246B61" />
                    <SortedDescendingCellStyle BackColor="#D4DFE1" />
                    <SortedDescendingHeaderStyle BackColor="#15524A" />
                </asp:GridView>
                <asp:LinqDataSource ID="LinqDataSource1" runat="server" ContextTypeName="Webdev_Assignment2.DataBaseServerDataContext" EnableDelete="True" EnableInsert="True" EnableUpdate="True" EntityTypeName="" TableName="Doctors" OnSelecting="LinqDataSource1_Selecting">
                </asp:LinqDataSource>
                <br />
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="NameLabel" runat="server" Text="Name:"></asp:Label>
                &nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="NameTextBox" runat="server"></asp:TextBox>
                <br />
                <br />
                &nbsp;&nbsp;&nbsp;
                <asp:Label ID="DobLabel" runat="server" Text="Date of birth:"></asp:Label>
                &nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="DateOfBirthTextBox" runat="server"></asp:TextBox>
                <br />
                <br />
                <asp:Label ID="LicenseLabel" runat="server" Text="License number:"></asp:Label>
                &nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="LicenseTextBox" runat="server"></asp:TextBox>
                <br />
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="AddressLabel" runat="server" Text="Address:"></asp:Label>
                &nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="AddressTextBox" runat="server"></asp:TextBox>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
