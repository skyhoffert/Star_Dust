using UnityEngine;

/*
 * 
 * Abilities should have a short description above
 * 
 * This class is a 'template' for all actual abilities 
 * 
 */

public abstract class Ability {
	public float cooldown;
	public float powerCost;
	public float timeLastUsed;
	public Sprite icon;

	protected Ability() { }

	// triggers for actions, with a ship as guidance
	public abstract void OnKeyDown(Ship ship);
	public abstract void OnKeyHeld(Ship ship);
	public abstract void OnKeyUp(Ship ship);
}
