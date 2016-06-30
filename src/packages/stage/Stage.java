package packages.stage;

import java.awt.Graphics2D;

import packages.comp.Drawable;
import packages.main.Main;

public abstract class Stage {
	
	//Variables
	private Drawable background;
	
	//constructor
	public Stage(String s){
		background = new Drawable(Main.width / 2, Main.height / 2, Main.width, Main.height, s);
	}
	
	//for all actions!!
	public abstract void act();
	
	//for things on the mouse
	public abstract void LMBDown(int x, int y);
	public abstract void LMBUp(int x, int y);
	public abstract void RMBDown(int x, int y);
	public abstract void RMBUp(int x, int y);
	public abstract void mouseAt(int x, int y);
	public abstract void scrollWheelAt(int x);
	//for when a key is released
	public abstract void keyUp(int i);
	public abstract void keyDown(int i);
	
	//draw shtuff
	public void draw(Graphics2D g){
		background.draw(g);
	}

}
