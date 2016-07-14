using UnityEngine;

/*
 *
 * Abilities should have a description of how they work
 *
 * This class is a "template" for all actual abilities
 *
*/

abstract class Ability{
	protected float cooldown;
	protected float powerCost;

	protected Ability();
	public abstract void OnKeyDown(Ship ship);
	public abstract void OnKeyUp(Ship ship);
}
