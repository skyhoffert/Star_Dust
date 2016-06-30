package packages.comp;

import java.awt.Graphics2D;
import packages.stage.GameStage;

public class Ship_Default extends Entity{

	// variables
	protected int health, maxHealth;
	
	public Ship_Default(double x, double y){
		super(x, y, 32, 32, "player_default", 0, 0, 0, 0);
		this.maxHealth = 1000;
		this.health = this.maxHealth;
	}
	
	@Override
	public void act(GameStage stage)
	{
		// if health is below 0 ... DIE
		if (health < 0){
			stage.getPlayers().remove(this);
		}
		
		// use the super act
		super.act(stage);
	}
	
	// adds to acceleration
	public void accelerate(double aX, double aY){
		accelX += aX;
		accelY += aY;
	}
	
	public void addVel(double vX, double vY){
		velX += vX;
		velY += vY;
	}
	
	// do damage to THIS ship
	public void damage(int d){
		// will incorporate armor and stuff eventually
		System.out.println("damage: " + d);
		health -= d;
		System.out.println(health);
	}
	
	public void draw(Graphics2D g){
		super.draw(g);
		// TODO - debug
		// should be removed eventually
		g.drawLine((int) posX, (int) posY, (int)(posX + Math.cos(angle)*100), (int)(posY + Math.sin(angle)*100));
	}
	
}
