namespace DeliveryInatechMvc.Controllers
{
    using DeliveryInatechMvc.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    namespace DeliveryBookingMVC.Controllers
    {
        public class ProjectController : Controller
        {
            // GET: Project
            public ActionResult Index()
            {
                return View();
            }
        public ActionResult Home()
            {
                return View();
            }

            public ActionResult About()
            {
                return View();
            }
         
            public ActionResult Terms()
            {
                return View();
            }
            public ActionResult CustomerLogin()
            {
                return View();
            }

            [HttpPost]
            public ActionResult CustomerLogin(DeliveryInatechMvc.Models.CustomerTb col)
            {
                using (DeliveryDbEntities db = new DeliveryDbEntities())
                {
                    var detail = db.CustomerTbs.Where(x => x.Email == col.Email && x.Password == col.Password).FirstOrDefault();
                    if (detail == null)
                    {
                        TempData["Message"] = "Invaldi Login Credentials";
                        return RedirectToAction("CustomerLogin", "Project");
                    }
                    else
                    {
                        return RedirectToAction("index1", "Project");
                    }
                }
            }

            public ActionResult Index1()
            {
                return View();
            }

            public ActionResult CustomerSignUp()
            {
                return View();
            }
            [HttpPost]
            public ActionResult CustomerSignUp(DeliveryInatechMvc.Models.CustomerTb col)
            {
                using (DeliveryDbEntities db = new DeliveryDbEntities())
                {
                    var detail = db.CustomerTbs.Where(x => x.Email == col.Email).FirstOrDefault();
                    if (detail == null)
                    {
                        db.CustomerTbs.Add(col);
                        db.SaveChanges();
                        TempData["Message"] = "Customer registered Successfully";
                        ModelState.Clear();
                        return View("CustomerLogin");
                    }
                    else
                    {
                        TempData["Message"] = "Email Already Exist Please Login";
                        ModelState.Clear();
                        return View("CustomerLogin");
                    }
                }
            }
            
             public ActionResult ExecutiveLogin()
            {
                return View();
            }
            [HttpPost]
            public ActionResult ExecutiveLogin(DeliveryInatechMvc.Models.ExecutiveTb elo)
            {
                using (DeliveryDbEntities db = new DeliveryDbEntities())
                {
                    var detail = db.ExecutiveTbs.Where(x => x.Email == elo.Email && x.Password == elo.Password).FirstOrDefault();
                    if (detail == null)
                    {
                        TempData["Message"] = "Invalid Login Credentials";
                        return RedirectToAction("ExecutiveLogin", "Project");
                    }
                    else
                    {
                        return RedirectToAction("index2", "Project");
                    }
                }
            }

            public ActionResult Index2()
            {
                return View();
            }
            public ActionResult ExecutiveSignUp()
            {
                return View();
            }
            [HttpPost]
            public ActionResult ExecutiveSignUp(DeliveryInatechMvc.Models.ExecutiveTb clog)
            {
                using (DeliveryDbEntities db = new DeliveryDbEntities())
                {
                    var detail = db.ExecutiveTbs.Where(x => x.Email == clog.Email).FirstOrDefault();
                    //var detail = db.CustomerTb.Where(x => x.Name == clog.Name x => x.Age == clog.Age x => clog.Address == clog.Address x => x.Password == clog.Password x => x.Email == clog.Email).FirstOrDefault();
                    if (detail == null)
                    {
                        db.ExecutiveTbs.Add(clog);      //email not found add clog into db.
                        db.SaveChanges();
                        TempData["Message"] = "Executive Registered Successfully";
                        return View("ExecutiveLogin");
                    }
                    else
                    {
                        TempData["Message"] = "Email Already Exist Please Login";
                        return View("ExecutiveLogin");
                    }
                }

            }

            public ActionResult ViewBooking()
            {
                using (DeliveryDbEntities db = new DeliveryDbEntities())
                {
                    var data = db.BookingTbs.ToList();
                    return View(data);
                }
            }
             public ActionResult CancelOrder(int OrderId)
            {

                using (DeliveryDbEntities db = new DeliveryDbEntities())
                {
                    var id = db.BookingTbs.Where(d => d.OrderId == OrderId).First();
                    if (id == null)
                    {
                        TempData["Message"] = "Error Occured";
                        return View("ViewBooking");
                    }
                    else
                    {
                        db.BookingTbs.Remove(id);
                        db.SaveChanges();
                        var data = db.BookingTbs.ToList();
                       TempData["Message"] = "Order Cancelled";
                        return View("ViewBooking", data);
                    }
                }
            }
            public ActionResult PendingDelivery()
            {
                using (DeliveryDbEntities db = new DeliveryDbEntities())
                {
                    
                    var data = db.BookingTbs.ToList();
                    return View(data);
                }
                
            }
            public ActionResult PendingDelivery2(BookingTb obj)
            {
                using (DeliveryDbEntities db = new DeliveryDbEntities())
                   {
                    BookingTb tbl = new BookingTb();
                    if (ModelState.IsValid)
                    {
                        tbl.OrderId = obj.OrderId;
                        tbl.CustomerId = obj.CustomerId;
                        tbl.Date = obj.Date;
                        tbl.Time = obj.Time;
                        tbl.Weight = obj.Weight;
                        tbl.Price = obj.Price;
                        tbl.Flag = false;
                        db.Entry(tbl).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                    ModelState.Clear();
                    //var data = db.Booking_Tbl.Where(d => d.Flag == true).ToList();
                    var data = db.BookingTbs.ToList();
                    TempData["Message"] = "Order Delivered";
                    return View("PendingDelivery", data);
                }
            }
               public ActionResult AddBooking()
            {
                BookingTb tbl = new BookingTb
                {
                    //CustomerId = Convert.ToInt32(Session["id"])
                    //Price = 100
                };
                return View(tbl);

            }
            [HttpPost]
            public ActionResult AddBooking(DeliveryInatechMvc.Models.BookingTb col)
            {
                try
                {
                    using (DeliveryDbEntities db = new DeliveryDbEntities())
                    {
                        db.BookingTbs.Add(col);
                        db.SaveChanges();
                    }
                    ModelState.Clear();
                    TempData["Message"] = "Booking successfully added to the system";
                    return RedirectToAction("ViewBooking", "Project");
                }
                catch (Exception ex)
                {
                    TempData["Message"] = ex.Message;
                    return View("AddBooking");
                }



            }

        }

    }
}       
    





