﻿// Copyright (c) Source Tree Solutions, LLC. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cloudscribe.Core.Models
{
    /// <summary>
    /// lighter weight version of user for lists and dropdowns
    /// base class for SiteUser
    /// </summary>
    //[Serializable]
    public class UserInfo : IUserInfo
    {
        public UserInfo()
        { }

        
        public int UserId { get; set; } = -1;
        public Guid UserGuid { get; set; } = Guid.Empty;
        public Guid SiteGuid { get; set; } = Guid.Empty;
        public int SiteId { get; set; } = -1;

        private string email = string.Empty;
        public string Email
        {
            get { return email ?? string.Empty; }
            set { email = value; }
        }

        private string userName = string.Empty;
        public string UserName
        {
            get { return userName ?? string.Empty; }
            set { userName = value; }
        }

        private string displayName = string.Empty;
        public string DisplayName
        {
            get { return displayName ?? string.Empty; }
            set { displayName = value; }
        }

        private string firstName = string.Empty;
        public string FirstName
        {
            get { return firstName ?? string.Empty; }
            set { firstName = value; }
        }

        private string lastName = string.Empty;
        public string LastName
        {
            get { return lastName ?? string.Empty; }
            set { lastName = value; }
        }
        
        public bool IsDeleted { get; set; } = false;
        public bool Trusted { get; set; } = false;

        private string avatarUrl = string.Empty;
        public string AvatarUrl
        {
            get { return avatarUrl ?? string.Empty; }
            set { avatarUrl = value; }
        }

        
        public DateTime DateOfBirth { get; set; } = DateTime.MinValue;
        public DateTime CreatedUtc { get; set; } = DateTime.UtcNow;
        public bool DisplayInMemberList { get; set; } = true;

        private string gender = string.Empty;
        public string Gender
        {
            get { return gender ?? string.Empty; }
            set { gender = value; }
        }

        public bool IsLockedOut { get; set; } = false;

        private string country = string.Empty;
        public string Country
        {
            get { return country ?? string.Empty; }
            set { country = value; }
        }

        private string state = string.Empty;
        public string State
        {
            get { return state ?? string.Empty; }
            set { state = value; }
        }

        
        public DateTime LastActivityDate { get; set; } = DateTime.MinValue;
        public DateTime LastLoginDate { get; set; } = DateTime.MinValue;

        private string phoneNumber = string.Empty;
        public string PhoneNumber
        {
            get { return phoneNumber ?? string.Empty; }
            set { phoneNumber = value; }
        }

        public bool PhoneNumberConfirmed { get; set; } = false;
        public bool AccountApproved { get; set; } = true;

        private string timeZoneId = "Eastern Standard Time";
        public string TimeZoneId
        {
            get { return timeZoneId ?? "Eastern Standard Time"; }
            set { timeZoneId = value; }
        }

        
        private string webSiteUrl = string.Empty;
        public string WebSiteUrl
        {
            get { return webSiteUrl ?? string.Empty; }
            set { webSiteUrl = value; }
        }

       

    }
}
