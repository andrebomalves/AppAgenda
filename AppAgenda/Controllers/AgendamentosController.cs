﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AppAgenda.Models;

namespace AppAgenda.Controllers
{
    public class AgendamentosController : Controller
    {
        private readonly AppAgendaContext _context;

        public AgendamentosController(AppAgendaContext context)
        {
            _context = context;
        }

        // GET: Agendamentos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Agendamentos.ToListAsync());
        }

        // GET: Agendamentos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agendamento = await _context.Agendamentos
                .FirstOrDefaultAsync(m => m.AgendaId == id);
            if (agendamento == null)
            {
                return NotFound();
            }

            return View(agendamento);
        }

        // GET: Agendamentos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Agendamentos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AgendaId,Nome,DataNascimento,DataHoraInicio,DataHoraFim,Observacao")] Agendamento agendamento)
        {
            if (agendamento.DataHoraInicio > agendamento.DataHoraFim)
                ModelState.AddModelError("DataHoraInicio", "O horário Inicial não pode ser maior que o horário final.");

            if (ModelState.IsValid)
            {
                _context.Add(agendamento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(agendamento);
        }

        // GET: Agendamentos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agendamento = await _context.Agendamentos.FindAsync(id);
            if (agendamento == null)
            {
                return NotFound();
            }
            return View(agendamento);
        }

        // POST: Agendamentos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AgendaId,Nome,DataNascimento,DataHoraInicio,DataHoraFim,Observacao")] Agendamento agendamento)
        {
            if (id != agendamento.AgendaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(agendamento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AgendamentoExists(agendamento.AgendaId))
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
            return View(agendamento);
        }

        // GET: Agendamentos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agendamento = await _context.Agendamentos
                .FirstOrDefaultAsync(m => m.AgendaId == id);
            if (agendamento == null)
            {
                return NotFound();
            }

            return View(agendamento);
        }

        // POST: Agendamentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var agendamento = await _context.Agendamentos.FindAsync(id);
            _context.Agendamentos.Remove(agendamento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AgendamentoExists(int id)
        {
            return _context.Agendamentos.Any(e => e.AgendaId == id);
        }
    }
}
