//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DeliveryInatechMvc.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class BookingTb
    {
        public int OrderId { get; set; }
        public Nullable<int> CustomerId { get; set; }
        public Nullable<int> ExecutiveId { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public Nullable<int> Weight { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<bool> Flag { get; set; }
    }
}