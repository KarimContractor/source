using System;
using System.Linq;
using WebApplication10.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication10.Controllers
{
    [RequireHttps]
        //[SessionState(System.Web.SessionState.SessionStateBehavior.Default)]
    public class HomeController : Controller
    {

        private readonly context con;
        public HomeController(context icon)
        {
            con = icon;
        }

        public ActionResult Index()
        {
            //Response.Cache.SetNoStore();
            //var count = con.Carts.Count();
           ViewData["count"] =Cartcount();
            ViewData["total"]= Gettotal();
            var a = (from abc in con.Stocks select abc).ToList();
            return View(a);
            
        }
        public ActionResult ViewCart()
        {
            var count = con.Carts.Count();
            ViewData["count"] = Cartcount();
            ViewData["total"] = Gettotal();

            var a = (from abc in con.Carts select abc).ToList();
            return View(a);

        }
        public ActionResult CheckOutinfo()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CheckOutinfo(Order od)
        {
            if (TryValidateModel(od))
            {
                Order or = new Order();
                or.Address = od.Address;
                or.City = od.City;
                or.Country = od.Country;
                or.Email = od.Email;
                or.FirstName = od.FirstName;
                or.LastName = od.LastName;
                or.OrderDate = DateTime.Now.ToLocalTime();
                or.Phone = od.Phone;
                or.PostalCode = od.PostalCode;
                or.State = od.State;
                or.Total = Gettotal();

                con.Orders.Add(or);
                con.SaveChanges();
                TempData["orderid"] = or.OrderId;
               
                return RedirectToAction(actionName:"Orderdetail",controllerName:"Home");

               
                
            }
            else
            {
                return View();
            }
        }
        public ActionResult Orderdetail()
        {

            var ID =Convert.ToInt32(TempData["orderid"]);
            var a = (from abc in con.Carts select abc).ToList();
            foreach (var b in a)
            {
                var st = (from abc in con.Stocks where abc.id.Equals(b.Stockid) select abc).FirstOrDefault();
                Orderdetail od = new Orderdetail();
                od.OrderId = ID;
                od.StockId = b.Stockid;
                od.Quantity = b.Quantity;
                od.UnitPrice = st.UnitPriceavg;
                con.Orderdetails.Add(od);   
            }
            con.SaveChanges();
            TempData["ordid"] = ID;
           

            return RedirectToAction("sale",controllerName:"Home");
        }
        public ActionResult sale()
        {
            try
            {
                var id =Convert.ToInt32(TempData["ordid"]);
                var a = (from abc in con.Carts select abc).ToList();
                foreach (var b in a)
                {
                    var st = (from abc in con.Stocks where abc.id.Equals(b.Stockid) select abc).FirstOrDefault();
                    Sales se = new Sales();
                    se.Name = st.Name;
                    se.Price = st.UnitPriceavg;
                    se.Quantity = b.Quantity;
                    se.Category = st.Category;
                    se.OrderId = id;
                    con.Sale.Add(se);
                    var stk = (from abc in con.Stocks where abc.id.Equals(b.Stockid) select abc).ToList();
                    foreach (var v in stk)
                    {
                        v.Quantity -= b.Quantity;
                    }

                }
                Emptycart();
                con.SaveChanges();

                return RedirectToAction("Index", controllerName: "Home");
            } catch (Exception ex) { return View(ex.Message); }
        }
        public PartialViewResult All()
        {
            try
            {
                var a = (from abc in con.Stocks select abc).ToList();
                return PartialView(a);
            }
            catch (Exception ex)
            {
                return PartialView(ex.Message);
            }
        }
        public ActionResult Search(string text)
        {
            try
            {
                var a = (from abc in con.Stocks where abc.Name.StartsWith(text) || abc.Name.EndsWith(text) select abc).ToList();
                return View(a);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }
        public ActionResult Addtocart(Stock st)
        {
            try
            {
                var a = (from abc in con.Carts where abc.Stockid.Equals(st.id) select abc).FirstOrDefault();
                if (a == null)
                {
                    Cart cr = new Cart();
                    cr.Stockid = st.id;
                    cr.Addon = DateTime.Now.ToLocalTime();
                    cr.Quantity = 1;

                    con.Carts.Add(cr);
                    con.SaveChanges();
                }
                else
                {
                    var b = (from abc in con.Carts where abc.Stockid.Equals(st.id) select abc).ToList();
                    foreach (var abc in b)
                    {
                        abc.Quantity += 1;
                    }
                    con.SaveChanges();
                }

                return RedirectToAction("Index", controllerName: "Home");
            }
            catch (Exception ex) { return View(ex.Message); }
        }

        public ActionResult Removeitem(Stock st)
        {
            try
            {
                var a = (from abc in con.Carts where abc.Stockid.Equals(st.id) && abc.Quantity > 1 select abc).ToList();
                if (a != null)
                {
                    foreach (var abc in a)
                    {
                        abc.Quantity -= 1;
                    }
                    con.SaveChanges();
                }
                else
                {
                    var b = (from abc in con.Carts where abc.Stockid.Equals(st.id) && abc.Quantity > 1 select abc).FirstOrDefault();
                    con.Carts.Remove(b);
                    con.SaveChanges();
                }


                return View();
            }
            catch (Exception ex) { return View(ex.Message); }
        }
        public int Cartcount()
        {
            try
            {
                int count = 0;
                var a = (from abc in con.Carts select abc).ToList();
                foreach (var b in a)
                {
                    count += b.Quantity;
                }

                return count;
            }
            catch (Exception ex) { return 101; }
        }
        public ActionResult Emptycart()
        {
            try
            {
                ///List<Cart> ct = new List<Cart>();
                var a = (from abc in con.Carts select abc).ToList();
                foreach (var b in a)
                {
                    con.Carts.Remove(b);
                   // Cart c = new Cart();
                   // c.Id = b.Id;
                    //c.Quantity = b.Quantity;
                    //c.Stockid = b.Stockid;
                    //c.Addon = b.Addon;
                    //ct.Add(c);
                }

                //con.Carts.RemoveRange(ct);
                con.SaveChanges();
                return RedirectToAction("Index",controllerName:"Home");
            }
            catch (Exception ex) { return View(ex.Message); }
        }
        public int Gettotal()
        {
            try
            {
                int total = 0;
                var a = (from abc in con.Carts select abc).ToList();
                foreach (var b in a)
                {
                    var c = (from abc in con.Stocks where abc.id.Equals(b.Stockid) select abc).FirstOrDefault();
                    total += c.UnitPriceavg * b.Quantity;
                }

                return total;
            }
            catch (Exception ex) { return 101; }

        }
        public ActionResult Login()
        {

            return View();  
        }

        [HttpPost]
        public ActionResult Login(Logs lg)
        {
            //HttpContext.Session.Add("abc",null);
            //HttpContext.Session.Add("UserName", null);
            //HttpContext.Session.Add("Previlages", null);
            try
            {
                var a = (from abc in con.log where abc.UserName.Equals(lg.UserName.ToString()) && abc.Password.Equals(lg.Password.ToString()) select abc).FirstOrDefault();
                if (a != null)
                {
                    string us =Convert.ToString(a.UserName);
                    var pre =a.Previlages;
                    
                    TempData["id"] = a.Id;
                    HttpContext.Session.Set("tt" , System.Text.Encoding.Unicode.GetBytes(a.Previlages.ToString()));
                    
                   // Session["Username"] = Convert.ToString(a.UserName);
                  //Session["Previlages"] = Convert.ToString(a.Previlages);
                    if (pre.Equals("Admin"))
                    {
                        TempData["prev"] = "Admin";
                       // Session.Add("sat", pre);

                        //Session["sat"] = "Admin";
                        return RedirectToAction("Index", controllerName: "Admin");
                    }
                    else if (pre.Equals("Sales"))
                    {
                        TempData["prev"] = "Sales";
                        //Session.Add("sat", pre);
                        //Session["sat"] = "Sales";
                        return RedirectToAction("Index", controllerName: "Sales");
                    }
                    else if (pre.Equals("Purchase"))
                    {
                        TempData["prev"] = "Purchase";
                        //Session.Add("sat", "Purchase");
                        //Session["sat"] = "Purchases";
                        return RedirectToAction("Index", controllerName: "Purchase");
                    }
                    else { return View(); }
                }
            }
            catch (Exception e) { (e.Message).ToString(); }


            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}