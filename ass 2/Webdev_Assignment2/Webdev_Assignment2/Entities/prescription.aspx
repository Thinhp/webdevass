<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="prescription.aspx.cs" Inherits="Webdev_Assignment2.Entities.prescription" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></asp:ToolkitScriptManager>
    <link href="../Stylesheet/prescrition.css" rel="stylesheet" />
    <div id="drugfield">

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div id="drugsearchfield">
                    <asp:Label ID="Label1" class="LabelSite" runat="server" Text="PRESCRIPTION " Font-Bold="False"></asp:Label>
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
                    CellPadding="4" ForeColor="#1C5E55" GridLines="None" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Width="800px" PageSize="15" DataKeyNames="id" DataSourceID="LinqDataSource1">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:HyperLinkField Text="View" ControlStyle-CssClass="btn btn-warning btn-xs" DataNavigateUrlFields="Id" DataNavigateUrlFormatString="prescriptiondetails.aspx?id={0}" >
                            <ControlStyle CssClass="btn btn-warning btn-xs" />
                        </asp:HyperLinkField>
                        <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
                        <asp:TemplateField HeaderText="Date" SortExpression="Date">
                            <EditItemTemplate>
                                  <asp:TextBox ID="DateCol" runat="server" Text='<%# Bind("Date") %>'></asp:TextBox>

                            </EditItemTemplate>
                            <ItemTemplate>
                                 <asp:Label ID="Label3" runat="server" Text='<%# Bind("Date") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="PrescribedDoctor" SortExpression="PrescribedDoctor">
                                                    <EditItemTemplate>
                                <%--<asp:DropDownList ID="PrescriptChange"
                                                  DataSourceID="LinqDataSource3"
                                                  DataValueField="Id"
                                                  DataTextField="DrugId"
                                                  SelectedValue='<%# Bind("PrescriptionDetailsId") %>'
                                                  runat="server"/>--%>
                                <asp:DropDownList ID="DoctorChange" runat="server" 
                                    DataSourceID="LinqDataSource2" 
                                    DataTextField="Name" 
                                    DataValueField="Id" 
                                    SelectedValue='<%# Bind("PrescribedDoctor") %>' />
                            </EditItemTemplate>
                            <ItemTemplate>
                                <%--<asp:Label ID="Label1" runat="server" Text='<%# Bind("PrescribedDoctor") %>'></asp:Label>--%>
                                <%# Eval("Doctor.Name") %>
                            </ItemTemplate>
                        
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="PrescriptionDetailsId" SortExpression="PrescriptionDetailsId">

                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("PrescriptionDetailsId") %>'></asp:TextBox>
                                <%--<asp:DropDownList ID="PrescriptChange"
                                                  DataSourceID="LinqDataSource3"
                                                  DataValueField="Id"
                                                  DataTextField="DrugId"
                                                  SelectedValue='<%# Bind("PrescriptionDetailsId") %>'
                                                  runat="server"/>--%>
                                
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("PrescriptionDetailsId") %>'></asp:Label>
                                
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
                <asp:LinqDataSource ID="LinqDataSource1" runat="server" ContextTypeName="Webdev_Assignment2.DataBaseServerDataContext" EntityTypeName="" TableName="Prescriptions" OnSelecting="LinqDataSource1_Selecting" EnableDelete="True" EnableInsert="True" EnableUpdate="True">
                </asp:LinqDataSource>
                <asp:LinqDataSource ID="LinqDataSource3" runat="server" ContextTypeName="Webdev_Assignment2.DataBaseServerDataContext" TableName="PrescriptionDetails" EntityTypeName="">
                </asp:LinqDataSource>
                <asp:LinqDataSource ID="LinqDataSource2" runat="server" ContextTypeName="Webdev_Assignment2.DataBaseServerDataContext" TableName="Doctors" EntityTypeName="">
                </asp:LinqDataSource>
                <div id="SuccessBoxMessage" class="AlertBoxMessage alert alert-dismissable alert-success">
                    <strong>Inserted successfull !</strong>
                </div>

                <asp:Panel ID="panel_insert" runat="server" class="Newbox panel panel-success">
                    <asp:Panel ID="Panel1" runat="server" class="panel-heading" Style="z-index: 1;">
                        <h3 class="panel-title" style="float: left;">Create new drug</h3>
                    </asp:Panel>
                    <div id="Insertplace" class="NewBoxBelow panel-body" style="display: block;">
                        <table class="table table-striped table-bordered table-hover">
                            <tr>
                                <td>
                                    <asp:Label ID="DateLabel" class="NewBoxTextLabel" runat="server" Text="Date:"></asp:Label></td>
                                <td>
                                    <asp:TextBox ID="DateTextBox" runat="server" Width="196px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="DobValidation" runat="server" ValidationGroup="InsertAllValidation"
                                        ErrorMessage="* Date is required"
                                        ControlToValidate="DateTextBox" Font-Bold="true" ForeColor="Red"></asp:RequiredFieldValidator>
                                    <asp:CalendarExtender ID="CalendarExtender2" Format="dd-MM-yyyy" runat="server" TargetControlID="DateTextBox"></asp:CalendarExtender>


                                </td>
                            </tr>

                            <tr>
                                <td>
                                    <asp:Label ID="DoctorLabel" class="NewBoxTextLabel" runat="server" Text="Doctor :"></asp:Label></td>
                                <td>
                                    <asp:DropDownList ID="DoctorTextBox" runat="server" Width="106px">
                                        <asp:ListItem></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="GenderValidation" runat="server" ValidationGroup="InsertAllValidation"
                                        Font-Bold="true" ForeColor="Red" ControlToValidate="DoctorTextBox"
                                        ErrorMessage="*Doctor is required"></asp:RequiredFieldValidator>

                                </td>
                            </tr>

                            <tr>
                                <td>
                                    <asp:Label ID="Prescrition" class="NewBoxTextLabel" runat="server" Text="Prescription info id:"></asp:Label></td>
                                <td>
                                    <asp:DropDownList ID="PresDropDown" runat="server" Width="106px">
                                        <asp:ListItem></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="InsertAllValidation"
                                        Font-Bold="true" ForeColor="Red" ControlToValidate="PresDropDown"
                                        ErrorMessage="Prescription id is required"></asp:RequiredFieldValidator>

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
