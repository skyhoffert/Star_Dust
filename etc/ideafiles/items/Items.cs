using UnityEngine.UI;
namespace ItemNamespace {
	// this class demonstrates the framework other items should use
	abstract class Item {
		// these fields need to be set
		public Image = null;
		public float cost = 0;
		public float sell = 0;
		public float healthFlat = 0;
		public float healthPercentage = 0;
		public float powerFlat = 0;
		public float powerPercentage = 0;
		public float accelFlat = 0;

		protected Item();
		public Item(Item copyItem){
			Image = copyItem.Image;
			cost = copyItem.cost;
			sell = copyItem.sell;
			healthFlat = copyItem.healthFlat;
			healthPercentage = copyItem.healthPercentage;
			powerFlat = copyItem.powerFlat;
			powerPercentage = copyItem.powerPercentage;
			accelFlat = copyItem.accelFlat;
		}
	}
	// adds more power
	class ExtraBattery : Item {
		public ExtraBattery() : base() {
			Image = Resources.Load("ExtraBatteryIcon.png");
			cost = 100;
			sell = 50;
			powerFlat = 100;
		}
	}
	// adds health
	class ArmorPiece : Item {
		public ArmorPiece() : base() {
			Image = Resources.Load("ArmorPieceIcon.png");
			cost = 75;
			sell = 40;	
			healthFlat = 80;
		}
	}
}
