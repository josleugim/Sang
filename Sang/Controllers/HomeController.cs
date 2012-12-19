using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sang.Models;
using System.Web.SessionState;

namespace Sang.Controllers
{
    public class HomeController : Controller
    {
        private SangDBContext _db = new SangDBContext();

        public ActionResult Options()
        {
            return View();
        }

        //
        // GET: /Collection/Create

        public ActionResult Create()
        {
            SangUser users = _db.SangUsers.FirstOrDefault(c => c.Email.Equals(User.Identity.Name));
            SangClient client = _db.SangClients.FirstOrDefault(c => c.SangUser.SangUserID.Equals(users.SangUserID));
            if (client == null)
            {

                List<int> n = new List<int> { 1, 2 };
                ViewBag.nMattress = new SelectList(n);

            //    List<int> age = new List<int> { 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50,
            //51, 52, 53, 54, 55, 56, 57, 58, 59, 60, 61, 62, 63, 64, 65, 66, 67, 68, 69, 70};
            //    ViewBag.cAge = new SelectList(age);

                //Set the ID of the relational sanguser
                var model = new SangClient
                {
                    SangUserId = users.SangUserID,
                    SangUser = users,
                    //Age = 0,
                    nMattressUsers = 0,
                    UserType = "Mayor de edad"
                };

                return View(model);
            }
            else
                return RedirectToAction("Edit", new { id = client.SangClientID });
        }

        //
        // POST: /Collection/Create

        [HttpPost]
        public ActionResult Create(SangClient sangclient, string cGender)
        {
            if (ModelState.IsValid)
            {
                if (sangclient.PrivacyNotice == false)
                {
                    return View(sangclient);
                }

                SangUser users = _db.SangUsers.FirstOrDefault(c => c.Email.Equals(User.Identity.Name));

                _db.SangClients.Add(sangclient);
                //sangclient.nMattressUsers = Convert.ToInt32(nMattress);
                sangclient.CompleteName = sangclient.UserName + " " + sangclient.FirstName + " " + sangclient.LastName;
                //sangclient.Age = Convert.ToInt32(cAge);
                sangclient.Gender = cGender;
                sangclient.RegisterDate = DateTime.Now;
                sangclient.SangUser = users;
                _db.SaveChanges();
                return RedirectToAction("AdultCuestionary", new { id = sangclient.SangClientID });
            }

            List<int> n = new List<int> { 1, 2 };
            ViewBag.nMattress = new SelectList(n);

            //List<int> age = new List<int> { 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50,
            //51, 52, 53, 54, 55, 56, 57, 58, 59, 60, 61, 62, 63, 64, 65, 66, 67, 68, 69, 70};
            //ViewBag.cAge = new SelectList(age);

            return View(sangclient);
        }

        //
        // GET: /Collection/Edit/

