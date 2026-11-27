<%@ Application Language="VB" %>

<script runat="server">
        Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
            AddHandler DevExpress.Web.ASPxWebControl.CallbackError, AddressOf Application_Error
            DevExpress.Security.Resources.AccessSettings.DataResources.SetRules(DevExpress.Security.Resources.DirectoryAccessRule.Allow(Server.MapPath("~/Content")), DevExpress.Security.Resources.UrlAccessRule.Allow())
        End Sub
        
        Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
        End Sub
        
        Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
        End Sub
        
        Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)
        End Sub
        
        Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)
        End Sub
</script>
