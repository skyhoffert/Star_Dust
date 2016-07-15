using UnityEngine;

namespace Items {

	// this class demonstrates the framework other items should use
	public abstract class Item {
		public static int NUM_ITEMS = 2;

		// these fields need to be set
		public Sprite image = null;
		public float cost = 0;
		public float sell = 0;
		public float healthFlat = 0;
		public float healthPercentage = 0;
		public float powerFlat = 0;
		public float powerPercentage = 0;
		// adds to ship's shield modifier
		public float shieldModifier = 0;
		public float accelFlat = 0;

		protected Item() { }

		protected Item(Item copyItem) {
			image = copyItem.image;
			cost = copyItem.cost;
			sell = copyItem.sell;
			healthFlat = copyItem.healthFlat;
			healthPercentage = copyItem.healthPercentage;
			powerFlat = copyItem.powerFlat;
			powerPercentage = copyItem.powerPercentage;
			shieldModifier = copyItem.shieldModifier;
			accelFlat = copyItem.accelFlat;
		}
	}
	// adds more power
	public class ExtraBattery : Item {
		public ExtraBattery() {
			image = Resources.Load<Sprite>("ExtraBatteryIcon.png");
			cost = 100;
			sell = 50;
			powerFlat = 100;
		}
	}
	// adds health
	public class ArmorPiece : Item {
		public ArmorPiece() : base() {
			image = Resources.Load<Sprite>("ArmorPieceIcon.png");
			cost = 75;
			sell = 40;
			shieldModifier = .05f;
		}
	}
}