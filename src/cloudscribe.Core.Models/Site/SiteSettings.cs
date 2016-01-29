﻿// Copyright (c) Source Tree Solutions, LLC. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
// Author:					Joe Audette
// Created:					2014-08-16
// Last Modified:			2016-01-17
// 

using System;

namespace cloudscribe.Core.Models
{
    //[Serializable()]
    public class SiteSettings : SiteInfo, ISiteSettings
    {

        public SiteSettings()
        {

        }

        private string defaultEmailFromAddress = string.Empty;
        public string DefaultEmailFromAddress
        {
            get { return defaultEmailFromAddress ?? string.Empty; }
            set { defaultEmailFromAddress = value; }
        }

        //public string DefaultFromEmailAlias { get; set; } = string.Empty;

        private string layout = string.Empty;
        public string Layout
        {
            get { return layout ?? string.Empty; }
            set { layout = value; }
        }
        
        
        public bool AllowNewRegistration { get; set; } = true;
        public bool UseSecureRegistration { get; set; } = false;
        public bool UseSslOnAllPages { get; set; } = false;
        
        public bool UseLdapAuth { get; set; } = false;
        public bool AllowDbFallbackWithLdap { get; set; } = false;
        public bool EmailLdapDbFallback { get; set; } = false;
        public bool AutoCreateLdapUserOnFirstLogin { get; set; } = true;
        
        private string ldapServer = string.Empty;
        public string LdapServer
        {
            get { return ldapServer ?? string.Empty; }
            set { ldapServer = value; }
        }

        private string ldapDomain = string.Empty;
        public string LdapDomain
        {
            get { return ldapDomain ?? string.Empty; }
            set { ldapDomain = value; }
        }

        public int LdapPort { get; set; } = 389;

        private string ldapRootDN = string.Empty;
        public string LdapRootDN
        {
            get { return ldapRootDN ?? string.Empty; }
            set { ldapRootDN = value; }
        }

        private string ldapUserDNKey = "CN";
        public string LdapUserDNKey
        {
            get { return ldapUserDNKey ?? string.Empty; }
            set { ldapUserDNKey = value; }
        }
        
        public bool AllowUserFullNameChange { get; set; } = true;
        public bool ReallyDeleteUsers { get; set; } = true;
        public bool UseEmailForLogin { get; set; } = true;
        public bool DisableDbAuth { get; set; } = false;
       
        public bool RequiresQuestionAndAnswer { get; set; } = false;
        public bool RequireApprovalBeforeLogin { get; set; } = false;
        
        public int MaxInvalidPasswordAttempts { get; set; } = 10;
        public int PasswordAttemptWindowMinutes { get; set; } = 5;
        
        public int MinRequiredPasswordLength { get; set; } = 7;    
        public int MinReqNonAlphaChars { get; set; } = 0;
        
        public bool AllowPersistentLogin { get; set; } = true;
        public bool CaptchaOnRegistration { get; set; } = false;
        public bool CaptchaOnLogin { get; set; } = false;
        //public bool RequireEnterEmailTwiceOnRegistration { get; set; } = false;

        private string recaptchaPrivateKey = string.Empty;
        public string RecaptchaPrivateKey
        {
            get { return recaptchaPrivateKey ?? string.Empty; }
            set { recaptchaPrivateKey = value; }
        }

        private string recaptchaPublicKey = string.Empty;
        public string RecaptchaPublicKey
        {
            get { return recaptchaPublicKey ?? string.Empty; }
            set { recaptchaPublicKey = value; }
        }

        private string facebookAppId = string.Empty;
        public string FacebookAppId
        {
            get { return facebookAppId ?? string.Empty; }
            set { facebookAppId = value; }
        }

        private string facebookAppSecret = string.Empty;
        public string FacebookAppSecret
        {
            get { return facebookAppSecret ?? string.Empty; }
            set { facebookAppSecret = value; }
        }

        private string microsoftClientId = string.Empty;
        public string MicrosoftClientId
        {
            get { return microsoftClientId ?? string.Empty; }
            set { microsoftClientId = value; }
        }