        public ActionResult Edit(int id)
        {
            SangClient client = _db.SangClients.Find(id);
            return View(client);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="formValues"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Edit(SangClient client)
        {
            if (ModelState.IsValid)
            {
                //SangClient adult = _db.SangClients.FirstOrDefault(a => a.SangClientID.Equals(id));
                _db.Entry(client).State = EntityState.Modified;
                _db.SaveChanges();

                return RedirectToAction("Options");
            }
            return View();
        }

        public ActionResult Introduction(string MenorEdad, string nMattress)
        {
            ViewBag.Message = "Inicio";
            ViewBag.ModelMattressID = new SelectList(_db.ModelMattress, "ModelMattressID", "ModelName");

            List<int> n = new List<int> { 1, 2 };
            ViewBag.nMattress = new SelectList(n);


            if (Request.HttpMethod == "POST")
            {
                if (nMattress != "")
                {
                    //SangClient client = _db.SangClients.FirstOrDefault(c => c.Email.Equals(User.Identity.Name));
                    //UpdateModel(client);
                    //client.nMattressUsers = Convert.ToInt32(nMattress);
                    //_db.SaveChanges();

                    if (MenorEdad == "Si")
                        return RedirectToAction("CuestionaryChild", "Home", new { id = Convert.ToInt32(nMattress) });
                    if (MenorEdad == "No")
                        return RedirectToAction("AdultCuestionary", "Home", new { id = Convert.ToInt32(nMattress) });
                }
            }

            return View();
        }

        //
        //Create Child Cuestionary
        //public ActionResult CuestionaryChild(int id)
        //{
        //    List<int> n = new List<int> { 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 };
        //    ViewBag.childAge = new SelectList(n);

        //    return View();
        //}

        //[HttpPost]
        //public ActionResult CuestionaryChild(SangChild child, int id, string Q1, string Q2, string Q3, string Q4, string Q5, string Q6, string Q7, string Q8,
        //    string Q9, string childAge)
        //{
        //    //if (ModelState.IsValid)
        //    //{
        //    child.CuestionaryResult = Convert.ToInt32(Q1) + Convert.ToInt32(Q2) + Convert.ToInt32(Q3) + Convert.ToInt32(Q4) + Convert.ToInt32(Q5) + Convert.ToInt32(Q6) + Convert.ToInt32(Q7) +
        //        Convert.ToInt32(Q8) + Convert.ToInt32(Q9);

        //    _db.SangChildren.Add(child);
        //    child.CompleteName = child.Name + " " + child.FirstName + " " + child.LastName;
        //    //child.Age = Convert.ToInt32(childAge);
        //    child.RegisterDate = DateTime.Now; //DateTime.ParseExact(DateTime.Now.ToShortDateString(),"dd/MM/yyyy",null);
        //    SangClient client = _db.SangClients.FirstOrDefault(c => c.SangClientID.Equals(id));
        //    child.SangClient = client;
        //    _db.SaveChanges();

        //    int result = Convert.ToInt32(child.CuestionaryResult);
        //    if (result != null)
        //    {
        //        ViewData["waranty"] = result * 10;
        //        if (result < 20)
        //            ViewData["Sugest"] = "El resultado de Grado de Somnolencia Epworth para menores de edad se encuentra dentro de los limites normales, por lo que por el momento no requiere apoyo especializado, si considera que es importante la valoración de un especialista, por favor imprima éste estudio y programe una cita en una de las Clínicas del Sueño cuyos datos se encuentran en los panfletos que venían dentro del folleto de su producto säng y al hacerlo por favor mencione el resultado obtenido a través del portal säng.";
        //        if (result >= 20)
        //            ViewData["Sugest"] = "El resultado de Grado de Somnolencia Epworth para menores de edad no se encuentra dentro de límites normales. Lo que sugiere la presencia de un trastorno de sueño, por lo que le sugerimos realizar el Estudio de Calidad del Sueño (Sleep Image).";
        //    }
        //    //return RedirectToAction("ChildResult", new { result = Convert.ToInt32(child.CuestionaryResult)});
        //    return View("ChildDiagnosis", child);
        //    //}

        //    //return View();
        //}

        public ActionResult ChildResult(int result, SangChild child)
        {
            ViewData["waranty"] = result * 10;
            if (result < 20)
                ViewData["Sugest"] = "El resultado de Grado de Somnolencia Epworth para menores de edad se encuentra dentro de los limites normales, por lo que por el momento no requiere apoyo especializado, si considera que es importante la valoración de un especialista, por favor imprima éste estudio y programe una cita en una de las Clínicas del Sueño cuyos datos se encuentran en los panfletos que venían dentro del folleto de su producto säng y al hacerlo por favor mencione el resultado obtenido a través del portal säng.";
            if (result >= 20)
                ViewData["Sugest"] = "El resultado de Grado de Somnolencia Epworth para menores de edad no se encuentra dentro de límites normales. Lo que sugiere la presencia de un trastorno de sueño, por lo que le sugerimos realizar el Estudio de Calidad del Sueño (Sleep Image).";

            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //public ActionResult Edit(int id)
        //{
        //    SangClient adult = _db.SangClients.Find(id);
        //    return View(adult);
        //}


        //
        //Edit Adult cuestionary result and data
        public ActionResult AdultCuestionary(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdultCuestionary(int id, string Q1, string Q2, string Q3, string Q4, string Q5, string Q6, string Q7, string Q8,
            string Q9, string Q10, string Q11, string Q12, string Q13, string Q14, string Q15, string Q16, string Q17, string Q18, string Q19, string Q20,
            string Q21)
        //public ActionResult AdultCuestionary(int id, FormCollection formValues)
        {
            if (ModelState.IsValid)
            {
                SangClient adult = _db.SangClients.FirstOrDefault(a => a.SangClientID.Equals(id));
                UpdateModel(adult);

                adult.Disorder1 = (Convert.ToInt32(Q1) + Convert.ToInt32(Q7) + Convert.ToInt32(Q8)) / 3;
                adult.Disorder2 = (Convert.ToInt32(Q2) + Convert.ToInt32(Q3) + Convert.ToInt32(Q4) + Convert.ToInt32(Q12)) / 4;
                adult.Disorder3 = (Convert.ToInt32(Q5) + Convert.ToInt32(Q10)) / 2;
                adult.Disorder4 = Convert.ToInt32(Q10);
                adult.Disorder5 = (Convert.ToInt32(Q6) + Convert.ToInt32(Q9) + Convert.ToInt32(Q11)) / 3;
                adult.Disorder7 = Convert.ToInt32(Q13) + Convert.ToInt32(Q14) + Convert.ToInt32(Q15) + Convert.ToInt32(Q16) + Convert.ToInt32(Q17) + Convert.ToInt32(Q18) +
                    Convert.ToInt32(Q19) + Convert.ToInt32(Q20);
                adult.Disorder8 = Convert.ToInt32(Q21);

                _db.SaveChanges();

                return RedirectToAction("AdultResult", new
                {
                    d1 = Convert.ToInt32(adult.Disorder1),
                    d2 = Convert.ToInt32(adult.Disorder2),
                    d3 = Convert.ToInt32(adult.Disorder3),
                    d4 = Convert.ToInt32(adult.Disorder4),
                    d5 = Convert.ToInt32(adult.Disorder5),
                    d7 = Convert.ToInt32(adult.Disorder7),
                    d8 = Convert.ToInt32(adult.Disorder8)
                });
            }

            return View();
        }

        public ActionResult AdultResult(int d1, int d2, int d3, int d4, int d5, int d7, int d8)
        {
            //Scale 1 x 4
            ViewData["d1"] = d1 * 4;
            ViewData["d2"] = d2 * 4;
            ViewData["d3"] = d3 * 4;
            ViewData["d5"] = d5 * 4;

            ViewData["d4High"] = "yes";
            ViewData["d4Low"] = "yes";
            if (d4 <= 40)
                ViewData["d4High"] = "hidden";
            else
                ViewData["d4Low"] = "hidden";


            ViewData["d7"] = d7;

            if (d8 == 100)
                ViewData["d8Low"] = "hidden";
            else
                ViewData["d8High"] = "hidden";

            return View();
        }

        public ActionResult About()
        {

            return Redirect("Content/index.html");
        }

        //
        //Search Warranty
        public ActionResult Index(string searchString)
        {
            ViewBag.Message = "Säng";
            if (Request.HttpMethod == "POST")
            {
                if (!String.IsNullOrEmpty(searchString))
                {
                    var searchw = from w in _db.Warranties
                                  where w.WarrantyCode == searchString
                                  select w;

                    if (searchw.Count() != 0)
                    {
                        var actived = searchw.First();
                        if (actived.IsActived)
                        {
                            return RedirectToAction("Register", "Account", new { w = searchString });
                        }
                        else
                            return RedirectToAction("LogOn", "Account", new { message = "Garantía activada, inicie sesión para continuar." });

                    }

                    if (searchw.Count() == 0)
                    {
                        ViewData["waranty"] = "Garantía invalida";
                        Response.Write("<script>alert('Garantía invalida!!');</script>");
                    }
                }
                else
                    ViewData["waranty"] = "Proporcione una garantía";
                Response.Write("<script>alert('Proporcione una garantía!!');</script>");
            }

            return View();
        }

        //
        //Validate Security Code
        public ActionResult ValidateCode(string id)
        {
            if (!String.IsNullOrEmpty(id))
            {
                //var searchcode = from c in _db.SangClients
                //              where c.SecureCode.ToString() == code
                //              select c;
                Guid temp = new Guid(id);
                SangUser user = _db.SangUsers.FirstOrDefault(s => s.SecureCode.Equals(temp));

                if (user != null)
                {
                    UpdateModel(user);
                    user.IsActived = true;
                    _db.SaveChanges();

                    Warranty warranty = _db.Warranties.FirstOrDefault(s => s.WarrantyCode.Equals(user.tempWarranty));
                    UpdateModel(warranty);
                    warranty.IsActived = false;
                    _db.SaveChanges();

                    return RedirectToAction("LogOn", "Account", new { message = "Cuenta activada, inicie sesión para continuar." });
                }
            }

            return View();
        }

        /// <summary>
        /// Newsletters the register.
        /// </summary>
        /// <param name="newsletter">The newsletter.</param>
        /// <returns></returns>
        [HttpPost]
        public ViewResult NewsletterRegister(Newsletter newsletter)
        {
            if (ModelState.IsValid)
            {
                var searchMail = from e in _db.Newsletters
                                 where e.Email == newsletter.Email
                                 select e;
                if (searchMail.Count() == 0)
                {
                    _db.Newsletters.Add(newsletter);
                    newsletter.IsActived = true;
                    newsletter.RegisterDate = DateTime.Now;
                    _db.SaveChanges();
                    return View("ThanksNewsletter", newsletter);
                }
                else
                    return View("AlreadyEmailRegister");
            }
            return View("ErrorEmailRegister");
        }
    }
}
