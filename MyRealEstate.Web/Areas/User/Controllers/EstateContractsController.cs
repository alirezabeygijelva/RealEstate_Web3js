using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyRealEstate.DataLayer.Context;
using MyRealEstate.DomainClasses.Estate;
using MyRealEstate.Services.Repositories;
using MyRealEstate.Web.Models;
using RealStateWebAPI.Services;

namespace MyRealEstate.Web.Areas.User.Controllers
{
    [Area("User")]
    public class EstateContractsController : Controller
    {
        private readonly IEstateContractRepository _estateContractRepository;
        private readonly IRealEstateService _realEstateService;
        private readonly UserManager<ApplicationUser> _userManager;

        public EstateContractsController(IEstateContractRepository estateContractRepository, IRealEstateService realEstateService, UserManager<ApplicationUser> userManager)
        {
            _estateContractRepository = estateContractRepository;
            _realEstateService = realEstateService;
            _userManager = userManager; 
        }

   

        // GET: User/EstateContracts
        public async Task<IActionResult> Index(int id)
        {
            var myRealEstateDbContext = _estateContractRepository.GetEstateContracts(id);
            ViewData["EstateId"] = id;
            ViewData["Balance"] =
                await _realEstateService.GetBalance(_userManager.FindByNameAsync(User.Identity.Name).Result
                    .EthAccountAddress);
            return View(myRealEstateDbContext);
        }

        // GET: User/EstateContracts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estateContract =  _estateContractRepository.GetEstateContract(id.Value);
            if (estateContract == null)
            {
                return NotFound();
            }

            return View(estateContract);
        }

        // GET: User/EstateContracts/Create
        public IActionResult Create(int id)
        {
            ViewData["EstateId"] = id;
            ViewData["MyUsers"] = new SelectList(_userManager.Users, "Id", "Email");
            return View();
        }

        // POST: User/EstateContracts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EstateContractId,EstateId,OwnerUserId,BuyerUserId,SellerUserId,Note,Amount")] EstateContract estateContract)
        {
            if (ModelState.IsValid)
            {
                estateContract.SaveTime = DateTime.Now;
                estateContract.OwnerUserId = _userManager.GetUserId(User);
                estateContract.BuyerOK = false;
                estateContract.SellerOK = false;
                _estateContractRepository.InsertEstateContract(estateContract);
                _estateContractRepository.Save();
                await _realEstateService.AddEstateContract( Convert.ToUInt32(estateContract.EstateContractId),
                    addressBuyer: _userManager.FindByIdAsync(estateContract.BuyerUserId).Result.EthAccountAddress,
                    _userManager.FindByIdAsync(estateContract.SellerUserId).Result.EthAccountAddress,
                    Convert.ToUInt16(estateContract.Amount));
                return RedirectToAction(nameof(Index), new {id = estateContract.EstateId});
            }
            ViewData["EstateId"] = estateContract.EstateId;
            return View(estateContract);
        }


        // GET: User/EstateContracts/Delete/5
        public async Task<IActionResult> Accept(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estateContract = _estateContractRepository.GetEstateContract(id.Value);
            if (estateContract == null)
            {
                return NotFound();
            }

            ViewData["EstateId"] = estateContract.EstateId;
            return View(estateContract);
        }

        // POST: User/EstateContracts/Delete/5
        [HttpPost, ActionName("Accept")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Accept(int id)
        {
            var estateContract = _estateContractRepository.GetEstateContract(id);
            if (User.FindFirst(ClaimTypes.NameIdentifier).Value == estateContract.BuyerUserId)
            {
                estateContract.BuyerOK = true;
                estateContract.BuyerOKTime = DateTime.Now;
            }
            else if (User.FindFirst(ClaimTypes.NameIdentifier).Value == estateContract.SellerUserId)
            {
                estateContract.SellerOK = true;
                estateContract.SellerOKTime = DateTime.Now;
            }

            await _realEstateService.Accept(Convert.ToUInt32(estateContract.EstateContractId));
            _estateContractRepository.Save();
            return RedirectToAction(nameof(Index), new {id = estateContract.EstateId});
        }

    }
}
