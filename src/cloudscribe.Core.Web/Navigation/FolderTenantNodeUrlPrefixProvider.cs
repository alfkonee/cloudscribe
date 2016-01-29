﻿// Copyright (c) Source Tree Solutions, LLC. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
// Author:					Joe Audette
// Created:					2015-08-02
// Last Modified:			2015-11-18
// 

using cloudscribe.Core.Identity;
using cloudscribe.Core.Models;
using cloudscribe.Web.Navigation;
using Microsoft.Extensions.OptionsModel;

namespace cloudscribe.Core.Web.Navigation
{
    public class FolderTenantNodeUrlPrefixProvider : INodeUrlPrefixProvider
    {
        public FolderTenantNodeUrlPrefixProvider(
            ISiteResolver siteResolver,
            IOptions<MultiTenantOptions> multiTenantOptions)
        {
            this.siteResolver = siteResolver;
            options = multiTenantOptions.Value;
        }

        private ISiteResolver siteResolver;
        private MultiTenantOptions options;

        public string GetPrefix()
        {
            if(options.Mode == MultiTenantMode.FolderName)
            {
                ISiteSettings site = siteResolver.Resolve();
                if((site != null)&&(site.SiteFolderName.Length > 0))
                {
                    return site.SiteFolderName;
                }
            }

            return string.Empty;
        }

    }
}
