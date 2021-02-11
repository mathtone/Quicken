using System;
using System.Collections.Generic;
using System.Linq;
using static Quicken.Poker.Rank;
using static Quicken.Poker.Suit;

namespace Quicken.Poker.FastEvalService {

	public static class FastHandEvaluator {

		public static HandClass GetHandClass(ushort value) {
			if(value > 6185) return (HandClass.HighCard);  // 1277 high card
			if(value > 3325) return (HandClass.OnePair);   // 2860 one pair
			if(value > 2467) return (HandClass.TwoPair);   //  858 two pair
			if(value > 1609) return (HandClass.Trips);     //  858 three of a kind
			if(value > 1599) return (HandClass.Straight);  //   10 straight
			if(value > 322) return (HandClass.Flush);      // 1277 flushe
			if(value > 166) return (HandClass.FullHouse);  //  156 full house
			if(value > 10) return (HandClass.Quads);       //  156 four of a kind
			return (HandClass.StraightFlush);              //   10 straight-flushes
		}

		public static ushort Evaluate(IEnumerable<int> cards) {
			if(cards == null)
				throw new ArgumentException($"{nameof(cards)} is null");

			if(cards.Count() != 5)
				throw new InvalidOperationException("Hand must contain exactly 5 cards");

			var q = (uint)cards.Aggregate((x,y) => x | y) >> 16;

			//Flushes & Straight flushes
			if((cards.Aggregate((x,y) => x & y) & 0xF000) > 0) {
				return Lookups.Flushes[q];
			}

			//Straights & high-card hands
			var s = Lookups.NonPairedNonFlushes[q];

			if(s > 0)
				return s;

			//Ok fine you win, we do it the hard way...
			q = FindFast((uint)cards.Select(i => i & 0xFF).Aggregate((x,y) => x * y));

			return Lookups.HashValues[q];
		}


		public static ushort Evaluate(IEnumerable<PlayingCard> cards) => Evaluate(cards.Select(CardIndex));

		private static readonly Dictionary<Suit,int> SuitIndex = new Dictionary<Suit,int>() {
			{ Spades, 0x1000 }, { Hearts, 0x2000 }, { Diamonds, 0x4000 }, { Clubs, 0x8000 }
		};

		private static readonly Dictionary<Rank,int> RankIndex = new Dictionary<Rank,int>() {
			{ Two, 0 }, { Three, 1 }, { Four, 2 },
			{ Five, 3 }, { Six, 4 }, { Seven, 5 },
			{ Eight, 6 }, { Nine, 7 }, { Ten, 8 },
			{ Jack, 9 }, { Queen, 10 }, { King, 11 },
			{ Ace, 12 }
		};

		private static int CardIndex(PlayingCard card) {
			var rankIdx = RankIndex[card.Rank];
			var suitIdx = SuitIndex[card.Suit];
			return Lookups.Primes[rankIdx] | (rankIdx << 8) | suitIdx | (1 << (16 + rankIdx));
		}

		//This is the magical part.
		private static uint FindFast(uint u) {
			uint a, b, rtn;
			u += 0xe91aaa35;
			u ^= u >> 16;
			u += u << 8;
			u ^= u >> 4;
			b = (u >> 8) & 0x1ff;
			a = (u + (u << 2)) >> 19;
			rtn = a ^ Lookups.HashAdjust[b];
			return rtn;
		}
	}
}