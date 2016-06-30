package packages.main;

import java.awt.Color;
import java.awt.Graphics;
import java.awt.Graphics2D;

import javax.swing.JPanel;

@SuppressWarnings("serial")
public class Panel extends JPanel{

	public Panel(Color bg){ setBackground(bg); }
	
	public void drawing(){ repaint(); }
	
	@Override
	public void paintComponent(Graphics g){
		super.paintComponent(g);
		Graphics2D g2d = (Graphics2D) g;
		
		Main.draw(g2d);
	}	
}
