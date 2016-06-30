package packages.abilities;

import packages.comp.Ship_Default;
import packages.stage.GameStage;

public abstract class Ability
{
	protected String name;
	// all cooldowns are in microseconds
	protected int cooldown_max;
	protected long time_last_used;
	protected boolean hasBeenActivated;
	
	public Ability(String s, int cd){
		this.name = s;
		this.cooldown_max = cd;
		this.time_last_used = 0;
		this.hasBeenActivated = false;
	}
	
	// this is called whenever abiliity is used
	public void act(GameStage stage, Ship_Default ship){
		// call the private function, so it must be overridden
		// if it was active for one loop, it will go through "interact"
		interact(stage, ship);
		
		// always set to false
		hasBeenActivated = false;		
	}
	
	// actually activate the ability
	public void activate(){
		hasBeenActivated = true;
		time_last_used = System.currentTimeMillis();
	}
	
	// this will do the core of the stuff
	protected abstract void interact(GameStage stage, Ship_Default ship);
	
	// if it is ready to be used
	public boolean isReady(){ return System.currentTimeMillis() - time_last_used > cooldown_max; }
	public int getCooldownMax(){ return cooldown_max; }

}
