<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128598175/13.1.4%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E843)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [Form1.cs](./CS/E843/Form1.cs) (VB: [Form1.vb](./VB/E843/Form1.vb))
* [XtraReport1.cs](./CS/E843/XtraReport1.cs) (VB: [XtraReport1.vb](./VB/E843/XtraReport1.vb))
<!-- default file list end -->
# How to access data row values from the HtmlItemCreated event


<p><strong>Description</strong>:<br />
I want to create a dynamic hyperlink on each line in a report that utilizes some data from that line.  For instance, each data element has an "id" field that uniquely defines it.  I would like to take the value of that "id" field and generate a hyperlink that will be linked to another page in my system.</p><p>Id Name<br />
-----------------------------<br />
1 Williams<br />
2 Smith</p><p>A hyperlink should be as follows, where the "id" parameter value corresponds to the Id field value in my database for a given row:<br />
http://www.testarea.com/property.aspx?id=1"</p>

<p>I have looked at the HtmlItemCreated event, but could not access the Id field value from it.</p><p><strong>Solution</strong>:<br />
Data row values are unavailable from the HtmlItemCreated event.  You will need to write a BeforePrint event hander for the object for which you handle the HtmlItemCreated event and set the desired values to the object's Tag property.  Then, you will be able to extract them from the e.Data.Tag parameter of the HtmlItemCreated event.</p><p></p>

```cs
private void xrLabel1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)        
{            
	((XRLabel)sender).Tag = GetCurrentColumnValue("ID");        
}

private void xrLabel1_HtmlItemCreated(object sender, HtmlEventArgs e)        
{            
	e.ContentCell.InnerHtml = String.Format("<a href=http://www.testarea.com/property.aspx?id={1}>{0}</a>", e.ContentCell.InnerText, e.Brick.Value);        
}
```

<p> </p>

<br/>


