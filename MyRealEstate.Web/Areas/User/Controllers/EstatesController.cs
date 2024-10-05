using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyRealEstate.DataLayer.Context;
using MyRealEstate.DomainClasses.Estate;
using MyRealEstate.Services.Repositories;

namespace MyRealEstate.Web.Areas.User.Controllers
{
    [Area("User")]
    public class EstatesController : Controller
    {
        private readonly IEstateRepository _estateRepository;
        private readonly INeighborhoodRepository _neighborhoodRepository;

        public EstatesController(IEstateRepository estateRepository, INeighborhoodRepository neighborhoodRepository)
        {
            _estateRepository = estateRepository;
            _neighborhoodRepository = neighborhoodRepository;
        }

        // GET: User/Estates
        public async Task<IActionResult> Index()
        {
            return View(_estateRepository.GetAllEstate());
        }

        // GET: User/Estates/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estate = _estateRepository.GetEstateById(id.Value);
            if (estate == null)
            {
                return NotFound();
            }

            return View(estate);
        }

        // GET: User/Estates/Create
        public IActionResult Create()
        {
            ViewData["NeighborhoodId"] = new SelectList(_neighborhoodRepository.GetAllNeighborhood(), "NeighborhoodId", "NeighborhoodName");
            return View();
        }

        // POST: User/Estates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EstateId,NeighborhoodId,ForSale,ForRequest,Title,Note,Area,RoomNo,ConstructionYear,Price,RegDate,Enable")] Estate estate,IFormFile logoUpload)
        {
            if (ModelState.IsValid)
            {
                estate.Enable = true;
                estate.RegDate = DateTime.Now;
                estate.EstateStatusId = 1;
                if (logoUpload != null)
                {
                    estate.EstateLogo = Guid.NewGuid().ToString() + Path.GetExtension(logoUpload.FileName);
                    string SavePath = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/EstateImages", estate.EstateLogo);
                    using (var stream = new FileStream(SavePath, FileMode.Create))
                    {
                        logoUpload.CopyToAsync(stream);
                    }
                }
                _estateRepository.InsertEstate(estate);
                _estateRepository.Save();
                return RedirectToAction(nameof(Index));
            }
            ViewData["NeighborhoodId"] = new SelectList(_neighborhoodRepository.GetAllNeighborhood(), "NeighborhoodId", "NeighborhoodName", estate.NeighborhoodId);
            return View(estate);
        }

        // GET: User/Estates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estate = _estateRepository.GetEstateById(id.Value);
            if (estate == null)
            {
                return NotFound();
            }
            ViewData["NeighborhoodId"] = new SelectList(_neighborhoodRepository.GetAllNeighborhood(), "NeighborhoodId", "NeighborhoodName", estate.NeighborhoodId);
            return View(estate);
        }

        // POST: User/Estates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EstateId,NeighborhoodId,ForSale,ForRequest,Title,Note,Area,RoomNo,ConstructionYear,Price,RegDate,Enable")] Estate estate, IFormFile logoUpload)
        {
            if (id != estate.EstateId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (logoUpload != null)
                    {
                        if (estate.EstateLogo == null)
                            estate.EstateLogo = Guid.NewGuid().ToString() + Path.GetExtension(logoUpload.FileName);
                        string savePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/EstateImages", estate.EstateLogo);
                        using (var stream = new FileStream(savePath, FileMode.Create))
                        {
                            await logoUpload.CopyToAsync(stream);
                        }
                    }
                    _estateRepository.UpdateEstate(estate);
                    _estateRepository.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstateExists(estate.EstateId))
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
            ViewData["NeighborhoodId"] = new SelectList(_neighborhoodRepository.GetAllNeighborhood(), "NeighborhoodId", "NeighborhoodName", estate.NeighborhoodId);
            return View(estate);
        }

        // GET: User/Estates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estate = _estateRepository.GetEstateById(id.Value);
            if (estate == null)
            {
                return NotFound();
            }

            return View(estate);
        }

        // POST: User/Estates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _estateRepository.DeleteEstate(id);
            _estateRepository.Save();
            return RedirectToAction(nameof(Index));
        }

        private bool EstateExists(int id)
        {
            return _estateRepository.EstateExists(id);
        }
    }
}
