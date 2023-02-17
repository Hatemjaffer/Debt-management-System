using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMM.BL
{                                   //الغرض من هذ الواظيفة عمل تحديث للموردين
   public class UPDATE
    {
        //DataBae and Table
        DBDMMEntities db;
        TB_Suppliers tbSupplier;
        Payment_Suppliers tbPayment;
        Debit_Suppliers tbdbebit;

        //
        int id;
        double Payment;
        double Debit;
        double PaymentRs;

        public void SupplierDataUpdate()
        {
            try
            {
                db = new DBDMMEntities();
                var SupplierIDList = db.TB_Suppliers.Select(x => x.ID).ToArray();
                for(int i=0 ; i<SupplierIDList.Length ; i++)
                {
                    id = SupplierIDList[i];
                                             // هدي خدينها من log_suppliers من دالة DebitPaymentCal()
                    
                        //Get Debit
                        Debit = (double)db.Debit_Suppliers.Where(x => x.ID_Supplier == id).Select(x => x.Debit).ToArray().Sum();
                        Payment = (double)db.Payment_Suppliers.Where(x => x.ID_Supplier == id).Select(x => x.Payment).ToArray().Sum();
                        PaymentRs = Debit - Payment;

                    tbSupplier = db.TB_Suppliers.Where(x => x.ID == id).FirstOrDefault();
                    tbSupplier.Debit = PaymentRs;
                    db.Entry(tbSupplier).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();


                      
                }
            }
            catch { }
        }
        public void CustomerDataUpdate()
        {
            try
            {
                db = new DBDMMEntities();
                var SupplierIDList = db.TB_Customers.Select(x => x.ID).ToArray();
                for (int i = 0; i < SupplierIDList.Length; i++)
                {
                    id = SupplierIDList[i];
                    // هدي خدينها من log_suppliers من دالة DebitPaymentCal()

                    //Get Debit
                    Debit = (double)db.Debit_Oustomer.Where(x => x.ID_Supplier == id).Select(x => x.Debit).ToArray().Sum();
                    Payment = (double)db.PaymentCustomers.Where(x => x.ID_Supplier == id).Select(x => x.Payment).ToArray().Sum();
                    PaymentRs = Debit - Payment;

                 var   tbcustomer = db.TB_Customers.Where(x => x.ID == id).FirstOrDefault(); // changed var ....
                    tbcustomer.Debit = PaymentRs;
                    db.Entry(tbcustomer).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();



                }
            }
            catch { }
        }
    }
}
