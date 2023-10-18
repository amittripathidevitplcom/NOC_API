﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RJ_NOC_Model
{
    public class PaymentGatewayDataModel
    {

        public int ID { get; set; }
        public int PaymentGateway { get; set; }
        public string PaymentGatewayName { get; set; }
        public string PaymentRequestURL { get; set; }
        public string MerchantCode { get; set; }
        public string CheckSumKey { get; set; }
        public string ENCRYPTIONKEY { get; set; }
        public string SuccessURL { get; set; }
        public string FailureURL { get; set; }

        public string CencelURL { get; set; }
        public string RedirectURL { get; set; }

        public string VerificationURL { get; set; }
        public string RefundURL { get; set; }
        public string CallBackURL { get; set; }
        public string RefundStatusURL { get; set; }
        public string TransactionListURL { get; set; }
        public bool IsActive { get; set; }
        public int DepartmentID { get; set; }


    }

    public enum enmPaymentGatway
    {
        RPP = 1
    }
}
