package packages.main;

import java.awt.Color;
import java.awt.Container;
import java.awt.Graphics2D;
import java.io.File;
import java.util.Scanner;

import javax.swing.JFrame;

import packages.stage.MainMenu;
import packages.stage.Stage;

public class Main implements Runnable {

	// frame and panel
	public static double scale;
	// wid x height
	public static int width;
	public static int height;
	public static final int SLEEP_TIME = 2;
	public static final String TITLE = "LoL In Space";
	private static JFrame frame;
	private static Panel panel;
	private static Container pane;
	private static InputHandler input;
	private static Scanner inStream;
	
	// global game variables
	public static int mouseX, mouseY;
	public static int mouseDownX, mouseDownY;
	public static int mouseUpX, mouseUpY;
	public static int volume;
	public static boolean isFocused;
	public static boolean isMouseDownRight, isMouseDownLeft;
	public static boolean[] keys;
		
	// privates
	private static Stage stage;
	private static boolean running;
	
	private Main(){
		//first the instream must grab the size of the window
		//try to open it
		try {
			File file = new File("settings.txt");
			inStream = new Scanner(file);

			//try reading in info
			try {
				//get settings
				inStream.next();
				width = inStream.nextInt();
				inStream.next();
				height = inStream.nextInt();
				inStream.next();
				scale = inStream.nextInt();
				
				//scale it
				width *= scale;
				height *= scale;
			} catch (Exception e){ e.printStackTrace(); }
			//close it
			inStream.close();
		} catch (Exception e) { e.printStackTrace(); }
		
		
		//init
		frame = new JFrame(TITLE);
		frame.setSize(width, height);
		frame.setUndecorated(true);
		frame.setLocationRelativeTo(null);
		panel = new Panel(Color.black);
		pane = frame.getContentPane();
		pane.add(panel);
		frame.setVisible(true);
		pane.setVisible(true);
		
		//adding input
		input = new InputHandler();
		frame.addKeyListener(input);
		panel.addMouseListener(input);
		panel.addMouseMotionListener(input);
		frame.addFocusListener(input);
		
		//init stuff
		System.out.println("Width: " +panel.getWidth());
		System.out.println("Height: " +panel.getHeight());
		
		volume = -8;
		running = true;
		stage = new MainMenu();
	}
	
	public static void main(String Args[]){
		new Main().start();
	}

	private synchronized void start(){
		new Thread(this).start();
	}
	
	public synchronized static void stop(){
		System.exit(0);
	}

	//our main funtion
	public void run() {
		// for frame rate etc
		long lastTime = System.nanoTime(), lastTimer = System.currentTimeMillis(), now;
		double nsPerTick = 1000000000.0 / 60.0, delta = 0;
		int frames = 0, ticks = 0;

		// Main Game Loop
		while (running) {
			// for fps purposes
			now = System.nanoTime();
			delta += (now - lastTime) / nsPerTick;
			lastTime = now;
			boolean shouldRender = true;

			// more fps
			while (delta >= 1) {
				ticks++;
				delta -= 1;
				shouldRender = true;
			}

			// sleep
			try { Thread.sleep(SLEEP_TIME); }
			catch (InterruptedException e) { e.printStackTrace(); }

			// every time a frame happens
			if (shouldRender) {
				frames++;
				render();
				shouldRender = false;
			}

			// for fps again
			if (System.currentTimeMillis() - lastTimer >= 1000) {
				lastTimer += 1000;
				System.out.println(frames + " frames , " + ticks + " ticks");
				frames = 0;
				ticks = 0;
			}
		}

		stop();
	}
	
	public static void draw(Graphics2D g){
		if (stage != null){
			stage.draw(g);
		}
	}
	
	//mutators
	public static void setStage(Stage s){ stage = s; }
	public static void LMBDown(int x, int y){ stage.LMBDown(x, y); }
	public static void LMBUp(int x, int y){ stage.LMBUp(x, y); }
	public static void RMBDown(int x, int y){ stage.RMBDown(x, y); }
	public static void RMBUp(int x, int y){ stage.RMBUp(x, y); }
	public static void mouseAt(int x, int y){ stage.mouseAt(x, y); }
	public static void scrollWheelAt(int x){ stage.scrollWheelAt(x); }
	public static void keyUp(int code){ stage.keyUp(code); }
	public static void keyDown(int code){ stage.keyDown(code); }
	
	//getters
	public static Stage getStage(){ return stage; }

	private void render(){
		//update input
		update();
		//act
		stage.act();

		//draw
		panel.drawing();
	}
	
	//this just updates the inputs from the user
	private void update(){
		mouseX = input.getMouseX();
		mouseY = input.getMouseY();
		mouseDownX = input.getMouseDownX();
		mouseDownY = input.getMouseDownY();
		mouseUpX = input.getMouseUpX();
		mouseUpY = input.getMouseUpY();
		isFocused = input.getIsFocused();
		isMouseDownLeft = input.getIsMouseDownLeft();
		isMouseDownRight = input.getIsMouseDownRight();
		keys = input.getKeys();
	}
}














