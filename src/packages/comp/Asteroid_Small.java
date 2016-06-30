package packages.comp;

import packages.main.Operations;
import packages.stage.GameStage;

public class Asteroid_Small extends Entity {

	public Asteroid_Small(double x, double y, int w, int h, double vX, double vY){
		super(x, y, w, h, "asteroid_default", vX, vY, 0, 0);
	}
	
	@Override
	public void act(GameStage stage){
		super.act(stage);
		
		for (int i = 0; i < stage.getPlayers().size(); i++){
			Ship_Default curShip = stage.getPlayers().get(i);
			if (Operations.pointDrawableCollision(posX, posY, curShip)){
				curShip.damage((int) (50 + 2000 * Math.pow(curShip.getVelX(), 2) + Math.pow(curShip.getVelY(), 2)));
				stage.getAsteroids().remove(this);
				break;
			}
		}
	}
}
