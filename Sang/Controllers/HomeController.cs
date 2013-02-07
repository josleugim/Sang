using System;
using System.Data;
using System.Linq;
using System.Web.Mvc;
using Sang.Models;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.IO;

namespace Sang.Controllers
{
    public class HomeController : Controller
    {
        private readonly SangDBContext _db = new SangDBContext();

        public ActionResult Options()
        {
            return View();
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
        public ActionResult Introduction(string menorEdad)
        {
            ViewBag.Message = "Introducción";

            if (Request.HttpMethod == "POST")
            {
                var users = _db.SangUsers.FirstOrDefault(c => c.Email.Equals(User.Identity.Name));
                var client = _db.SangClients.FirstOrDefault(c => c.SangUser.SangUserID.Equals(users.SangUserID));

                if (menorEdad == "Si")
                    return RedirectToAction("Create", "Child");
                if (menorEdad == "No")
                    return RedirectToAction("AdultCuestionary", "Home", new { id = Convert.ToInt32(client.SangClientID) });
            }

            return View();
        }

        /// <summary>
        /// Introduction2s the specified menor edad, en este método el cliente ya creo las 2 cuentas.
        /// </summary>
        /// <param name="menorEdad">The menor edad.</param>
        /// <returns></returns>
        public ActionResult Introduction2(string menorEdad)
        {
            ViewBag.Message = "Inicio";
            var users = _db.SangUsers.FirstOrDefault(c => c.Email.Equals(User.Identity.Name));

            //Cuantos clientes existen
            var nClient = from e in _db.SangClients
                          where e.SangUser.SangUserID == users.SangUserID
                          select e;
            if (nClient.Count() == 2)
            {
                var client =
                _db.SangClients.Where(u => u.SangUserId == users.SangUserID)
                   .OrderByDescending(c => c.SangClientID)
                   .FirstOrDefault();

                if (client.SangClientID != null && client.Disorder1.HasValue)
                {
                    //Thanks view
                    return View("ThanksAdult");
                }

                if (Request.HttpMethod == "POST")
                {
                    if (menorEdad == "Si")
                        return RedirectToAction("CuestionaryChild", "Home", new { id = Convert.ToInt32(client.SangClientID) });
                    //Mayor de edad
                    if (menorEdad == "No")
                        return RedirectToAction("AdultCuestionary2", "Home", new { id = client.SangClientID });
                }
            }

            if (Request.HttpMethod == "POST")
            {
                if (menorEdad == "Si")
                    return RedirectToAction("CuestionaryChild", "Home");
                //Mayor de edad
                if (menorEdad == "No")
                    return RedirectToAction("CreateSecond", "Home");
            }

            return View();
        }

        //Create Child Cuestionary
        public ActionResult CuestionaryChild(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult CuestionaryChild(SangChild child, int id, string Q1, string Q2, string Q3, string Q4, string Q5, string Q6, string Q7, string Q8,
            string Q9, string childAge)
        {
            if (ModelState.IsValid)
            {
                //var adult = _db.SangClients.FirstOrDefault(a => a.SangClientID.Equals(id));
                //var users = _db.SangUsers.FirstOrDefault(c => c.Email.Equals(User.Identity.Name));

                UpdateModel(child);
                child.CuestionaryResult = Convert.ToInt32(Q1) + Convert.ToInt32(Q2) + Convert.ToInt32(Q3) + Convert.ToInt32(Q4) + Convert.ToInt32(Q5) + Convert.ToInt32(Q6) + Convert.ToInt32(Q7) +
                    Convert.ToInt32(Q8) + Convert.ToInt32(Q9);
                _db.SaveChanges();

                //_db.SangClients.Add(child);
                //child.CompleteName = child.Name + " " + child.FirstName + " " + child.LastName;
                //child.Age = Convert.ToInt32(childAge);
                //child.RegisterDate = DateTime.Now; //DateTime.ParseExact(DateTime.Now.ToShortDateString(),"dd/MM/yyyy",null);
                //SangClient client = _db.SangClients.FirstOrDefault(c => c.SangClientID.Equals(id));
                //child.SangClient = client;
                //_db.SaveChanges();

                var result = Convert.ToInt32(child.CuestionaryResult);

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
            }

            return View();
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
        {
            if (ModelState.IsValid)
            {
                var adult = _db.SangClients.FirstOrDefault(a => a.SangClientID.Equals(id));
                //var users = _db.SangUsers.FirstOrDefault(c => c.Email.Equals(User.Identity.Name));

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

                var d1 = Convert.ToInt32(adult.Disorder1);
                var d2 = Convert.ToInt32(adult.Disorder2);
                var d3 = Convert.ToInt32(adult.Disorder3);
                var d4 = Convert.ToInt32(adult.Disorder4);
                var d5 = Convert.ToInt32(adult.Disorder5);
                var d7 = Convert.ToInt32(adult.Disorder7);
                var d8 = Convert.ToInt32(adult.Disorder8);

                //Generar resultados en pdf
                var doc = new Document(PageSize.A4);
                var output = new FileStream(Server.MapPath("../../Content/Documents/" + adult.CompleteName + adult.SangUser.tempWarranty + ".pdf"), FileMode.Create);
                var writer = PdfWriter.GetInstance(doc, output);

                doc.Open();


                var logoHospital = Image.GetInstance(Server.MapPath(adult.Hospital.HospitalLogo));
                logoHospital.Alignment = 1;
                logoHospital.ScalePercent(50f);
                doc.Add(logoHospital);

                var titleResult = Image.GetInstance(Server.MapPath("../../Content/images/ResultadosEvaluacion.jpg"));
                titleResult.Alignment = 1;
                titleResult.ScalePercent(40f);
                doc.Add(titleResult);
                var table = new PdfPTable(4);

                //var cellHosp = new PdfPCell(logoHospital, false) { Colspan = 4, HorizontalAlignment = 1 };
                //table.AddCell(cellHosp);

                //var cellHeader = new PdfPCell(titleResult, false) { Colspan = 4, HorizontalAlignment = 1 };
                //table.AddCell(cellHeader);

                var cellLabelName =
                    new PdfPCell(new Phrase("Nombre: ",
                                            new Font(Font.FontFamily.HELVETICA, 8f, Font.NORMAL, BaseColor.WHITE)));
                cellLabelName.BackgroundColor = new BaseColor(0, 0, 0);
                cellLabelName.HorizontalAlignment = 0;
                table.AddCell(cellLabelName);

                var cellName =
                    new PdfPCell(new Phrase(adult.CompleteName,
                                            new Font(Font.FontFamily.HELVETICA, 8f, Font.NORMAL, BaseColor.WHITE)));
                cellName.BackgroundColor = new BaseColor(0, 0, 0);
                cellName.HorizontalAlignment = 0;
                table.AddCell(cellName);

                var cellLabelAddress =
                    new PdfPCell(new Phrase("Dirección: ",
                                            new Font(Font.FontFamily.HELVETICA, 8f, Font.NORMAL, BaseColor.WHITE)));
                cellLabelAddress.BackgroundColor = new BaseColor(0, 0, 0);
                cellLabelAddress.HorizontalAlignment = 0;
                table.AddCell(cellLabelAddress);

                var cellAddress =
                    new PdfPCell(new Phrase(adult.Address,
                                            new Font(Font.FontFamily.HELVETICA, 8f, Font.NORMAL, BaseColor.WHITE)));
                cellAddress.BackgroundColor = new BaseColor(0, 0, 0);
                cellAddress.HorizontalAlignment = 0;
                table.AddCell(cellAddress);

                var cellLabelColony =
                    new PdfPCell(new Phrase("Colonia: ",
                                            new Font(Font.FontFamily.HELVETICA, 8f, Font.NORMAL, BaseColor.WHITE)));
                cellLabelColony.BackgroundColor = new BaseColor(0, 0, 0);
                cellLabelColony.HorizontalAlignment = 0;
                table.AddCell(cellLabelColony);

                var cellColony =
                    new PdfPCell(new Phrase(adult.Colony,
                                            new Font(Font.FontFamily.HELVETICA, 8f, Font.NORMAL, BaseColor.WHITE)));
                cellColony.BackgroundColor = new BaseColor(0, 0, 0);
                cellColony.HorizontalAlignment = 0;
                table.AddCell(cellColony);

                var cellLabelTownship =
                    new PdfPCell(new Phrase("Municipio/Delegación: ",
                                            new Font(Font.FontFamily.HELVETICA, 8f, Font.NORMAL, BaseColor.WHITE)));
                cellLabelTownship.BackgroundColor = new BaseColor(0, 0, 0);
                cellLabelTownship.HorizontalAlignment = 0;
                table.AddCell(cellLabelTownship);

                var cellTownship =
                    new PdfPCell(new Phrase(adult.Township,
                                            new Font(Font.FontFamily.HELVETICA, 8f, Font.NORMAL, BaseColor.WHITE)));
                cellTownship.BackgroundColor = new BaseColor(0, 0, 0);
                cellTownship.HorizontalAlignment = 0;
                table.AddCell(cellTownship);

                var cellLabelState =
                    new PdfPCell(new Phrase("Estado: ",
                                            new Font(Font.FontFamily.HELVETICA, 8f, Font.NORMAL, BaseColor.WHITE)));
                cellLabelState.BackgroundColor = new BaseColor(0, 0, 0);
                cellLabelState.HorizontalAlignment = 0;
                table.AddCell(cellLabelState);

                var cellState =
                    new PdfPCell(new Phrase(adult.ShortState,
                                            new Font(Font.FontFamily.HELVETICA, 8f, Font.NORMAL, BaseColor.WHITE)));
                cellState.BackgroundColor = new BaseColor(0, 0, 0);
                cellState.HorizontalAlignment = 0;
                table.AddCell(cellState);

                doc.Add(table);

                //var htmlWorker = new HTMLWorker(doc);
                //var str = "<html><head></head><body>" +
                //  "<br /><h1 style='text-align: center'>Distirbuios del sueño</h1><div width='300px' bgcolor='red' height='100px' background-color='black'><p>Test</p></div>" +
                //  "<table style='margin: 0 auto; border: 2px solid #9A0D0D'><tr><th style='background-color: #9A0D0D'>Trastorno de inicio y continuidad del sueño</th></tr>" +
                //  "<tr><td bgcolor='red'><div style='width:" + d1 + "px; height: 36px; text-align: right;'><img src='" + Server.MapPath("../../Content/images/down_arrow.png") + "' alt='Arrow' /></div>" + 
                //  "<div style='width: 400px; height: 10px; font-size: 12px; text-align: center; color: Black;'>" +
                //        "<div style='float: left; width: 80px; height: 20px; background-color: #75E109'>" +
                //            "Riesgo bajo" +
                //        "</div>"+
                //        "<div style='float: left; width: 80px; height: 20px; background-color: #FFFF00'>"+
                //            "Riesgo medio"+
                //        "</div>"+
                //        "<div style='float: left; width: 240px; height: 20px; background-color: red'>Riesgo alto</div>"+
                //    "</div></td></tr>" +
                //  "</table></body></html>";
                //htmlWorker.Parse(new StringReader(str));

                PdfContentByte cb = writer.DirectContent;
                //cb.SetColorStroke(new CMYKColor(1f, 0f, 0f, 0f));
                cb.SetColorFill(new BaseColor(0, 128, 0));

                
                //cb.MoveTo(10, 500);
                //cb.LineTo(410, 500);
                ////Path closed and stroked
                //cb.ClosePathStroke();

                //for (int i = 10; i < 420; i += 10)
                //{
                //    cb.MoveTo(i, 495);
                //    cb.LineTo(i, 505);
                //    //Path closed and stroked
                //    cb.ClosePathStroke();
                //}

                //Trastorno de inicio y continuidad del sueño
                cb.SetColorFill(new BaseColor(0, 128, 0));
                cb.MoveTo(100, 400);
                cb.LineTo(200, 400);
                cb.LineTo(200, 410);
                cb.LineTo(100, 410);
                //Path closed, stroked and filled
                cb.ClosePathFillStroke();

                //Trastorno de inicio y continuidad del sueño
                cb.SetColorFill(new BaseColor(255, 255, 0));
                cb.MoveTo(200, 400);
                cb.LineTo(300, 400);
                cb.LineTo(300, 410);
                cb.LineTo(200, 410);
                //Path closed, stroked and filled
                cb.ClosePathFillStroke();

                cb.MoveTo(190, 200);
                cb.LineTo(290, 200);
                cb.LineTo(290, 300);
                cb.LineTo(190, 300);

                //Filled, but not stroked or closed

                cb.Fill();



                cb.MoveTo(310, 200);

                cb.LineTo(410, 200);

                cb.LineTo(410, 300);

                cb.LineTo(310, 300);

                //Filled, stroked, but path not closed

                cb.FillStroke();



                

                doc.Close();

                //Generación de vale
                return RedirectToAction("GenerateCoupon", "Coupon", new { id = adult.SangUserId });

                //return RedirectToAction("AdultResult", new
                //{
                //    d1 = Convert.ToInt32(adult.Disorder1),
                //    d2 = Convert.ToInt32(adult.Disorder2),
                //    d3 = Convert.ToInt32(adult.Disorder3),
                //    d4 = Convert.ToInt32(adult.Disorder4),
                //    d5 = Convert.ToInt32(adult.Disorder5),
                //    d7 = Convert.ToInt32(adult.Disorder7),
                //    d8 = Convert.ToInt32(adult.Disorder8)
                //});
            }

            return View();
        }

        //
        //Create Adult cuestionary result and data
        public ActionResult AdultCuestionary2(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdultCuestionary2(int id, string Q1, string Q2, string Q3, string Q4, string Q5, string Q6, string Q7, string Q8,
            string Q9, string Q10, string Q11, string Q12, string Q13, string Q14, string Q15, string Q16, string Q17, string Q18, string Q19, string Q20,
            string Q21)
        //public ActionResult AdultCuestionary(int id, FormCollection formValues)
        {
            if (ModelState.IsValid)
            {
                SangClient adult = _db.SangClients.FirstOrDefault(a => a.SangClientID.Equals(id));
                //var users = _db.SangUsers.FirstOrDefault(c => c.Email.Equals(User.Identity.Name));

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

                if (adult.Disorder8 == 100)
                {
                    var coupon = new Coupon();

                    coupon.CouponNumber = "ASD123";
                    coupon.RegisterDate = DateTime.Now;
                    _db.Coupons.Add(coupon);
                    _db.SaveChanges();
                }

                return View("ThanksCuestionary");

                //return RedirectToAction("AdultResult", new
                //{
                //    d1 = Convert.ToInt32(adult.Disorder1),
                //    d2 = Convert.ToInt32(adult.Disorder2),
                //    d3 = Convert.ToInt32(adult.Disorder3),
                //    d4 = Convert.ToInt32(adult.Disorder4),
                //    d5 = Convert.ToInt32(adult.Disorder5),
                //    d7 = Convert.ToInt32(adult.Disorder7),
                //    d8 = Convert.ToInt32(adult.Disorder8)
                //});
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

            return View("Error");
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
