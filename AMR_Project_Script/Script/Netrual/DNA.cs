using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DNA : MonoBehaviour {
    public GameObject player;


	void Update ()
	{
		rotate ();
	}

	// add funds and disappers when a germ picks it up.
    void OnTriggerEnter(Collider pick)
    {
        if (pick.gameObject.CompareTag("germ"))
        {
            Evolution.countfunds = Evolution.countfunds + 1;
            Destroy(this.gameObject);
        }
    }

	// Add a spin to the dna pickups
    void rotate()
    {
		
		transform.Rotate (0, 50 * Time.deltaTime, 0);
    }
}
