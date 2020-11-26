using OESK_Projekt_I.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OESK_Projekt_I.TestCases
{
    public class Tester
    {
        private ADO_Queries ADO;
        private EF_Queries EF;

        private int numberOfTests;

        public Tester(int num)
        {
            ADO = new ADO_Queries();
            EF = new EF_Queries();

            ADO.GetAllCustomers();
            EF.GetAllCustomers();

            numberOfTests = num;
        }

        public void GetAllCustomers_TEST()
        {
            CsvWriter writer = new CsvWriter("GetAllCustomers.csv", "l.p", "ADO", "EF");

            for(int i = 1; i <= numberOfTests; i++)
            {
                writer.WriteLine(i, ADO.GetAllCustomers(), EF.GetAllCustomers());
                GC.Collect();
            }
            writer.Save();
        }

        public void GetAllCustomersProcedure_TEST()
        {
            CsvWriter writer = new CsvWriter("GetAllCustomersProcedure.csv", "l.p", "ADO", "EF");

            for (int i = 1; i <= numberOfTests; i++)
            {
                writer.WriteLine(i, ADO.GetAllCustomersProcedure(), EF.GetAllCustomersProcedure());
                GC.Collect();
            }
            writer.Save();
        }

        public void GetCustomersWith7InPhone_TEST()
        {
            CsvWriter writer = new CsvWriter("GetCustomersWith7InPhone.csv", "l.p", "ADO", "EF");

            for (int i = 1; i <= numberOfTests; i++)
            {
                writer.WriteLine(i, ADO.GetCustomersWith7InPhone(), EF.GetCustomersWith7InPhone());
                GC.Collect();
            }
            writer.Save();
        }

        public void GetCustomersWith7InPhoneProcedure_TEST()
        {
            CsvWriter writer = new CsvWriter("GetCustomersWith7InPhoneProcedure.csv", "l.p", "ADO", "EF");

            for (int i = 1; i <= numberOfTests; i++)
            {
                writer.WriteLine(i, ADO.GetCustomersWith7InPhoneProcedure(), EF.GetCustomersWith7InPhoneProcedure());
                GC.Collect();
            }
            writer.Save();
        }

        public void GetCompanyAndBoughtProduct_TEST()
        {
            CsvWriter writer = new CsvWriter("GetCompanyAndBoughtProduct.csv", "l.p", "ADO", "EF");

            for (int i = 1; i <= numberOfTests; i++)
            {
                writer.WriteLine(i, ADO.GetCompanyAndBoughtProduct(), EF.GetCompanyAndBoughtProduct());
                GC.Collect();
            }
            writer.Save();
        }

        public void GetCompanyAndBoughtProductProcedure_TEST()
        {
            CsvWriter writer = new CsvWriter("GetCompanyAndBoughtProductProcedure.csv", "l.p", "ADO", "EF");

            for (int i = 1; i <= numberOfTests; i++)
            {
                writer.WriteLine(i, ADO.GetCompanyAndBoughtProductProcedure(), EF.GetCompanyAndBoughtProductProcedure());
                GC.Collect();
            }
            writer.Save();
        }

        public void GetCompanyAndGroupProduct_TEST()
        {
            CsvWriter writer = new CsvWriter("GetCompanyAndGroupProduct.csv", "l.p", "ADO", "EF");

            for (int i = 1; i <= numberOfTests; i++)
            {
                writer.WriteLine(i, ADO.GetCompanyAndGroupProduct(), EF.GetCompanyAndGroupProduct());
                GC.Collect();
            }
            writer.Save();
        }

        public void GetCompanyAndGroupProductProcedure_TEST()
        {
            CsvWriter writer = new CsvWriter("GetCompanyAndGroupProductProcedure.csv", "l.p", "ADO", "EF");

            for (int i = 1; i <= numberOfTests; i++)
            {
                writer.WriteLine(i, ADO.GetCompanyAndGroupProductProcedure(), EF.GetCompanyAndGroupProductProcedure());
                GC.Collect();
            }
            writer.Save();
        }
    }
}
