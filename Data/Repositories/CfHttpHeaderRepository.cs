﻿using Data.Repositories.Common;
using Libs.Models;
using Libs.Repositories;

namespace Data.Repositories
{
    internal class CfHttpHeaderRepository : RepositoryBase<CfHttpHeader>, ICfHttpHeaderRepository
    {
        public CfHttpHeaderRepository(ApplicationContext repositoryContext) : base(repositoryContext) {}
    }
}