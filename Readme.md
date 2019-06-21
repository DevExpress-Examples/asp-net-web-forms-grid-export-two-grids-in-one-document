<!-- default file list -->
*Files to look at*:

* [Default.aspx](./CS/WebSite/Default.aspx) (VB: [Default.aspx](./VB/WebSite/Default.aspx))
* [Default.aspx.cs](./CS/WebSite/Default.aspx.cs) (VB: [Default.aspx.vb](./VB/WebSite/Default.aspx.vb))
<!-- default file list end -->
# How to combine a number of ASPxGridView documents in one when exporting
<!-- run online -->
**[[Run Online]](https://codecentral.devexpress.com/e1535/)**
<!-- run online end -->



### Steps to implement (v11.1 and newer):
This example shows how to export several ASPxGridView to one XLS document. The scenario is implemented with the **DevExpress Printing.Core** library.

1. Add several ASPxGridViews to a page.
2. Add the [ASPxGridViewExporter](https://documentation.devexpress.com/AspNet/DevExpress.Web.ASPxGridViewExporter.members) component for each grid. 
3. Associate ASPxGridViewExporters with grids using the GridViewID property.
4. Create [PrintableComponentLinkBase](https://documentation.devexpress.com/CoreLibraries/DevExpress.XtraPrintingLinks.PrintableComponentLinkBase.members) objects in code behind for each grid. Use ASPxGridViewExporters as Component of these objects:
```cs
        PrintableComponentLinkBase link1 = new PrintableComponentLinkBase(ps);
        link1.Component = GridExporter1;

        PrintableComponentLinkBase link2 = new PrintableComponentLinkBase(ps);
        link2.Component = GridExporter2;
```
```vb
        Dim link1 As New PrintableComponentLinkBase(ps)
        link1.Component = GridExporter1
        Dim link2 As New PrintableComponentLinkBase(ps)
        link2.Component = GridExporter2
```
5. To combine PrintableComponentLinkBase instances, use [CompositeLinkBase](https://documentation.devexpress.com/CoreLibraries/DevExpress.XtraPrintingLinks.CompositeLinkBase.members):
```cs
  CompositeLinkBase compositeLink = new CompositeLinkBase(ps);
  compositeLink.Links.AddRange(new object[] { link1, link2 });
  compositeLink.CreateDocument();
```
```vb
  Dim compositeLink As New CompositeLinkBase(ps)
  compositeLink.Links.AddRange(New Object() { link1, link2 })
```

6. Export the CompositeLinkBase component by using the [ExportTo[FORMAT]](https://documentation.devexpress.com/CoreLibraries/DevExpress.XtraPrintingLinks.CompositeLinkBase.Class.methods) method.


### For old versions (below v11.1)
You can combine several reports in one by embedding a number of GridViewLinks (see DevExpress.Web.ASPxGridView.Export.Helper.GridViewLink) using the *CompositeLink* component.
  
### See Also:
  
### MVC Version: [How to export multiple GridViews into a single print document](https://www.devexpress.com/Support/Center/p/E3891)
[How to export several controls to different XLSX worksheets](https://www.devexpress.com/Support/Center/p/E3626)
[How to export the ASPxGridView and WebChartControl to the same print document](https://www.devexpress.com/Support/Center/p/E2226)


