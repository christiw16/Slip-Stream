using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LaserEnemyAI : MonoBehaviour
{
	public float MOVESPEED;
	static GameObject Laser;
	public GameObject laserPrefab;
	public GameObject PlayerShip;
	//public GameObject NearestWall;
	public int LaserCooldown;
	// Use this for initialization
	void Start ()
	{
		MOVESPEED = .5f;
		LaserCooldown = 10;
		InvokeRepeating ("CooldownUpdate", 1.0f, 1.0f);
		PlayerShip = GameObject.FindWithTag ("Player");

		this.transform.position = Vector3.Lerp (transform.position,
		                                        GetNearestWall().transform.position,
		                                        Time.deltaTime * MOVESPEED);

		//NearestWall = GetNearestWall ();

	}
	
	// Update is called once per frame
	void Update ()
	{
		//this.transform.LookAt (target);

		this.transform.rotation = Quaternion.Lerp (transform.rotation,
		                                            Quaternion.LookRotation (PlayerShip.transform.position - this.transform.position),
		                                            Time.deltaTime * 1f);


		this.transform.position = Vector3.Lerp (transform.position,
		                                        GetNearestWall().transform.position,
		                                        Time.deltaTime * MOVESPEED);

		/*this.transform.position = Vector3.Lerp (transform.position,
		                                        NearestWall.transform.position,
		                                        Time.deltaTime * MOVESPEED); */

		if (LaserCooldown == 0)
			Fire ();


	}

	void CooldownUpdate()
	{
		LaserCooldown--;
		if (LaserCooldown < 0)
		{
			LaserCooldown = 0;
		}
	}

	void Fire()
	{
		Laser = Instantiate(laserPrefab, this.transform.position, this.transform.rotation) as GameObject;
		LaserCooldown = 10;
	}

	GameObject GetNearestWall()
	{
		IList<GameObject> walls = GameObject.FindGameObjectsWithTag ("Walls");
		GameObject nearWall = walls [0];

		foreach (GameObject wall in walls)
		{
			if(Vector3.Distance(this.transform.position, wall.transform.position)
			   < Vector3.Distance(this.transform.position, nearWall.transform.position))
				nearWall = wall;
		}

		return nearWall;
	}
}
