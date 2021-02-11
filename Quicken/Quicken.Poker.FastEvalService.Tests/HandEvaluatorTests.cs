using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Quicken.Poker.FastEvalService.Tests {
	public class HandEvaluatorTests {
		[TestCase("2H,3H,4H,5H,7C",7462,HandClass.HighCard)]
		[TestCase("2H,3H,4H,5H,2C",6185,HandClass.OnePair)]
		[TestCase("2H,3H,5S,5H,2C",3292,HandClass.TwoPair)]
		[TestCase("2H,3H,5S,2S,2C",2466,HandClass.Trips)]
		[TestCase("3H,4H,5S,6S,7S",1607,HandClass.Straight)]
		[TestCase("2H,3H,4H,5H,7H",1599,HandClass.Flush)]
		[TestCase("2H,5C,2D,5H,2C",320,HandClass.FullHouse)]
		[TestCase("2H,2C,5D,5H,5C",286,HandClass.FullHouse)]
		[TestCase("2H,5S,5D,5H,5C",130,HandClass.Quads)]
		[TestCase("2H,3H,4H,5H,6H",9,HandClass.StraightFlush)]
		[TestCase("AH,TH,JH,QH,KH",1,HandClass.StraightFlush)]
		public void Evaluate_Hand(string cards,int rank,HandClass handClass) {
			Assert.AreEqual(rank,FastHandEvaluator.Evaluate(PlayingCard.FromString(cards)));
			Assert.AreEqual(handClass,FastHandEvaluator.GetHandClass(Convert.ToUInt16(rank)));
		}

		[Test]
		public void Evaluate_NullInput() =>
			Assert.Throws<ArgumentException>(() => FastHandEvaluator.Evaluate(default(IEnumerable<int>)));

		[TestCase("AH,TH,JH,QH")]
		[TestCase("AH,TH,JH,QH,7D,JS")]
		public void Evaluate_Not5Cards(string input) =>
			Assert.Throws<InvalidOperationException>(() => FastHandEvaluator.Evaluate(PlayingCard.FromString(input)));
	}
}