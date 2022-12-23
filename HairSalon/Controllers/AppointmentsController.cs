using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using HairSalon.Models;
using System.Collections.Generic;

namespace HairSalon.Controllers
{
  public class AppointmentsController : Controller
  {
    private readonly HairSalonContext _db;

    public AppointmentsController(HairSalonContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Appointment> model = _db.Appointments
        .Include(appointment => appointment.Stylist)
        .Include(appointment => appointment.Client)
        .ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      ViewBag.ClientId = new SelectList(_db.Clients, "ClientId", "Name");
      ViewBag.StylistId = new SelectList(_db.Stylists, "StylistId", "Name");
      return View();
    }
    [HttpPost]
    public ActionResult Create(Appointment appointment)
    {
      if (appointment.StylistId == 0)
      {
        return RedirectToAction("Create", "Stylists");
      }
      else if (appointment.ClientId == 0)
      {
        return RedirectToAction("Create", "Clients");
      }
      _db.Appointments.Add(appointment);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    // public ActionResult Details(int id)
    // {
    //   Client thisClient = _db.Clients
    //     .Include(client => client.Stylist)
    //     .FirstOrDefault(client => client.ClientId == id);
    //   return View(thisClient);
    // }

    // public ActionResult Edit(int id)
    // {
    //   Client thisClient = _db.Clients.FirstOrDefault(client => client.ClientId == id);
    //   ViewBag.StylistId = new SelectList(_db.Stylists, "StylistId", "Name");
    //   return View(thisClient);
    // }
    // [HttpPost]
    // public ActionResult Edit(Client client)
    // {
    //   _db.Clients.Update(client);
    //   _db.SaveChanges();
    //   return RedirectToAction("Index");
    // }

    // [HttpPost]
    // public ActionResult Delete(int id)
    // {
    //   Client thisClient = _db.Clients.FirstOrDefault(client => client.ClientId == id);
    //   _db.Clients.Remove(thisClient);
    //   _db.SaveChanges();
    //   return RedirectToAction("Index");
    // }
  }
}