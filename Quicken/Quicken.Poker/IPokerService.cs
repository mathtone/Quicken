using System.Collections.Generic;
using System.Linq;

namespace Quicken.Poker {

	public interface IPokerService {
		IEnumerable<HandResult> Evaluate(params PlayerHand[] hands);
	}
}