using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace E843
{
    public partial class XtraReport1 : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReport1()
        {
            InitializeComponent();

            dataSet1.Tables[0].Rows.Add(new Object[]{1, "Williams"});
            dataSet1.Tables[0].Rows.Add(new Object[]{2, "Smith" });
        }

        private void xrLabel1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            ((XRLabel)sender).Tag = GetCurrentColumnValue("ID");
        }

        private void xrLabel1_HtmlItemCreated(object sender, HtmlEventArgs e)
        {
            e.ContentCell.InnerHtml = String.Format("<a href=http://www.testarea.com/property.aspx?id={1}>{0}</a>", e.ContentCell.InnerText, e.Brick.Value);
        }
    }
}
