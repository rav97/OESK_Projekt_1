using OESK_Projekt_I.Database.EntityFramework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OESK_Projekt_I.Database
{
    class EF_Queries : IQueriesSet
    {
        Stopwatch sw;

        public EF_Queries()
        {
            sw = new Stopwatch();
        }

        public long GetAllCustomers()
        {
            using (var context = new OESK_NorthwindEntities())
            {
                sw.Restart();
                var result = context.Customers.ToList();
                sw.Stop();
            }
            return sw.ElapsedMilliseconds;
        }

        public long GetAllCustomersProcedure()
        {
            using (var context = new OESK_NorthwindEntities())
            {
                sw.Restart();
                var result = context.GET_ALL_CUSTOMERS().ToList();
                sw.Stop();
            }
            return sw.ElapsedMilliseconds;
        }

        public long GetCustomersWith7InPhone()
        {
            using (var context = new OESK_NorthwindEntities())
            {
                sw.Restart();
                var result = context.Customers.Where(c => c.Phone.Contains("7")).ToList();
                sw.Stop();
            }
            return sw.ElapsedMilliseconds;
        }

        public long GetCustomersWith7InPhoneProcedure()
        {
            using (var context = new OESK_NorthwindEntities())
            {
                sw.Restart();
                var result = context.GET_CUSTOMERS_WITH_7_IN_PHONE().ToList();
                sw.Stop();
            }
            return sw.ElapsedMilliseconds;
        }

        public long GetCompanyAndBoughtProduct()
        {
            using (var context = new OESK_NorthwindEntities())
            {
                sw.Restart();
/*
                var result = (from c in context.Customers
                              join o in context.Orders on c.CustomerID equals o.CustomerID
                              join od in context.Order_Details on o.OrderID equals od.OrderID
                              join p in context.Products on od.ProductID equals p.ProductID
                              select new
                              {
                                  CompanyName = c.CompanyName,
                                  ProductName = p.ProductName
                              }).ToList();
*/
                var result = context.Order_Details
                                    .Select(od => new { od.Orders.Customers.CompanyName, od.Products.ProductName })
                                    .ToList();
                sw.Stop();
            }
            return sw.ElapsedMilliseconds;
        }

        public long GetCompanyAndBoughtProductProcedure()
        {
            using (var context = new OESK_NorthwindEntities())
            {
                sw.Restart();
                var result = context.GET_COMPANY_AND_BOUGHT_PRODUCT().ToList();
                sw.Stop();
            }
            return sw.ElapsedMilliseconds;
        }

        public long GetCompanyAndGroupProduct()
        {
            using (var context = new OESK_NorthwindEntities())
            {
                sw.Restart();
                /*
                var result = (from c in context.Customers
                              join o in context.Orders on c.CustomerID equals o.CustomerID
                              join od in context.Order_Details on o.OrderID equals od.OrderID
                              join p in context.Products on od.ProductID equals p.ProductID
                              group c by c.CompanyName into g
                              select new
                              {
                                  CompanyName = g.Key,
                                  ProductCount = g.Count()
                              }).OrderBy(x => x.CompanyName).ToList();
                */

                var result = context.Order_Details
                                    .GroupBy(od => od.Orders.Customers.CompanyName)
                                    .Select(g => new { CompanyName = g.Key, ProductCount = g.Count() })
                                    .OrderBy(x => x.CompanyName)
                                    .ToList();

                sw.Stop();
            }
            return sw.ElapsedMilliseconds;
        }

        public long GetCompanyAndGroupProductProcedure()
        {
            using (var context = new OESK_NorthwindEntities())
            {
                sw.Restart();
                var result = context.GET_COMPANY_AND_GROUP_PRODUCT().ToList();
                sw.Stop();
            }
            return sw.ElapsedMilliseconds;
        }
    }
}
