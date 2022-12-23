using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using HairSalon.Models;
using System.Collections.Generic;

namespace HairSalon.Controllers
{
  public class StylistController : Controller
  {
    private readonly HairSalonContext _db;

    public StylistController(HairSalonContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Stylist> model = _db.Stylists.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      return View();
    }
    [HttpPost]
    public ActionResult Create(Stylist stylist)
    {
      _db.Add(stylist);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}