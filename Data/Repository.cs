namespace DemoApi.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using DemoApi.Domain.Entities;

    /// <summary>
    /// The repository.
    /// </summary>
    public class Repository
    {
        /// <summary>
        /// The loans.
        /// </summary>
        private static readonly List<Loan> Loans = new List<Loan>
                                                       {
                                                           new Loan() { Id = 1, Amount = 100, Status = LoanStatus.Active },
                                                           new Loan() { Id = 2, Amount = 200, Status = LoanStatus.Disabled },
                                                           new Loan() { Id = 3, Amount = 300, Status = LoanStatus.Active },
                                                           new Loan() { Id = 4, Amount = 400, Status = LoanStatus.Disabled },
                                                       };

        /// <summary>
        /// The get loans.
        /// </summary>
        /// <returns>
        /// The <see cref="List{T}"/>.
        /// </returns>
        public static List<Loan> GetLoans()
        {
            return Loans;
        }
    }
}
