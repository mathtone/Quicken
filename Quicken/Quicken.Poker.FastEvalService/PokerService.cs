using System;
using System.Collections.Generic;
using System.Linq;
using static Quicken.Poker.FastEvalService.Properties.Settings;

namespace Quicken.Poker.FastEvalService {
	public class PokerService : IPokerService {

		public IEnumerable<HandResult> Evaluate(params PlayerHand[] hands) {

			var eval = hands.Select(
				h => new {
					Hand = h,
					Value = FastHandEvaluator.Evaluate(h.Cards.Select(c => new PlayingCard(c)))
				}
			).ToArray();

			var min = eval.Min(e => e.Value);
			return eval.Select(e => new HandResult {
				Hand = e.Hand,
				IsWinner = e.Value == min,
				Class = Describe(e.Value)
			});
		}

		protected static HandClassDescription Describe(ushort value) {
			var v = FastHandEvaluator.GetHandClass(value);
			var rtn = new HandClassDescription {
				Value = v,
				Description = Descriptions[v]
			};
			return rtn;
		}

		protected static Dictionary<HandClass,string> Descriptions = new Dictionary<HandClass,string> {
			{HandClass.HighCard,HandClass_HighCard },
			{HandClass.OnePair,HandClass_OnePair},
			{HandClass.TwoPair,HandClass_TwoPair },
			{HandClass.Trips,HandClass_Trips },
			{HandClass.Straight,HandClass_Straight },
			{HandClass.Flush,HandClass_Flush },
			{HandClass.FullHouse,HandClass_FullHouse },
			{HandClass.Quads,HandClass_Quads },
			{HandClass.StraightFlush,HandClass_StraightFlush }
		};
	}
}