﻿using Data.Repositories.Common;
using Libs.Models;
using Libs.Repositories;

namespace Data.Repositories
{
    internal class TlsClientAuthRepository : RepositoryBase<TlsClientAuth>, ITlsClientAuthRepository
    {
        public TlsClientAuthRepository(ApplicationContext repositoryContext) : base(repositoryContext) {}
    }
}