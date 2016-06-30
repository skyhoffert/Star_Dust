package packages.main;

import java.awt.event.FocusEvent;
import java.awt.event.FocusListener;
import java.awt.event.KeyEvent;
import java.awt.event.KeyListener;
import java.awt.event.MouseEvent;
import java.awt.event.MouseListener;
import java.awt.event.MouseMotionListener;

public class InputHandler implements FocusListener, MouseListener, MouseMotionListener, KeyListener{
	
	private int mouseX, mouseY;
	private int mouseDownX, mouseDownY;
	private int mouseUpX, mouseUpY;
	private boolean[] keys;
	private boolean isFocused;
	private boolean isMouseDownLeft, isMouseDownRight;

	public InputHandler(){
		this.mouseX = -1;
		this.mouseY = -1;
		this.mouseDownX = -1;
		this.mouseDownY = -1;
		this.isFocused = true;
		this.keys = new boolean[68836];
	}
	
	public void mouseDragged(MouseEvent e) {
		this.mouseX = e.getX();
		this.mouseY = e.getY();
		Main.mouseAt(mouseX, mouseY);
	}

	public void mouseMoved(MouseEvent e) {
		this.mouseX = e.getX();
		this.mouseY = e.getY();
		Main.mouseAt(mouseX, mouseY);
	}

	public void mouseClicked(MouseEvent e) {
	}

	public void mouseEntered(MouseEvent e) {
		
	}

	public void mouseExited(MouseEvent e) {
		
	}

	public void mousePressed(MouseEvent e) {
		this.mouseDownX = e.getX();
		this.mouseDownY = e.getY();
		if (e.getButton() == MouseEvent.BUTTON1){
			isMouseDownLeft = true;
			Main.LMBDown(mouseDownX, mouseDownY);
		} else if (e.getButton() == MouseEvent.BUTTON3){
			isMouseDownRight = true;
			Main.RMBDown(mouseDownX, mouseDownY);
		}
	}

	public void mouseReleased(MouseEvent e) {
		this.mouseUpX = e.getX();
		this.mouseUpY = e.getY();
		if (e.getButton() == MouseEvent.BUTTON1){
			isMouseDownLeft = false;
			Main.LMBUp(mouseDownX, mouseDownY);
		} else if (e.getButton() == MouseEvent.BUTTON3){
			isMouseDownRight = false;
			Main.RMBUp(mouseDownX, mouseDownY);
		}
	}

	public void focusGained(FocusEvent e) {
		 this.isFocused = true;
	}

	public void focusLost(FocusEvent e) {
		 this.isFocused = false;
	}

	public void keyPressed(KeyEvent e) {
		keys[e.getKeyCode()] = true;
		Main.keyDown(e.getKeyCode());
	}

	public void keyReleased(KeyEvent e) {
		keys[e.getKeyCode()] = false;
		Main.keyUp(e.getKeyCode());
	}

	public void keyTyped(KeyEvent e) {
	}

	public int getMouseDownX() {
		return mouseDownX;
	}

	public int getMouseDownY() {
		return mouseDownY;
	}

	public int getMouseUpX() {
		return mouseUpX;
	}

	public int getMouseUpY() {
		return mouseUpY;
	}
	
	public int getMouseX() {
		return mouseX;
	}

	public int getMouseY() {
		return mouseY;
	}
	
	public boolean getIsFocused(){
		return isFocused;
	}
	
	public boolean getIsMouseDownRight(){
		return isMouseDownRight;
	}
	
	public boolean getIsMouseDownLeft(){
		return isMouseDownLeft;
	}

	public boolean[] getKeys() {
		return keys;
	}
}
