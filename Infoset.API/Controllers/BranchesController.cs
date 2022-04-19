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
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetClosetBranches()
        {
            var _params = new BrancheParams { Distance = 1, CurrentLocation = new Location() { Latitude = 0, Longitude = 0 } };
            return HandleResult(await Mediator.Send(new NearMe.Query() { Params = _params }));
        }
    }
}
