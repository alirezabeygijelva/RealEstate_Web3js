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
    public class CitiesController : Controller
    {
        private readonly IStateRepository _stateRepository;
        private readonly ICityRepository _cityRepository;
        public CitiesController(IStateRepository stateRepository, ICityRepository cityRepository)
        {
            _stateRepository = stateRepository;
            _cityRepository = cityRepository;
        }

        // GET: Admin/Cities
        public async Task<IActionResult> Index()
        {
            return View(_cityRepository.GetAllCity());
        }

        // GET: Admin/Cities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var city = _cityRepository.GetCityById(id.Value);
            if (city == null)
            {
                return NotFound();
            }

            return View(city);
        }

        // GET: Admin/Cities/Create
        public IActionResult Create()
        {
            ViewData["StateId"] = new SelectList(_stateRepository.GetAllState(), "StateId", "StateName");
            return View();
        }

        // POST: Admin/Cities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CityId,StateId,CityName")] City city)
        {
            if (ModelState.IsValid)
            {
                _cityRepository.InsertCity(city);
                _cityRepository.Save();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StateId"] = new SelectList(_stateRepository.GetAllState(), "StateId", "StateName", city.StateId);
            return View(city);
        }

        // GET: Admin/Cities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var city =  _cityRepository.GetCityById(id.Value);
            if (city == null)
            {
                return NotFound();
            }
            ViewData["StateId"] = new SelectList(_stateRepository.GetAllState(), "StateId", "StateName", city.StateId);
            return View(city);
        }

        // POST: Admin/Cities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CityId,StateId,CityName")] City city)
        {
            if (id != city.CityId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _cityRepository.UpdateCity(city);
                    _cityRepository.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CityExists(city.CityId))
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
            ViewData["StateId"] = new SelectList(_stateRepository.GetAllState(), "StateId", "StateName", city.StateId);
            return View(city);
        }

        // GET: Admin/Cities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var city = _cityRepository.GetCityById(id.Value);
            if (city == null)
            {
                return NotFound();
            }

            return View(city);
        }

        // POST: Admin/Cities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _cityRepository.DeleteCity(id);
            _cityRepository.Save();
            return RedirectToAction(nameof(Index));
        }

        private bool CityExists(int id)
        {
            return _cityRepository.CityExists(id);
        }
    }
}
