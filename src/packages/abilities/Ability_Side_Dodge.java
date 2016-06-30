package packages.abilities;

import packages.comp.Ship_Default;
import packages.stage.GameStage;

public class Ability_Side_Dodge extends Ability{
	
	public Ability_Side_Dodge(){
		super("abil_side_dodge", 1000);
	}

	@Override
	protected void interact(GameStage stage, Ship_Default ship) {
		if (hasBeenActivated){
			ship.addVel(Math.sin(ship.getAngle() + 90) / 2, Math.cos(ship.getAngle()) / 2);
		}
	}

}
