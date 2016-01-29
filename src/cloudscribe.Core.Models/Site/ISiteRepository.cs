﻿// Copyright (c) Source Tree Solutions, LLC. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
// Author:					Joe Audette
// Created:					2014-08-16
// Last Modified:			2015-12-28
// 

// TODO: we should update all the async signatures to take a cancellationtoken

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace cloudscribe.Core.Models
{
    public interface ISiteRepository : IDisposable
    {
        ISiteSettings FetchNonAsync(int siteId);
        ISiteSettings FetchNonAsync(Guid siteGuid);
        ISiteSettings FetchNonAsync(string hostName);

        Task<ISiteSettings> Fetch(int siteId, CancellationToken cancellationToken);
        Task<ISiteSettings> Fetch(Guid siteGuid, CancellationToken cancellationToken);
        Task<ISiteSettings> Fetch(string hostName, CancellationToken cancellationToken);
        
        Task<int> GetCount(CancellationToken cancellationToken);
        Task<int> CountOtherSites(int currentSiteId, CancellationToken cancellationToken);
        Task<List<ISiteInfo>> GetList(CancellationToken cancellationToken);
        Task<List<ISiteInfo>> GetPageOtherSites(
            int currentSiteId,
            int pageNumber,
            int pageSize,
            CancellationToken cancellationToken);

        Task<bool> Save(ISiteSettings site, CancellationToken cancellationToken);
        Task<bool> Delete(int siteId, CancellationToken cancellationToken);

        Task<List<ISiteHost>> GetSiteHosts(int siteId, CancellationToken cancellationToken);
        Task<List<ISiteHost>> GetAllHosts(CancellationToken cancellationToken);
        Task<ISiteHost> GetSiteHost(string hostName, CancellationToken cancellationToken);
        Task<int> GetHostCount(CancellationToken cancellationToken);
        Task<List<ISiteHost>> GetPageHosts(
            int pageNumber,
            int pageSize,
            CancellationToken cancellationToken);
        Task<bool> AddHost(Guid siteGuid, int siteId, string hostName, CancellationToken cancellationToken);
        Task<bool> DeleteHost(int hostId, CancellationToken cancellationToken);
        Task<bool> DeleteHostsBySite(int siteId, CancellationToken cancellationToken);
        Task<int> GetSiteIdByHostName(string hostName, CancellationToken cancellationToken);
        
        Task<List<ISiteFolder>> GetSiteFoldersBySite(Guid siteGuid, CancellationToken cancellationToken);
        Task<List<ISiteFolder>> GetAllSiteFolders(CancellationToken cancellationToken);
        Task<int> GetFolderCount(CancellationToken cancellationToken);
        Task<ISiteFolder> GetSiteFolder(string folderName, CancellationToken cancellationToken);
        Task<List<ISiteFolder>> GetPageSiteFolders(
            int pageNumber,
            int pageSize,
            CancellationToken cancellationToken);
        Task<bool> Save(ISiteFolder siteFolder, CancellationToken cancellationToken);
        Task<bool> DeleteFolder(Guid guid, CancellationToken cancellationToken);
        Task<bool> DeleteFoldersBySite(Guid siteGuid, CancellationToken cancellationToken);
        Task<int> GetSiteIdByFolder(string folderName, CancellationToken cancellationToken);
        Task<Guid> GetSiteGuidByFolder(string folderName, CancellationToken cancellationToken);
        Task<bool> FolderExists(string folderName, CancellationToken cancellationToken);

        List<ISiteHost> GetAllHostsNonAsync();
        List<ISiteFolder> GetAllSiteFoldersNonAsync();
        int GetSiteIdByFolderNonAsync(string folderName);

    }
}
