using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingAI : MonoBehaviour
{
	// variables for enemy AI
    public float speed = 0.1f;
    public float rotatingSpeed = 20;
    public float vision = 5;
    public float stop = 0;
    //public GameObject target;
   // public new Vector3 targetposition;
         
    Rigidbody rb;

   void Start()
    {
        // gets and store the rigidbody variables 
        rb= GetComponent<Rigidbody>();
    }
    void Update()
    {
        // Finds the closest target and chase them if there is one
        GameObject closestTarget = FindClosestTarget();
        if (closestTarget != null)
        {
            chase(closestTarget);
        }
        //Debug.Log("Distance" + distance);
        //Debug.Log("targetposition" + targetposition);
    }

// moves toward target posistion 
void chase(GameObject target)
    {

        // gets the target posistion 
        Vector3 targetPos = target.transform.position;
        //Debug.Log("TARGETPOSITION: " + targetPos);

		// if the germ is within the antibody range
		// if (distance <= vision && distance > (stop))
       // {
            
            //targetposition = target.transform.position;
            //rb.transform.Translate(targetposition*(speed * Time.deltaTime));
       // }


		// Move toward them by the object speed.
		rb.transform.position = Vector3.MoveTowards(rb.position, targetPos, (speed * Time.deltaTime));
    }

	// Gets the closest Target to this object
    GameObject FindClosestTarget()
    {
		// gathers all the object with the germ tag 
        GameObject[] target;
        target = GameObject.FindGameObjectsWithTag("germ");

		// set some varaibles used for calulation 
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;

		// checks and compares each target in the level and finds the closest one
        foreach (GameObject go in target)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }return closest;
    }
    
  }
         
       

