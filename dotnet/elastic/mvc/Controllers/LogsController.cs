using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace mvc.Controllers
{
    public class LogsController : Controller
    {
        private readonly LogContext _context;
        private readonly IElasticLogsClient elasticLogsClient;

        public LogsController(LogContext context, IElasticLogsClient elasticLogsClient)
        {
            _context = context;
            this.elasticLogsClient = elasticLogsClient;
        }

        // GET: Logs
        [HttpGet("logs/{reference}")]
        [HttpGet("logs")]
        // [HttpPost("logs/{searchString}")]
        // [HttpPost("logs")]
        public async Task<IActionResult> Index(string type, string reference)
        {
            var indexLogVM = new IndexLogViewModel
            {
                Types = new SelectList(new List<string>{"pain","mt","camt"}),
                Logs = elasticLogsClient.GetLogs(type, reference).ToList()
            };

            return View(indexLogVM);

            // IQueryable<string> typeQuery = from m in _context.Log
            //                                 orderby m.Type
            //                                 select m.Type;

            // var logs = from m in _context.Log
            //              select m;

            // if (!string.IsNullOrEmpty(searchString))
            // {
            //     logs = logs.Where(s => s.Reference.Contains(searchString));
            // }

            // if (!string.IsNullOrEmpty(type))
            // {
            //     logs = logs.Where(x => x.Type == type);
            // }

            // var movieGenreVM = new IndexLogViewModel
            // {
            //     Types = new SelectList(await typeQuery.Distinct().ToListAsync()),
            //     Logs = await logs.ToListAsync()
            // };

            // return View(movieGenreVM);
        }

        // GET: Logs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var log = await _context.Log
                .FirstOrDefaultAsync(m => m.Id == id);
            if (log == null)
            {
                return NotFound();
            }

            return View(log);
        }

        // GET: Logs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Logs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Author,LoggedDate,LogLevel,Message,Reference,Type")] Log log)
        {
            if (ModelState.IsValid)
            {
                _context.Add(log);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(log);
        }

        // GET: Logs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var log = await _context.Log.FindAsync(id);
            if (log == null)
            {
                return NotFound();
            }
            return View(log);
        }

        // POST: Logs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Author,LoggedDate,LogLevel,Message,Reference,Type")] Log log)
        {
            if (id != log.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(log);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LogExists(log.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(log);
        }

        // GET: Logs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var log = await _context.Log
                .FirstOrDefaultAsync(m => m.Id == id);
            if (log == null)
            {
                return NotFound();
            }

            return View(log);
        }

        // POST: Logs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var log = await _context.Log.FindAsync(id);
            _context.Log.Remove(log);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LogExists(int id)
        {
            return _context.Log.Any(e => e.Id == id);
        }
    }
}
