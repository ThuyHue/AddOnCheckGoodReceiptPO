using System.Text;
using System.Windows.Forms;
using CXS.Retail.Extensibility;
using CXS.SubSystem.Inventory;
using DevExpress.XtraEditors;

namespace CheckGoodReceiptPO
{
    class CheckGoodreceiptPO: CXS.Retail.Extensibility.Modules.Inventory.PurchaseOrderReceiptViewModuleBase
    {
        public override void OnBeforeSave(object sender, EventArgs<GoodReceipt> args)
        {
            try
            {
                GoodReceipt good = args.Item;
                var lstDetail = good.Details;
                string query = string.Format("select U_PerentOfQuantity from CfgEnterprise");
                int count = iVendQuery.iVendRunQuery(query);
                var message = new StringBuilder();
                foreach (var item in lstDetail)
                {
                    var orderQuantity = item.QuantityOrdered;
                    var receiptQuanty = item.QuantityReceivable;
                    var orderQty1 = orderQuantity - count;
                    var orderQty2 = orderQuantity + count;
                    if (orderQty1 > receiptQuanty || receiptQuanty > orderQty2)
                    {
                        if (message.Length == 0)
                            message.AppendLine("Số lượng mặt hàng nhận không được ít hơn hoặc vượt quá " + count + " so với số lượng đặt hàng:");
                        message.AppendLine(" - Sản phẩm " + item.ProductId + ": " + item.ProductDescription);
                    }

                }
                if (message.Length > 0)
                {
                    XtraMessageBox.Show(message.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    args.Cancel = true;
                    return;
                }
            }
            catch (System.Exception ex)
            {
                var className = this.GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod().Name;
                LogGoodReceip.WriteLog(LogType.ERROR, className,ex.Message);
            }
           
        }
    }
}
