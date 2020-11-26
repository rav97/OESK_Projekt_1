using OESK_Projekt_I.Database;
using OESK_Projekt_I.TestCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OESK_Projekt_I
{
    class Program
    {
        private static Tester tester;

        static void Main(string[] args)
        {
            tester = new Tester(1000);
            
            tester.GetAllCustomers_TEST();
            tester.GetAllCustomersProcedure_TEST();
            tester.GetCustomersWith7InPhone_TEST();
            tester.GetCustomersWith7InPhoneProcedure_TEST();
            tester.GetCompanyAndBoughtProduct_TEST();
            tester.GetCompanyAndBoughtProductProcedure_TEST();
            tester.GetCompanyAndGroupProduct_TEST();
            tester.GetCompanyAndGroupProductProcedure_TEST();
        }
    }
}
