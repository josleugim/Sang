using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using Sang.Models;
using System.Net.Mail;
using System.Net;

namespace Sang.Controllers
{
    public class AccountController : Controller
    {
        private readonly SangDBContext _db = new SangDBContext();
        //
        // GET: /Account/LogOn

        public ActionResult LogOn(string message)
        {
            ViewData["message"] = message;
            return View();
        }

        //
        // POST: /Account/LogOn

        [HttpPost]
        public ActionResult LogOn(LogOnModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (Membership.ValidateUser(model.Email, model.Password))
                {
                    SangUser user = _db.SangUsers.FirstOrDefault(c => c.Email.Equals(model.Email));
                    if (user.IsActived)
                    {
                        FormsAuthentication.SetAuthCookie(model.Email, model.RememberMe);
                        if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                            && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                            return Redirect(returnUrl);

                        if (User.Identity.Name == "abc@sang.mx" || User.Identity.Name == "angeles@sang.mx")
                            return RedirectToAction("Index", "Coupon");

                        return RedirectToAction("Introduction", "Home");
                    }
                    ModelState.AddModelError("", "Active su registro mediante el correo que se le envio.");
                }
                else
                    ModelState.AddModelError("", "El nombre de usuario o la contraseña especificados son incorrectos.");
            }

            // Si llegamos a este punto, es que se ha producido un error y volvemos a mostrar el formulario
            return View(model);
        }

