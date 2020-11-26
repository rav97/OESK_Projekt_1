using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OESK_Projekt_I.Database
{
    public interface IQueriesSet
    {
        long GetAllCustomers();
        long GetAllCustomersProcedure();
        long GetCustomersWith7InPhone();
        long GetCustomersWith7InPhoneProcedure();
        long GetCompanyAndBoughtProduct();
        long GetCompanyAndBoughtProductProcedure();
        long GetCompanyAndGroupProduct();
        long GetCompanyAndGroupProductProcedure();
    }
}
