namespace Policy.Service.Entity
{
    using System;
    public class PolicyDetail
    {
        public string PolicyNumber { get; set; }
        public string PolicyId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}