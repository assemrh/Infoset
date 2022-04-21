using Infoset.Application.Core;
using Infoset.Domain;
using Infoset.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infoset.Application.Branches
{
    public class List
    {
        public class Query : IRequest<Result<List<Branche>>> { }
        public class Handler : IRequestHandler<Query, Result<List<Branche>>>
        {
            private readonly DataContext _context;
            private readonly ILogger<List> logger;
            public Handler(DataContext context, ILogger<List> logger)
            {
                _context = context;
                this.logger = logger;
            }
            public async Task<Result<List<Branche>>> Handle(Query request, CancellationToken cancellationToken)
            {
                return Result<List<Branche>>.Success(await _context.Branches.ToListAsync(cancellationToken));
            }
        }
    }
}
