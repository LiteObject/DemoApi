namespace DemoApi.Controllers
{
    using System.Collections.Generic;
    using System.Linq;

    using DemoApi.Domain.Entities;

    using Microsoft.AspNetCore.JsonPatch;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// The loans controller.
    /// Web API design: https://docs.microsoft.com/en-us/azure/architecture/best-practices/api-design
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class LoansController : ControllerBase
    {
        /// <summary>
        /// The get all.
        /// </summary>
        /// <returns>
        /// The <see cref="IActionResult"/>.
        /// </returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Loan> loans = Data.Repository.GetLoans();
            return Ok(loans);
        }

        /// <summary>
        /// The get.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="IActionResult"/>.
        /// </returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id == default)
            {
                return NotFound();
            }

            Loan loan = Data.Repository.GetLoans().FirstOrDefault(l => l.Id == id);

            return Ok(loan);
        }

        /// <summary>
        /// The post.
        /// </summary>
        /// <param name="loan">
        /// The loan.
        /// </param>
        /// <returns>
        /// The <see cref="IActionResult"/>.
        /// </returns>
        [HttpPost]
        public IActionResult Post(Loan loan)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            
            return Accepted();
        }

        /// <summary>
        /// The put.
        /// </summary>
        /// <param name="loan">
        /// The loan.
        /// </param>
        /// <returns>
        /// The <see cref="IActionResult"/>.
        /// </returns>
        [HttpPut]
        public IActionResult Put(Loan loan)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }

            return NoContent();
        }

        /// <summary>
        /// The patch.
        /// https://docs.microsoft.com/en-us/aspnet/core/web-api/jsonpatch?view=aspnetcore-3.1
        /// Payload:
        /// [
        ///     {"op": "replace", "path":"/amount", "value":"100"},
        ///     {"op": "add", "path": "/headers", "value": [{"type": 0, "enabled": true}] }
        /// ]
        /// </summary>
        /// <param name="id">
        ///  The entity identifier.
        /// </param>
        /// <param name="patchDoc">
        ///  The patch doc.
        /// </param>
        /// <returns>
        /// The <see cref="IActionResult"/>.
        /// </returns>
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, [FromBody] JsonPatchDocument<Loan> patchDoc)
        {
            if (patchDoc != null)
            {
                // var loan = CreateLoan();
                Loan loanFromDb = Data.Repository.GetLoans().FirstOrDefault(l => l.Id == id); // Get from repo/database by id

                if (loanFromDb == null)
                {
                    return NotFound();
                }

                patchDoc.ApplyTo(loanFromDb, ModelState);

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                // await _context.SaveChangesAsync();
                return new ObjectResult(loanFromDb);
            }
            else
            {
                return BadRequest($"{nameof(patchDoc)} cannot be null.");
            }
        }

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="IActionResult"/>.
        /// </returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Loan loan = Data.Repository.GetLoans().FirstOrDefault(l => l.Id == id);

            if (loan is null)
            {
                return NotFound($"Loan (id: {id}) not found in the system.");
            }

            return NoContent();
        }

        /// <summary>
        /// The add header.
        /// </summary>
        /// <param name="header">
        /// The header.
        /// </param>
        /// <returns>
        /// The <see cref="IActionResult"/>.
        /// </returns>
        [HttpPost("{id}/headers")]
        public IActionResult AddHeader(Header header)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }

            return Accepted();
        }

        /// <summary>
        /// The update header.
        /// </summary>
        /// <param name="headerId">
        /// The header id.
        /// </param>
        /// <param name="header">
        /// The header.
        /// </param>
        /// <returns>
        /// The <see cref="IActionResult"/>.
        /// </returns>
        [HttpPut("{id}/headers/{headerId}")]
        public IActionResult UpdateHeader(int headerId, Header header)
        {
            if (headerId == default)
            {
                return BadRequest($"{nameof(headerId)} cannot be null, empty, or default.");
            }

            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }

            return NoContent();
        }

        /// <summary>
        /// The delete header.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <param name="headerId">
        /// The header id.
        /// </param>
        /// <returns>
        /// The <see cref="IActionResult"/>.
        /// </returns>
        [HttpDelete("{id}/headers/{headerId}")]
        public IActionResult DeleteHeader(int id, int headerId)
        {
            Loan loan = Data.Repository.GetLoans().FirstOrDefault(l => l.Id == id);

            if (loan is null)
            {
                return NotFound($"Loan (id: {id}) not found in the system.");
            }

            Header header = loan.Headers?.FirstOrDefault(h => h.Id == headerId);

            if (header is null)
            {
                return NotFound($"Header (HeaderId: {headerId}, LoanId: {id}) not found in the system.");
            }

            return NoContent();
        }
    }
}