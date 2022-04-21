using Infoset.Application.Branches;
using Infoset.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Infoset.API.Controllers
{
    public class BranchesController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetBranches(CancellationToken cancellationToken)
        {

            return HandleResult(await Mediator.Send(new List.Query(), cancellationToken));
        }
        [HttpGet("Closest")]
        public async Task<IActionResult> GetClosetBranches(double latitude , double longitude, int maxDistance = 10)
        {
            //40.982468121810626, 28.872966419154096
            var _params = new BrancheParams { MaxDistance = maxDistance, CurrentLocation = new Location() { Latitude = latitude, Longitude = longitude } };
            return HandleResult(await Mediator.Send(new Closest.Query() { Params = _params }));
        }
    }
}
