using System;
using System.Collections.Generic;

namespace BlazorApp.Data.Model
{
    public partial class SalesOrderHeader
    {
        public int SalesOrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public int CustomerId { get; set; }
        public decimal TotalDue { get; set; }
    }
}