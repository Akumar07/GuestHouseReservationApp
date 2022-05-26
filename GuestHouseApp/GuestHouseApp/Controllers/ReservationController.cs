using GuestHouseApp.Dal;
using GuestHouseApp.Models;
using GuestHouseApp.ViewModels;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuestHouseApp.Controllers
{
    public class ReservationController : Controller
    {
        // GET: Regervation
        public ActionResult BookingHistory()
        {
            List<MasterTable> data = new List<MasterTable>();
            using (var session = DataBaseSetting.openSession())
            {
                data = session.Query<MasterTable>()
                                        .Fetch(x=>x.GovtIdCard)
                                        .Fetch(x=>x.Country)
                                        .Fetch(x=>x.PaymentMethod)
                                        .OrderBy(x=>x.DateOfArr)
                                        .Where(x => x.Active == 1).ToList();
            }
            return View(data);
        }
        public ActionResult Create()
        {
            ReservationVM vm = new ReservationVM();
            using(var session = DataBaseSetting.openSession())
            {
                vm.GovtIdCardList = session.Query<GovtIdCard>().Where(x => x.Active == 1).ToList();
                vm.CountryList = session.Query<Country>().Where(x => x.Active == 1).ToList();
                vm.PaymentMethodList = session.Query<PaymentMethod>().Where(x => x.Active == 1).ToList();
            }
            return View(vm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ReservationVM vm)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception("Please Fill all Mandatory Fields !!");
                }
                MasterTable model = new MasterTable
                {
                    FirstName=vm.MasterTable.FirstName,
                    LastName=vm.MasterTable.LastName,
                    Email=vm.MasterTable.Email,
                    GovtIdCard=new GovtIdCard { Id=vm.MasterTable.GovtIdCard.Id},
                    GovtIdNo=vm.MasterTable.GovtIdNo,
                    DateOfArr=vm.MasterTable.DateOfArr,
                    DateOfDep=vm.MasterTable.DateOfDep,
                    Country=new Country { Id=vm.MasterTable.Country.Id},
                    NumberOfPerson=vm.MasterTable.NumberOfPerson,
                    Remarks=vm.MasterTable.Remarks,
                    PaymentMethod=new PaymentMethod { Id=vm.MasterTable.PaymentMethod.Id},
                    Active=1,
                    UpdatedBy=vm.MasterTable.Email,
                    UpdatedOn=DateTime.Now
                };
                using (var session = DataBaseSetting.openSession())
                {
                    using (var tx = session.BeginTransaction())
                    {
                        session.Save(model);
                        tx.Commit();
                        TempData["message"] = "Your Booking is Confirmed !!";
                    }
                }
            }
            catch(Exception e)
            {
                TempData["message"]=e.Message;
                using (var session = DataBaseSetting.openSession())
                {
                    vm.GovtIdCardList = session.Query<GovtIdCard>().Where(x => x.Active == 1).ToList();
                    vm.CountryList = session.Query<Country>().Where(x => x.Active == 1).ToList();
                    vm.PaymentMethodList = session.Query<PaymentMethod>().Where(x => x.Active == 1).ToList();
                }
                return View(vm);
            }
            return RedirectToAction("BookingHistory");
        }
    }
}