﻿// Copyright (c) Source Tree Solutions, LLC. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
// Author:					Joe Audette
// Created:					2014-10-26
// Last Modified:			2016-01-20
// 

using cloudscribe.Core.Identity;
using cloudscribe.Core.Models;
using cloudscribe.Core.Web.Components.Messaging;
using cloudscribe.Core.Web.ViewModels.Account;
using cloudscribe.Core.Web.ViewModels.SiteUser;
//using cloudscribe.Messaging.Email;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;


namespace cloudscribe.Core.Web.Controllers
{
    [Authorize]
    public class AccountController : CloudscribeBaseController
    {

        public AccountController(
            ISiteResolver siteResolver,
            SiteUserManager<SiteUser> userManager,
            SiteSignInManager<SiteUser> signInManager,
            ISiteMessageEmailSender emailSender,
            ISmsSender smsSender,
            ILogger<AccountController> logger)
        {
            Site = siteResolver.Resolve();
            this.userManager = userManager;
            this.signInManager = signInManager;
            //config = configuration;
            this.emailSender = emailSender;
            this.smsSender = smsSender;
            log = logger;
        }

        //private ISiteResolver resolver;
        private readonly ISiteSettings Site;
        //private readonly ConfigHelper config;
        private readonly SiteUserManager<SiteUser> userManager;
        private readonly SiteSignInManager<SiteUser> signInManager;
        private readonly ISiteMessageEmailSender emailSender;
        private readonly ISmsSender smsSender;
        private ILogger log;


        // GET: /Account/Login
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            ViewData["Title"] = "Log in";
            ViewData["ReturnUrl"] = returnUrl;
            LoginViewModel model = new LoginViewModel();
            model.ExternalAuthenticationList = signInManager.GetExternalAuthenticationSchemes();
            if ((Site.CaptchaOnLogin)&& (Site.RecaptchaPublicKey.Length > 0))
            {
                model.RecaptchaSiteKey = Site.RecaptchaPublicKey;     
            }

            model.LoginInfoTop = Site.LoginInfoTop;
            model.LoginInfoBottom = Site.LoginInfoBottom;

