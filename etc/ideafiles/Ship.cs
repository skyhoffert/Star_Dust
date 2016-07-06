
class Ship : Entity {
	
	// stats every ship will have
	protected float health;
	protected float maxHealth;
	protected float mass;
	protected bool isAlive;
	
	public Ship(){
		// initialize everything to default values 
		maxHealth = 1; 
		heatlh = maxHealth; 
		mass = 1; 
		isAlive = true; 
	}

	// take a given amount of damage
        // sub classes should override and consider armor stats
	public void ApplyDamage(float amount){
		health -= amount;
		if (health <= 0){
			health = 0;
			isAlive = false;
		}
	}
	
}
