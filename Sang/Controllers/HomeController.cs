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
        // GET: /SangClient/Create

        public ActionResult Create()
        {
            SangUser users = _db.SangUsers.FirstOrDefault(c => c.Email.Equals(User.Identity.Name));
            Hospital hosp = _db.Hospitals.FirstOrDefault(h => h.HospitalName.Equals("Ninguno"));
            SangClient client = _db.SangClients.FirstOrDefault(c => c.SangUser.SangUserID.Equals(users.SangUserID));

            //
            //Si no existe el cliente se crea la cuenta
            if (client == null)
            {
                List<string> estado = new List<string> { "Aguascalientes", "Baja California", "Baja California Sur", "Campeche", 
                    "Chiapas", "Chihuahua", "Coahuila", "Colima", "Durango", "Guanajuato", "Guerrero", "Hidalgo", "Jalisco", "México",
                "Michoacán de Ocampo", "Morelos", "Nayarit", "Nuevo León", "Oaxaca", "Puebla", "Querétaro", "Quintana Roo",
                "San Luis Potosí", "Sinaloa", "Sonora", "Tabasco", "Tamaulipas", "Tlaxcala", "Veracruz", "Yucatán", "Zacatecas"};
                ViewBag.estado = new SelectList(estado);

                List<int> n = new List<int> { 1, 2 };
                ViewBag.nMattress = new SelectList(n);

                //Set the ID of the relational sanguser
                var model = new SangClient
                {
                    SangUserId = users.SangUserID,
                    SangUser = users,
                    nMattressUsers = 0,
                    UserType = "Mayor de edad",
                    Gender = "Ninguno",
                    HospitalId = hosp.HospitalID,
                    Hospital = hosp
                };

                return View(model);
            }
            //
            //Si ya existe la cuenta se envía la garantía
            else
                return RedirectToAction("Create", "Purchase", new { id = users.tempWarranty });
        }

        //
        // POST: /SangClient/Create

        [HttpPost]
        public ActionResult Create(SangClient sangclient, string cGender, string nMattress)
        {
            if (ModelState.IsValid && sangclient.PrivacyNotice != false)
            {
                var users = _db.SangUsers.FirstOrDefault(c => c.Email.Equals(User.Identity.Name));
                var hosp = _db.Hospitals.FirstOrDefault(h => h.HospitalName.Equals("Ninguno"));

                _db.SangClients.Add(sangclient);
                sangclient.CompleteName = sangclient.UserName + " " + sangclient.FirstName + " " + sangclient.LastName;
                sangclient.Gender = cGender;
                sangclient.RegisterDate = DateTime.Now;
                sangclient.SangUser = users;
                sangclient.Hospital = hosp;
                sangclient.nMattressUsers = Convert.ToInt32(nMattress);
                _db.SaveChanges();
                //return RedirectToAction("AdultCuestionary", new { id = sangclient.SangClientID });

                //Update the client in the warranty
                var warranty = _db.Warranties.FirstOrDefault(s => s.WarrantyCode.Equals(users.tempWarranty));
                UpdateModel(warranty);
                warranty.SangClient = sangclient;
                _db.SaveChanges();

                return RedirectToAction("Create", "Purchase", new { id = warranty.WarrantyCode });
            }

            var estado = new List<string> { "Aguascalientes", "Baja California", "Baja California Sur", "Campeche", 
                    "Chiapas", "Chihuahua", "Coahuila", "Colima", "Durango", "Guanajuato", "Guerrero", "Hidalgo", "Jalisco", "México",
                "Michoacán de Ocampo", "Morelos", "Nayarit", "Nuevo León", "Oaxaca", "Puebla", "Querétaro", "Quintana Roo",
                "San Luis Potosí", "Sinaloa", "Sonora", "Tabasco", "Tamaulipas", "Tlaxcala", "Veracruz", "Yucatán", "Zacatecas"};
            ViewBag.estado = new SelectList(estado);

            var n = new List<int> { 1, 2 };
            ViewBag.nMattress = new SelectList(n);

            return View(sangclient);
        }

        public ActionResult CreateSecond()
        {
            var users = _db.SangUsers.FirstOrDefault(c => c.Email.Equals(User.Identity.Name));
            var hosp = _db.Hospitals.FirstOrDefault(h => h.HospitalName.Equals("Ninguno"));

            var estado = new List<string> { "Aguascalientes", "Baja California", "Baja California Sur", "Campeche", 
                    "Chiapas", "Chihuahua", "Coahuila", "Colima", "Durango", "Guanajuato", "Guerrero", "Hidalgo", "Jalisco", "México",
                "Michoacán de Ocampo", "Morelos", "Nayarit", "Nuevo León", "Oaxaca", "Puebla", "Querétaro", "Quintana Roo",
                "San Luis Potosí", "Sinaloa", "Sonora", "Tabasco", "Tamaulipas", "Tlaxcala", "Veracruz", "Yucatán", "Zacatecas"};
            ViewBag.estado = new SelectList(estado);

            var n = new List<int> { 1, 2 };
            ViewBag.nMattress = new SelectList(n);

            //Set the ID of the relational sanguser
            if (hosp != null)
            {
                if (users != null)
                {
                    var model = new SangClient
                        {
                            SangUserId = users.SangUserID,
                            SangUser = users,
                            nMattressUsers = 0,
                            UserType = "Mayor de edad",
                            Gender = "Ninguno",
                            HospitalId = hosp.HospitalID,
                            Hospital = hosp
                        };

                    return View(model);
                }
            }

            return View();
                //return RedirectToAction("Introduction", "Home");
        }

        //
        // POST: /SangClient/Create

        [HttpPost]
        public ActionResult CreateSecond(SangClient sangclient, string cGender)
        {
            if (ModelState.IsValid && sangclient.PrivacyNotice != false)
            {
                var users = _db.SangUsers.FirstOrDefault(c => c.Email.Equals(User.Identity.Name));
                var hosp = _db.Hospitals.FirstOrDefault(h => h.HospitalName.Equals("Ninguno"));

                _db.SangClients.Add(sangclient);
                sangclient.CompleteName = sangclient.UserName + " " + sangclient.FirstName + " " + sangclient.LastName;
                sangclient.Gender = cGender;
                sangclient.RegisterDate = DateTime.Now;
                sangclient.SangUser = users;
                sangclient.Hospital = hosp;
                _db.SaveChanges();
                //return RedirectToAction("AdultCuestionary", new { id = sangclient.SangClientID });

                //Update the client in the warranty
                var warranty = _db.Warranties.FirstOrDefault(s => s.WarrantyCode.Equals(users.tempWarranty));
                UpdateModel(warranty);
                if (warranty != null) warranty.SangClient = sangclient;
                _db.SaveChanges();

                if (warranty != null) return RedirectToAction("Introduction", "Home", new { id = sangclient.SangClientID });
            }

            var estado = new List<string> { "Aguascalientes", "Baja California", "Baja California Sur", "Campeche", 
                    "Chiapas", "Chihuahua", "Coahuila", "Colima", "Durango", "Guanajuato", "Guerrero", "Hidalgo", "Jalisco", "México",
                "Michoacán de Ocampo", "Morelos", "Nayarit", "Nuevo León", "Oaxaca", "Puebla", "Querétaro", "Quintana Roo",
                "San Luis Potosí", "Sinaloa", "Sonora", "Tabasco", "Tamaulipas", "Tlaxcala", "Veracruz", "Yucatán", "Zacatecas"};
            ViewBag.estado = new SelectList(estado);

            var n = new List<int> { 1, 2 };
            ViewBag.nMattress = new SelectList(n);

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

        /// <summary>
        /// Direcciona al exámen dependiendo de la edad.
        /// </summary>
        /// <param name="menorEdad">The menor edad.</param>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public ActionResult Introduction(string menorEdad, int id)
        {
            ViewBag.Message = "Inicio";
            //ViewBag.ModelMattressID = new SelectList(_db.ModelMattress, "ModelMattressID", "ModelName");

            var n = new List<int> { 1, 2 };
            ViewBag.nMattress = new SelectList(n);

            if (Request.HttpMethod == "POST")
            {
                var users = _db.SangUsers.FirstOrDefault(c => c.Email.Equals(User.Identity.Name));
                var nMattress = _db.SangClients.FirstOrDefault(c => c.SangUser.SangUserID.Equals(users.SangUserID));

                if (menorEdad == "Si")
                    return RedirectToAction("CuestionaryChild", "Home", new { id = Convert.ToInt32(nMattress.SangClientID) });
                if (menorEdad == "No")
                    return RedirectToAction("AdultCuestionary", "Home", new { id = Convert.ToInt32(nMattress.SangClientID) });
            }

            return View();
        }

        //Create Child Cuestionary
        public ActionResult CuestionaryChild(int id)
        {
            List<int> n = new List<int> { 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 };
            ViewBag.childAge = new SelectList(n);

            return View();
        }

        [HttpPost]
        public ActionResult CuestionaryChild(SangChild child, int id, string Q1, string Q2, string Q3, string Q4, string Q5, string Q6, string Q7, string Q8,
            string Q9, string childAge)
        {
            //if (ModelState.IsValid)
            //{
            child.CuestionaryResult = Convert.ToInt32(Q1) + Convert.ToInt32(Q2) + Convert.ToInt32(Q3) + Convert.ToInt32(Q4) + Convert.ToInt32(Q5) + Convert.ToInt32(Q6) + Convert.ToInt32(Q7) +
                Convert.ToInt32(Q8) + Convert.ToInt32(Q9);

            //_db.SangClients.Add(child);
            child.CompleteName = child.Name + " " + child.FirstName + " " + child.LastName;
            //child.Age = Convert.ToInt32(childAge);
            child.RegisterDate = DateTime.Now; //DateTime.ParseExact(DateTime.Now.ToShortDateString(),"dd/MM/yyyy",null);
            SangClient client = _db.SangClients.FirstOrDefault(c => c.SangClientID.Equals(id));
            child.SangClient = client;
            _db.SaveChanges();

            int result = Convert.ToInt32(child.CuestionaryResult);
            if (result != null)
            {
                ViewData["waranty"] = result * 10;
                if (result < 20)
                    ViewData["Sugest"] = "El resultado de Grado de Somnolencia Epworth para menores de edad se encuentra dentro de los limites normales, por lo que por el momento no requiere apoyo especializado, si considera que es importante la valoración de un especialista, por favor imprima éste estudio y programe una cita en una de las Clínicas del Sueño cuyos datos se encuentran en los panfletos que venían dentro del folleto de su producto säng y al hacerlo por favor mencione el resultado obtenido a través del portal säng.";
                if (result >= 20)
                    ViewData["Sugest"] = "El resultado de Grado de Somnolencia Epworth para menores de edad no se encuentra dentro de límites normales. Lo que sugiere la presencia de un trastorno de sueño, por lo que le sugerimos realizar el Estudio de Calidad del Sueño (Sleep Image).";
            }
            //return RedirectToAction("ChildResult", new { result = Convert.ToInt32(child.CuestionaryResult)});
            return View("ChildDiagnosis", child);
            //}

            //return View();
        }

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

                    //Block the warranty
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