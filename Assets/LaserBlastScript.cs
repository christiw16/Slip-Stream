using UnityEngine;
using System.Collections;

public class LaserBlastScript : MonoBehaviour
{
	bool canCollide;
	public const int speed = 20000;
	// Use this for initialization
	void Start () 
	{
		//set the start position of the missile so that it's not inside the ship shooting it
		rigidbody.transform.Translate(0f, 7f, 0f);
		rigidbody.AddRelativeForce(0, 0, speed);
		//only after moving the starting position of the missile do we allow it to collide
		canCollide = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
