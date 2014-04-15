using UnityEngine;
using System.Collections;

public class EnemySkiffAI: MonoBehaviour
{
	public float MOVESPEED = 5f;
	GameObject PlayerShip;
	public float RotateVal;
	public int currMissileCooldown;
	public GameObject missilePrefab;
	public int FIREANGLE;
	private int health;

	public float FIREDISTANCE;

	static GameObject missile;

	// Use this for initialization
	void Start ()
	{
		PlayerShip = GameObject.FindWithTag ("Player");
		InvokeRepeating ("CooldownUpdate", 1.0f, 1.0f);
		currMissileCooldown = 0;
		FIREDISTANCE = 20f;
		FIREANGLE = 7;
		health = 10;
	}
	
	// Update is called once per frame
	void Update()
	{
		this.transform.rotation = Quaternion.Slerp (transform.rotation,
		                                       		Quaternion.LookRotation (PlayerShip.transform.position - this.transform.position),
		                                            5f);

		rigidbody.AddRelativeForce (0f, 0f, MOVESPEED);
		float xDiff = this.transform.position.x - PlayerShip.transform.position.x;
		float zDiff = this.transform.position.z - PlayerShip.transform.position.z;
		if (xDiff < FIREDISTANCE && xDiff > -FIREDISTANCE
		    && zDiff < FIREDISTANCE && zDiff > -FIREDISTANCE)
		{
			this.Fire();
		}

	}

	void CooldownUpdate()
	{
		currMissileCooldown--;
		if (currMissileCooldown < 0)
		{
			currMissileCooldown = 0;
		}
	}

	void Fire()
	{
		if (currMissileCooldown == 0)
		{
			for(int i = -2; i <= 2; i++)
			{
				missile = Instantiate(missilePrefab, this.transform.position, this.transform.rotation) as GameObject;
				missile.transform.Rotate(0, 270 + (FIREANGLE * i), 0);
			}

		}

		currMissileCooldown = 5;
	}

}
