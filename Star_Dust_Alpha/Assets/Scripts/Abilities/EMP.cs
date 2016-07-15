using UnityEngine;
using System.Collections;
using System;

/*
 * 
 * TODO
 * Describe
 * 
 */

public class EMP : Ability {

	public EMP() {
		cooldown = 4;
		powerCost = 10;
	}

	public override void OnKeyDown(Ship ship) {
	}
	
	public override void OnKeyHeld(Ship ship) {
	}

	public override void OnKeyUp(Ship ship) {
	}

}
