<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="icd.aspx.cs" Inherits="Webdev_Assignment2.Entities.icd" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></asp:ToolkitScriptManager>
    <link href="../Stylesheet/icd.css" rel="stylesheet" />
    <div id="icdfield">

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div id="icdsearchfield">
                    <asp:Label ID="Label1" class="LabelSite" runat="server" Text="ICD" Font-Bold="False"></asp:Label>
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
                    CellPadding="4" DataKeyNames="Code" DataSourceID="LinqDataSource1" ForeColor="#1C5E55" GridLines="None" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Width="800px" PageSize="15">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:HyperLinkField Text="View" ControlStyle-CssClass="btn btn-warning btn-xs" DataNavigateUrlFields="Code" DataNavigateUrlFormatString="icddetails.aspx?id={0}" >
                            <ControlStyle CssClass="btn btn-warning btn-xs" />
                        </asp:HyperLinkField>
                        <asp:BoundField DataField="Code" HeaderText="Code" SortExpression="Code" ReadOnly="True" />
                        <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" >
                            </asp:BoundField>
                        <asp:TemplateField HeaderText="Chapter" SortExpression="ICDChapterId">
                            <EditItemTemplate>
                                <%--<asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("ICDChapterId") %>'></asp:TextBox>--%>

                                <asp:DropDownList ID="DrugGroupChange"
                                                  DataSourceID="LinqDataSource2"
                                                  DataValueField="Id"
                                                  DataTextField="Name"
                                                  SelectedValue='<%# Bind("ICDChapterId") %>'
                                                  runat="server"/>

                            </EditItemTemplate>
                            <ItemTemplate>
                                <%--<asp:Label ID="Label1" runat="server" Text='<%# Bind("ICDChapterId") %>'></asp:Label>--%>
                                <%# Eval("ICDChapter.Name") %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ShowHeader="False">
                            <EditItemTemplate>
                                <asp:LinkButton ID="LinkButton1" CssClass="btn btn-warning btn-sm" runat="server" CausesValidation="True" CommandName="Update" Text="Update"></asp:LinkButton>
                                &nbsp;<asp:LinkButton ID="LinkButton2" CssClass="btn btn-default btn-sm" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" CssClass="btn btn-primary btn-sm" runat="server" CausesValidation="False" CommandName="Edit" Text="Edit"></asp:LinkButton>
                                &nbsp;<asp:LinkButton ID="LinkButton2" CssClass="btn btn-danger btn-sm" runat="server" CausesValidation="False" CommandName="Delete" Text="Delete"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EditRowStyle BackColor="#7C6F57" HorizontalAlign="Left" />
                    <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#1C5E55" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#E3EAEB" />
                    <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F8FAFA" />
                    <SortedAscendingHeaderStyle BackColor="#246B61" />
                    <SortedDescendingCellStyle BackColor="#D4DFE1" />
                    <SortedDescendingHeaderStyle BackColor="#15524A" />
                    <EditRowStyle CssClass="edit_rows_style" /> 
                </asp:GridView>
                <asp:LinqDataSource ID="LinqDataSource1" runat="server" ContextTypeName="Webdev_Assignment2.DataBaseServerDataContext" EnableDelete="True" EnableInsert="True" EnableUpdate="True" EntityTypeName="" TableName="ICDs" OnSelecting="LinqDataSource1_Selecting">
                </asp:LinqDataSource>
                <asp:LinqDataSource ID="LinqDataSource2" runat="server" ContextTypeName="Webdev_Assignment2.DataBaseServerDataContext" EntityTypeName="" TableName="ICDChapters"></asp:LinqDataSource>

                <div id="SuccessBoxMessage" class="AlertBoxMessage alert alert-dismissable alert-success">
                    <strong>Inserted successfull !</strong>
                </div>

                <asp:Panel ID="panel_insert" runat="server" class="Newbox panel panel-success">
                    <asp:Panel ID="Panel1" runat="server" class="panel-heading" Style="z-index: 1;">
                        <h3 class="panel-title" style="float: left;">Create new doctor</h3>
                    </asp:Panel>
                    <div id="Insertplace" class="NewBoxBelow panel-body" style="display: block;">
                        <table class="table table-striped table-bordered table-hover">
                            <tr>
                                <td>
                                    <asp:Label ID="Label2" class="NewBoxTextLabel" runat="server" Text="Code:"></asp:Label></td>
                                <td>
                                    <asp:TextBox ID="CodeBox" runat="server" Width="196px"></asp:TextBox>

                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Display="Dynamic" ValidationGroup="InsertAllValidation"
                                        ForeColor="Red" Font-Bold="true" ErrorMessage="* Wrong Code format (xxx-xxx) (i.e. A00-B99)" ControlToValidate="CodeBox"
                                        ValidationExpression="^[a-zA-Z0-9]{3}-[a-zA-Z0-9]{3}$"></asp:RegularExpressionValidator>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="InsertAllValidation"
                                        runat="server" ErrorMessage="* ICD Code is required" Display="Dynamic"
                                        ControlToValidate="CodeBox" Font-Bold="true" ForeColor="Red"></asp:RequiredFieldValidator>

                                </td>
                            </tr>
                            
                            <tr>
                                <td>
                                    <asp:Label ID="NameLabel" class="NewBoxTextLabel" runat="server" Text="ICD Name:"></asp:Label></td>
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
                                    <asp:Label ID="Label3" class="NewBoxTextLabel" runat="server" Text="Chapter:"></asp:Label></td>
                                <td>
                                    <asp:DropDownList ID="ICDChapterDropDown" runat="server" Width="106px">
                                        <asp:ListItem></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                        ValidationGroup="InsertAllValidation" 
                                        ont-Bold="true" ForeColor="Red" ControlToValidate="ICDChapterDropDown"
                                        ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>

                                </td>
                            </tr>
                            
                            <tr>
                                <td>
                                    <td>
                                        <asp:Button ID="InsertButton" ValidationGroup="InsertAllValidation" class="btn btn-success" runat="server" OnClick="InsertButton_Click" Text="Insert" Width="106px"></asp:Button></td>
                            </tr>
                        </table>

                    </div>
                </asp:Panel>
                <br />
                <br />

            </ContentTemplate>
        </asp:UpdatePanel>
    </div>

</asp:Content>
