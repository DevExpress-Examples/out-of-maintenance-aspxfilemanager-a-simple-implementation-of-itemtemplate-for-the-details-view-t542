<%@ Page Language="vb" AutoEventWireup="true" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<%@ Register Assembly="DevExpress.Web.v15.1, Version=15.1.2.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ASPxFileManager - A simple implementation of ItemTemplate for the DetailView</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>ASPxFileManager - A simple implementation of ItemTemplate for the DetailView</h2>

            <dx:ASPxFileManager ID="ASPxFileManager1" runat="server">
                <Settings RootFolder="~\Root" ThumbnailFolder="~\Thumb\" InitialFolder="Images\Employees\" />
                <SettingsFileList View="Details" ShowFolders="true" ShowParentFolder="true">
                    <DetailsViewSettings ThumbnailHeight="75" ThumbnailWidth="75">
                        <Columns>
                            <dx:FileManagerDetailsColumn FileInfoType="Thumbnail" VisibleIndex="0"/>
                            <dx:FileManagerDetailsColumn Caption="Name">
                                <ItemTemplate>
                                    <dx:ASPxLabel runat="server" Text='<%#GetItemName(Container.Item)%>' />
                                </ItemTemplate>
                            </dx:FileManagerDetailsColumn>
                            <dx:FileManagerDetailsColumn Caption="Type">
                                <ItemTemplate>
                                    <dx:ASPxLabel runat="server" Text='<%#GetItemType(Container.Item)%>' />
                                </ItemTemplate>
                            </dx:FileManagerDetailsColumn>
                            <dx:FileManagerDetailsColumn Caption="Size">
                                <ItemTemplate>
                                    <dx:ASPxLabel runat="server" Text='<%#GetSize(Container.Item)%>' />
                                </ItemTemplate>
                            </dx:FileManagerDetailsColumn>
                        </Columns>
                    </DetailsViewSettings>
                </SettingsFileList>
            </dx:ASPxFileManager>
        </div>
    </form>
</body>
</html>