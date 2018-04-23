using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using DevExpress.Xpo;

namespace ServerModeWithParameters {
    public partial class _Default : System.Web.UI.Page {
        DevExpress.Xpo.Session XpoSession;

        protected void Page_Init(object sender, EventArgs e) {
            XpoSession = XpoHelper.GetNewSession();
            ASPxComboBox1.DataSource = GetCustomerTypes();

            XpoDataSource1.Session = XpoSession ;
        }
        
        protected void Page_Load(object sender, EventArgs e) {
            ASPxComboBox1.DataBind();
        }

        private object GetCustomerTypes() {
            XPView view = new XPView(XpoSession, typeof(AdventureWorks.Customer));
            view.AddProperty("CustomerType", "CustomerType", true);
            return view;
        }

        protected void ASPxGridView1_BeforePerformDataSelect(object sender, EventArgs e) {
            Session["CustomerType"] = ASPxComboBox1.Text;
        }
    }
}
