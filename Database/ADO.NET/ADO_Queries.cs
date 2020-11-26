using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OESK_Projekt_I.Database
{
    class ADO_Queries : ADO_BaseCommands, IQueriesSet
    {
        string conntectionString;
        Stopwatch sw;

        public ADO_Queries()
        {
            conntectionString = ConfigurationManager.ConnectionStrings["ADO_OESK_Northwind"].ConnectionString;
            sw = new Stopwatch();
        }

        public long GetAllCustomers()
        {
            using (SqlConnection sqlConnection = new SqlConnection(conntectionString))
            {
                sw.Restart();
                var result = ExecuteSqlCommand(sqlConnection,
                                                  CommandType.Text,
                                                  "SELECT * FROM Customers");
                sw.Stop();
            }

            return sw.ElapsedMilliseconds;
        }

        public long GetAllCustomersProcedure()
        {
            using (SqlConnection sqlConnection = new SqlConnection(conntectionString))
            {
                sw.Restart();
                var result = ExecuteSqlCommand(sqlConnection,
                                                  CommandType.StoredProcedure,
                                                  "GET_ALL_CUSTOMERS");
                sw.Stop();
            }

            return sw.ElapsedMilliseconds;
        }

        public long GetCustomersWith7InPhone()
        {
            using (SqlConnection sqlConnection = new SqlConnection(conntectionString))
            {
                sw.Restart();
                var result = ExecuteSqlCommand(sqlConnection,
                                               CommandType.Text,
                                               @"SELECT * FROM Customers WHERE Phone LIKE '%' + @Num + '%'",
                                               new SqlParameter("Num", "7"));
                sw.Stop();
            }

            return sw.ElapsedMilliseconds;
        }

        public long GetCustomersWith7InPhoneProcedure()
        {
            using (SqlConnection sqlConnection = new SqlConnection(conntectionString))
            {
                sw.Restart();
                var result = ExecuteSqlCommand(sqlConnection,
                                               CommandType.StoredProcedure,
                                               "GET_CUSTOMERS_WITH_7_IN_PHONE");
                sw.Stop();
            }

            return sw.ElapsedMilliseconds;
        }

        public long GetCompanyAndBoughtProduct()
        {
            using (SqlConnection sqlConnection = new SqlConnection(conntectionString))
            {
                sw.Restart();
                var result = ExecuteSqlCommand(sqlConnection,
                                                  CommandType.Text,
                                                  @"SELECT 
	                                                    c.CompanyName, p.ProductName
                                                    FROM
	                                                    Customers c
                                                    join 
	                                                    Orders o
                                                    on 
	                                                    c.CustomerID = o.CustomerID
                                                    join 
	                                                    [Order Details] od
                                                    on 
	                                                    od.OrderID = o.OrderID
                                                    join 
	                                                    Products p
                                                    on 
	                                                    p.ProductID = od.ProductID");
                sw.Stop();
            }

            return sw.ElapsedMilliseconds;
        }

        public long GetCompanyAndBoughtProductProcedure()
        {
            using (SqlConnection sqlConnection = new SqlConnection(conntectionString))
            {
                sw.Restart();
                var result = ExecuteSqlCommand(sqlConnection,
                                               CommandType.StoredProcedure,
                                               "GET_COMPANY_AND_BOUGHT_PRODUCT");
                sw.Stop();
            }

            return sw.ElapsedMilliseconds;
        }

        public long GetCompanyAndGroupProduct()
        {
            using (SqlConnection sqlConnection = new SqlConnection(conntectionString))
            {
                sw.Restart();
                var result = ExecuteSqlCommand(sqlConnection,
                                                  CommandType.Text,
                                                  @"SELECT 
	                                                    c.CompanyName, 
                                                        COUNT(p.ProductName) AS ProductCount
                                                    FROM
	                                                    Customers c
                                                    join 
	                                                    Orders o
                                                    on 
	                                                    c.CustomerID = o.CustomerID
                                                    join 
	                                                    [Order Details] od
                                                    on 
	                                                    od.OrderID = o.OrderID
                                                    join 
	                                                    Products p
                                                    on 
	                                                    p.ProductID = od.ProductID
                                                    GROUP BY 
                                                        C.CompanyName
                                                    ORDER BY 
                                                        C.CompanyName");
                sw.Stop();
            }

            return sw.ElapsedMilliseconds;
        }

        public long GetCompanyAndGroupProductProcedure()
        {
            using (SqlConnection sqlConnection = new SqlConnection(conntectionString))
            {
                sw.Restart();
                var result = ExecuteSqlCommand(sqlConnection,
                                               CommandType.StoredProcedure,
                                               "GET_COMPANY_AND_GROUP_PRODUCT");
                sw.Stop();
            }

            return sw.ElapsedMilliseconds;
        }
    }
}
