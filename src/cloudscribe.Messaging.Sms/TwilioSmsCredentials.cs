﻿// Copyright (c) Source Tree Solutions, LLC. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
// Author:					Joe Audette
// Created:				    2016-01-24
// Last Modified:		    2016-01-24
// 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cloudscribe.Messaging.Sms
{
    public class TwilioSmsCredentials
    {
        public string AccountSid { get; set; } = string.Empty;

        public string AuthToken { get; set; } = string.Empty;

        public string FromNumber { get;set;}

        public string SmsEndpointUrlFormat { get; set; } = "https://api.twilio.com/2010-04-01/Accounts/{0}/SMS/Messages";

    }
}
