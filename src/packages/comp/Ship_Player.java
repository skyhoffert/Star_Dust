package packages.comp;

import java.awt.event.KeyEvent;

import packages.abilities.*;
import packages.main.Main;
import packages.stage.GameStage;

public class Ship_Player extends Ship_Default
{
	protected int cooldown_standard_attack;
	protected long time_last_attack;
	protected Ability abil_Q, abil_W, abil_E, abil_R;
	
	public Ship_Player(double x, double y){
		super(x, y);
		this.cooldown_standard_attack = 1000;
		this.time_last_attack = 0;
		this.abil_Q = new Ability_Laser_Burst_Shot();
		this.abil_W = new Ability_Side_Dodge();
		this.abil_E = new Ability_Locked();
		this.abil_R = new Ability_Locked();
	}
	
	public void act(GameStage stage)
	{
		// temporary value for angle maths
		double val;
		// TODO
		// should probably be simplified
		if (Main.mouseX > posX){
			val = Math.atan((Main.mouseY - posY) / (Main.mouseX - posX));
			if (Math.abs(val - angle) > .01){
				spinVel = (float) (val - angle) / 50;
			} else {
				spinVel = 0;
			}
		} else {
			val = Math.atan((Main.mouseY - posY) / (Main.mouseX - posX));
			if (Math.abs(val - angle + Math.PI) > .01){
				spinVel = (float) (val - angle + Math.PI) / 50;
			} else {
				spinVel = 0;
			}
		}
		
		if (stage.isLMB){
			// attack
			// only happens when cooldown is ready
			if (cooldown_standard_attack <= System.currentTimeMillis() - time_last_attack){
				time_last_attack = System.currentTimeMillis();
				stage.addLaser(new Laser_Default(posX, posY, Math.cos(angle) * 2, Math.sin(angle) * 2));
			}
		}
		
		// abilities
		// Q
		if (Main.keys[KeyEvent.VK_Q]){
			if (abil_Q.isReady()){
				System.out.println("Q - ing");
				abil_Q.activate();
			}
		}
		abil_Q.act(stage, this);
		// W
		if (Main.keys[KeyEvent.VK_W]){
			if (abil_W.isReady()){
				System.out.println("W - ing");
				abil_W.activate();
			}
		}
		abil_W.act(stage, this);
		// E
		if (Main.keys[KeyEvent.VK_E]){
			if (abil_E.isReady()){
				System.out.println("E - ing");
				abil_E.activate();
			}
		}
		abil_E.act(stage, this);
		// R
		if (Main.keys[KeyEvent.VK_R]){
			if (abil_R.isReady()){
				System.out.println("R - ing");
				abil_R.activate();
			}
		}
		abil_R.act(stage, this);
		
		// movement
		if (stage.isRMB){
			accelX = Math.cos(angle) / 300;
			accelY = Math.sin(angle) / 300;
		}
		// if nothing is pressed stop accelerating
		if (!stage.isRMB){
			accelX = 0;
			accelY = 0;
		}
		
		super.act(stage);
	}
	
}
