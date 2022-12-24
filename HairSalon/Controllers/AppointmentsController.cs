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
        .OrderBy(appointment => appointment.DateTime)
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

    public ActionResult Details(int id)
    {
      Appointment thisAppointment = _db.Appointments
        .Include(appointment => appointment.Stylist)
        .Include(appointment => appointment.Client)
        .FirstOrDefault(appointment => appointment.AppointmentId == id);
      return View(thisAppointment);
    }

    public ActionResult Edit(int id)
    {
      Appointment thisAppointment = _db.Appointments.FirstOrDefault(appointment => appointment.AppointmentId == id);
      ViewBag.ClientId = new SelectList(_db.Clients, "ClientId", "Name");
      ViewBag.StylistId = new SelectList(_db.Stylists, "StylistId", "Name");
      return View(thisAppointment);
    }
    [HttpPost]
    public ActionResult Edit(Appointment appointment)
    {
      _db.Appointments.Update(appointment);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpPost]
    public ActionResult Delete(int id)
    {
      Appointment thisAppointment = _db.Appointments.FirstOrDefault(appointment => appointment.AppointmentId == id);
      _db.Appointments.Remove(thisAppointment);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}