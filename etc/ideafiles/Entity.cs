// example entity file that should be used
//

class Entity {
	
	// stats every entity will have
	protected float health;
	protected float maxHealth;

	// for movement
	protected Vector3 velocity;

	// default constructor
	public Entity(){
		// initialize everything to default values
		maxHealth = 500;
		heatlh = maxHealth;
		velocity = new Vector3(0, 0, 0);
	}

}
