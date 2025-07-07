using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Business.APIResponse
{
    public class Messages
    {
        public static string UserDoesNotExists()
        {
            return string.Format("Invalid credentials,  please try again.");
        }
        public static string Logout()
        {
            return string.Format("Logout Successfully.");
        }
        //public static string OTP_SMS_DLR(string OTP)
        //{
        //    return string.Format("<%23> Dear user, " + OTP + " is your OTP for Dealer App " + Convert.ToString(ConfigurationSettings.AppSettings["DealerApp"]));
        //}

        //public static string OTP_SMS_DLT(string OTP, string AppName, string AppLink)
        //{
        //    AppLink = Convert.ToString(ConfigurationSettings.AppSettings["DealerApp"]);
        //    return string.Format("Dear user," + OTP + " is your otp for " + AppName + " " + AppLink + " - Swaraj Tractors.");
        //}


        //public static string OTP_SMS_MGMT(string OTP)
        //{
        //    return string.Format("<%23> Dear user, " + OTP + " is your OTP for Management App " + Convert.ToString(ConfigurationSettings.AppSettings["MgmtApp"]));
        //}

        //public static string OTP_SMS_CUST(string OTP)
        //{
        //    return string.Format("<%23> Dear user, " + OTP + " is your OTP for Mera Swaraj App " + Convert.ToString(ConfigurationSettings.AppSettings["CustApp"]));
        //}

        //public static string OTP_SMS_CUST(string OTP)
        //{
        //    string abc= string.Format("<%23> Dear user,"+" "+ "{{<%23>"+ OTP  +"<%23>}}" +" is your OTP for Mera Swaraj App " + Convert.ToString(ConfigurationSettings.AppSettings["CustApp"]));
        //    return abc;
        //}

        //public static string UpgradeVersion()
        //{
        //    return string.Format("Dear user, your current running version is incompatible, Please download latest build.");
        //}

        public static string EmailSent()
        {
            return string.Format("Email has been sent succesfully");

        }

        public static string Emailfailure()
        {
            return string.Format("Failure in sending email.Please check your internet connection.");

        }

        public static string Unauthorized()
        {
            return string.Format("You are not authorized to login into this application.");
        }

        public static object UserDoesNotReg()
        {
            return string.Format("Your number is not registered");
        }

        public static string ForgotPassword(string Password, string Name)
        {
            return string.Format("Dear {0}, your password to login is {1}.", Name, Password);
            //<%23> Dear user, your login OTP:" + " " + OTP + "  " + "5h8JRknk2t8" + "";
        }
        public static string ChangesUpdatedSuccessfully()
        {
            return "Changes updated successfully";
        }
    }
}
