using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Quicken.Poker.REST.Controllers {

	[ApiController]
	[Route("[controller]/[action]")]
	public class PokerServiceController : ControllerBase, IPokerService {

		protected IPokerService PokerService { get; }

		//Service implementation gets injected via DI
		public PokerServiceController(IPokerService service) {
			this.PokerService = service;
		}

		//Should really be GET but this will be easier to test...
		[HttpPost]
		public IEnumerable<HandResult> Evaluate(PlayerHand[] hands) => PokerService.Evaluate(hands);
	}
}