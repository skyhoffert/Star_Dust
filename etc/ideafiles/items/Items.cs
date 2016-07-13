using UnityEngine.UI;
namespace ItemNamespace {
	// this class demonstrates the framework other items should use
	abstract class Item {
		// these fields need to be set
		public Image = null;
		public float cost = 0;
		public float sell = 0;
		public float healthFlat = 0;
		public float powerFlat = 0;
		public float healthPercentage = 0;
		public float powerPercentage = 0;

		protected GenericItem();

		// applies effect to specified ship
		// on purchase
		public void OnPurchase(StarShip starship, Ship ship){
			starship.TakeResources(cost);
			ship.AddHealthFromItem(healthFlat);
			ship.AddHealthPercentageFromItem(healthPercentage);
			ship.AddPowerFromItem(powerFlat);
			ship.AddPowerPercentageFromItem(powerPercentage);
		}
		public void OnSell(StarShip starship, Ship ship){
			starship.AddResources(sell);
			ship.RemoveHealthFromItem(healthFlat);
			ship.RemoveHealthPercentageFromItem(healthPercentage);
			ship.RemovePowerFromItem(powerFlat);
			ship.RemovePowerPercentageFromItem(powerPercentage);
		}
		// other methods could be used, such as
		// this could be run every frame, if it needs to check something
		// public abstract void OnUpdate(Ship ship);
	}

	class ExtraBattery : Item {

		public ExtraBattery() : base() {
			cost = 100;
			sell = 50;
			// adds 
			powerFlat = 100;
		}

	
	}
}
