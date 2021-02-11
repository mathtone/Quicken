using System.Collections.Generic;
using System.Linq;
using static Quicken.Poker.Rank;
using static Quicken.Poker.Suit;

namespace Quicken.Poker {
	public struct PlayingCard {

		public Rank Rank { get; private set; }
		public Suit Suit { get; private set; }

		public PlayingCard(Rank rank,Suit suit) : this() {
			this.Rank = rank;
			this.Suit = suit;
		}

		public PlayingCard(string code) {
			this.Rank = CharToRank[code[0]];
			this.Suit = code.Length >= 2 ?
				CharToSuit[code[1]] :
				Suit.Unknown;
		}

		public override string ToString() => new string(new[] {
			RankToChar[Rank],
			SuitToChar[Suit]});

		public override bool Equals(object obj) =>
			(obj is PlayingCard crd) &&
				this.Rank == crd.Rank &&
				this.Suit == crd.Suit;

		public override int GetHashCode() => this.ToString().GetHashCode();

		public static readonly PlayingCard Unknown = new PlayingCard(Rank.Unknown,Suit.Unknown);

		public static IEnumerable<PlayingCard> FromString(string cards,char delimiter = ',') =>
			cards.Split(delimiter).Select(c => new PlayingCard(c));

		static readonly Dictionary<char,Rank> CharToRank = new Dictionary<char,Rank> {
			{'A',Ace }, {'2',Two }, {'3',Three},
			{'4',Four}, {'5',Five}, {'6',Six },
			{'7',Seven}, {'8',Eight}, {'9',Nine},
			{'T',Ten }, {'J',Jack}, {'Q',Queen},
			{'K',King}, {'*',Rank.Unknown},
		};

		static readonly Dictionary<Rank,char> RankToChar = new Dictionary<Rank,char> {
			{Ace,'A' }, {Two,'2' }, {Three,'3'},
			{Four,'4'}, {Five,'5'}, {Six ,'6'},
			{Seven,'7'}, {Eight,'8'}, {Nine,'9'},
			{Ten,'T'}, {Jack,'J'}, {Queen,'Q'},
			{King,'K'}, {Rank.Unknown,'*'}
		};

		static readonly Dictionary<char,Suit> CharToSuit = new Dictionary<char,Suit> {
			{'C',Clubs }, {'D',Diamonds }, {'H',Hearts}, {'S',Spades }, {'*',Suit.Unknown}
		};

		static readonly Dictionary<Suit,char> SuitToChar = new Dictionary<Suit,char> {
			{Clubs,'C'}, {Diamonds,'D'}, {Hearts,'H'}, {Spades,'S'}, {Suit.Unknown,'*'}
		};
	}
}