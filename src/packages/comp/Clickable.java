package packages.comp;

import java.awt.Color;
import java.awt.Font;
import java.awt.Graphics2D;

import packages.main.Operations;

public class Clickable extends Drawable{

	//vars
	private String text;
	private Color textColor;
	private boolean hasText;
	
	public Clickable(int x, int y, int w, int h, String s){
		super(x, y, w, h, s);
		this.hasText = false;
	}
	
	//add a text to a button or something else
	public void addText(String s, Color c){
		text = s;
		textColor = c;
	}
	
	//check if it ollides with a point
	//useful for mouse clicking
	public boolean collidesWith(int x, int y){
		return Operations.pointDrawableCollision(x, y, this);
	}
	
	//draw with some extra stuff
	public void draw(Graphics2D g){
		super.draw(g);
		if (hasText){
			g.setColor(textColor);
			g.setFont(new Font("Arial", Font.BOLD, (int) (height * 3 / 4)));
			g.drawString(text, (int) (posX - width * 3 / 8), (int) (posY - height * 3 / 8));
		}
	}
}