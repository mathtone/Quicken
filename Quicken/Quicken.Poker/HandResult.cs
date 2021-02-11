namespace Quicken.Poker {
	public class HandResult {
		public PlayerHand Hand { get; set; }
		public bool IsWinner { get; set; }

		public HandClassDescription Class { get; set; }
	}
}