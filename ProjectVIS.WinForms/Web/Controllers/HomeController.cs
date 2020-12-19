using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Text;
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

        [HttpPost]
        public IActionResult Extend(ExtendForm form)
        {
            RentalActiveRecord rental = RentalActiveRecord.Find(form.id);
            rental.Extended = true;
            rental.Save();
            return RedirectToAction("RentalList", "Home");
        }

        [HttpPost]
        public IActionResult Book(ExtendForm form)
        {
            BookActiveRecord book = BookActiveRecord.Find(form.id);
            book.Available -= 1;
            book.Save();
            return RedirectToAction("BookList", "Home");
        }


        public FileContentResult DownloadCSV()
        {
            List<BookActiveRecord> books = BookActiveRecord.Find();
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("Nazev;Autor;Zanr;Skladem");
            foreach(BookActiveRecord book in books)
            {
                builder.AppendLine();
                builder.Append(book.Title + ";");
                builder.Append(book.Author.Name + " " + book.Author.Surname + ";");
                builder.Append(book.Genre + ";");
                builder.Append(book.Available + ";");
            }
            string csv = builder.ToString();
            return File(new System.Text.UTF32Encoding().GetBytes(csv), "text/csv", "Books.csv");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
