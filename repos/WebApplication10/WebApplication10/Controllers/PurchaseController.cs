using System;
using System.Linq;
using WebApplication10.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace Inventory_Mangement_System.Controllers
{
    [RequireHttps]
    public class PurchaseController : Controller
    {
        private readonly context con;
        public PurchaseController(context icon)
        {
            con = icon;
        }

        // GET: Purchase
        public ActionResult Index()
        {
            //Response.Cache.SetNoStore();
            try
            {
                var id = System.Text.Encoding.Unicode.GetBytes(TempData["id"].ToString());
                var pre = TempData["prev"];
                HttpContext.Session.Set("Adm", id);
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
                        return RedirectToAction("Index", controllerName: "Sales");
                    }
                    else if (pre.Equals("Purchase"))
                    {
                        return View(); //RedirectToAction("Index", controllerName: "Purchase");
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
        public ActionResult Index(Purchases ps)
        {
            if (TryValidateModel(ps))
            { var a = (from abc in con.Stocks where abc.Name.Equals(ps.Name.ToString()) && abc.Quantity > 0 select abc).FirstOrDefault();
                if (a != null)
                {

                    con.Purchase.Add(ps);
                    con.SaveChanges();
                    
                    return RedirectToAction("Stockupd", new { Id = ps.id, st = a.id });
                }
                else
                {
                     con.Purchase.Add(ps);
                    con.SaveChanges();
                    Stock st = new Stock()
                    {
                      
                     Name =ps.Name,
                     Quantity =ps.Quantity,
                     Category =ps.Category,
                    UnitPriceavg =ps.Price,


                    };
                    con.Stocks.Add(st);
                    con.SaveChanges();
                    return RedirectToAction("List", controllerName: "Purchase");
                }
            }
            else
            {
                return View();
            }
        }
        

        public ActionResult Stockupd(int Id, int st)
        {
            try
            {
                double unitprice = 0;
                int b = 1;
                string name;
                var n = (from abc in con.Purchase where abc.id.Equals(Id) select abc).FirstOrDefault();
                name = n.Name;
                Purchases sl = n;

                var a = (from abc in con.Purchase where abc.Name.Equals(name) select abc).ToList();

                foreach (var acc in a)
                {

                    unitprice += acc.Price;
                    b++;


                }
                TempData["purid"] = n.id;
                int unit =Convert.ToInt32(unitprice / b);
                var stk = (from abc in con.Stocks where abc.id.Equals(st) select abc).ToList();
                foreach (Stock abc in stk)
                {
                    abc.Quantity += sl.Quantity;
                    abc.UnitPriceavg = unit;

                }
                //con.Stocks.SqlQuery("update Stock where id=='" + stk.id + "'set Name='" + sl.Name + "',Quantity='" + sl.Quantity + "',Category='" + sl.Category + "',UnitPriceavg='" + unit + "'");
                con.SaveChanges();
                return View();
            }
            catch (Exception ex)
            {
                return View(ex.Message.ToString());
            }
        }
        [HttpPost]
        public ActionResult List(Payables ps)
        {
            if (HttpContext.Session.GetString("Adm") != null)
            {
                try
                {
                    var sl = Convert.ToInt32(TempData["purid"].ToString());
                    Purchases a = (from abc in con.Purchase where abc.id.Equals(sl) select abc).FirstOrDefault();
                    Payables rd = new Payables()
                    {

                        ProvidersID = a.ProviderId,
                        PurchasesID = a.id,
                        dateadd = DateTime.Now.ToLocalTime(),
                        SlipNo = ps.SlipNo,
                        Status = ps.Status

                    };
                    con.Payable.Add(rd);
                    con.SaveChanges();
                    return View((from abc in con.Purchase select abc).ToList());
                }
                catch (Exception ex)
                {
                    //   return View((from abc in con.Sale select abc).ToList());
                    ex.Message.ToString();
                    return View((from abc in con.Purchase select abc).ToList());
                }
            }
            else
            {
                return RedirectToAction("Login", controllerName: "Home");
            }


        }

    }

}
