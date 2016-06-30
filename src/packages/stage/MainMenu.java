package packages.stage;

import java.awt.Graphics2D;

import packages.comp.Clickable;
import packages.main.Main;
import packages.main.Operations;

public class MainMenu extends Stage {

	// variables for clicking, etc
	private Clickable buttonPlay;
	
	public MainMenu(){
		super("MainMenuBackground");
		//create buttons
		this.buttonPlay = new Clickable(Main.width / 2, Main.height / 2, Main.width / 4, Main.height / 4, "MainMenuPlayButton");
	}
	
	// actions baybay
	public void act(){
		
	}
	
	// lastly is always drawing
	public void draw(Graphics2D g){
		super.draw(g);
		// draw the buttons after background
		buttonPlay.draw(g);
	}

	@Override
	public void LMBDown(int x, int y) {
		// TODO Auto-generated method stub
		
	}

	@Override
	public void LMBUp(int x, int y) {
		// TODO Auto-generated method stub
		if (Operations.pointDrawableCollision(x, y, buttonPlay)){
			Main.setStage(new TestLevel());
		}
	}

	@Override
	public void RMBDown(int x, int y) {
		// TODO Auto-generated method stub
		
	}

	@Override
	public void RMBUp(int x, int y) {
		// TODO Auto-generated method stub
		
	}

	@Override
	public void mouseAt(int x, int y) {
		// TODO Auto-generated method stub
		
	}

	@Override
	public void scrollWheelAt(int x) {
		// TODO Auto-generated method stub
		
	}

	@Override
	public void keyUp(int i) {
		// TODO Auto-generated method stub
		
	}

	@Override
	public void keyDown(int i) {
		// TODO Auto-generated method stub
		
	}
	
}
