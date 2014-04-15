using UnityEngine;
using System.Collections;

public class LightShip : MonoBehaviour {

    public float TURNSPEED = 1.8f;
    public float SPEED = 20;
    //this determines the angle between projectiles in the blast attack
    public float blastFanOut = 7;
    public GameObject blastPrefab;
    GameObject blastProjectile;

	// Use this for initialization
	void Start () 
    {
        
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 blastStartLocation = new Vector3(transform.position.x, transform.position.y, transform.position.z);

            blastProjectile = Instantiate(blastPrefab, blastStartLocation, transform.rotation) as GameObject;
            blastProjectile.transform.Rotate(0, -2 * blastFanOut, 0);
            blastProjectile = Instantiate(blastPrefab, blastStartLocation, transform.rotation) as GameObject;
            blastProjectile.transform.Rotate(0, -1 * blastFanOut, 0);
            blastProjectile = Instantiate(blastPrefab, blastStartLocation, transform.rotation) as GameObject;
            blastProjectile.transform.Rotate(0, 0, 0);
            blastProjectile = Instantiate(blastPrefab, blastStartLocation, transform.rotation) as GameObject;
            blastProjectile.transform.Rotate(0, blastFanOut, 0);
            blastProjectile = Instantiate(blastPrefab, blastStartLocation, transform.rotation) as GameObject;
            blastProjectile.transform.Rotate(0, 2 * blastFanOut, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(0.0f, TURNSPEED, 0.0f);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(0.0f, -1 * TURNSPEED, 0.0f);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rigidbody.AddRelativeForce(SPEED, 0f, 0f);
        }
       
	}
}
