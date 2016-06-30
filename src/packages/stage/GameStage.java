package packages.stage;

import java.awt.Graphics2D;
import java.awt.event.KeyEvent;
import java.util.ArrayList;

import packages.comp.Asteroid_Small;
import packages.comp.Laser_Default;
import packages.comp.Ship_Default;
import packages.main.Main;

public class GameStage extends Stage{

	protected ArrayList<Ship_Default> players;
	protected ArrayList<Asteroid_Small> asteroids;
	protected ArrayList<Laser_Default> lasers;
	public boolean isLMB;
	public boolean isRMB;
	public int mouseX, mouseY;
	
	public GameStage(String s){
		super(s);
		this.players = new ArrayList<Ship_Default>();
		this.asteroids = new ArrayList<Asteroid_Small>();
		this.lasers = new ArrayList<Laser_Default>();
		this.isLMB = false;
		this.isRMB = false;
	}

	@Override
	public void act() {
		for (int i = 0; i < players.size(); i++){
			players.get(i).act(this);
		}
		for (int i = 0; i < asteroids.size(); i++){
			asteroids.get(i).act(this);
		}
		for (int i = 0; i < lasers.size(); i++){
			lasers.get(i).act(this);
		}
	}
	
	// getters
	public int getMouseX(){ return mouseX; }
	public int getMouseY(){ return mouseY; }
	public ArrayList<Asteroid_Small> getAsteroids(){ return asteroids; }
	public ArrayList<Laser_Default> getLasers(){ return lasers; }
	public ArrayList<Ship_Default> getPlayers(){ return players; }
	
	// add laser to list
	public void addLaser(Laser_Default newLaser){
		lasers.add(newLaser);
	}
	
	@Override
	public void keyUp(int i) {
		if (i == KeyEvent.VK_ESCAPE){
			// quit the game
			Main.stop();
		} else if (i == KeyEvent.VK_F1){
			// reset to menu
			Main.setStage(new MainMenu());
		}
	}

	@Override
	public void LMBDown(int x, int y) {
		isLMB = true;
	}

	@Override
	public void LMBUp(int x, int y) {
		isLMB = false;
	}

	@Override
	public void RMBDown(int x, int y) {
		isRMB = true;
	}

	@Override
	public void RMBUp(int x, int y) {
		isRMB = false;
	}

	@Override
	public void mouseAt(int x, int y) {
		this.mouseX = x;
		this.mouseY = y;
	}

	@Override
	public void scrollWheelAt(int x) {
		// TODO Auto-generated method stub
	}

	@Override
	public void keyDown(int i) {
		// TODO Auto-generated method stub
		
	}
	
	public void draw(Graphics2D g){
		for (int i = 0; i < players.size(); i++){
			players.get(i).draw(g);
		}
		for (int i = 0; i < asteroids.size(); i++){
			asteroids.get(i).draw(g);
		}
		for (int i = 0; i < lasers.size(); i++){
			lasers.get(i).draw(g);
		}
	}
	
}
