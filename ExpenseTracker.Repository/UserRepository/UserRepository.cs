
using ExpenseTracker.Business.User;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Azure.Core.HttpHeader;

namespace ExpenseTracker.Repository.UserRepository
{
    public class UserRepository : IUserRepository
    {
        public LoginDetails CheckLogin(string username, string password)
        {
            
            
            LoginDetails loggedInUser = null;
            try
            {
                DbParam[] param = new DbParam[2];
                param[0] = new DbParam("@user_name", username, SqlDbType.VarChar);
                param[1] = new DbParam("@password", password, SqlDbType.VarChar);
                DataSet dataSet = Db.GetDataSet("usp_Cc_Check_User_Login", param);

                if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                {
                    loggedInUser = new LoginDetails();
                    DataRow row = dataSet.Tables[0].Rows[0];
                    if (Db.ToInteger(row["UserId"]) != null)
                    {
                        loggedInUser.UserId = Db.ToString(row["UserId"]);
                        loggedInUser.RoleId = Db.ToString(row["RoleId"]);
                        loggedInUser.UserRole = Db.ToString(row["RoleName"]);
                        loggedInUser.UserName = Db.ToString(row["FName"] + " " + row["LName"]);
                        loggedInUser.Email = Db.ToString(row["Email"]);
                        DbParam[] paramOtp = new DbParam[2];
                        int results = 0;
                        DataRow row1;
                        string otp = "";
                        //string new_otp = Common.Common.RandomString(6);
                        //string enOtp = Common..Encrypt(new_otp);
                        //paramOtp[0] = new DbParam("@UserId", loggedInUser.UserId, SqlDbType.Int);
                        //paramOtp[1] = new DbParam("@new_otp", enOtp, SqlDbType.NVarChar);
                        //row1 = Db.GetDataRow("usp_api_get_login_otp_for_cc", paramOtp);
                        //if (row1 != null)
                        //{
                        //    results = Db.ToInteger(row1["otp_id"]);
                        //    otp = Db.ToString(row1["otp"]);
                        //    otp = Common.Common.IsEncrypted(otp) ? Common.Common.Decrypt(otp) : otp;
                        //    loggedInUser.OTP = otp;
                        //    loggedInUser.OTPID = results;
                        //    //SwarajUtility
                        //    SwarajUtility.SendEmailOTP.SendCommonEmailCDMS(Db.ToString(row1["Email"]), Db.ToString(row1["EmailCC"]), Db.ToString(row1["EmailBCC"]), Db.ToString(row1["SubjectHeading"]), Db.ToString(row1["EmailBody"]).Replace("@OTP@", otp), "", Db.ToString(row1["DisplayName"]));
                        //    //int dt = SwarajUtility.SendEmailOTP.SendCommonEmailCDMS(Db.ToString(row1["Email"]), Db.ToString(row1["EmailCC"]), Db.ToString(row1["EmailBCC"]), Db.ToString(row1["SubjectHeading"]), Db.ToString(row1["EmailBody"]).Replace("@OTP@", otp), "", Db.ToString(row1["DisplayName"]));

                        //}
                    }
                }
            }
            catch(Exception ex)
            {
                Common.Logger.LogError(ex.Message);
            }
            return loggedInUser;
        }
    }
}
