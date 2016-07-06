// example entity file that should be used
// almost all game objects will be entities
// with health, mass, and velocity

class Entity {

	// Unity stuff
	CharController controller;	

	// for movement
	protected Vector3 velocity;

	// default constructor
	public Entity(){
		velocity = new Vector3(0, 0, 0);
	}

	void Start(){
	}

	void Update(){
		// if it is not alive
		MoveByVelocity();
	}

	// just move by the velocity
	protected void MoveByVelocity(){
		controller.Move(velocity * Time.deltaTime);
	}

}
