Imports DevExpress.Web
Imports System
Imports System.Collections.Generic
Imports System.IO
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Partial Public Class _Default
    Inherits System.Web.UI.Page


    Private extensionsDisplayName_Renamed As Dictionary(Of String, String)

    Private ReadOnly Property ExtensionsDisplayName() As Dictionary(Of String, String)
        Get
            If extensionsDisplayName_Renamed Is Nothing Then
                extensionsDisplayName_Renamed = New Dictionary(Of String, String)()
                extensionsDisplayName_Renamed.Add(".txt", "Text Document (.txt)")
                extensionsDisplayName_Renamed.Add(".rtf", "Rich Text Document (.rtf)")
                extensionsDisplayName_Renamed.Add(".xml", "XML File (.xml)")
                extensionsDisplayName_Renamed.Add(".png", "PNG image (.png)")
                extensionsDisplayName_Renamed.Add(".jpg", "JPEG image (.jpg)")
                extensionsDisplayName_Renamed.Add(".mp3", "MPEG Layer 3 Audio File (.mp3)")
                extensionsDisplayName_Renamed.Add(".avi", "AVI File (.avi)")
                extensionsDisplayName_Renamed.Add(".zip", "Compressed (zipped) Folder (.zip)")
            End If
            Return extensionsDisplayName_Renamed
        End Get
    End Property

    Public Function GetItemName(ByVal item As FileManagerItem) As String
        If item Is Nothing Then
            Return String.Empty
        End If
        Dim file As FileManagerFile = TryCast(item, FileManagerFile)
        If file IsNot Nothing Then
            Return Path.GetFileNameWithoutExtension(file.RelativeName)
        Else
            Return item.Name
        End If
    End Function
    Public Function GetItemType(ByVal item As FileManagerItem) As String
        If item Is Nothing Then
            Return String.Empty
        End If
        Dim file As FileManagerFile = TryCast(item, FileManagerFile)
        If file IsNot Nothing Then
            If ExtensionsDisplayName.ContainsKey(file.Extension) Then
                Return ExtensionsDisplayName(file.Extension)
            End If
        Else
            Return If(item.Name.Equals(".."), String.Empty, "Folder")
        End If
        Return String.Empty
    End Function

    Public Function GetSize(ByVal item As FileManagerItem) As String
        If item Is Nothing Then
            Return String.Empty
        End If
        Dim folder As FileManagerFolder = TryCast(item, FileManagerFolder)
        If folder IsNot Nothing Then
            If folder.Name.Equals("..") Then
                Return String.Empty
            Else
                Return String.Format("{0:f} Kb", CountFolderSize(folder) / 1024)
            End If
        End If
        Return item.Length \ 1024 & " Kb"
    End Function

    Private Function CountFolderSize(ByVal folder As FileManagerFolder, Optional ByVal length As Single = 0) As Single
        Dim files() As FileManagerFile = folder.GetFiles()
        For Each file As FileManagerFile In files
            length += file.Length
        Next file

        Dim folders() As FileManagerFolder = folder.GetFolders()
        For Each childFolder As FileManagerFolder In folders
            length = CountFolderSize(childFolder, length)
        Next childFolder
        Return length
    End Function
End Class