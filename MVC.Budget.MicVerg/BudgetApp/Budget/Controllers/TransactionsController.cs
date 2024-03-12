using Budget.Data;
using Budget.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Budget.Controllers
{
        [Route("api/[controller]")]
        [ApiController]
        public class TransactionsController : ControllerBase
        {
            private readonly BudgetContext _context;

            public TransactionsController(BudgetContext context)
            {
                _context = context;
            }

            // GET: api/Transactions
            [HttpGet]
            public async Task<ActionResult<IEnumerable<Transaction>>> GetTransactions()
            {
                return await _context.Transactions.ToListAsync();
            }

            // GET: api/Transactions/5
            [HttpGet("{id}")]
            public async Task<ActionResult<Transaction>> GetTransaction(int id)
            {
                var transactionModel = await _context.Transactions.FindAsync(id);

                if (transactionModel == null)
                {
                    return NotFound();
                }

                return transactionModel;
            }

            // PUT: api/Transactions/5
            // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
            [HttpPut("{id}")]
            public async Task<IActionResult> PutTransaction(int id, Transaction transactionModel)
            {
                if (id != transactionModel.Id)
                {
                    return BadRequest();
                }

                _context.Entry(transactionModel).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransactionExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return NoContent();
            }

            // POST: api/Transactions
            // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
            [HttpPost]
            public async Task<ActionResult<Transaction>> PostTransactionModel(Transaction transactionModel)
            {
                _context.Transactions.Add(transactionModel);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetTransaction), new { id = transactionModel.Id }, transactionModel);
            }

            // DELETE: api/Transactions/5
            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteTransactionModel(int id)
            {
                var transactionModel = await _context.Transactions.FindAsync(id);
                if (transactionModel == null)
                {
                    return NotFound();
                }

                _context.Transactions.Remove(transactionModel);
                await _context.SaveChangesAsync();

                return NoContent();
            }

            private bool TransactionExists(int id)
            {
                return _context.Transactions.Any(e => e.Id == id);
            }
        }
    }