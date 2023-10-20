using System;
using System.Web.UI;
using System.IO;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrintingLinks;

public partial class _Default : System.Web.UI.Page {
    protected void ExportButton_Click(object sender, EventArgs e) {
        PrintingSystemBase ps = new PrintingSystemBase();

        PrintableComponentLinkBase link1 = new PrintableComponentLinkBase(ps);
        link1.Component = Grid1;

        PrintableComponentLinkBase link2 = new PrintableComponentLinkBase(ps);
        link2.Component = Grid2;

        CompositeLinkBase compositeLink = new CompositeLinkBase(ps);
        compositeLink.Links.AddRange(new object[] { link1, link2 });

        compositeLink.CreateDocument();
        using (MemoryStream stream = new MemoryStream()) {
            compositeLink.ExportToXls(stream);
            WriteToResponse("filename", true, "xls", stream);
        }
        ps.Dispose();
    }
    void WriteToResponse(string fileName, bool saveAsFile, string fileFormat, MemoryStream stream) {
        if (Page == null || Page.Response == null)
            return;
        string disposition = saveAsFile ? "attachment" : "inline";
        Page.Response.Clear();
        Page.Response.Buffer = false;
        Page.Response.AppendHeader("Content-Type", string.Format("application/{0}", fileFormat));
        Page.Response.AppendHeader("Content-Transfer-Encoding", "binary");
        Page.Response.AppendHeader("Content-Disposition",
            string.Format("{0}; filename={1}.{2}", disposition, fileName, fileFormat));
        Page.Response.BinaryWrite(stream.GetBuffer());
        Page.Response.End();
    }
}