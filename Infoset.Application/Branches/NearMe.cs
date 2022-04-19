using Infoset.Application.Core;
using Infoset.Domain;
using Infoset.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infoset.Application.Branches
{
    public class NearMe
    {
        public class Query : IRequest<Result<List<Branche>>>
        {
            public BrancheParams Params { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<List<Branche>>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<List<Branche>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var currentLocation = request.Params.CurrentLocation;
                var branches = await _context.Branches.ToListAsync();
                branches = branches.Where(p => Distance(currentLocation, new Location { Latitude = p.Latitude, Longitude = p.Longitude }) > request.Params.Distance).ToList();
                return Result<List<Branche>>.Success(branches);
            }
        }
        public static double Distance(Location location1, Location location2)
        {
            var p = Math.PI/180;///0.0174532925199433;
            //Haversine formula
            var hav = 0.5 - Math.Cos((location2.Latitude - location1.Latitude) * p) / 2 + Math.Cos(location1.Latitude * p) * Math.Cos(location2.Latitude * p) * (1 - Math.Cos((location2.Longitude - location1.Longitude) * p)) / 2;
            return 12742 * Math.Asin(Math.Sqrt(hav));
        }
    }
}
