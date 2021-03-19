using CXS.Retail.Extensibility;
using System;


namespace CheckGoodReceiptPO
{
    class Plugin : BasePlugin // nếu để public class (version 6.6) khi restart MC sẽ bị lỗi
    {
        public override string Name
        {
            get { return "CheckGoodReceiptPO"; }
        }

        public override string Description
        {
            get { return "Check Good Receipt PO"; }
        }

        public override string CompanyName
        {
            get { return "FTI Trading"; }
        }

        public override Version VersionInfo
        {
            get { return new Version("1.0.0.4"); }
        }
        public override void Start()
        {
            base.Start();
        }
    }
}
