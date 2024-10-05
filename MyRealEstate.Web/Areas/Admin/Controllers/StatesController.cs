using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyRealEstate.DataLayer.Context;
using MyRealEstate.DomainClasses.Admin;
using MyRealEstate.Services.Repositories;

namespace MyRealEstate.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StatesController : Controller
    {
        readonly IStateRepository _stateRepository;
        public StatesController(IStateRepository stateRepository)
        {
            _stateRepository = stateRepository;
        }

        // GET: Admin/States
        public async Task<IActionResult> Index()
        {
            return View(_stateRepository.GetAllState());
        }

        // GET: Admin/States/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var state = _stateRepository.GetStateById(id.Value);
            if (state == null)
            {
                return NotFound();
            }

            return View(state);
        }

        // GET: Admin/States/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/States/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StateId,StateName")] State state)
        {
            if (ModelState.IsValid)
            {
                _stateRepository.InsertState(state);
                _stateRepository.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(state);
        }

        // GET: Admin/States/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var state = _stateRepository.GetStateById(id.Value);
            if (state == null)
            {
                return NotFound();
            }
            return View(state);
        }

        // POST: Admin/States/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StateId,StateName")] State state)
        {
            if (id != state.StateId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _stateRepository.UpdateState(state);
                    _stateRepository.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StateExists(state.StateId))
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
            return View(state);
        }

        // GET: Admin/States/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var state = _stateRepository.GetStateById(id.Value);
            if (state == null)
            {
                return NotFound();
            }

            return View(state);
        }

        // POST: Admin/States/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _stateRepository.DeleteState(id);
            _stateRepository.Save();
            return RedirectToAction(nameof(Index));
        }

        private bool StateExists(int id)
        {
            return _stateRepository.StateExists(id);
        }
    }
}
