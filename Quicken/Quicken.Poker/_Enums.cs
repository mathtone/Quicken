using System.Text.Json.Serialization;

namespace Quicken.Poker {

	public enum HandClass : byte {
		StraightFlush = 1,
		Quads = 2,
		FullHouse = 3,
		Flush = 4,
		Straight = 5,
		Trips = 6,
		TwoPair = 7,
		OnePair = 8,
		HighCard = 9
	}

	public enum Rank : byte {
		Unknown, Ace, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King
	}

	public enum Suit : byte {
		Unknown, Clubs, Diamonds, Hearts, Spades
	}
}