using CXS.Platform.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckGoodReceiptPO
{
    class iVendQuery
    {
        public static int iVendRunQuery (string query)
        {
            var className = typeof(iVendQuery).FullName + "." + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                return Convert.ToInt32(SessionManager.Instance.ExecuteScalar(query));
            }
            catch(Exception ex)
            {

                LogGoodReceip.WriteLog(LogType.ERROR, className, ex.Message);
                return 0;
            }
        }
    }
}
