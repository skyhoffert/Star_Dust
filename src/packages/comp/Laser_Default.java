package packages.comp;

import packages.main.Operations;
import packages.stage.GameStage;

public class Laser_Default extends Entity{

	public Laser_Default(double x, double y, double vX, double vY){
		super(x, y, 10, 20, "laser_default", vX, vY, 0, 0);
		this.angle = Math.atan(vY / vX);
	}
	
	@Override
	public void act(GameStage stage){
		super.act(stage);
		
		for (int i = 0; i < stage.getAsteroids().size(); i++){
			if (Operations.pointDrawableCollision(posX, posY, stage.getAsteroids().get(i))){
				stage.getAsteroids().remove(i);
				stage.getLasers().remove(this);
				break;
			}
		}
	}
	
}
