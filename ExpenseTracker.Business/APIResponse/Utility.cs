using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Business.APIResponse
{
    public class Utility
    {
        public enum CommonActions
        {
            RecordSaved = 0,
            RecordUpdated = 1,
            RecordDeleted = 2,
            Error = 3,
            InvalidValue = 4,
            UserDoesNotExists = 5,
            PasswordDoesNotMatch = 6,
            LoginFailure = 7,
            UserAlreadyLogin = 8,
            LoginSuccess = 9,
            DuplicateRecord = 10,
            Successful = 11,
            Failed = 12,
            SMSSuccessful = 13,
            EmailSendingFailed = 14,
            EmailSent = 15,
            NoRecordFound = 16,
            OTP_Expired = 17,
            OTP_DoesNotMatch = 18,
            OTP_Verified = 19,
            RecordFound = 20,
            UpgradeYourAppVersion = 21,
            Unauthorized = 22,
            UserDoesNotRegWithSwaraj = 23
        }
    }
}
