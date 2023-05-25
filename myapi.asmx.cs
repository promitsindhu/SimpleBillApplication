using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace SimpleBillApplication
{
    /// <summary>
    /// Summary description for myapi
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class myapi : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public clsbill getmybilldata(string ssbillno)
        {
            return clsbill.getdata(ssbillno);
        }


        [WebMethod]
        public bool savemydata(clsbill mybilldata)
        {
            return clsbill.savedata(mybilldata);
        }

        [WebMethod]
        public clsclient getmyblurdata(string ccode)
        {
            return clsclient.getclientdata(ccode);
        }
        [WebMethod]
        public clsItem itemblurdata(string item)
        {
            return clsItem.getitemdata(item);
        }

        [WebMethod]
        public clsModal showdatainmodel(string ii)
        {
            return clsModal.showData();
        }

        [WebMethod]
        public clsItem additemdata(string itemCode)
        {
            return clsItem.getitemdata(itemCode);
        }
    }
}
