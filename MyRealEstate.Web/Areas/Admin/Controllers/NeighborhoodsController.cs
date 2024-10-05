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
    public class NeighborhoodsController : Controller
    {
        private readonly INeighborhoodRepository _neighborhoodRepository;
        private readonly ICityRepository _cityRepository;
        public NeighborhoodsController(INeighborhoodRepository neighborhoodRepository, ICityRepository cityRepository)
        {
            _neighborhoodRepository = neighborhoodRepository;
            _cityRepository = cityRepository;
        }

        // GET: Admin/Neighborhoods
        public async Task<IActionResult> Index()
        {
            return View(_neighborhoodRepository.GetAllNeighborhood());
        }

        // GET: Admin/Neighborhoods/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var neighborhood = _neighborhoodRepository.GetNeighborhoodById(id.Value);
            if (neighborhood == null)
            {
                return NotFound();
            }

            return View(neighborhood);
        }

        // GET: Admin/Neighborhoods/Create
        public IActionResult Create()
        {
            ViewData["CityId"] = new SelectList(_cityRepository.GetAllCity(), "CityId", "CityName");
            return View();
        }

        // POST: Admin/Neighborhoods/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NeighborhoodId,CityId,NeighborhoodName")] Neighborhood neighborhood)
        {
            if (ModelState.IsValid)
            {
                _neighborhoodRepository.InsertNeighborhood(neighborhood);
                _neighborhoodRepository.Save();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CityId"] = new SelectList(_cityRepository.GetAllCity(), "CityId", "CityName", neighborhood.CityId);
            return View(neighborhood);
        }

        // GET: Admin/Neighborhoods/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var neighborhood = _neighborhoodRepository.GetNeighborhoodById(id.Value);
            if (neighborhood == null)
            {
                return NotFound();
            }
            ViewData["CityId"] = new SelectList(_cityRepository.GetAllCity(), "CityId", "CityName", neighborhood.CityId);
            return View(neighborhood);
        }

        // POST: Admin/Neighborhoods/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NeighborhoodId,CityId,NeighborhoodName")] Neighborhood neighborhood)
        {
            if (id != neighborhood.NeighborhoodId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _neighborhoodRepository.UpdateNeighborhood(neighborhood);
                    _neighborhoodRepository.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NeighborhoodExists(neighborhood.NeighborhoodId))
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
            ViewData["CityId"] = new SelectList(_cityRepository.GetAllCity(), "CityId", "CityName", neighborhood.CityId);
            return View(neighborhood);
        }

        // GET: Admin/Neighborhoods/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var neighborhood = _neighborhoodRepository.GetNeighborhoodById(id.Value);
            if (neighborhood == null)
            {
                return NotFound();
            }

            return View(neighborhood);
        }

        // POST: Admin/Neighborhoods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _neighborhoodRepository.DeleteNeighborhood(id);
            _neighborhoodRepository.Save();
            return RedirectToAction(nameof(Index));
        }

        private bool NeighborhoodExists(int id)
        {
            return _neighborhoodRepository.NeighborhoodExists(id);
        }
    }
}
