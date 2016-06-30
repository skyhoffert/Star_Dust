package packages.main;

import packages.comp.Drawable;

public class Operations {

	private Operations(){}
	
	public static boolean pointDrawableCollision(double x, double y, Drawable d){
		if (x >= d.getX() - d.getWidth()/2){
			if (x <= d.getX() + d.getWidth()/2){
				if (y >= d.getY() - d.getHeight()/2){
					if (y <= d.getY() + d.getHeight()/2){
						return true;
					}
				}
			}
		}
		return false;
	}
	
	public static double findDistance(int x, int y, int xx, int yy){
		return Math.sqrt(Math.pow((xx - x), 2) + Math.pow((yy - y), 2));
	}

	public static double findDistance(double x, double y, double xx, double yy){
		return Math.sqrt(Math.pow((xx - x), 2) + Math.pow((yy - y), 2));
	}
	
	public static double findHypotenuse(double x, double y){
		return x / Math.cos(Math.atan(y / x)) * Math.signum(x);
	}
}