        private string microsoftClientSecret = string.Empty;
        public string MicrosoftClientSecret
        {
            get { return microsoftClientSecret ?? string.Empty; }
            set { microsoftClientSecret = value; }
        }

        private string googleClientId = string.Empty;
        public string GoogleClientId
        {
            get { return googleClientId ?? string.Empty; }
            set { googleClientId = value; }
        }

        private string googleClientSecret = string.Empty;
        public string GoogleClientSecret
        {
            get { return googleClientSecret ?? string.Empty; }
            set { googleClientSecret = value; }
        }

        private string twitterConsumerKey = string.Empty;
        public string TwitterConsumerKey
        {
            get { return twitterConsumerKey ?? string.Empty; }
            set { twitterConsumerKey = value; }
        }

        private string twitterConsumerSecret = string.Empty;
        public string TwitterConsumerSecret
        {
            get { return twitterConsumerSecret ?? string.Empty; }
            set { twitterConsumerSecret = value; }
        }

        private string addThisDotComUsername = string.Empty;
        public string AddThisDotComUsername
        {
            get { return addThisDotComUsername ?? string.Empty; }
            set { addThisDotComUsername = value; }
        }

        private string apiKeyExtra1 = string.Empty;
        public string ApiKeyExtra1
        {
            get { return apiKeyExtra1 ?? string.Empty; }
            set { apiKeyExtra1 = value; }
        }

        private string apiKeyExtra2 = string.Empty;
        public string ApiKeyExtra2
        {
            get { return apiKeyExtra2 ?? string.Empty; }
            set { apiKeyExtra2 = value; }
        }

        private string apiKeyExtra3 = string.Empty;
        public string ApiKeyExtra3
        {
            get { return apiKeyExtra3 ?? string.Empty; }
            set { apiKeyExtra3 = value; }
        }

        private string apiKeyExtra4 = string.Empty;
        public string ApiKeyExtra4
        {
            get { return apiKeyExtra4 ?? string.Empty; }
            set { apiKeyExtra4 = value; }
        }

        private string apiKeyExtra5 = string.Empty;
        public string ApiKeyExtra5
        {
            get { return apiKeyExtra5 ?? string.Empty; }
            set { apiKeyExtra5 = value; }
        }

        private string timeZoneId = "Eastern Standard Time";
        public string TimeZoneId
        {
            get { return timeZoneId ?? "Eastern Standard Time"; }
            set { timeZoneId = value; }
        }

        private string companyName = string.Empty;
        public string CompanyName
        {
            get { return companyName ?? string.Empty; }
            set { companyName = value; }
        }

        private string companyStreetAddress = string.Empty;
        public string CompanyStreetAddress
        {
            get { return companyStreetAddress ?? string.Empty; }
            set { companyStreetAddress = value; }
        }

        private string companyStreetAddress2 = string.Empty;
        public string CompanyStreetAddress2
        {
            get { return companyStreetAddress2 ?? string.Empty; }
            set { companyStreetAddress2 = value; }
        }

        private string companyLocality = string.Empty;
        public string CompanyLocality
        {
            get { return companyLocality ?? string.Empty; }
            set { companyLocality = value; }
        }

        private string companyRegion = string.Empty;
        public string CompanyRegion
        {
            get { return companyRegion ?? string.Empty; }
            set { companyRegion = value; }
        }

        private string companyPostalCode = string.Empty;
        public string CompanyPostalCode
        {
            get { return companyPostalCode ?? string.Empty; }
            set { companyPostalCode = value; }
        }

        private string companyCountry = string.Empty;
        public string CompanyCountry
        {
            get { return companyCountry ?? string.Empty; }
            set { companyCountry = value; }
        }

        private string companyPhone = string.Empty;
        public string CompanyPhone
        {
            get { return companyPhone ?? string.Empty; }
            set { companyPhone = value; }
        }

        private string companyFax = string.Empty;
        public string CompanyFax
        {
            get { return companyFax ?? string.Empty; }
            set { companyFax = value; }
        }

