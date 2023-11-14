Imports System
Imports System.Web.UI
Imports System.IO
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraPrintingLinks

Partial Public Class _Default
	Inherits System.Web.UI.Page

	Protected Sub ExportButton_Click(ByVal sender As Object, ByVal e As EventArgs)
		Dim ps As New PrintingSystemBase()

		Dim link1 As New PrintableComponentLinkBase(ps)
		link1.Component = Grid1

		Dim link2 As New PrintableComponentLinkBase(ps)
		link2.Component = Grid2

		Dim compositeLink As New CompositeLinkBase(ps)
		compositeLink.Links.AddRange(New Object() { link1, link2 })

		compositeLink.CreateDocument()
		Using stream As New MemoryStream()
			compositeLink.ExportToXls(stream)
			WriteToResponse("filename", True, "xls", stream)
		End Using
		ps.Dispose()
	End Sub
	Private Sub WriteToResponse(ByVal fileName As String, ByVal saveAsFile As Boolean, ByVal fileFormat As String, ByVal stream As MemoryStream)
		If Page Is Nothing OrElse Page.Response Is Nothing Then
			Return
		End If
		Dim disposition As String = If(saveAsFile, "attachment", "inline")
		Page.Response.Clear()
		Page.Response.Buffer = False
		Page.Response.AppendHeader("Content-Type", String.Format("application/{0}", fileFormat))
		Page.Response.AppendHeader("Content-Transfer-Encoding", "binary")
		Page.Response.AppendHeader("Content-Disposition", String.Format("{0}; filename={1}.{2}", disposition, fileName, fileFormat))
		Page.Response.BinaryWrite(stream.GetBuffer())
		Page.Response.End()
	End Sub
End Class