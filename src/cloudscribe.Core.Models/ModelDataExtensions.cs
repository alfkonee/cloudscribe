﻿// Copyright (c) Source Tree Solutions, LLC. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
// Author:					Joe Audette
// Created:					2014-12-09
// Last Modified:			2015-11-12
// 

using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Globalization;


namespace cloudscribe.Core.Models.DataExtensions
{
    public static class ModelDataExtensions
    {
        public static void LoadFromReader(this ISiteRole role, DbDataReader reader)
        {
            role.RoleId = Convert.ToInt32(reader["RoleID"]);
            role.SiteId = Convert.ToInt32(reader["SiteID"]);
            role.RoleName = reader["RoleName"].ToString();
            role.DisplayName = reader["DisplayName"].ToString();
            role.SiteGuid = new Guid(reader["SiteGuid"].ToString());
            role.RoleGuid = new Guid(reader["RoleGuid"].ToString());
        }

        public static void LoadFromReader(this IUserLogin userLogin, DbDataReader reader)
        {
            userLogin.SiteId = Convert.ToInt32(reader["SiteId"]);
            userLogin.LoginProvider = reader["LoginProvider"].ToString();
            userLogin.ProviderKey = reader["ProviderKey"].ToString();
            userLogin.UserId = reader["UserId"].ToString();
            userLogin.ProviderDisplayName = reader["ProviderDisplayName"].ToString();
        }

        public static void LoadFromReader(this IUserClaim userClaim, DbDataReader reader)
        {
            userClaim.SiteId = Convert.ToInt32(reader["SiteId"]);
            userClaim.Id = Convert.ToInt32(reader["Id"]);
            userClaim.UserId = reader["UserId"].ToString();
            userClaim.ClaimType = reader["ClaimType"].ToString();
            userClaim.ClaimValue = reader["ClaimValue"].ToString();
        }

        public static void LoadFromReader(this IUserInfo user, DbDataReader reader)
        {
            user.UserId = Convert.ToInt32(reader["UserID"], CultureInfo.InvariantCulture);
            if (reader["UserGuid"] != DBNull.Value)
            {
                user.UserGuid = new Guid(reader["UserGuid"].ToString());
            }
            user.SiteId = Convert.ToInt32(reader["SiteID"], CultureInfo.InvariantCulture);
            user.SiteGuid = new Guid(reader["SiteGuid"].ToString());
            user.DisplayName = reader["Name"].ToString();
            user.UserName = reader["LoginName"].ToString();
            user.Email = reader["Email"].ToString();
            user.FirstName = reader["FirstName"].ToString();
            user.LastName = reader["LastName"].ToString();

            user.Gender = reader["Gender"].ToString();

            if (reader["AccountApproved"] != DBNull.Value)
            {
                user.AccountApproved = Convert.ToBoolean(reader["AccountApproved"]);
            }

           
            if (reader["Trusted"] != DBNull.Value)
            {
                user.Trusted = Convert.ToBoolean(reader["Trusted"]);
            }
            if (reader["DisplayInMemberList"] != DBNull.Value)
            {
                user.DisplayInMemberList = Convert.ToBoolean(reader["DisplayInMemberList"]);
            }
            user.WebSiteUrl = reader["WebSiteURL"].ToString();
            user.Country = reader["Country"].ToString();
            user.State = reader["State"].ToString();
           
            user.AvatarUrl = reader["AvatarUrl"].ToString();

            if (reader["DateCreated"] != DBNull.Value)
            {
                user.CreatedUtc = Convert.ToDateTime(reader["DateCreated"]);
            }

            if (reader["IsDeleted"] != DBNull.Value)
            {
                user.IsDeleted = Convert.ToBoolean(reader["IsDeleted"]);
            }
            if (reader["LastActivityDate"] != DBNull.Value)
            {
                user.LastActivityDate = Convert.ToDateTime(reader["LastActivityDate"]);
            }
            if (reader["LastLoginDate"] != DBNull.Value)
            {
                user.LastLoginDate = Convert.ToDateTime(reader["LastLoginDate"]);
            }

            if (reader["IsLockedOut"] != DBNull.Value)
            {
                user.IsLockedOut = Convert.ToBoolean(reader["IsLockedOut"]);
            }
            
            user.TimeZoneId = reader["TimeZoneId"].ToString();

            if (reader["DateOfBirth"] != DBNull.Value)
            {
                user.DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]);
            }