        private string companyPublicEmail = string.Empty;
        public string CompanyPublicEmail
        {
            get { return companyPublicEmail ?? string.Empty; }
            set { companyPublicEmail = value; }
        }

        private string smtpUser = string.Empty;
        public string SmtpUser
        {
            get { return smtpUser ?? string.Empty; }
            set { smtpUser = value; }
        }

        private string smtpPassword = string.Empty;
        public string SmtpPassword
        {
            get { return smtpPassword ?? string.Empty; }
            set { smtpPassword = value; }
        }
        
        public int SmtpPort { get; set; } = 25;

        private string smtpPreferredEncoding = string.Empty;
        public string SmtpPreferredEncoding
        {
            get { return smtpPreferredEncoding ?? string.Empty; }
            set { smtpPreferredEncoding = value; }
        }

        private string smtpServer = string.Empty;
        public string SmtpServer
        {
            get { return smtpServer ?? string.Empty; }
            set { smtpServer = value; }
        }

        public bool SmtpRequiresAuth { get; set; } = false;
        public bool SmtpUseSsl { get; set; } = false;

        private string googleAnalyticsProfileId = string.Empty;
        public string GoogleAnalyticsProfileId
        {
            get { return googleAnalyticsProfileId ?? string.Empty; }
            set { googleAnalyticsProfileId = value; }
        }

        private string registrationAgreement = string.Empty;
        public string RegistrationAgreement
        {
            get { return registrationAgreement ?? string.Empty; }
            set { registrationAgreement = value; }
        }

        private string registrationPreamble = string.Empty;
        public string RegistrationPreamble
        {
            get { return registrationPreamble ?? string.Empty; }
            set { registrationPreamble = value; }
        }

        private string loginInfoTop = string.Empty;
        public string LoginInfoTop
        {
            get { return loginInfoTop ?? string.Empty; }
            set { loginInfoTop = value; }
        }

        private string loginInfoBottom = string.Empty;
        public string LoginInfoBottom
        {
            get { return loginInfoBottom ?? string.Empty; }
            set { loginInfoBottom = value; }
        }

        
        public bool SiteIsClosed { get; set; } = false;

        private string siteIsClosedMessage = string.Empty;
        public string SiteIsClosedMessage
        {
            get { return siteIsClosedMessage ?? string.Empty; }
            set { siteIsClosedMessage = value; }
        }

        private string privacyPolicy = string.Empty;
        public string PrivacyPolicy
        {
            get { return privacyPolicy ?? string.Empty; }
            set { privacyPolicy = value; }
        }

        public bool IsDataProtected { get; set; } = false;

        public DateTime CreatedUtc { get; set; } = DateTime.UtcNow;


