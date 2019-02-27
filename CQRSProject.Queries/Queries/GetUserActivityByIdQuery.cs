using System;
using System.Collections.Generic;
using CQRSProject.Core.Entities;
using CQRSProject.Queries.Extensibility;

namespace CQRSProject.Queries.Queries
{
    public class GetUserActivityByIdQuery : IQuery<IEnumerable<UserActivity>>
    {
        public Guid UserId { get; }

        public GetUserActivityByIdQuery(Guid userId)
        {
            UserId = userId;
        }
    }
}