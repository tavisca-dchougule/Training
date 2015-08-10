using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DotNetOpenAuth.AspNet;
using Microsoft.Web.WebPages.OAuth;
using WebMatrix.WebData;
using RoleBasedAccessMVC.Filters;
using RoleBasedAccessMVC.Models;
using RoleBasedAccess.Model;

namespace RoleBasedAccessMVC.Controllers
{
    [Authorize]
    [InitializeSimpleMembership]
    public class AccountController : Controller
    {
        //
        // GET: /Account/Login

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            Credential credential = new Credential();
            credential.UserName = model.UserName;
            credential.Password = model.Password;
            EmployeeResponse response= credential.Authenticate();
            if (ModelState.IsValid && response.Status.StatusCode.Equals("200"))
            {
                if (returnUrl == null)
                {
                    FormsAuthentication.SetAuthCookie(model.UserName.Trim(), false);
                    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, model.UserName.Trim(), DateTime.UtcNow, DateTime.UtcNow.AddMinutes(10), false, response.Employee.Designation.Trim());
                    HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(ticket));
                    Response.Cookies.Add(cookie);
                    Session["employeeId"] = response.Employee.Id.Trim();
                    if (string.Equals(response.Employee.Designation.Trim(), "hr", StringComparison.OrdinalIgnoreCase))
                        return RedirectToAction("AddRemark", "Hr");
                    else
                        return RedirectToAction("EmployeeViewRemark", "Employee");
                }
                else
                {
                    FormsAuthentication.SetAuthCookie(model.UserName.Trim(), false);
                    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, model.UserName.Trim(), DateTime.UtcNow, DateTime.UtcNow.AddMinutes(10), false, response.Employee.Designation.Trim());
                    HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(ticket));
                    Response.Cookies.Add(cookie);
                    return RedirectToLocal(returnUrl);
                }
            }
            // If we got this far, something failed, redisplay form
            ModelState.AddModelError("", "The user name or password provided is incorrect.");
            return View(model);
        }

        //
        // POST: /Account/LogOff

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            try
            {
                Session.Abandon();
                HttpCookie cookies = System.Web.HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
                cookies.Expires = DateTime.Now.AddDays(-1);
                System.Web.HttpContext.Current.Response.Cookies.Add(cookies);
            }
            catch (Exception ex)
            {
            }
            
            return RedirectToAction("Login", "Account");           
        }


        public ActionResult Manage(ManageMessageId? message)
        {
            ViewBag.StatusMessage =
                message == ManageMessageId.ChangePasswordSuccess ? "Your password has been changed."
                : message == ManageMessageId.SetPasswordSuccess ? "Your password has been set."
                : message == ManageMessageId.RemoveLoginSuccess ? "The external login was removed."
                : "";
   
            ViewBag.ReturnUrl = Url.Action("Manage");
            return View();
        }

   
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Manage(LocalPasswordModel model)
        {
            ViewBag.ReturnUrl = Url.Action("Manage");
           
                if (ModelState.IsValid)
                {
                    // ChangePassword will throw an exception rather than return false in certain failure scenarios.
                    bool changePasswordSucceeded;
                    try
                    {
                        ChangeCredential credential = new ChangeCredential();
                        FormsIdentity id = (FormsIdentity)System.Web.HttpContext.Current.User.Identity;
                        FormsAuthenticationTicket ticket = id.Ticket;
                        credential.UserName =  ticket.Name;
                        credential.OldPassword = model.OldPassword;
                        credential.NewPassword = model.NewPassword;
                        EmployeeResponse response = credential.CredentialChange();
                        if (response.Status.StatusCode.Equals("200") == false)
                            throw new Exception();
                        else
                            changePasswordSucceeded = true;
                    }
                    catch (Exception)
                    {
                        changePasswordSucceeded = false;
                    }

                    if (changePasswordSucceeded)
                    {
                        return RedirectToAction("Manage", new { Message = ManageMessageId.ChangePasswordSuccess });
                    }
                    else
                    {
                        ModelState.AddModelError("", "The current password is incorrect or the new password is invalid.");
                    }
                }
            return View(model);
        }

        //
        // POST: /Account/ExternalLogin

      
        #region Helpers
        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public enum ManageMessageId
        {
            ChangePasswordSuccess,
            SetPasswordSuccess,
            RemoveLoginSuccess,
        }
        #endregion
    }
}
