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
        public async Task<IActionResult> GetClosetBranches()
        {
            //40.982468121810626, 28.872966419154096
            var _params = new BrancheParams { Distance = 10, CurrentLocation = new Location() { Latitude = 40.982468121810626, Longitude = 28.872966419154096 } };
            return HandleResult(await Mediator.Send(new Closest.Query() { Params = _params }));
        }
    }
}
