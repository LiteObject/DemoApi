namespace DemoApi.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// The header.
    /// </summary>
    public class Header
    {
        /// <summary>
        /// The header type.
        /// </summary>
        public enum HeaderType
        {
            /// <summary>
            /// The type 0.
            /// </summary>
            Type0 = 0,

            /// <summary>
            /// The type 1.
            /// </summary>
            Type1 = 1,

            /// <summary>
            /// The type 2.
            /// </summary>
            Type2 = 2
        }

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        public HeaderType Type { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether enabled.
        /// </summary>
        public bool Enabled { get; set; }

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
}