        //
        // GET: /Account/LogOff

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }

        //
        // GET: /Account/Register

        public ActionResult Register(string w)
        {
            return View();
        }

        //
        // POST: /Account/Register

        [HttpPost]
        public ActionResult Register(RegisterModel model, string w)
        {


            if (ModelState.IsValid)
            {
                // Intento de registrar al usuario
                MembershipCreateStatus createStatus;
                Membership.CreateUser(model.Email, model.Password, model.Email, null, null, true, null, out createStatus);

                if (createStatus == MembershipCreateStatus.Success)
                {
                    SangUser user = _db.SangUsers.FirstOrDefault(c => c.Email.Equals(model.Email));

                    //Se mapea la garantía que el usuario selecciono para ser ligada posteriormente
                    UpdateModel(user);
                    user.tempWarranty = w;
                    _db.SaveChanges();

                    //Aquí se enviía mail
                    SmtpClient smtpClient1 = new SmtpClient();

                    using (MailMessage message = new MailMessage())
                    {
                        message.From = new MailAddress("mail@sang.mx", "Säng");
                        message.To.Add(model.Email);
                        message.Subject = "Säng - Confirmación de registro";
                        //message.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(" <div style='width:500px; font-size:18px;'> <p>Estimado participante:</p><p style='margin:0;'>Muchas gracias por tu interés en nuestro <u style='color:#005681;'>Concurso de Fotografía Bienestar Cerca de Ti.</u>Tu fotografía y datos han quedado registrados, los cuales son claves para reclamar el premio en caso de que resultes ganador.</p> <p style='margin:0;'>Tu clave de participación es: <b><a target='_blank' href='http://localhost:2317/Home/ValidateCode/" + user.SecureCode + "'>Verificar e-mail</a></b> </p> <p style='margin:0;'>Seguiremos en contacto contigo para comunicarte cuáles son las fotografías ganadoras, una vez que finalice el concurso.</p> <p style='margin:0;'>Atentamente</p> <p style='margin:0; color:#005681;'>Concurso de Fotografía Bienestar Cerca de Ti</p><div style='width:500px; height:2px; background-color:#C32941;'></div> <p style='font-size:11px;'>*Este email fue enviado desde una cuenta de correo electrónico para notificación únicamente, no puede recibir correos. En caso de necesitar asistencia por favor llame desde el interior de la República Mexicana al teléfono 01-800-003-2273 (CARE). Este mensaje y cualquier archivo adjunto son confidenciales y pueden contener información privilegiada o estar protegidos de alguna forma contra su divulgación. Asimismo, te recordamos de nuestra política de privacidad y derechos de autor que aceptaste al inscribirte a este concurso, la cual puedes consultar en: <a href='http://www.merckseronodiabetes.com.mx/concursobienestar/' target='_blank'>http://www.merckseronodiabetes.com.mx/concursobienestar/</a></p> </div>", null, "text/html"));
                        message.AlternateViews.Add(AlternateView.CreateAlternateViewFromString("<table width='100%' style='text-align: justify; font-family: Arial; font-size: 16px; color: #FFFFFF; background-color: #000000'> " +
                            "<tr><td><table width='600px' align='center'><tr><th colspan='2'><p style='font-size: 22px'>SÄNG The nordik way of resting</p></th></tr><tr><td rowspan='3' style='width: 250px'>" +
                            "<img src='http://sang.mx/newsletterImages/a_colecciones.jpg' alt='Logo Säng' />" +
                        "</td><td><p style='margin:10px'>En Säng nos preocupamos por tu bienestar, por eso hemos creado diferentes evaluaciones del sueño.</p></td></tr><tr><td><p style='margin:10px'>Te invitamos a completar tu proceso de registro para disfrutar de estos beneficios,dando clic al siguiente link:</p></td></tr><tr><td>" +
                            "<p style='margin:10px'>" + "<b><a target='_blank' href='http://sang.mx/Home/ValidateCode/" + user.SecureCode + "'>Verificar e-mail</a></b>" + "</p></td></tr></table></td></tr></table>", null, "text/html"));
                        smtpClient1.Send(message);
                    }

                    //Warranty warranty = _db.Warranties.FirstOrDefault(s => s.WarrantyCode.Equals(w));
                    //UpdateModel(warranty);
                    //warranty.SangClient = user;
                    //warranty.IsActived = false;
                    //_db.SaveChanges();

                    //FormsAuthentication.SetAuthCookie(model.Email, false /* createPersistentCookie */);
                    //ViewBag.lblmsj = "Su cuenta a sido creada, se le ha enviado un e-mail de confirmación";
                    return View("Thanks", user);
                }
                else
                {
                    ModelState.AddModelError("", ErrorCodeToString(createStatus));
                }
            }

            // Si llegamos a este punto, es que se ha producido un error y volvemos a mostrar el formulario
            return View(model);
        }

        public ViewResult Thanks(SangUser sangusers)
        {
            return View();
        }

        //
        // GET: /Account/ChangePassword

        [Authorize]
        public ActionResult ChangePassword()
        {
            return View();
        }

        //
        // POST: /Account/ChangePassword

        [Authorize]
        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordModel model)
        {
            if (ModelState.IsValid)
            {

                // ChangePassword iniciará una excepción en lugar de
                // devolver false en determinados escenarios de error.
                bool changePasswordSucceeded;
                try
                {
                    MembershipUser currentUser = Membership.GetUser(User.Identity.Name, true /* userIsOnline */);
                    changePasswordSucceeded = currentUser.ChangePassword(model.OldPassword, model.NewPassword);
                }
                catch (Exception)
                {
                    changePasswordSucceeded = false;
                }

                if (changePasswordSucceeded)
                {
                    return RedirectToAction("ChangePasswordSuccess");
                }
                else
                {
                    ModelState.AddModelError("", "La contraseña actual es incorrecta o la nueva contraseña no es válida.");
                }
            }

            // Si llegamos a este punto, es que se ha producido un error y volvemos a mostrar el formulario
            return View(model);
        }

        //
        // GET: /Account/ChangePasswordSuccess

        public ActionResult ChangePasswordSuccess()
        {
            return View();
        }

        #region Status Codes
        private static string ErrorCodeToString(MembershipCreateStatus createStatus)
        {
            // Vaya a http://go.microsoft.com/fwlink/?LinkID=177550 para
            // obtener una lista completa de códigos de estado.
            switch (createStatus)
            {
                case MembershipCreateStatus.DuplicateUserName:
                    return "El nombre de usuario ya existe. Escriba un nombre de usuario diferente.";

                case MembershipCreateStatus.DuplicateEmail:
                    return "Ya existe un nombre de usuario para esa dirección de correo electrónico. Escriba una dirección de correo electrónico diferente.";

                case MembershipCreateStatus.InvalidPassword:
                    return "La contraseña especificada no es válida. Escriba un valor de contraseña válido.";

                case MembershipCreateStatus.InvalidEmail:
                    return "La dirección de correo electrónico especificada no es válida. Compruebe el valor e inténtelo de nuevo.";

                case MembershipCreateStatus.InvalidAnswer:
                    return "La respuesta de recuperación de la contraseña especificada no es válida. Compruebe el valor e inténtelo de nuevo.";

                case MembershipCreateStatus.InvalidQuestion:
                    return "La pregunta de recuperación de la contraseña especificada no es válida. Compruebe el valor e inténtelo de nuevo.";

                case MembershipCreateStatus.InvalidUserName:
                    return "El nombre de usuario especificado no es válido. Compruebe el valor e inténtelo de nuevo.";

                case MembershipCreateStatus.ProviderError:
                    return "El proveedor de autenticación devolvió un error. Compruebe los datos especificados e inténtelo de nuevo. Si el problema continúa, póngase en contacto con el administrador del sistema.";

                case MembershipCreateStatus.UserRejected:
                    return "La solicitud de creación de usuario se ha cancelado. Compruebe los datos especificados e inténtelo de nuevo. Si el problema continúa, póngase en contacto con el administrador del sistema.";

                default:
                    return "Error desconocido. Compruebe los datos especificados e inténtelo de nuevo. Si el problema continúa, póngase en contacto con el administrador del sistema.";
            }
        }
        #endregion
    }
}