            user.PhoneNumber = reader["PhoneNumber"].ToString();
            user.PhoneNumberConfirmed = Convert.ToBoolean(reader["PhoneNumberConfirmed"]);
        }

        public static void LoadFromReader(this SiteUser user, DbDataReader reader)
        {
            user.UserId = Convert.ToInt32(reader["UserID"], CultureInfo.InvariantCulture);
            user.SiteId = Convert.ToInt32(reader["SiteID"], CultureInfo.InvariantCulture);
            user.DisplayName = reader["Name"].ToString();
            user.UserName = reader["LoginName"].ToString();

            user.Email = reader["Email"].ToString();
            user.LoweredEmail = reader["LoweredEmail"].ToString();
            
            user.Gender = reader["Gender"].ToString();

            if (reader["AccountApproved"] != DBNull.Value)
            {
                user.AccountApproved = Convert.ToBoolean(reader["AccountApproved"]);
            }

            if (reader["RegisterConfirmGuid"] != DBNull.Value)
            {
                user.RegisterConfirmGuid = new Guid(reader["RegisterConfirmGuid"].ToString());
            }
            
            if (reader["Trusted"] != DBNull.Value)
            {
                user.Trusted = Convert.ToBoolean(reader["Trusted"]);
            }
            if (reader["DisplayInMemberList"] != DBNull.Value)
            {
                user.DisplayInMemberList = Convert.ToBoolean(reader["DisplayInMemberList"]);
            }
            user.WebSiteUrl = reader["WebSiteURL"].ToString();
            user.Country = reader["Country"].ToString();
            user.State = reader["State"].ToString();
            
            user.AvatarUrl = reader["AvatarUrl"].ToString();

            user.Signature = reader["Signature"].ToString();
            if (reader["DateCreated"] != DBNull.Value)
            {
                user.CreatedUtc = Convert.ToDateTime(reader["DateCreated"]);
            }
            if (reader["UserGuid"] != DBNull.Value)
            {
                user.UserGuid = new Guid(reader["UserGuid"].ToString());
            }
            
            if (reader["IsDeleted"] != DBNull.Value)
            {
                user.IsDeleted = Convert.ToBoolean(reader["IsDeleted"]);
            }
            if (reader["LastActivityDate"] != DBNull.Value)
            {
                user.LastActivityDate = Convert.ToDateTime(reader["LastActivityDate"]);
            }
            if (reader["LastLoginDate"] != DBNull.Value)
            {
                user.LastLoginDate = Convert.ToDateTime(reader["LastLoginDate"]);
            }
            if (reader["LastPasswordChangedDate"] != DBNull.Value)
            {
                user.LastPasswordChangedDate = Convert.ToDateTime(reader["LastPasswordChangedDate"]);
            }
            if (reader["LastLockoutDate"] != DBNull.Value)
            {
                user.LastLockoutDate = Convert.ToDateTime(reader["LastLockoutDate"]);
            }
            if (reader["FailedPasswordAttemptCount"] != DBNull.Value)
            {
                user.FailedPasswordAttemptCount = Convert.ToInt32(reader["FailedPasswordAttemptCount"]);
            }
            if (reader["FailedPwdAttemptWindowStart"] != DBNull.Value)
            {
                user.FailedPasswordAttemptWindowStart = Convert.ToDateTime(reader["FailedPwdAttemptWindowStart"]);
            }
            if (reader["FailedPwdAnswerAttemptCount"] != DBNull.Value)
            {
                user.FailedPasswordAnswerAttemptCount = Convert.ToInt32(reader["FailedPwdAnswerAttemptCount"]);
            }
            if (reader["FailedPwdAnswerWindowStart"] != DBNull.Value)
            {
                user.FailedPasswordAnswerAttemptWindowStart = Convert.ToDateTime(reader["FailedPwdAnswerWindowStart"]);
            }
            if (reader["IsLockedOut"] != DBNull.Value)
            {
                user.IsLockedOut = Convert.ToBoolean(reader["IsLockedOut"]);
            }
            
            user.Comment = reader["Comment"].ToString();
           
            user.SiteGuid = new Guid(reader["SiteGuid"].ToString());
            
            user.FirstName = reader["FirstName"].ToString();
            user.LastName = reader["LastName"].ToString();

            user.MustChangePwd = Convert.ToBoolean(reader["MustChangePwd"]);
            user.NewEmail = reader["NewEmail"].ToString();
            
            user.EmailChangeGuid = new Guid(reader["EmailChangeGuid"].ToString());
            user.TimeZoneId = reader["TimeZoneId"].ToString();
            user.PasswordResetGuid = new Guid(reader["PasswordResetGuid"].ToString());
            user.RolesChanged = Convert.ToBoolean(reader["RolesChanged"]);
            user.AuthorBio = reader["AuthorBio"].ToString();
            if (reader["DateOfBirth"] != DBNull.Value)
            {
                user.DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]);
            }

            user.EmailConfirmed = Convert.ToBoolean(reader["EmailConfirmed"]);

            user.SecurityStamp = reader["SecurityStamp"].ToString();
            user.PhoneNumber = reader["PhoneNumber"].ToString();
            user.PhoneNumberConfirmed = Convert.ToBoolean(reader["PhoneNumberConfirmed"]);
            user.TwoFactorEnabled = Convert.ToBoolean(reader["TwoFactorEnabled"]);
            if (reader["LockoutEndDateUtc"] != DBNull.Value)
            {
                user.LockoutEndDateUtc = Convert.ToDateTime(reader["LockoutEndDateUtc"]);
            }

            user.PasswordHash = reader["PasswordHash"].ToString();
            
        }

        public static void LoadFromReader(this ISiteInfo site, DbDataReader reader)
        {
            site.SiteId = Convert.ToInt32(reader["SiteID"]);
            site.SiteGuid = new Guid(reader["SiteGuid"].ToString());
            site.SiteName = reader["SiteName"].ToString();
            site.SiteFolderName = reader["SiteFolderName"].ToString();
            site.PreferredHostName = reader["PreferredHostName"].ToString();
            site.IsServerAdminSite = Convert.ToBoolean(reader["IsServerAdminSite"]);
        }

        public static void LoadFromReader(this ISiteSettings site, DbDataReader reader)
        {
            site.SiteId = Convert.ToInt32(reader["SiteID"]);
            site.SiteGuid = new Guid(reader["SiteGuid"].ToString());
            
            site.SiteName = reader["SiteName"].ToString();
            site.Layout = reader["Skin"].ToString();
            site.AllowNewRegistration = Convert.ToBoolean(reader["AllowNewRegistration"]);
            site.UseSecureRegistration = Convert.ToBoolean(reader["UseSecureRegistration"]);
            site.UseSslOnAllPages = Convert.ToBoolean(reader["UseSSLOnAllPages"]);

            site.IsServerAdminSite = Convert.ToBoolean(reader["IsServerAdminSite"]);
            site.UseLdapAuth = Convert.ToBoolean(reader["UseLdapAuth"]);
            site.AutoCreateLdapUserOnFirstLogin = Convert.ToBoolean(reader["AutoCreateLdapUserOnFirstLogin"]);
            
            site.LdapServer = reader["LdapServer"].ToString();
            site.LdapPort = Convert.ToInt32(reader["LdapPort"]);
            site.LdapDomain = reader["LdapDomain"].ToString();
            site.LdapRootDN = reader["LdapRootDN"].ToString();
            site.LdapUserDNKey = reader["LdapUserDNKey"].ToString();

            site.ReallyDeleteUsers = Convert.ToBoolean(reader["ReallyDeleteUsers"]);
            site.UseEmailForLogin = Convert.ToBoolean(reader["UseEmailForLogin"]);
            site.AllowUserFullNameChange = Convert.ToBoolean(reader["AllowUserFullNameChange"]);
            
            site.RequiresQuestionAndAnswer = Convert.ToBoolean(reader["RequiresQuestionAndAnswer"]);
            site.MaxInvalidPasswordAttempts = Convert.ToInt32(reader["MaxInvalidPasswordAttempts"]);
            site.PasswordAttemptWindowMinutes = Convert.ToInt32(reader["PasswordAttemptWindowMinutes"]);
           
            site.MinRequiredPasswordLength = Convert.ToInt32(reader["MinRequiredPasswordLength"]);
            site.MinReqNonAlphaChars = Convert.ToInt32(reader["MinReqNonAlphaChars"]);
            
            site.DefaultEmailFromAddress = reader["DefaultEmailFromAddress"].ToString();
            site.RecaptchaPrivateKey = reader["RecaptchaPrivateKey"].ToString();
            site.RecaptchaPublicKey = reader["RecaptchaPublicKey"].ToString();
            
            site.AddThisDotComUsername = reader["AddThisDotComUsername"].ToString();
            site.ApiKeyExtra1 = reader["ApiKeyExtra1"].ToString();
            site.ApiKeyExtra2 = reader["ApiKeyExtra2"].ToString();
            site.ApiKeyExtra3 = reader["ApiKeyExtra3"].ToString();
            site.ApiKeyExtra4 = reader["ApiKeyExtra4"].ToString();
            site.ApiKeyExtra5 = reader["ApiKeyExtra5"].ToString();
            
            site.DisableDbAuth = Convert.ToBoolean(reader["DisableDbAuth"]);
            
            site.RequireApprovalBeforeLogin = Convert.ToBoolean(reader["RequireApprovalBeforeLogin"]);
            site.AllowDbFallbackWithLdap = Convert.ToBoolean(reader["AllowDbFallbackWithLdap"]);
            site.EmailLdapDbFallback = Convert.ToBoolean(reader["EmailLdapDbFallback"]);
            site.AllowPersistentLogin = Convert.ToBoolean(reader["AllowPersistentLogin"]);
            site.CaptchaOnLogin = Convert.ToBoolean(reader["CaptchaOnLogin"]);
            site.CaptchaOnRegistration = Convert.ToBoolean(reader["CaptchaOnRegistration"]);
            site.SiteIsClosed = Convert.ToBoolean(reader["SiteIsClosed"]);
            site.SiteIsClosedMessage = reader["SiteIsClosedMessage"].ToString();
            site.PrivacyPolicy = reader["PrivacyPolicy"].ToString();
            site.TimeZoneId = reader["TimeZoneId"].ToString();
            site.GoogleAnalyticsProfileId = reader["GoogleAnalyticsProfileId"].ToString();
            site.CompanyName = reader["CompanyName"].ToString();
            site.CompanyStreetAddress = reader["CompanyStreetAddress"].ToString();
            site.CompanyStreetAddress2 = reader["CompanyStreetAddress2"].ToString();
            site.CompanyRegion = reader["CompanyRegion"].ToString();
            site.CompanyLocality = reader["CompanyLocality"].ToString();
            site.CompanyCountry = reader["CompanyCountry"].ToString();
            site.CompanyPostalCode = reader["CompanyPostalCode"].ToString();
            site.CompanyPublicEmail = reader["CompanyPublicEmail"].ToString();
            site.CompanyPhone = reader["CompanyPhone"].ToString();
            site.CompanyFax = reader["CompanyFax"].ToString();
            site.FacebookAppId = reader["FacebookAppId"].ToString();
            site.FacebookAppSecret = reader["FacebookAppSecret"].ToString();
            site.GoogleClientId = reader["GoogleClientId"].ToString();
            site.GoogleClientSecret = reader["GoogleClientSecret"].ToString();
            site.TwitterConsumerKey = reader["TwitterConsumerKey"].ToString();
            site.TwitterConsumerSecret = reader["TwitterConsumerSecret"].ToString();
            site.MicrosoftClientId = reader["MicrosoftClientId"].ToString();
            site.MicrosoftClientSecret = reader["MicrosoftClientSecret"].ToString();
            site.PreferredHostName = reader["PreferredHostName"].ToString();
            site.SiteFolderName = reader["SiteFolderName"].ToString();
            site.AddThisDotComUsername = reader["AddThisDotComUsername"].ToString();
            site.LoginInfoTop = reader["LoginInfoTop"].ToString();
            site.LoginInfoBottom = reader["LoginInfoBottom"].ToString();
            site.RegistrationAgreement = reader["RegistrationAgreement"].ToString();
            site.RegistrationPreamble = reader["RegistrationPreamble"].ToString();
            site.SmtpServer = reader["SmtpServer"].ToString();
            site.SmtpPort = Convert.ToInt32(reader["SmtpPort"]);
            site.SmtpUser = reader["SmtpUser"].ToString();
            site.SmtpPassword = reader["SmtpPassword"].ToString();
            site.SmtpPreferredEncoding = reader["SmtpPreferredEncoding"].ToString();
            site.SmtpRequiresAuth = Convert.ToBoolean(reader["SmtpRequiresAuth"]);
            site.SmtpUseSsl = Convert.ToBoolean(reader["SmtpUseSsl"]);

            site.IsDataProtected = Convert.ToBoolean(reader["IsDataProtected"]);
            if(reader["CreatedUtc"] != DBNull.Value)
            {
                site.CreatedUtc = Convert.ToDateTime(reader["CreatedUtc"]);
            }
            

        }


        public static void LoadFromReader(this ISiteFolder folder, DbDataReader reader)
        {
            folder.Guid = new Guid(reader["Guid"].ToString());
            folder.SiteGuid = new Guid(reader["SiteGuid"].ToString());
            folder.FolderName = reader["FolderName"].ToString();
        }

        public static void LoadFromReader(this ISiteHost host, DbDataReader reader)
        {
            host.HostId = Convert.ToInt32(reader["HostID"]);
            host.HostName = reader["HostName"].ToString();
            host.SiteGuid = new Guid(reader["SiteGuid"].ToString());
            host.SiteId = Convert.ToInt32(reader["SiteID"]);
        }

        public static void LoadExpandoSettings(this ISiteSettings site, List<ExpandoSetting> expandoProperties)
        {
            // this may go away

            //string b = GetExpandoProperty(expandoProperties, "AllowPersistentLogin");
            //if (!string.IsNullOrEmpty(b)) { site.AllowPersistentLogin = Convert.ToBoolean(b); }

            //site.AvatarSystem = GetExpandoProperty(expandoProperties, "AvatarSystem");
            //site.CommentProvider = GetExpandoProperty(expandoProperties, "CommentProvider");
            

        }

        public static void SetExpandoSettings(this ISiteSettings site, List<ExpandoSetting> expandoProperties)
        {
            //SetExpandoProperty(expandoProperties, "AvatarSystem", site.AvatarSystem);
            //SetExpandoProperty(expandoProperties, "AllowUserEditorPreference", site.AllowUserEditorPreference);
            
        }

        private static string GetExpandoProperty(List<ExpandoSetting> exapandoProperties, string keyName)
        {
            //EnsureExpandoProperties();

            foreach (ExpandoSetting s in exapandoProperties)
            {
                if (s.KeyName.Trim().Equals(keyName, StringComparison.CurrentCulture))
                {
                    return s.KeyValue;
                }

            }

            return null;

        }

        private static void SetExpandoProperty(List<ExpandoSetting> exapandoProperties, string keyName, string keyValue)
        {  
            foreach (ExpandoSetting s in exapandoProperties)
            {
                if (s.KeyName.Trim().Equals(keyName, StringComparison.CurrentCulture))
                {
                    if (s.KeyValue != keyValue)
                    {
                        s.KeyValue = keyValue;
                        s.IsDirty = true;
                    };
                    break;
                }
            }
        }

        

        
    }
}
