package packages.gfx;

import java.awt.Image;
import java.awt.Toolkit;
import java.net.URL;

public class ImageFinder {

	private ImageFinder(){}
	
	public static Image getImage(String s){
		Image tempImage = null;
		try {
			URL imageURL = ImageFinder.class.getResource(s + ".png");
			tempImage = Toolkit.getDefaultToolkit().getImage(imageURL);
		} catch (Exception e){
			System.out.println("Image not found");
		}
		return tempImage;
	}
	
}
