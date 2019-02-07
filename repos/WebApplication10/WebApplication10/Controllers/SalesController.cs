using System;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication10.Models;

namespace WebApplication10.Controllers
{
    [RequireHttps]
    public class SalesController : Controller
    {
        private readonly context con;
        public SalesController(context icon)
        {
            con = icon;
        }
        
        // GET: Sales
        public ActionResult Index()
        {
           // Response.Cache.SetNoStore();
            try
            {
                var id =System.Text.Encoding.Unicode.GetBytes(TempData["id"].ToString());
                var pre = TempData["prev"];
                HttpContext.Session.Set("Adm" , id);
                //var a =Convert.ToString(Session["sat"]);
                if (id != null)
                {

                    //var data = (from abc in con.log where abc.Id.Equals(id) select abc).FirstOrDefault();
                    //Response.Cache.SetNoStore();
                    //Cunstructor

                    if (pre.Equals("Admin"))
                    {
                        return  RedirectToAction("Index", controllerName: "Admin");
                    }
                    else if (pre.Equals("Sales"))
                    {
                        return View();// RedirectToAction("Index", controllerName: "Sales");
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
                return RedirectToAction("Login", controllerName: "Home");
                //RedirectTo("Login", controllerName: "Home");
            }

            
        }
        [HttpPost]
        public ActionResult Index(Sales sl)
        {
            if (TryValidateModel(sl))
            {

                var a = (from abc in con.Stocks where abc.Name.Equals(sl.Name.ToString())&& abc.Quantity>0 select abc).FirstOrDefault();
                if (a != null)
                {
                    
                    con.Sale.Add(sl);
                    con.SaveChanges();
                    Recivables rss = new Recivables()
                    {
                        CustomerID = sl.CustomerId,
                        SalesID = sl.id,
                        dateadd = DateTime.Now.ToLocalTime(),
                        

                        
                    };

                    
                    return RedirectToAction("Stockupd",new { Id=sl.id,st=a.id });


                }
                else
                {
                    return View("Not present Stock");
                   // con.Sale.Add(sl);
                    //con.SaveChanges();
                    //Stock st = new Stock()
                    //{
                      //  id=0,
                       // Name =sl.Name,
                       // Quantity =sl.Quantity,
                       // Category =sl.Category,
                        //UnitPriceavg =sl.Price,
                        
                        
                    //};
                    //con.Stocks.Add(st);
                    //con.SaveChanges();

                }


                //return RedirectToAction("Index", controllerName: "Sales");
            }
            
            {
                return View();
            }
        }

        public ActionResult Stockupd(int Id, int st)
        {
            try
            {
                //double unitprice=0;
                //int b = 1;
                //string name;
                var n = (from abc in con.Sale where abc.id.Equals(Id) select abc).FirstOrDefault();
                //name = n.Name;
                Sales sl = n;
               
                HttpContext.Session.Set("Sale" , System.Text.Encoding.Unicode.GetBytes(n.id.ToString()));
                TempData["sid"] = n.id;
                // var a = (from abc in con.Sale where abc.Name.Equals(name) select abc).ToList();

                //foreach (var acc in a)
                // {

                //   unitprice += acc.Price;
                //  b++;


                //         }
                //     var unit= unitprice / b;
                var stk = (from abc in con.Stocks where abc.id.Equals(st) select abc).ToList();
                foreach (Stock abc in stk)
                {
                    abc.Quantity -= sl.Quantity;
                    //abc.UnitPriceavg =Convert.ToInt32(unit.ToString());

                }

                //con.Stocks.SqlQuery("update Stock where id=='" + stk.id + "'set Name='" + sl.Name + "',Quantity='" + sl.Quantity + "',Category='" + sl.Category + "',UnitPriceavg='" + unit + "'");
                con.SaveChanges();

                return View();
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                return View();
            }
        }
        [HttpPost]
        public ActionResult list(Recivables rs)
        {
            if (HttpContext.Session.GetString("Adm") != null)
            {
                try
                {
                    var sl = Convert.ToInt32(TempData["sid"].ToString());
                    Sales a = (from abc in con.Sale where abc.id.Equals(sl) select abc).FirstOrDefault();
                    Recivables rd = new Recivables()
                    {

                        CustomerID = a.CustomerId,
                        SalesID = a.id,
                        dateadd = DateTime.Now.ToLocalTime(),
                        SlipNo = rs.SlipNo,
                        Status = rs.Status



                    };
                    con.Recivable.Add(rd);
                    con.SaveChanges();
                    return View((from abc in con.Sale select abc).ToList());
                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                    return View((from abc in con.Sale select abc).ToList());
                }
            }
            else { return RedirectToAction("Login", controllerName: "Home"); }
        }
    }
}