﻿using Data.Repositories.Common;
using Libs.Models;
using Libs.Repositories;

namespace Data.Repositories
{
    internal class TlsExportedAuthenticatorRepository : RepositoryBase<TlsExportedAuthenticator>, ITlsExportedAuthenticatorRepository
    {
        public TlsExportedAuthenticatorRepository(ApplicationContext repositoryContext) : base(repositoryContext) {}
    }
}