using UnityEngine;
using System.Collections;

public class LightShipBlastScript : MonoBehaviour {

    #region test variables
    //variables for visual testing
    public float testSpeed = .2f;
    public int curCycle = 0;
    //cycles before the test missile changes directions
    public int cycleLength = 200;
    //boolean used for visual testing
    bool movingForward = true;
    #endregion

    public int speed = 3000;
    //the number of frames before it disappears
    public int lifeSpan = 15;

    //when we first create the object, before we can relocate it to the side of the ship
    //the collider creates a collision with the ship itself. This bool is used to prevent that
    bool canCollide=false;

	// Use this for initialization
	void Start () 
    {
        //set the start position of the missile so that it's not inside the ship shooting it
        rigidbody.transform.Translate(4f, 0f, 0f);
        rigidbody.AddRelativeForce(speed, 0, 0);
        //only after moving the starting position of the missile do we allow it to collide
        canCollide = true;
	}
	
	// Update is called once per frame
	void Update () 
    {
        //you can uncomment this if you want to test the visual effects of the missile
        //visualTestMode();

        //count down until the projectile dies
        lifeSpan--;
        if (lifeSpan <= 0)
        {
            Destroy(gameObject);
        }
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Missile")
        {
            if (canCollide)
            {
                Destroy(gameObject);
            }
        }
    }

    //moves the missile back and forth. Call this method if you want to test the animation
    void visualTestMode()
    {
        if (movingForward)
        {
            //rigidbody.AddRelativeForce(0, 0, -2);
            transform.Translate(0f, 0f, -1 * testSpeed);
            curCycle++;
            if (curCycle > cycleLength)
            {
                movingForward = false;
                curCycle = 0;
            }
        }
        if (!movingForward)
        {
            //rigidbody.AddRelativeForce(0, 0, 2);
            transform.Translate(0f, 0f, testSpeed);
            curCycle++;
            if (curCycle > cycleLength)
            {
                movingForward = true;
                curCycle = 0;
            }
        }
    }
}
