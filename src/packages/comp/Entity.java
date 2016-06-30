package packages.comp;

import packages.stage.GameStage;

public class Entity extends Drawable{

	protected double velX, velY;
	protected double accelX, accelY;
	// spinning will go counter-clockwise
	protected float spinVel;
	protected double maxVel;
	
	public Entity(double x, double y, int w, int h, String s, double vX, double vY, double aX, double aY){
		super(x, y, w, h, s);
		this.velX = vX;
		this.velY = vY;
		this.accelX = aX;
		this.accelY = aY;
		this.spinVel = 0;
		this.maxVel = 9999;
	}
	
	public void act(GameStage stage){
		// move
		move(velX, velY);
		
		// accelerate
		velX += accelX;
		velY += accelY;
		
		// rotate
		angle += spinVel;
	}
	
	public double getVelX(){ return velX; }
	public double getVelY(){ return velY; }
	
}
