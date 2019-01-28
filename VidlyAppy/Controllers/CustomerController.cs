using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VidlyAppy.Models;
using VidlyAppy.ViewModels;

namespace VidlyAppy.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext _context;
        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        // GET all Customer
        [OutputCache(Duration = 10, Location = System.Web.UI.OutputCacheLocation.Server)]
        public ActionResult Index()
        {
            if(User.IsInRole("CanManageCustomer"))
                 return View("IndexAdmin");
            return View("IndexClient"); 
        }

        public ActionResult Details(int ID)
        {
            
            var name = _context.customers.Include("MembershipType").SingleOrDefault(c => c.id == ID);
            return View(name);
        }

        //create a form
        public ActionResult CreateForm()
        {
            var customer1 = new Customer();
            var memberships1 = _context.membershipTypes.ToList();
            var viewModel = new CustomerMembershipTypeVM
            {
                customer = customer1,
                membershipTypes = memberships1

            };
            return View(viewModel);
        }


        //submit the new or edited form
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer Customer)
        {
            if (!ModelState.IsValid)
            {
                var ViewModel = new CustomerMembershipTypeVM
                {
                    customer = Customer,
                    membershipTypes = _context.membershipTypes
                };
                return View("CreateForm", ViewModel);
            }
            _context.customers.Add(Customer);
            _context.SaveChanges();
            return RedirectToAction("Index", "Customer");
        }

        //Get customer to edit
        [Authorize(Roles = "CanManageCustomer")]
        public ActionResult Edit(int Id)
        {
            var Customer = _context.customers.SingleOrDefault(c => c.id == Id);

            if(Customer == null)
                return HttpNotFound();
            
            var viewModel = new CustomerMembershipTypeVM
            {
                customer = Customer,
                membershipTypes = _context.membershipTypes.ToList()
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Customer Customer)
        {
            if (!ModelState.IsValid)
            {

                var ViewModel = new CustomerMembershipTypeVM
                {
                    customer = Customer,
                    membershipTypes = _context.membershipTypes
                };
                return View("CreateForm", ViewModel);
            }
            var CustomerDb = _context.customers.Single(c => c.id == Customer.id);
            //TryUpdateModel(Customer1);


            CustomerDb.Name = Customer.Name;
            CustomerDb.BirthDay = Customer.BirthDay;
            CustomerDb.MembershipTypeId = Customer.MembershipTypeId;
            CustomerDb.IsSubscribedNewsLetter = Customer.IsSubscribedNewsLetter;
            

            _context.SaveChanges();
            return RedirectToAction("Index", "Customer");
        }
    }
}