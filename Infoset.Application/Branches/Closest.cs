using Infoset.Application.Core;
using Infoset.Domain;
using Infoset.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MySqlConnector;

namespace Infoset.Application.Branches
{
    public class Closest
    {
        public class Query : IRequest<Result<List<Branche>>>
        {
            public BrancheParams Params { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<List<Branche>>>
        {
            private readonly DataContext _context;
            private readonly ILogger<Closest> logger;
            public Handler(DataContext context, ILogger<Closest> logger)
            {
                _context = context;
                this.logger = logger;
            }

            public async Task<Result<List<Branche>>> Handle(Query request, CancellationToken cancellationToken)
            {
                List<Branche> branchesNearMe = new List<Branche>();
                var currentLocation = request.Params.CurrentLocation;
                var p = Math.PI / 180;///0.0174532925199433;
                var sqlQuery = @"
                            select * 
                            from Branches as b 
                            where (12742 * ASIN(SQRT(0.5 - COS((b.latitude - @latitude1) * @p) / 2 + COS(@latitude1 * @p) * COS(b.latitude * @p) * (1 - COS((b.longitude - @longitude1) * @p)) / 2))) < @maxDistance
                        ";
                branchesNearMe = await _context
                    .Branches
                    .FromSqlRaw(sqlQuery,
                    new MySqlParameter("@latitude1", currentLocation.Latitude),
                    new MySqlParameter("@longitude1", currentLocation.Longitude),
                    new MySqlParameter("@maxDistance", request.Params.MaxDistance),
                    new MySqlParameter("@p", p)
                    ).Take(request.Params.Count)
                    .ToListAsync();
                //var branches = await _context.Branches.ToListAsync();
                //foreach (var branch in branches)
                //{
                //    var temp= new Location { Latitude = branch.Latitude, Longitude = branch.Longitude };
                //    //logger.LogInformation($"Distance is {Distance(currentLocation, temp)}");
                //    if (CalculateDistance(currentLocation, temp) <= request.Params.MaxDistance)
                //    {
                //        branchesNearMe.Add(branch);
                //        if (branchesNearMe.Count >= request.Params.Count)
                //            break;
                //    }
                //}
                return Result<List<Branche>>.Success(branchesNearMe);
            }
        }
        public static double CalculateDistance(Location location1, Location location2)
        {
            var p = Math.PI/180;///0.0174532925199433;
            /*  
             *  Haversine formula
             *  https://en.wikipedia.org/wiki/Haversine_formula
            */
            var hav = 0.5 - Math.Cos((location2.Latitude - location1.Latitude) * p) / 2 + Math.Cos(location1.Latitude * p) * Math.Cos(location2.Latitude * p) * (1 - Math.Cos((location2.Longitude - location1.Longitude) * p)) / 2;
            return 12742 * Math.Asin(Math.Sqrt(hav));
        }
    }
}