            return View(model);
        }


        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl)
        {
            ViewData["Title"] = "Log in";
            ViewData["ReturnUrl"] = returnUrl;
            if ((Site.CaptchaOnLogin)&& (Site.RecaptchaPublicKey.Length > 0))
            {
                model.RecaptchaSiteKey = Site.RecaptchaPublicKey;
                model.LoginInfoTop = Site.LoginInfoTop;
                model.LoginInfoBottom = Site.LoginInfoBottom;
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if ((Site.CaptchaOnLogin) && (Site.RecaptchaPublicKey.Length > 0))
            {
                string recpatchaSecretKey = Site.RecaptchaPrivateKey;
                
                var captchaResponse = await this.ValidateRecaptcha(Request, recpatchaSecretKey);

                if (!captchaResponse.Success)
                {
                    ModelState.AddModelError("recaptchaerror", "reCAPTCHA Error occured. Please try again");
                    return View(model);
                }
            }

            if(userManager.Site.UseSecureRegistration || userManager.Site.RequireApprovalBeforeLogin)
            {
                var user = await userManager.FindByNameAsync(model.Email);
                if (user != null)
                {
                    if (userManager.Site.UseSecureRegistration)
                    {
                        if (!await userManager.IsEmailConfirmedAsync(user))
                        {
                            ModelState.AddModelError(string.Empty, "You must have a confirmed email to log in.");
                            return View(model);
                        }
                    }

                    if(userManager.Site.RequireApprovalBeforeLogin)
                    {
                        if(!user.AccountApproved)
                        {
                            ModelState.AddModelError(string.Empty, "Your account must be approved by an administrator before you can log in. If an administrator approves your account, you will receive an email notifying you that your account is ready.");
                            return View(model);
                        }
                    }
                    
                }
            }


            //TODO: we don't want to lockout on first failure, we need something more advanced
            // based on sitesettings
            //var maxFailures = userManager.Site.MaxInvalidPasswordAttempts;
            // probably need to override signInManager.PasswordSignInAsync
            // or create a new method that does what we want
            // we also need to prevent login if site requires confirmed email
            // and user email is not confirmed
            // also need to prevent login if site requires approval before new users can login
            // and user is not yet approved
            // also need a UI to manually lockout a user 


            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, change to lockoutOnFailure: true
            bool persistent = false;
            if(userManager.Site.AllowPersistentLogin)
            {
                //TODO: hide remember me in view if persistent login not allowed  site settings
                persistent = model.RememberMe;
            }
            var result = await signInManager.PasswordSignInAsync(
                model.Email,
                model.Password,
                persistent,
                lockoutOnFailure : false);
            
            if (result.Succeeded)
            {
                return this.RedirectToLocal(returnUrl);
            }
            if (result.RequiresTwoFactor)
            {
                return RedirectToAction(nameof(SendCode), new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
            }
            if (result.IsLockedOut)
            {
                return View("Lockout");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return View(model);
            }
        }





        // GET: /Account/Register
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            ViewData["Title"] = "Register";
            
            RegisterViewModel model = new RegisterViewModel();
            model.SiteGuid = Site.SiteGuid;
            if ((Site.CaptchaOnRegistration)&& (Site.RecaptchaPublicKey.Length > 0))
            {
                model.RecaptchaSiteKey = Site.RecaptchaPublicKey;  
            }

            model.RegistrationPreamble = Site.RegistrationPreamble;
            model.RegistrationAgreement = Site.RegistrationAgreement;


            return View(model);
        }


        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            ViewData["Title"] = "Register";

            if ((Site.CaptchaOnRegistration)&& (Site.RecaptchaPublicKey.Length > 0))
            {
                model.RecaptchaSiteKey = Site.RecaptchaPublicKey;     
            }

            model.RegistrationPreamble = Site.RegistrationPreamble;
            model.RegistrationAgreement = Site.RegistrationAgreement;

            bool isValid = ModelState.IsValid;
            if (isValid)
            {
                if ((Site.CaptchaOnRegistration)&& (Site.RecaptchaPublicKey.Length > 0))
                {
                    string recpatchaSecretKey = Site.RecaptchaPrivateKey;
                    
                    var captchaResponse = await this.ValidateRecaptcha(Request, recpatchaSecretKey);

                    if (!captchaResponse.Success)
                    {
                        //if (captchaResponse.ErrorCodes.Count <= 0)
                        //{
                        //    return View(model);
                        //}

                        ////TODO: log these errors rather than show them in the ui
                        //var error = captchaResponse.ErrorCodes[0].ToLower();
                        //switch (error)
                        //{
                        //    case ("missing-input-secret"):
                        //        ModelState.AddModelError("recaptchaerror", "The secret parameter is missing.");     
                        //        break;
                        //    case ("invalid-input-secret"):
                        //        ModelState.AddModelError("recaptchaerror", "The secret parameter is invalid or malformed.");
                        //        break;
                        //    case ("missing-input-response"):
                        //        ModelState.AddModelError("recaptchaerror", "The response parameter is missing.");
                        //        break;
                        //    case ("invalid-input-response"):
                        //        ModelState.AddModelError("recaptchaerror", "The response parameter is invalid or malformed.");
                        //        break;
                        //    default:
                        //        ModelState.AddModelError("recaptchaerror", "Error occured. Please try again");
                        //        break;
                        //}

                        ModelState.AddModelError("recaptchaerror", "reCAPTCHA Error occured. Please try again");
                        isValid = false;
                        
                    }

                }

                //if (Site.RegistrationAgreement.Length > 0)
                //{
                //    if (!model.AgreeToTerms)
                //    {
                //        ModelState.AddModelError("agreementerror", "You must agree to the terms");
                //        isValid = false;
                //    }
                //}

                if (!isValid)
                {
                    return View(model);
                }

                var user = new SiteUser
                {
                    UserName = model.LoginName.Length > 0? model.LoginName : model.Email.Replace("@",string.Empty).Replace(".",string.Empty),
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    DisplayName = model.DisplayName
                };

                if (model.DateOfBirth.HasValue)
                {
                    user.DateOfBirth = model.DateOfBirth.Value;
                }


                var result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    
                    if(Site.UseSecureRegistration) // require email confirmation
                    {
                        var code = await userManager.GenerateEmailConfirmationTokenAsync(user);
                        var callbackUrl = Url.Action("ConfirmEmail", "Account", 
                            new { userId = user.Id, code = code }, 
                            protocol: HttpContext.Request.Scheme);

                        await emailSender.SendAccountConfirmationEmailAsync(
                            Site,
                            model.Email, 
                            "Confirm your account",
                            callbackUrl);

                        if (this.SessionIsAvailable())
                        {
                            this.AlertSuccess("Please check your email inbox, we just sent you a link that you need to click to confirm your account", true);
                            
                            return Redirect("/");
                        }
                        else
                        {
                            return RedirectToAction("EmailConfirmationRequired", new { userGuid = user.Id, didSend = true });
                        }

                    }
                    else
                    {
                        if(Site.RequireApprovalBeforeLogin)
                        {
                            //TODO: send notification to admins about request for approval

                        }
                        else
                        {
                            await signInManager.SignInAsync(user, isPersistent: false);
                            return Redirect("/");
                        }
                    }

                   
                    
                }
                AddErrors(result);
            }
            //else
            //{
            //    this.AlertDanger("model was invalid", true);
            //}

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult EmailConfirmationRequired(Guid userGuid, bool didSend = false)
        {
            UnconfirmedEmailViewModel model = new UnconfirmedEmailViewModel();
            model.UserGuid = userGuid;
            model.DidSend = didSend;

            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> VerifyEmail(Guid userGuid)
        {
            var user = await userManager.Fetch(userManager.Site.SiteId,  userGuid);

            if(user == null)
            {
                return Redirect("/");
            }

            if(user.EmailConfirmed)
            {
                return Redirect("/");
            }

            var callbackUrl = Url.Action("ConfirmEmail", "Account",
                            new { userId = user.Id, code = user.RegisterConfirmGuid.ToString() },
                            protocol: HttpContext.Request.Scheme);

            await emailSender.SendAccountConfirmationEmailAsync(
                            Site,
                            user.Email,
                            "Confirm your account",
                            callbackUrl);

            return RedirectToAction("EmailConfirmationRequired", new { userGuid = user.Id, didSend = true });
        }

        //

        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogOff()
        {
            await signInManager.SignOutAsync();
            return Redirect("/");
        }

        //[HttpGet]
        //public ActionResult SignOut()
        //{
        //    AuthenticationManager.SignOut();
        //    return RedirectToAction("Index", "Home");
        //}

        // POST: /Account/ExternalLogin
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public IActionResult ExternalLogin(string provider, string returnUrl = null)
        {
            log.LogInformation("ExternalLogin called for " + provider +" with returnurl " + returnUrl);

            // Request a redirect to the external login provider.
            var redirectUrl = Url.Action("ExternalLoginCallback", "Account", new { ReturnUrl = returnUrl });
            var properties = signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
            return new ChallengeResult(provider, properties);
        }

        // GET: /Account/ExternalLoginCallback
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ExternalLoginCallback(string returnUrl = null)
        {
            log.LogInformation("ExternalLoginCallback called with returnurl " + returnUrl);

            var info = await signInManager.GetExternalLoginInfoAsync();
            if (info == null)
            {
                log.LogInformation("ExternalLoginCallback redirecting to login because GetExternalLoginInfoAsync returned null ");
                return RedirectToAction("Login");
            }

            // Sign in the user with this external login provider if the user already has a login.
            var result = await signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false);
            if (result.Succeeded)
            {
                log.LogInformation("ExternalLoginCallback ExternalLoginSignInAsync succeeded ");
                return this.RedirectToLocal(returnUrl);
            }
            if (result.RequiresTwoFactor)
            {
                log.LogInformation("ExternalLoginCallback ExternalLoginSignInAsync RequiresTwoFactor ");
                return RedirectToAction("SendCode", new { ReturnUrl = returnUrl });
            }
            if (result.IsLockedOut)
            {
                log.LogInformation("ExternalLoginCallback ExternalLoginSignInAsync IsLockedOut ");
                return View("Lockout");
            }
            else
            {
                log.LogInformation("ExternalLoginCallback needs new account ");
                // If the user does not have an account, then ask the user to create an account.
                ViewData["ReturnUrl"] = returnUrl;
                ViewData["LoginProvider"] = info.LoginProvider;
                var email = info.ExternalPrincipal.FindFirstValue(ClaimTypes.Email);
                return View("ExternalLoginConfirmation", new ExternalLoginConfirmationViewModel { Email = email });
            }

        }

        // POST: /Account/ExternalLoginConfirmation
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ExternalLoginConfirmation(ExternalLoginConfirmationViewModel model, string returnUrl)
        {
            log.LogInformation("ExternalLoginConfirmation called with returnurl " + returnUrl);

            if (User.IsSignedIn())
            {
                return RedirectToAction("Index", "Manage");
            }

            if (ModelState.IsValid)
            {
                // Get the information about the user from the external login provider
                var info = await signInManager.GetExternalLoginInfoAsync();
                if (info == null)
                {
                    return View("ExternalLoginFailure");
                }
                var user = new SiteUser {
                    SiteGuid = Site.SiteGuid,
                    SiteId = Site.SiteId,
                    UserName = model.Email,
                    Email = model.Email
                };
                var result = await userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    log.LogInformation("ExternalLoginConfirmation user created ");

                    result = await userManager.AddLoginAsync(user, info);
                    if (result.Succeeded)
                    {
                        log.LogInformation("ExternalLoginConfirmation AddLoginAsync succeeded ");
                        await signInManager.SignInAsync(user, isPersistent: false);
                        return this.RedirectToLocal(returnUrl);
                    }
                    else
                    {
                        log.LogInformation("ExternalLoginConfirmation AddLoginAsync failed ");
                    }
                }
                else
                {
                    log.LogInformation("ExternalLoginConfirmation failed to user created ");
                }

                AddErrors(result);
            }
            else
            {
                log.LogInformation("ExternalLoginConfirmation called with ModelStateInvalid ");
            }

            ViewData["ReturnUrl"] = returnUrl;
            return View(model);
        }


        public async Task<JsonResult> LoginNameAvailable(int? userId, string loginName)
        {
            // same validation is used when editing or creating a user
            // if editing then the loginname is valid if found attached to the selected user
            // otherwise if found it is not already in use and not available
            int selectedUserId = -1;
            if (userId.HasValue) { selectedUserId = userId.Value; }
            bool available = await userManager.LoginIsAvailable(selectedUserId, loginName);


            return Json(available);
        }


        // GET: /Account/ConfirmEmail
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail(string userId, string code)
        {
           
            if (userId == null || code == null)
            {
                return View("Error");
            }
            var user = await userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return View("Error");
            }
            var result = await userManager.ConfirmEmailAsync(user, code);
            return View(result.Succeeded ? "ConfirmEmail" : "Error");
        }


        // GET: /Account/ForgotPassword
        [HttpGet]
        [AllowAnonymous]
        public IActionResult ForgotPassword()
        {

            return View();
        }


        // POST: /Account/ForgotPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByNameAsync(model.Email);
                if (user == null || !(await userManager.IsEmailConfirmedAsync(user)))
                {
                    // Don't reveal that the user does not exist or is not confirmed
                    return View("ForgotPasswordConfirmation");
                }

                // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=532713
                // Send an email with this link
                var code = await userManager.GeneratePasswordResetTokenAsync(user);
                var resetUrl = Url.Action("ResetPassword", "Account", 
                    new { userId = user.Id, code = code }, 
                    protocol: HttpContext.Request.Scheme);


                await emailSender.SendPasswordResetEmailAsync(
                    userManager.Site,
                    model.Email, 
                    "Reset Password",
                    resetUrl);

                return View("ForgotPasswordConfirmation");
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }


        // GET: /Account/ForgotPasswordConfirmation
        [HttpGet]
        [AllowAnonymous]
        public IActionResult ForgotPasswordConfirmation()
        {
            
            return View();
        }


        // GET: /Account/ResetPassword
        [HttpGet]
        [AllowAnonymous]
        public IActionResult ResetPassword(string code = null)
        {
            
            return code == null ? View("Error") : View();
        }


        // POST: /Account/ResetPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await userManager.FindByNameAsync(model.Email);
            if (user == null)
            {
                // Don't reveal that the user does not exist
                return RedirectToAction("ResetPasswordConfirmation", "Account");
            }
            var result = await userManager.ResetPasswordAsync(user, model.Code, model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("ResetPasswordConfirmation", "Account");
            }
            AddErrors(result);
            return View();
        }


        // GET: /Account/ResetPasswordConfirmation
        [HttpGet]
        [AllowAnonymous]
        public IActionResult ResetPasswordConfirmation()
        {
            return View();
        }





        // GET: /Account/SendCode
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> SendCode(string returnUrl = null, bool rememberMe = false)
        {
            var user = await signInManager.GetTwoFactorAuthenticationUserAsync();
            if (user == null)
            {
                return View("Error");
            }
            var userFactors = await userManager.GetValidTwoFactorProvidersAsync(user);
            var factorOptions = userFactors.Select(purpose => new SelectListItem { Text = purpose, Value = purpose }).ToList();
            return View(new SendCodeViewModel { Providers = factorOptions, ReturnUrl = returnUrl, RememberMe = rememberMe });
        }


        // POST: /Account/SendCode
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SendCode(SendCodeViewModel model)
        { 
            if (!ModelState.IsValid)
            {
                return View();
            }

            var user = await signInManager.GetTwoFactorAuthenticationUserAsync();
            if (user == null)
            {
                return View("Error");
            }

            // Generate the token and send it
            var code = await userManager.GenerateTwoFactorTokenAsync(user, model.SelectedProvider);
            if (string.IsNullOrWhiteSpace(code))
            {
                return View("Error");
            }

            
            if (model.SelectedProvider == "Email")
            {
                string toAddress = await userManager.GetEmailAsync(user);
                await emailSender.SendSecurityCodeEmailAsync(
                    Site,
                    toAddress, 
                    "Security Code", 
                    code);
            }
            else if (model.SelectedProvider == "Phone")
            {
                var message = "Your security code is: " + code;
                await smsSender.SendSmsAsync(await userManager.GetPhoneNumberAsync(user), message);
            }

            return RedirectToAction("VerifyCode", new { Provider = model.SelectedProvider, ReturnUrl = model.ReturnUrl, RememberMe = model.RememberMe });
        }


        // GET: /Account/VerifyCode
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> VerifyCode(string provider, string returnUrl, bool rememberMe)
        {
            
            // Require that the user has already logged in via username/password or external login
            var user = await signInManager.GetTwoFactorAuthenticationUserAsync();
            if (user == null)
            {
                return View("Error");
            }
            return View(new VerifyCodeViewModel { Provider = provider, ReturnUrl = returnUrl, RememberMe = rememberMe });

        }


        // POST: /Account/VerifyCode
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> VerifyCode(VerifyCodeViewModel model)
        {
            
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // The following code protects for brute force attacks against the two factor codes.
            // If a user enters incorrect codes for a specified amount of time then the user account
            // will be locked out for a specified amount of time.
            var result = await signInManager.TwoFactorSignInAsync(model.Provider, model.Code, model.RememberMe, model.RememberBrowser);
            if (result.Succeeded)
            {
                return this.RedirectToLocal(model.ReturnUrl);
            }
            if (result.IsLockedOut)
            {
                return View("Lockout");
            }
            else
            {
                ModelState.AddModelError("", "Invalid code.");
                return View(model);
            }

        }






        #region Helpers


        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        //private async Task<ApplicationUser> GetCurrentUserAsync()
        //{
        //    return await UserManager.FindByIdAsync(Context.User.GetUserId());
        //}

        //private IActionResult RedirectToLocal(string returnUrl)
        //{
        //    if (Url.IsLocalUrl(returnUrl))
        //    {
        //        return Redirect(returnUrl);
        //    }
        //    else
        //    {
        //        return RedirectToAction("Index", "Home");
        //    }
        //}

        #endregion
    }
}