using UnityEngine;
using System.Collections;
using Items;

public class PlayerShip : Ship {

    // the gun!
    public StandardLaserGun cannon;

	// player stats
	// adjusted health for after passives and actives
	protected float healthAdjusted;
	// same sort of layout for power, accel, and velocity
	protected float powerBase, powerCurrent, powerAdjusted;
	protected float accelCurrent, accelAdjusted;
	// current velocity is in the rigid body elements
	protected float maxspeedAdjusted;

	// damage
	// damage is ADDED to weapon's unique damage
	protected float standardAttackDamageFlat, standardAttackDamagePercentage;

	// abilities
	public Ability abilityAttack;
	public Ability abilityUtility;
	public Ability abilitySpecial;

	// could change for each ship
	protected int inventorySize = 4;
	public Item[] items;

	protected override void Initialize() {
        base.Initialize();

		buildCost = 100;

		rotationSpeed = 240;

		healthBase = 500;
		healthAdjusted = healthBase;
        healthCurrent = healthAdjusted;

		powerBase = 100;
		powerAdjusted = powerBase;
		powerCurrent = powerAdjusted;

		accelAdjusted = accelBase;
		accelCurrent = accelAdjusted;

		maxspeedAdjusted = maxspeedBase;

		standardAttackDamageFlat = 0;
		standardAttackDamagePercentage = 0;

		abilityAttack = null;
		abilityUtility = null;
		abilitySpecial = null;

		items = new Item[inventorySize];
    }

	// basically ship reconstructs ship and puts it at position
	public void Reconstruct(Vector3 position) {
		isAlive = true;
		healthCurrent = healthAdjusted;
		powerCurrent = powerAdjusted;
		accelCurrent = accelAdjusted;
		transform.position = position;
	}

    protected override void Act() {
        base.Act();
        if (isAlive)
        {
            SetVel();
            CannonManager();
        } else {
		}
    }

    public void PointTowardsMouse(Vector3 target)
    {
		PointTowards(target);
    }

    private void SetVel()
    {
        if (Input.GetButton("MoveForward"))
        {
            Vector3 direction = new Vector3(transform.forward.x, 0f, transform.forward.z);
            direction = direction.normalized;
            direction *= accelCurrent * Time.deltaTime;
            rigidBody.AddForce(direction);
        }
    }

    protected void CannonManager(){
        if (Input.GetButtonDown("Fire"))
        {
            cannon.FireOnce(standardAttackDamageFlat + standardAttackDamagePercentage * standardAttackDamageFlat);
        }
        else if (Input.GetButton("Fire"))
        {
            cannon.FireContinuous(standardAttackDamageFlat + standardAttackDamagePercentage * standardAttackDamageFlat);
        }
    }

	public override void AddHealth(float amount) {
		base.AddHealth(amount);
		healthAdjusted += amount;
	}

	void OnControllerColliderHit(ControllerColliderHit hit)
    {
        hasCollided = true;
    }

	public bool getIsAlive() { return isAlive; }
}
