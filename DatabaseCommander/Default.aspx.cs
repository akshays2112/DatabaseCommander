using System;
using System.Web.UI;
using DBCLib;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public override void RenderControl(HtmlTextWriter writer)
    {
        base.RenderControl(writer);
        DBCLib.Server server = new DBCLib.Server();
        if (Request.QueryString["Parameter"] != null &&
            Request.QueryString["Parameter1"] != null &&
            Request.QueryString["Parameter2"] != null)
        {
            writer.Write(server.ExecuteFunctionByName(Request.QueryString["Function"],
                new object[] { Request.QueryString["Parameter"],
                Request.QueryString["Parameter1"], Request.QueryString["Parameter2"] }));
        } else if (Request.QueryString["Parameter"] != null && 
            Request.QueryString["Parameter1"] != null)
        {
            writer.Write(server.ExecuteFunctionByName(Request.QueryString["Function"],
                new object[] { Request.QueryString["Parameter"],
                Request.QueryString["Parameter1"] }));
        }
        else if (Request.QueryString["Parameter"] != null)
        {
            writer.Write(server.ExecuteFunctionByName(Request.QueryString["Function"],
                new object[] { Request.QueryString["Parameter"] }));
        } else
        {
            writer.Write(server.ExecuteFunctionByName(Request.QueryString["Function"]));
        }
    }
}
