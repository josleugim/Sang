using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sang.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace Sang.Controllers
{
    public class HomeController : Controller
    {
        private readonly SangDBContext _db = new SangDBContext();

        public ActionResult CouponSearch(string coupon)
        {
            if (User.Identity.Name == "abc@sang.mx")
            {
                var infoMayor = from c in _db.SangClients
                                where c.CouponNumber.Equals(coupon)
                                select c;

                var infoMenor = from c in _db.SangChildren
                                where c.CouponNumber.Equals(coupon)
                                select c;

                if (Request.HttpMethod == "POST")
                {
                    //var infoMayor = _db.SangClients.FirstOrDefault(c => c.CouponNumber.Equals(coupon));
                    var res = new List<string> { "Bueno", "Malo" };
                    ViewBag.Result = new SelectList(res);

                    if (infoMayor.Count() != 0)
                        return View(infoMayor);

                    if (infoMenor.Count() != 0)
                        return View("CouponSearchChild", infoMenor);
                }

                return View(infoMayor);
            }

            return RedirectToAction("Introduction");
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

            if (User.Identity.Name == "abc@sang.mx" || User.Identity.Name == "angeles@sang.mx")
                return RedirectToAction("CouponSearch", "Home");

            var nCuentas = 0;
            var users = _db.SangUsers.FirstOrDefault(c => c.Email.Equals(User.Identity.Name));
            var client =
                _db.SangClients.Where(u => u.SangUserId == users.SangUserID)
                   .OrderByDescending(c => c.SangClientID)
                   .FirstOrDefault();

            //Verificación del número de registros creados
            var nClient = from e in _db.SangClients
                          where e.SangUser.SangUserID == users.SangUserID
                          select e;

            if (nClient.Any())
            {
                var nChildren = from c in _db.SangChildren
                                where c.SangClientId == client.SangClientID
                                select c;

                nCuentas = nClient.Count() + nChildren.Count();
            }

            /////////////////////////////////////////POST
            if (Request.HttpMethod == "POST")
            {
                if (menorEdad == "Si")
                {
                    if (Convert.ToInt32(nCuentas) >= 3)
                        return View("ThanksAdult");

                    return RedirectToAction("Create", "Child");
                }

                if (menorEdad == "No")
                {
                    if (Convert.ToInt32(nCuentas) >= 3)
                    {
                        if (client != null && client.Disorder1 == null)
                            return RedirectToAction("AdultCuestionary", new { id = client.SangClientID });

                        return View("ThanksAdult");
                    }
                    //Solo si el usuario usa el colchón y no contesto la prueba
                    if (client != null && client.Disorder1 == null && client.IsUser)
                        return RedirectToAction("AdultCuestionary", new { id = client.SangClientID });

                    return RedirectToAction("Create", "Client");
                }
            }
            ////////////////POST


            if (nCuentas == 0)
                return RedirectToAction("Create", "Client");
            if (nCuentas >= 2)
            {
                if (client != null && client.nMattressUsers == 2)
                {
                    if (client.Disorder1 == null && client.IsUser)
                        return RedirectToAction("AdultCuestionary", new { id = client.SangClientID });
                }

                if (client != null && (client.Disorder1 == null && client.nMattressUsers == 1))
                    return View("ThanksAdult");

                if (client != null)
                {
                    var child = _db.SangChildren.Where(ch => ch.SangClientId == client.SangClientID)
                .OrderByDescending(o => o.SangChildID)
                .FirstOrDefault();
                    if (child != null && child.CuestionaryResult == null)
                        return RedirectToAction("Edit", "Child", new { id = child.SangChildID });
                }
            }

            if (nCuentas == 3)
                return View("ThanksAdult");

            //Validar que la garantía este registrada
            var warranty = _db.Warranties.FirstOrDefault(c => c.WarrantyCode.Equals(users.tempWarranty));
            var purchase = _db.Purchase.FirstOrDefault(c => c.WarrantyId.Equals(warranty.WarrantyID));
            if (purchase == null)
                return RedirectToAction("Create", "Purchase", new { id = warranty.WarrantyCode });

            return View();
        }

        public ActionResult ChildResult(int id)
        {
            var child = _db.SangChildren.FirstOrDefault(a => a.SangChildID.Equals(id));

            ViewData["waranty"] = Convert.ToInt32(child.CuestionaryResult) * 10;

            if (Convert.ToInt32(child.CuestionaryResult) < 20)
                ViewData["Sugest"] = "El resultado de Grado de Somnolencia Epworth para menores de edad se encuentra dentro de los limites normales, por lo que por el momento no requiere apoyo especializado, si considera que es importante la valoración de un especialista, por favor imprima éste estudio y programe una cita en una de las Clínicas del Sueño cuyos datos se encuentran en los panfletos que venían dentro del folleto de su producto säng y al hacerlo por favor mencione el resultado obtenido a través del portal säng.";
            if (Convert.ToInt32(child.CuestionaryResult) >= 20)
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

                //Generar resultados en pdf del Vale

                //Si 1, 2, 3, 4, 5 es mayor de 40 o 7 > 9 = tiene problemas y
                //Si tiene problemas cardiacos = pase al doctor
                if (d1 > 40 || d2 > 40 || d3 > 40 || d4 > 40 || d5 > 40 || d7 > 9)
                {
                    if (d8 == 0)
                    {
                        //Generación de vale
                        //return RedirectToAction("GenerateCoupon", "Coupon", new { id = adult.SangUserId });
                        var users = _db.SangUsers.FirstOrDefault(c => c.Email.Equals(User.Identity.Name));

                        var client =
                            _db.SangClients.Where(u => u.SangUserId == users.SangUserID)
                               .OrderByDescending(c => c.SangClientID)
                               .FirstOrDefault();

                        var hosp = _db.Hospitals.FirstOrDefault(h => h.HospitalID.Equals(client.HospitalId));

                        var random = new Random();
                        int randomN = random.Next(1);

                        UpdateModel(adult);
                        adult.CouponNumber = users.tempWarranty + randomN + client.SangClientID;
                        adult.CouponUrl = "../../Content/Documents/" + adult.CouponNumber + ".pdf";
                        _db.SaveChanges();


                        var doc = new Document(PageSize.A4);
                        var output = new FileStream(Server.MapPath("../../Content/Documents/" + adult.CouponNumber + ".pdf"), FileMode.Create);
                        var writer = PdfWriter.GetInstance(doc, output);

                        doc.Open();


                        var logoVale = Image.GetInstance(Server.MapPath("../../Content/images/Logo-vale.jpg"));
                        var logoSang = Image.GetInstance(Server.MapPath("../../Content/images/logo-sang.jpg"));
                        var sleepImage = Image.GetInstance(Server.MapPath("../../Content/images/sleep-image.jpg"));
                        //var info = Image.GetInstance(Server.MapPath("../../Content/images/informes.jpg"));

                        var table = new PdfPTable(2);

                        float[] widths = new float[2];
                        widths[0] = 317.0F;
                        widths[1] = 483.0F;

                        table.SetTotalWidth(widths);

                        var cellLogoVale = new PdfPCell(logoVale, false) { Rowspan = 8, HorizontalAlignment = 1 };
                        table.AddCell(cellLogoVale);

                        var cellLogoSang = new PdfPCell(logoSang, false) { HorizontalAlignment = 1 };
                        table.AddCell(cellLogoSang);

                        var cellCategoria =
                            new PdfPCell(new Phrase("No. Vale: " + adult.CouponNumber,
                                                    new Font(Font.FontFamily.HELVETICA, 8f, Font.NORMAL, BaseColor.WHITE)));
                        cellCategoria.BackgroundColor = new BaseColor(0, 0, 0);
                        cellCategoria.HorizontalAlignment = 2;
                        table.AddCell(cellCategoria);


                        var cellSleepImage = new PdfPCell(sleepImage, true) { HorizontalAlignment = 1 };
                        table.AddCell(cellSleepImage);

                        var cellNombreCompleto = new PdfPCell(new Phrase(client.CompleteName, new Font(Font.FontFamily.HELVETICA, 11f, Font.NORMAL, BaseColor.WHITE))) { HorizontalAlignment = 1, BackgroundColor = new BaseColor(0, 0, 0) };
                        table.AddCell(cellNombreCompleto);

                        //var cellInforme = new PdfPCell(info, true) { HorizontalAlignment = 1 };
                        //table.AddCell(cellInforme);
                        var cellAgendar =
                            new PdfPCell(new Phrase("Para agendar una cita o si requiere informes:",
                                                    new Font(Font.FontFamily.HELVETICA, 8f, Font.NORMAL, BaseColor.WHITE)));
                        cellAgendar.BackgroundColor = new BaseColor(0, 0, 0);
                        cellAgendar.HorizontalAlignment = 0;
                        table.AddCell(cellAgendar);

                        var cellPhone = new PdfPCell(new Phrase(hosp.Phone, new Font(Font.FontFamily.HELVETICA, 11f, Font.NORMAL, BaseColor.WHITE))) { HorizontalAlignment = 0, BackgroundColor = new BaseColor(0, 0, 0) };
                        table.AddCell(cellPhone);

                        var cellAdrressLabel =
                            new PdfPCell(new Phrase("La dirección de la clínica es:",
                                                    new Font(Font.FontFamily.HELVETICA, 8f, Font.NORMAL, BaseColor.WHITE)));
                        cellAdrressLabel.BackgroundColor = new BaseColor(0, 0, 0);
                        cellAdrressLabel.HorizontalAlignment = 0;
                        table.AddCell(cellAdrressLabel);

                        var cellAddress = new PdfPCell(new Phrase(hosp.HospitalAddress, new Font(Font.FontFamily.HELVETICA, 11f, Font.NORMAL, BaseColor.WHITE))) { HorizontalAlignment = 0, BackgroundColor = new BaseColor(0, 0, 0) };
                        table.AddCell(cellAddress);

                        var cellPD =
                        new PdfPCell(new Phrase("* El estudio requiere que vaya a la clínica del sueño asignada en el vale para que recoja la máquina que realizará el Sleep Image.",
                                                new Font(Font.FontFamily.HELVETICA, 7f, Font.NORMAL, BaseColor.WHITE)));
                        cellPD.BackgroundColor = new BaseColor(0, 0, 0);
                        cellPD.HorizontalAlignment = 0;
                        cellPD.Colspan = 2;
                        table.AddCell(cellPD);

                        var cellPD2 =
                            new PdfPCell(new Phrase("En la clínica le mostraran comó usar la máquina y deberá regresarla al día siguiente.",
                                                    new Font(Font.FontFamily.HELVETICA, 7f, Font.NORMAL, BaseColor.WHITE)));
                        cellPD2.BackgroundColor = new BaseColor(0, 0, 0);
                        cellPD2.HorizontalAlignment = 0;
                        cellPD2.Colspan = 2;
                        table.AddCell(cellPD2);

                        doc.Add(table);

                        doc.Close();
                    }
                }

                if (d8 == 100)
                {
                    //Generación de vale de consulta
                    //return RedirectToAction("GenerateAppointment", "Coupon", new { id = adult.SangUserId });

                    var users = _db.SangUsers.FirstOrDefault(c => c.Email.Equals(User.Identity.Name));

                    var client =
                        _db.SangClients.Where(u => u.SangUserId == users.SangUserID)
                           .OrderByDescending(c => c.SangClientID)
                           .FirstOrDefault();

                    var hosp = _db.Hospitals.FirstOrDefault(h => h.HospitalID.Equals(client.HospitalId));

                    var random = new Random();
                    int randomN = random.Next(1);

                    UpdateModel(adult);
                    adult.CouponNumber = users.tempWarranty + randomN + client.SangClientID;
                    adult.CouponUrl = "../../Content/Documents/" + adult.CouponNumber + ".pdf";
                    _db.SaveChanges();

                    var doc = new Document(PageSize.A4);
                    var output = new FileStream(Server.MapPath("../../Content/Documents/" + adult.CouponNumber + ".pdf"), FileMode.Create);
                    var writer = PdfWriter.GetInstance(doc, output);

                    doc.Open();


                    var logoVale = Image.GetInstance(Server.MapPath("../../Content/images/Logo-vale.jpg"));
                    var logoSang = Image.GetInstance(Server.MapPath("../../Content/images/logo-sang.jpg"));
                    var consulta = Image.GetInstance(Server.MapPath("../../Content/images/vale-consulta.jpg"));
                    //var info = Image.GetInstance(Server.MapPath("../../Content/images/informes.jpg"));

                    var table = new PdfPTable(2);

                    float[] widths = new float[2];
                    widths[0] = 317.0F;
                    widths[1] = 483.0F;

                    table.SetTotalWidth(widths);

                    var cellLogoVale = new PdfPCell(logoVale, false) { Rowspan = 8, HorizontalAlignment = 1 };
                    table.AddCell(cellLogoVale);

                    var cellLogoSang = new PdfPCell(logoSang, false) { HorizontalAlignment = 1 };
                    table.AddCell(cellLogoSang);

                    var cellCategoria =
                        new PdfPCell(new Phrase("No. Vale: " + adult.CouponNumber,
                                                new Font(Font.FontFamily.HELVETICA, 8f, Font.NORMAL, BaseColor.WHITE)));
                    cellCategoria.BackgroundColor = new BaseColor(0, 0, 0);
                    cellCategoria.HorizontalAlignment = 2;
                    table.AddCell(cellCategoria);

                    var cellSleepImage = new PdfPCell(consulta, true) { HorizontalAlignment = 1 };
                    table.AddCell(cellSleepImage);

                    var cellNombreCompleto = new PdfPCell(new Phrase(client.CompleteName, new Font(Font.FontFamily.HELVETICA, 11f, Font.NORMAL, BaseColor.WHITE))) { HorizontalAlignment = 1, BackgroundColor = new BaseColor(0, 0, 0) };
                    table.AddCell(cellNombreCompleto);

                    //var cellInforme = new PdfPCell(info, true) { HorizontalAlignment = 1 };
                    //table.AddCell(cellInforme);

                    var cellAgendar =
                            new PdfPCell(new Phrase("Para agendar una cita o si requiere informes:",
                                                    new Font(Font.FontFamily.HELVETICA, 8f, Font.NORMAL, BaseColor.WHITE)));
                    cellAgendar.BackgroundColor = new BaseColor(0, 0, 0);
                    cellAgendar.HorizontalAlignment = 0;
                    table.AddCell(cellAgendar);

                    var cellPhone = new PdfPCell(new Phrase(hosp.Phone, new Font(Font.FontFamily.HELVETICA, 11f, Font.NORMAL, BaseColor.WHITE))) { HorizontalAlignment = 0, BackgroundColor = new BaseColor(0, 0, 0) };
                    table.AddCell(cellPhone);

                    var cellAdrressLabel =
                        new PdfPCell(new Phrase("La dirección de la clínica es:",
                                                new Font(Font.FontFamily.HELVETICA, 8f, Font.NORMAL, BaseColor.WHITE)));
                    cellAdrressLabel.BackgroundColor = new BaseColor(0, 0, 0);
                    cellAdrressLabel.HorizontalAlignment = 0;
                    table.AddCell(cellAdrressLabel);

                    var cellAddress = new PdfPCell(new Phrase(hosp.HospitalAddress, new Font(Font.FontFamily.HELVETICA, 11f, Font.NORMAL, BaseColor.WHITE))) { HorizontalAlignment = 0, BackgroundColor = new BaseColor(0, 0, 0) };
                    table.AddCell(cellAddress);

                    doc.Add(table);

                    doc.Close();
                }

                //return RedirectToAction("AdultResult", new
                //{
                //    id = adult.SangClientID,
                //    d1 = Convert.ToInt32(adult.Disorder1),
                //    d2 = Convert.ToInt32(adult.Disorder2),
                //    d3 = Convert.ToInt32(adult.Disorder3),
                //    d4 = Convert.ToInt32(adult.Disorder4),
                //    d5 = Convert.ToInt32(adult.Disorder5),
                //    d7 = Convert.ToInt32(adult.Disorder7),
                //    d8 = Convert.ToInt32(adult.Disorder8)
                //});
                if (adult.nMattressUsers == 1)
                    return View("ThanksAdult");

                return RedirectToAction("Introduction");
            }

            return View();
        }

        public ActionResult AdultResult(int id)
        {
            
            var adult = _db.SangClients.FirstOrDefault(a => a.SangClientID.Equals(id));
            if (adult != null)
            {
                //Scale 1 x 4
                ViewData["d1"] = Convert.ToInt32(adult.Disorder1) * 4;
                ViewData["d2"] = Convert.ToInt32(adult.Disorder2) * 4;
                ViewData["d3"] = Convert.ToInt32(adult.Disorder3) * 4;
                ViewData["d5"] = Convert.ToInt32(adult.Disorder5) * 4;

                ViewData["d4High"] = "yes";
                ViewData["d4Low"] = "yes";
                if (Convert.ToInt32(adult.Disorder4) <= 40)
                    ViewData["d4High"] = "hidden";
                else
                    ViewData["d4Low"] = "hidden";

                //Scale 1 x 20
                ViewData["d7"] = Convert.ToInt32(adult.Disorder7) * 20;

                if (Convert.ToInt32(adult.Disorder8) == 100)
                    ViewData["d8Low"] = "hidden";
                else
                    ViewData["d8High"] = "hidden";

                if (adult != null)
                {
                    ViewData["CouponOk"] = "Ver vale";
                    ViewData["Coupon"] = adult.CouponUrl;
                }

                return View(adult);
            }

            return View("Error");
        }

        public ViewResult SleepingImageMenor(string identificador, HttpPostedFileBase document, string result)
        {
            if (document != null && document.ContentLength != 0)
            {
                var sangchild = _db.SangChildren.Find(Convert.ToInt32(identificador));
                var reader = new StreamReader(document.InputStream);
                document.SaveAs(Server.MapPath("/Content/Documents/") + sangchild.SangChildID + document.FileName);
                UpdateModel(sangchild);
                sangchild.SleepingImageResult = result;
                sangchild.SleepingImageUrl = "../../Content/Documents/" + sangchild.SangChildID + document.FileName;
                _db.SaveChanges();

                return View("ThanksDoctor");
            }

            return View("Error");
        }

        public ViewResult SleepingImageMayor(string identificador, HttpPostedFileBase document, string result)
        {
            if (document != null && document.ContentLength != 0)
            {
                var sangclient = _db.SangClients.Find(Convert.ToInt32(identificador));
                var reader = new StreamReader(document.InputStream);
                document.SaveAs(Server.MapPath("/Content/Documents/") + sangclient.SangClientID + document.FileName);
                UpdateModel(sangclient);
                sangclient.SleepingImageResult = result;
                sangclient.SleepingImageUrl = "../../Content/Documents/" + sangclient.SangClientID + document.FileName;
                _db.SaveChanges();

                return View("ThanksDoctor");
            }

            return View("Error");
        }

        public ViewResult SleepingImageAsistMayor(int id)
        {
            var sangclient = _db.SangClients.Find(id);

            UpdateModel(sangclient);
            sangclient.SleepingImageIsActived = true;
            _db.SaveChanges();

            return View("ThanksAssits");
        }

        public ViewResult SleepingImageAsistMenor(int id)
        {
            var sangchild = _db.SangChildren.Find(id);

            UpdateModel(sangchild);
            sangchild.SleepingImageIsActived = true;
            _db.SaveChanges();

            return View("ThanksAssits");
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

                    if (!searchw.Any())
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
        //Validate activation Code
        public ActionResult ValidateCode(string id)
        {
            if (!String.IsNullOrEmpty(id))
            {
                //var searchcode = from c in _db.SangClients
                //              where c.SecureCode.ToString() == code
                //              select c;
                var temp = new Guid(id);
                var user = _db.SangUsers.FirstOrDefault(s => s.SecureCode.Equals(temp));

                if (user != null)
                {
                    UpdateModel(user);
                    user.IsActived = true;
                    _db.SaveChanges();

                    //Block the warranty
                    var warranty = _db.Warranties.FirstOrDefault(s => s.WarrantyCode.Equals(user.tempWarranty));
                    UpdateModel(warranty);
                    if (warranty != null) warranty.IsActived = false;
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
                if (!searchMail.Any())
                {
                    _db.Newsletters.Add(newsletter);
                    newsletter.IsActived = true;
                    newsletter.RegisterDate = DateTime.Now;
                    _db.SaveChanges();
                    return View("ThanksNewsletter", newsletter);
                }
                return View("AlreadyEmailRegister");
            }
            return View("ErrorEmailRegister");
        }
    }
}