        public static SiteSettings FromISiteSettings(ISiteSettings i)
        {
            if(i == null) { return null; }

            SiteSettings s = new SiteSettings();
            s.AddThisDotComUsername = i.AddThisDotComUsername;
            s.AllowDbFallbackWithLdap = i.AllowDbFallbackWithLdap;
            s.AllowNewRegistration = i.AllowNewRegistration;
            s.AllowPersistentLogin = i.AllowPersistentLogin;
            s.AllowUserFullNameChange = i.AllowUserFullNameChange;
            s.ApiKeyExtra1 = i.ApiKeyExtra1;
            s.ApiKeyExtra2 = i.ApiKeyExtra2;
            s.ApiKeyExtra3 = i.ApiKeyExtra3;
            s.ApiKeyExtra4 = i.ApiKeyExtra4;
            s.ApiKeyExtra5 = i.ApiKeyExtra5;
            s.AutoCreateLdapUserOnFirstLogin = i.AutoCreateLdapUserOnFirstLogin;
            s.CaptchaOnLogin = i.CaptchaOnLogin;
            s.CaptchaOnRegistration = i.CaptchaOnRegistration;
            s.CompanyCountry = i.CompanyCountry;
            s.CompanyFax = i.CompanyFax;
            s.CompanyLocality = i.CompanyLocality;
            s.CompanyName = i.CompanyName;
            s.CompanyPhone = i.CompanyPhone;
            s.CompanyPostalCode = i.CompanyPostalCode;
            s.CompanyPublicEmail = i.CompanyPublicEmail;
            s.CompanyRegion = i.CompanyRegion;
            s.CompanyStreetAddress = i.CompanyStreetAddress;
            s.CompanyStreetAddress2 = i.CompanyStreetAddress2;
            s.DefaultEmailFromAddress = i.DefaultEmailFromAddress;
            s.DisableDbAuth = i.DisableDbAuth;
            s.EmailLdapDbFallback = i.EmailLdapDbFallback;
            s.FacebookAppId = i.FacebookAppId;
            s.FacebookAppSecret = i.FacebookAppSecret;
            s.GoogleAnalyticsProfileId = i.GoogleAnalyticsProfileId;
            s.GoogleClientId = i.GoogleClientId;
            s.GoogleClientSecret = i.GoogleClientSecret;
            s.IsServerAdminSite = i.IsServerAdminSite;
            s.Layout = i.Layout;
            s.LdapDomain = i.LdapDomain;
            s.LdapPort = i.LdapPort;
            s.LdapRootDN = i.LdapRootDN;
            s.LdapServer = i.LdapServer;
            s.LdapUserDNKey = i.LdapUserDNKey;
            s.LoginInfoBottom = i.LoginInfoBottom;
            s.LoginInfoTop = i.LoginInfoTop;
            s.MaxInvalidPasswordAttempts = i.MaxInvalidPasswordAttempts;
            s.MicrosoftClientId = i.MicrosoftClientId;
            s.MicrosoftClientSecret = i.MicrosoftClientSecret;
            s.MinReqNonAlphaChars = i.MinReqNonAlphaChars;
            s.MinRequiredPasswordLength = i.MinRequiredPasswordLength;
            s.PasswordAttemptWindowMinutes = i.PasswordAttemptWindowMinutes;
            s.PreferredHostName = i.PreferredHostName;
            s.PrivacyPolicy = i.PrivacyPolicy;
            s.ReallyDeleteUsers = i.ReallyDeleteUsers;
            s.RecaptchaPrivateKey = i.RecaptchaPrivateKey;
            s.RecaptchaPublicKey = i.RecaptchaPublicKey;
            s.RegistrationAgreement = i.RegistrationAgreement;
            s.RegistrationPreamble = i.RegistrationPreamble;
            s.RequireApprovalBeforeLogin = i.RequireApprovalBeforeLogin;
            s.RequiresQuestionAndAnswer = i.RequiresQuestionAndAnswer;
            s.SiteFolderName = i.SiteFolderName;
            s.SiteGuid = i.SiteGuid;
            s.SiteId = i.SiteId;
            s.SiteIsClosed = i.SiteIsClosed;
            s.SiteIsClosedMessage = i.SiteIsClosedMessage;
            s.SiteName = i.SiteName;
            s.SmtpPassword = i.SmtpPassword;
            s.SmtpPort = i.SmtpPort;
            s.SmtpPreferredEncoding = i.SmtpPreferredEncoding;
            s.SmtpRequiresAuth = i.SmtpRequiresAuth;
            s.SmtpServer = i.SmtpServer;
            s.SmtpUser = i.SmtpUser;
            s.SmtpUseSsl = i.SmtpUseSsl;
            s.TimeZoneId = i.TimeZoneId;
            s.TwitterConsumerKey = i.TwitterConsumerKey;
            s.TwitterConsumerSecret = i.TwitterConsumerSecret;
            s.UseEmailForLogin = i.UseEmailForLogin;
            s.UseLdapAuth = i.UseLdapAuth;
            s.UseSecureRegistration = i.UseSecureRegistration;
            s.UseSslOnAllPages = i.UseSslOnAllPages;

            s.IsDataProtected = i.IsDataProtected;
            s.CreatedUtc = i.CreatedUtc;



            return s;
        }

    }
}
