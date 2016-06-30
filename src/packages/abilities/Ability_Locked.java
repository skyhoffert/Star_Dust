package packages.abilities;

import packages.comp.Ship_Default;
import packages.stage.GameStage;

public class Ability_Locked extends Ability{
	
	public Ability_Locked(){
		super("ability_locked", Integer.MAX_VALUE);
	}

	@Override
	protected void interact(GameStage stage, Ship_Default ship) {
		// TODO Auto-generated method stub
		// do nothing
	}

}
