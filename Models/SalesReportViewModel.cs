using System;
using System.Collections.Generic;

namespace BookStoreMVC.Models
{
    public class SalesReportViewModel
    {
        public DateTime ReportDate { get; set; }
        public decimal TotalSales { get; set; }
        public int TotalOrders { get; set; }
        public List<OrderDetailViewModel> OrderDetails { get; set; }
    }

    public class OrderDetailViewModel
    {
        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string PaymentStatus { get; set; }
    }
}
