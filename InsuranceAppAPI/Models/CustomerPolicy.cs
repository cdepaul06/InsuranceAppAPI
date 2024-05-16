﻿using System.ComponentModel.DataAnnotations;

namespace InsuranceAppAPI.Models
{
#nullable disable
    public class CustomerPolicy
    {
        [Key]
        public int CustomerPolicyId { get; set; }
        public int CustomerId { get; set; }
        public int PolicyId { get; set; } // Need to take this out
        public DateTime PolicyStartDate { get; set; }
        public DateTime PolicyEndDate { get; set; }
        public decimal PolicyPremium { get; set; }
        public int PolicyTypeId { get; set; }
        public int PolicyStatusId { get; set; }


        public virtual Customer Customer { get; set; }
        public virtual PolicyStatus PolicyStatus { get; set; }
        
    }
}