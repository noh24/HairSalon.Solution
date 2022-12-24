using System;

namespace HairSalon.Models
{
  public class Appointment
  {
    public int AppointmentId { get; set; }
    public DateTime DateTime { get; set; }
    public int Price { get; set; }
    public int StylistId { get; set; }
    public Stylist Stylist { get; set; }
    public int ClientId { get; set; }
    public Client Client { get; set; }
  }
}