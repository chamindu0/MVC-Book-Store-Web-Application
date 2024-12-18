using System;
using System.Collections.Generic;

namespace BookStoreMVC.Models
{
    public class UserReportViewModel
    {
        public DateTime ReportDate { get; set; }
        public List<UserDetailViewModel> Users { get; set; }
    }

    public class UserDetailViewModel
    {
        public int UserID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public int OrderCount { get; set; }
        public decimal TotalSpent { get; set; }
    }
}
