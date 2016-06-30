package packages.abilities;

import packages.comp.Laser_Default;
import packages.comp.Ship_Default;
import packages.stage.GameStage;

public class Ability_Laser_Burst_Shot extends Ability{

	// variables
	private int lasers_to_be_added, time_between_lasers, max_lasers;
	private long time_last_laser_used;
	private double speed_modifier;
	
	public Ability_Laser_Burst_Shot(){
		super("ability_laser_burst_shot", 10000);
		this.lasers_to_be_added = 0;
		this.time_between_lasers = 150;
		this.max_lasers = 5;
		this.speed_modifier = 1.5;
		this.time_last_laser_used = System.currentTimeMillis();
	}

	@Override
	protected void interact(GameStage stage, Ship_Default ship) {
		// if it was just activated
		if (hasBeenActivated){
			lasers_to_be_added = max_lasers;
		}
		
		// if any should be used
		if (lasers_to_be_added > 0){
			if (System.currentTimeMillis() - time_last_laser_used > time_between_lasers){
				lasers_to_be_added--;
				time_last_laser_used = System.currentTimeMillis();
				stage.addLaser(new Laser_Default(ship.getX(), ship.getY(), Math.cos(ship.getAngle()) * speed_modifier, Math.sin(ship.getAngle()) * speed_modifier));
			}
		}
	}
	
	
	
}
