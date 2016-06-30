package packages.comp;

import java.awt.Graphics2D;
import java.awt.Image;
import java.awt.geom.AffineTransform;

import packages.gfx.ImageFinder;
import packages.main.Main;

public class Drawable {

	// variables
	protected double posX, posY;
	protected int width, height;
	// in radians
	protected double angle;
	protected Image img;
	protected String name;
	// for a flipped image
	protected boolean isFlipped;
	
	public Drawable(double x, double y, int w, int h, String s){
		// everyting is scaled by the scale ** Important
		this.posX = x ;
		this.posY = y;
		this.width = (int) (w * Main.scale);
		this.height = (int) (h * Main.scale);
		this.name = s;
		this.angle = 0;
		this.img = ImageFinder.getImage(s);
		this.isFlipped = false;
	}
	
	// getters
	public double getX(){ return posX; }
	public double getY(){ return posY; }
	public double getAngle(){ return angle; }
	public double getWidth(){ return width; }
	public double getHeight(){ return height; }
	public String getName(){ return name; }
	
	// mutator
	public void move(double x, double y){ this.posX = posX + x; this.posY = posY + y; }
	public void moveTo(double x, double y){ this.posX = x; this.posY = y; }
	public void flip(){ isFlipped = !isFlipped; }
	public void setWidth(int i){ width = i; }
	public void setAngle(double d){ angle = d; }
	
	private void draw_withflipcontrol(Graphics2D g){
		if (!isFlipped){
			// left to right
			g.drawImage(img, (int) (posX - width/2), (int) (posY - height/2), (int) width, (int) height, null);
		} else {
			// right to left
			g.drawImage(img, (int) (posX + width/2), (int) (posY - height/2), (int) -width, (int) height, null);
		}
	}
	
	// drawing
	public void draw(Graphics2D g){
		if (angle != 0){
			if (Math.abs(angle) > 2 * Math.PI){
				angle -= 2 * Math.PI * Math.signum(angle);
			}
			AffineTransform old = g.getTransform();
			g.rotate(angle, posX, posY);
			
			draw_withflipcontrol(g);
			
			g.setTransform(old);
		} else {
			draw_withflipcontrol(g);
		}
	}
}
