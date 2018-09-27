using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PagedList.Core;
using PaginationDemo.Data;
using PaginationDemo.Infrastructure;
using PaginationDemo.Models;
using ReflectionIT.Mvc.Paging;

namespace PaginationDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        public int pageSize = 3;
        public int PageSize = 3;
        public PaginatedList<Person> Persons { get; set; }

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(int page=1)
        {
            

            PagedList<Person> model = new PagedList<Person>(_context.People,page, pageSize);
            var model2 = PagingList.Create(_context.People, pageSize, page);
            return View(model);
        }

        public IActionResult About()
        {

            var product = _context.Products.Where(x => x.Category == "Wspinanie");

            return View(product);
        }

        public IActionResult Contact(int applicationPage = 1)
        {

                var people = _context.People;
                var totalItems = people.Count();
                var peopleNew = people.Skip((applicationPage - 1) * PageSize).Take(PageSize);
                var peopleList = new PersonListViewModel()
                {
                    People = peopleNew,
                    PagingInfo = new PagingInfo
                    {
                        CurrentPage = applicationPage,
                        ItemsPerPage = PageSize,
                        TotalItems = totalItems
                    }
                };
                return View(peopleList);
            
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
