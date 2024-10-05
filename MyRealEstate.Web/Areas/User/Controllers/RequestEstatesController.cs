using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyRealEstate.DataLayer.Context;
using MyRealEstate.DomainClasses.Estate;
using MyRealEstate.Services.Repositories;
using MyRealEstate.Services.Services;

namespace MyRealEstate.Web.Areas.User.Controllers
{
    [Area("User")]
    public class RequestEstatesController : Controller
    {
        private readonly IRequestEstateRepository _requestEstateRepository;

        public RequestEstatesController(IRequestEstateRepository requestEstateRepository)
        {
            _requestEstateRepository = requestEstateRepository;
        }

        // GET: User/RequestEstates
        public async Task<IActionResult> Index(int id)
        {
            var myRealEstateDbContext = _requestEstateRepository.GetAllRequestEstate(id);
            ViewData["estateId"] = id;
            return View(myRealEstateDbContext);
        }

        // GET: User/RequestEstates/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requestEstate = _requestEstateRepository.GetRequestEstateById(id.Value);
            if (requestEstate == null)
            {
                return NotFound();
            }

            return View(requestEstate);
        }

        // GET: User/RequestEstates/Create
        public IActionResult Create(int id)
        {
            ViewData["EstateId"] = id;
            return View();
        }

        // POST: User/RequestEstates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RequestEstateId,SaveUserId,EstateId,SaveTime,Note")] RequestEstate requestEstate)
        {
            if (ModelState.IsValid)
            {
                _requestEstateRepository.InsertRequestEstate(requestEstate);
                _requestEstateRepository.Save();
                return RedirectToAction(nameof(Index), new { id = requestEstate.EstateId });
            }
            ViewData["EstateId"] = requestEstate.EstateId;
            return View(requestEstate);
        }

        // GET: User/RequestEstates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requestEstate = _requestEstateRepository.GetRequestEstateById(id.Value);
            if (requestEstate == null)
            {
                return NotFound();
            }
            ViewData["EstateId"] =  requestEstate.EstateId;
            return View(requestEstate);
        }

        // POST: User/RequestEstates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RequestEstateId,SaveUserId,EstateId,SaveTime,Note")] RequestEstate requestEstate)
        {
            if (id != requestEstate.RequestEstateId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _requestEstateRepository.UpdateRequestEstate(requestEstate);
                     _requestEstateRepository.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RequestEstateExists(requestEstate.RequestEstateId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), new { id = requestEstate.EstateId });
            }
            ViewData["EstateId"] =  requestEstate.EstateId;
            return View(requestEstate);
        }

        // GET: User/RequestEstates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requestEstate = _requestEstateRepository.GetRequestEstateById(id.Value);
            if (requestEstate == null)
            {
                return NotFound();
            }

            return View(requestEstate);
        }

        // POST: User/RequestEstates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var requestEstate = _requestEstateRepository.GetRequestEstateById(id);
            _requestEstateRepository.DeleteRequestEstate(requestEstate);
            _requestEstateRepository.Save();

            return RedirectToAction(nameof(Index),new { id = requestEstate.EstateId });
        }

        private bool RequestEstateExists(int id)
        {
            return _requestEstateRepository.RequestEstateExists(id);
        }
    }
}
