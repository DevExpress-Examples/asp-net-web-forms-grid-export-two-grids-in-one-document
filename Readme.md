<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128538425/22.2.3%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E1535)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->

# Grid View for Web Forms - How to export multiple grids into a single print document

This example shows how to use the **XtraPrinting** library to export several  [ASPxGridView](https://docs.devexpress.com/AspNet/DevExpress.Web.ASPxGridView) controls into a single XLS document.

## Implementation Details

You can export several grids into a single document in the following way:

1. Create a [PrintableComponentLinkBase](https://docs.devexpress.com/CoreLibraries/DevExpress.XtraPrintingLinks.PrintableComponentLinkBase) object for every grid.

```cs
PrintableComponentLinkBase link1 = new PrintableComponentLinkBase(ps);
link1.Component = Grid1;

PrintableComponentLinkBase link2 = new PrintableComponentLinkBase(ps);
link2.Component = Grid2;
```

2. Call the [CreateDocument](https://docs.devexpress.com/CoreLibraries/DevExpress.XtraPrinting.LinkBase.CreateDocument) method to create a document from the links, so it can be displayed or printed.

```cs
CompositeLinkBase compositeLink = new CompositeLinkBase(ps);
compositeLink.Links.AddRange(new object[] { link1, link2 });
compositeLink.CreateDocument();
```

3. Call the [PrintingSystemBase.ExportToXls](https://docs.devexpress.com/CoreLibraries/DevExpress.XtraPrinting.LinkBase.ExportToXls(System.IO.Stream)) method to export the document.

```cs
using(MemoryStream stream = new MemoryStream()) {
    compositeLink.ExportToXls(stream);
    WriteToResponse("filename", true, "xls", stream);
}
```

## Files to Review

* [Default.aspx](./CS/GridProject/Default.aspx) (VB: [Default.aspx](./VB/GridProject/Default.aspx))
* [Default.aspx.cs](./CS/GridProject/Default.aspx.cs) (VB: [Default.aspx.vb](./VB/GridProject/Default.aspx.vb))


## More Examples

* [How to export several controls to different XLSX worksheets](https://github.com/DevExpress-Examples/asp-net-web-forms-export-several-controls-to-different-sheets)
* [How to export ASPxPivotGrid and bound WebChartControl to the same print document](https://github.com/DevExpress-Examples/asp-net-web-forms-export-pivot-grid-and-chart-in-one-document)
* [How to export ASPxGridView and WebChartControl to the same print document](https://github.com/DevExpress-Examples/asp-net-web-forms-export-grid-and-chart-in-one-document)
<!-- feedback -->
## Does this example address your development requirements/objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=asp-net-web-forms-grid-export-two-grids-in-one-document&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=asp-net-web-forms-grid-export-two-grids-in-one-document&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
