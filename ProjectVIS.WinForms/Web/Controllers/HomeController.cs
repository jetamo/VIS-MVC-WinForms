using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Web.Models;
using DomainLayer.ActiveRecord;
using DomainLayer;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult BookList()
        {
            List<BookActiveRecord> books = BookActiveRecord.Find();
            ViewBag.Books = books;
            return View();
        }


        public IActionResult RentalList()
        {
            Dictionary<RentalActiveRecord, List<BookActiveRecord>> rentalDictionary = new Dictionary<RentalActiveRecord, List<BookActiveRecord>>();
            List<RentalActiveRecord> rentals = RentalActiveRecord.Find();
            List<RentalActiveRecord> customerRentals = new List<RentalActiveRecord>();
            List<BookInRentalActiveRecord> booksInRental = BookInRentalActiveRecord.Find();
            foreach(RentalActiveRecord rental in rentals)
            {
                if(rental.Customer.ID == Var.zakaznik.ID)
                {
                    customerRentals.Add(rental);
                }
            }
            foreach(RentalActiveRecord rental in customerRentals)
            {
                List<BookActiveRecord> tmpBooks = new List<BookActiveRecord>();
                foreach (BookInRentalActiveRecord book in booksInRental)
                {
                    if(book.Rental.ID == rental.ID)
                    {
                        tmpBooks.Add(BookActiveRecord.Find((int)book.Book.ID));
                    }
                }
                rentalDictionary.Add(rental, tmpBooks);
            }
            ViewBag.Rentals = rentalDictionary;
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
