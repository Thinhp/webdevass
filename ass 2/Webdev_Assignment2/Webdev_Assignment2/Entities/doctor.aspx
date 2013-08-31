<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="doctor.aspx.cs" Inherits="Webdev_Assignment2.Entities.doctor" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../Stylesheet/doctor.css" rel="stylesheet" />
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnablePageMethods="true"></asp:ToolkitScriptManager>
    <div id="doctorfield">

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div id="doctorsearchfield">
                    <asp:Label class="LabelSite" runat="server" Text="DOCTOR" Font-Bold="False"></asp:Label>
                    <br />
                    <br />
                    <asp:Button ID="SearchButton" class="AllSearchButtons btn btn-default" runat="server" Text="Search" OnClick="SearchButton_Click" />

                    <asp:TextBox ID="SearchField" runat="server" class="AllSearchFields" placeholder="Search" Height="33px" Width="310px"></asp:TextBox>

                    <asp:AutoCompleteExtender ID="SearchField_AutoCompleteExtender" runat="server" TargetControlID="SearchField"
                        MinimumPrefixLength="1" CompletionInterval="10" ServiceMethod="GetCompletionList"
                        Enabled="true" CompletionSetCount="10" EnableCaching="true">
                    </asp:AutoCompleteExtender>

                </div>
                <asp:UpdateProgress ID="UpdateProgress1" class="AllUpdateProgresses" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                    <ProgressTemplate>
                        <img src="../Image/ajax-loader.gif" style="width: 147px; height: 18px" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
                <asp:GridView ID="GridView1" class="AllGridViews" OnPreRender="GridView1_PreRender" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False"
                    CellPadding="4" DataKeyNames="Id" DataSourceID="LinqDataSource1" ForeColor="#1C5E55" GridLines="None" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Width="738px" PageSize="15">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:HyperLinkField Text="View" DataNavigateUrlFields="Id" DataNavigateUrlFormatString="doctordetails.aspx?id={0}" />
                        <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" InsertVisible="False" ReadOnly="True" />
                        <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                        <asp:BoundField DataField="Dob" HeaderText="Dob" SortExpression="Dob" />
                        <asp:BoundField DataField="Licensenumber" HeaderText="Licensenumber" SortExpression="Licensenumber" />
                        <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
                        <asp:TemplateField ShowHeader="False">
                            <EditItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Update" Text="Update"></asp:LinkButton>
                                &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit" Text="Edit"></asp:LinkButton>
                                &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete" Text="Delete"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EditRowStyle BackColor="#7C6F57" />
                    <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#1C5E55" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#E3EAEB" />
                    <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F8FAFA" />
                    <SortedAscendingHeaderStyle BackColor="#246B61" />
                    <SortedDescendingCellStyle BackColor="#D4DFE1" />
                    <SortedDescendingHeaderStyle BackColor="#15524A" />
                </asp:GridView>
                <asp:LinqDataSource  ID="LinqDataSource1" runat="server" ContextTypeName="Webdev_Assignment2.DataBaseServerDataContext" EnableDelete="True" EnableInsert="True" EnableUpdate="True" EntityTypeName="" TableName="Doctors" OnSelecting="LinqDataSource1_Selecting">
                </asp:LinqDataSource>
                <div id="SuccessBoxMessage" class="AlertBoxMessage alert alert-dismissable alert-success">
                    <strong>Inserted successfull !</strong>
                </div>

                <asp:panel id="panel_insert" runat="server" class="Newbox panel panel-success" >
                    <asp:panel runat="server" class="panel-heading" style="z-index:1;">
                        <h3 class="panel-title" style="float:left;">Create new doctor</h3>
                    </asp:panel>
                    <div id="Insertplace" class="NewBoxBelow panel-body" style="display: block;">
                        <table class="table table-striped table-bordered table-hover">
                            <tr>
                                <td>
                                    <asp:Label ID="NameLabel" class="NewBoxTextLabel" runat="server" Text="Name:"></asp:Label></td>
                                <td>
                                    <asp:TextBox ID="NameTextBox" runat="server" Width="196px"></asp:TextBox>

                                    <asp:RegularExpressionValidator ID="NameValidation" runat="server" Display="Dynamic" ValidationGroup="InsertAllValidation"
                                        ForeColor="Red" Font-Bold="true" ErrorMessage="* Wrong name format" ControlToValidate="NameTextBox"
                                        ValidationExpression="^[a-zA-Z''-'\s]{1,40}$"></asp:RegularExpressionValidator>
                                    <asp:RequiredFieldValidator ID="NameValidation2" ValidationGroup="InsertAllValidation"
                                        runat="server" ErrorMessage="* Name is required" Display="Dynamic"
                                        ControlToValidate="NameTextBox" Font-Bold="true" ForeColor="Red"></asp:RequiredFieldValidator>

                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="DobLabel" class="NewBoxTextLabel" runat="server" Text="Date of birth:"></asp:Label></td>
                                <td>
                                    <asp:TextBox Enabled="false" ID="DobTextBox" runat="server" Width="196px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="DobValidation" runat="server" ValidationGroup="InsertAllValidation"
                                        ErrorMessage="* Date of birth is required"
                                        ControlToValidate="DobTextBox" Font-Bold="true" ForeColor="Red"></asp:RequiredFieldValidator>
                                    <br />
                                    <br />
                                    <asp:Calendar ID="DobCalendar" runat="server"
                                        OnSelectionChanged="DobCalendar_SelectionChanged"
                                        
                                        Height="175px" Width="300px"></asp:Calendar>

                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="LicenseLabel" class="NewBoxTextLabel" runat="server" Text="License number:"></asp:Label></td>
                                <td>
                                    <asp:TextBox ID="LicenseTextBox" runat="server" Width="196px"></asp:TextBox>

                                    <asp:RequiredFieldValidator ID="LicenseValidation" runat="server" ValidationGroup="InsertAllValidation"
                                        Font-Bold="true" ForeColor="Red" ControlToValidate="LicenseTextBox"
                                        ErrorMessage="*License number is required"></asp:RequiredFieldValidator>

                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="AddressLabel" class="NewBoxTextLabel" runat="server" Text="Address:"></asp:Label></td>
                                <td>
                                    <asp:TextBox ID="AddressTextBox" runat="server" Width="196px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="AddressValidation" runat="server" ValidationGroup="InsertAllValidation"
                                        ForeColor="Red" Font-Bold="true" ControlToValidate="AddressTextBox"
                                        ErrorMessage="*Address is required"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <td>
                                        <asp:Button ID="InsertButton" ValidationGroup="InsertAllValidation" class="btn btn-success" runat="server" OnClick="InsertButton_Click" Text="Insert" Width="106px"></asp:Button></td>
                            </tr>
                        </table>

                    </div>
                </asp:panel>
                <br />
                <br />

            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
