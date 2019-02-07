using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using WebApplication10.Models;


namespace WebApplication10.Controllers
{
    [RequireHttps]
   // [SessionState(System.Web.SessionState.SessionStateBehavior.Default)]
    public class AdminController : Controller
    {
        private readonly context con;
        public AdminController(context icon)
        {
            
            con = icon;
        }

       
        // GET: Admin
        public ActionResult Index()
        {
            //Dashboard
            //Response.Cache.SetNoStore();
            try
            {
                var id =System.Text.Encoding.Unicode.GetBytes(TempData["id"].ToString());
                var pre = TempData["prev"];
               HttpContext.Session.Set("Adm",id);
                //var a =Convert.ToString(Session["sat"]);
                if (id != null)
                {

                    //var data = (from abc in con.log where abc.Id.Equals(id) select abc).FirstOrDefault();
                    //Response.Cache.SetNoStore();
                    //Cunstructor
                   
                    if (pre.Equals("Admin"))
                    {
                        return View();// RedirectToAction("Index", controllerName: "Admin");
                    }
                    else if (pre.Equals("Sales"))
                    {
                      return  RedirectToAction("Index", controllerName: "Sales");
                    }
                    else if (pre.Equals("Purchase"))
                    {
                       return RedirectToAction("Index", controllerName: "Purchase");
                    }
                    else
                    {
                       return RedirectToAction("Login", controllerName: "Home");
                    }
                }
                else { return RedirectToAction("Login", controllerName: "Home"); }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            return    RedirectToAction("Login", controllerName: "Home");
                //RedirectTo("Login", controllerName: "Home");
            }
            
        }
        //sales functions
        public ActionResult Salelist()
        {
            if (HttpContext.Session.GetString("adm") != null)
            {
                return View((from abc in con.Sale select abc).ToList());
            }
            else { return RedirectToAction("Login", controllerName: "Home"); }


        }
        public ActionResult Saleedt(Sales se)
        {

            var a = (from abc in con.Sale where abc.id.Equals(se.id) select abc).FirstOrDefault();
            return View(a);
        }
        public ActionResult Saleedt1(Sales se)
        {

            var a = (from abc in con.Sale where abc.id.Equals(se.id) select abc).FirstOrDefault();
            a.Name = se.Name;
            a.Price = se.Price;
            a.Quantity = se.Quantity;
            a.CustomerId = se.CustomerId;
            a.Category = se.Category;
            Saleedt(a);
            con.SaveChanges();
            return RedirectToAction("Salelist", controllerName: "Admin");
        }
        public ActionResult Saledel(Sales se)
        {
            con.Sale.Remove(se);
            con.SaveChanges();
            return RedirectToAction("Salelist", controllerName: "Admin");
        }
        //Purch
        public ActionResult Purchaselist()
        {
            if (HttpContext.Session.GetString("Adm") != null)
            {
                return View((from abc in con.Purchase select abc).ToList());
            }
            else
            {
                return RedirectToAction("Login", controllerName: "Home");
            }
        }
        public ActionResult purchaseedt(Purchases ps)
        {
           
            return View((from abc in con.Purchase where abc.id.Equals(ps.id) select abc).FirstOrDefault());
        }
        public ActionResult purcahseedt1(Purchases ps)
        {
            var a = (from abc in con.Purchase where abc.id.Equals(ps.id) select abc).FirstOrDefault();
            a.Name = ps.Name;
            a.Price = ps.Price;
            a.ProviderId = ps.ProviderId;
            a.Quantity = ps.Quantity;
            a.Category = ps.Category;
            purchaseedt(a);
            con.SaveChanges();
            return RedirectToAction("Purchaselist", controllerName: "Admin");
        }
        public ActionResult purcahsedel(Purchases ps)
        {
            con.Purchase.Remove(ps);
            con.SaveChanges();
            return RedirectToAction("Purchaselist", controllerName: "Admin");
        }
        public ActionResult Stocklist()
        {
            if (HttpContext.Session.GetString("Adm") != null)
            {
                return View((from abc in con.Stocks select abc).ToList());
            }
            else
            {
                return RedirectToAction("Login", controllerName: "Home");
            }

        }
        public ActionResult Stockedt(Stock st)
        {
            var a = (from abc in con.Stocks where abc.id.Equals(st.id) select abc).FirstOrDefault();
            return View(a);
        }
        public ActionResult Stockedt1(Stock st)
        {
            var a = (from abc in con.Stocks where abc.id.Equals(st.id) select abc).FirstOrDefault();
            a.Category = st.Category;
            a.Name = st.Name;
            a.Quantity = st.Quantity;
            a.UnitPriceavg = st.UnitPriceavg;
            Stockedt(a);
            con.SaveChanges();

            return RedirectToAction("Stocklist", controllerName: "Admin");
        }
        public ActionResult Stockdel(Stock st)
        {
            con.Stocks.Remove(st);
            con.SaveChanges();
            return RedirectToAction("Stocklist", controllerName: "Admin");
        }
        public ActionResult login()
        {
            if (HttpContext.Session.GetString("Adm") != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", controllerName: "Home");
            }
        }
        [HttpPost]
        public ActionResult login(Logs ls)
        {
            if (TryValidateModel(ls))
            {
                con.log.Add(ls);
                con.SaveChanges();
                return RedirectToAction("loginlist", controllerName: "Admin");
            }
            else
            {
                return View();
            }
        }
        public ActionResult loginlist()
        {
            if (HttpContext.Session.GetString("Adm") != null)
            {
                return View((from abc in con.log select abc).ToList());
            }
            else
            {
                return RedirectToAction("Login", controllerName: "Home");
            }
        }
        public ActionResult loginedt(Logs ls)
        {
            var a = (from abc in con.log where abc.Id.Equals(ls.Id) select abc).FirstOrDefault();
            return View(a);
        }
        public ActionResult loginedt1(Logs ls)
        {
            var a = (from abc in con.log where abc.Id.Equals(ls.Id) select abc).FirstOrDefault();
            a.Name = ls.Name;
            a.Password = ls.Password;
            a.Previlages = ls.Previlages;
            a.UserName = ls.UserName;
            loginedt(a);
            con.SaveChanges();
            return RedirectToAction("loginlist", controllerName: "Admin");
        }
        public ActionResult logindel(Logs ls)
        {
            con.log.Remove(ls);
            con.SaveChanges();
            return RedirectToAction("loginlist", controllerName: "Admin");
        }
        public ActionResult Provider()
        {
            if (HttpContext.Session.GetString("Adm") != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", controllerName: "Home");
            }
        }
        [HttpPost]
        public ActionResult Provider(Providers ps)
        {
            if (TryValidateModel(ps))
            {
                con.Provider.Add(ps);
                con.SaveChanges();
                return RedirectToAction("Providerlist", controllerName: "Admin");
            }
            else
            {
                return View();
            }
        }
        public ActionResult Providerlist()
        {
            if (HttpContext.Session.GetString("Adm") != null)
            {
                return View((from abc in con.Provider select abc).ToList());
            }
            else
            {
                return RedirectToAction("Login", controllerName: "Home");
            }
        }
        public ActionResult Provideredt(Providers ps)
        {
            var a = (from abc in con.Provider where abc.Id.Equals(ps) select abc).FirstOrDefault();
            return View(a);

        }
        public ActionResult Provideredt1(Providers ps)
        {
            var a = (from abc in con.Provider where abc.Id.Equals(ps) select abc).FirstOrDefault();
            a.Address = ps.Address;
            a.Membersfrom = DateTime.Now.ToLocalTime();
            a.Name = ps.Name;
            a.Rating = ps.Rating;
            a.Review = ps.Review;
            Provideredt(a);
            con.SaveChanges();
            return RedirectToAction("Providerlist", controllerName: "Admin");
        }
        public ActionResult Providerdel(Providers ps)
        {
            con.Provider.Remove(ps);
            con.SaveChanges();
            return RedirectToAction("Providerlist", controllerName: "Admin");
        }
        public ActionResult Customer()
        {
            if (HttpContext.Session.GetString("Adm") != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", controllerName: "Home");
            }
        }
        [HttpPost]
        public ActionResult Customer(Customers cs)
        {
            if (TryValidateModel(cs))
            {
                con.customer.Add(cs);
                con.SaveChanges();
                return RedirectToAction("Customerlist", controllerName: "Admin");
            }
            else
            {
                return View();
            }
        }
        public ActionResult Customerlist()
        {
            if (HttpContext.Session.GetString("Adm") != null)
            {
                return View((from abc in con.customer select abc).ToList());
            }
            else
            {
                return RedirectToAction("Login", controllerName: "Home");
            }
        }
        public ActionResult Customeredt(Customers cs)
        {
            var a = (from abc in con.customer where abc.Id.Equals(cs.Id)select abc).FirstOrDefault();
            return View(a);
        }
        public ActionResult Customeredt1(Customers cs)
        {
            var a = (from abc in con.customer where abc.Id.Equals(cs.Id) select abc).FirstOrDefault();
            a.Address = cs.Address;
            a.Customerfrom = DateTime.Now.ToLocalTime();
            a.Name = cs.Name;
            a.Rating = cs.Rating;
            Customeredt(a);
            con.SaveChanges();
            return RedirectToAction("Customerlist", controllerName: "Admin");
        }
        public ActionResult Customerdel(Customers cs)
        {
            con.customer.Remove(cs);
            con.SaveChanges();
            return RedirectToAction("Customerlist", controllerName: "Admin");
        }
        public ActionResult Payablelist()
        {
            if (HttpContext.Session.GetString("Adm") != null)
            {
                return View((from abc in con.Payable select abc).ToList());
            }
            else
            {
                return RedirectToAction("Login", controllerName: "Home");
            }
        }
        public ActionResult Payableedt(Payables ps)
        {
            var a = (from abc in con.Payable where abc.Id.Equals(ps.Id) select abc).FirstOrDefault();
            return View(a);
        }
        public ActionResult Payableedt1(Payables ps)
        {
            var a = (from abc in con.Payable where abc.Id.Equals(ps.Id) select abc).FirstOrDefault();
            //a.dateadd = ps.dateadd;
            a.ProvidersID = ps.ProvidersID;
            a.PurchasesID = ps.PurchasesID;
            a.SlipNo = ps.SlipNo;
            a.Status = ps.Status;
            a.updatedate = DateTime.Now.ToLocalTime();
            Payableedt(a);
            con.SaveChanges();
            return RedirectToAction("Payablelist", controllerName: "Admin");
        }
        public ActionResult Payabledel(Payables ps)
        {
            con.Payable.Remove(ps);
            con.SaveChanges();
            return RedirectToAction("Payablelist", controllerName: "Admin");
        }
        public ActionResult Recivablelist()
        {
            if (HttpContext.Session.GetString("Adm") != null)
            {
                return View((from abc in con.Recivable select abc).ToList());
            }
            else
            {
                return RedirectToAction("Login", controllerName: "Home");
            }
        }
        public ActionResult Recivableedt(Recivables rs)
        {
            var a = (from abc in con.Recivable where abc.Id.Equals(rs.Id) select abc).FirstOrDefault();

            return View(a);
        }
        public ActionResult Recivableedt1(Recivables rs)
        {
            var a = (from abc in con.Recivable where abc.Id.Equals(rs.Id) select abc).FirstOrDefault();
            a.SalesID = rs.SalesID;
            a.SlipNo = rs.SlipNo;
            a.Status = rs.Status;
            a.updatedate = DateTime.Now.ToLocalTime();
            Recivableedt(a);
            con.SaveChanges();

            return RedirectToAction("Recivablelist", controllerName: "Admin");
        }
        public ActionResult Recivabledel(Recivables rs)
        {
            con.Recivable.Remove(rs);
            con.SaveChanges();
            return RedirectToAction("Recivablelist", controllerName: "Admin");
        }

        public ActionResult Logout()
        {
            if (HttpContext.Session.GetString("Adm") != null)
            {
                
                HttpContext.Session.Remove("Adm");
                HttpContext.Session.Clear();
                return RedirectToAction("Login", controllerName: "Home");
            }
            else
            {
                return RedirectToAction("Login", controllerName: "Home");
            }
        }

    }
}