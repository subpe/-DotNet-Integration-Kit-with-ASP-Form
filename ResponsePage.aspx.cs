using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Collections.Specialized;
using System.Configuration;
using MerchantAPI;
using System.Security.Cryptography;

public partial class ResponsePage : System.Web.UI.Page
{
    Boolean verifyHash;
    string salt = "";
    
    MerchantAPI.ChecksumCalculator objCalc = new MerchantAPI.ChecksumCalculator();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            salt = ConfigurationSettings.AppSettings["saltValue"].ToString();
            verifyHash = objCalc.verifyHash(Request.Form, salt);
            if (verifyHash == false)
            {
                lblResponse.Text = "Checksum Mismatched";
            }
            else
            {
                lblResponse.Text = Request.Params.Get("RESPONSE_MESSAGE");
            }


        }
        catch (Exception ex)
        {
            lblResponse.Text = "Checksum Mismatched";
        }
    }
}