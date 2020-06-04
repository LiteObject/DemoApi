namespace DemoApi.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// The loan.
    /// </summary>
    public class Loan
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        public double Amount { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        public LoanStatus Status { get; set; }

        /// <summary>
        /// Gets or sets the headers.
        /// </summary>
        public Header[] Headers { get; set; }

        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// Gets or sets the created by.
        /// </summary>
        public DateTime CreatedBy { get; set; }
        
        /// <summary>
        /// Gets or sets the date updated.
        /// </summary>
        public DateTime UpdatedOn { get; set; }

        /// <summary>
        /// Gets or sets the updated by.
        /// </summary>
        public DateTime UpdatedBy { get; set; }
    }

    /// <summary>
    /// The loan status.
    /// </summary>
    public enum LoanStatus
    {
        /// <summary>
        /// The disabled.
        /// </summary>
        Disabled = 0,

        /// <summary>
        /// The active.
        /// </summary>
        Active = 1
    }
}
