using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetrualAi : MonoBehaviour
{


    public float speed = 0.1f;
    float range = 2f;
    float dist;
    Rigidbody rb;
    

    float minX=0;
    float maxX=20;
    float y = 0.5f;
    float minZ=0;
    float maxZ =20;
    float x,z;
    Vector3 point; 
    

	void Start()
    {
		// get Rigidbody of object
        rb = GetComponent<Rigidbody>();
        newpattern();
        move(point);
    }
    void Update()
    {
		//Gets the closest dna to object
        GameObject closestTarget = FindClosestTarget();
        
		move(point);

		// if the Dna target is in range go after it else go to a random point
        if (transform.position == point && dist >= range)
        {
            newpattern();
            
        }
        else if (closestTarget != null && dist <= range)
        {
           
            
                move(closestTarget.transform.position);
           
        }


    }
	// Makes a random location point to go to 
    void newpattern()
    {
        x = Random.Range(minX, maxX);
        z = Random.Range(minZ, maxZ);
       point = new Vector3 (x,0.5f,z); 

    }
	// moves toward the point
    void move(Vector3 location)
    {
       // Debug.Log("TARGETPOSITION: " + location);
        transform.position = Vector3.MoveTowards(rb.position,location, (speed * Time.deltaTime));
       
    }
	//if object hits a wall make a new point
    void OnTriggerEnter(Collider hit)
    {
        if (hit.gameObject.CompareTag("wall"))
        {
            newpattern();
            move(point);
        }
    //move faster when other germ touch due to passing genes 
    if (hit.gameObject.CompareTag("germ"))
        {
            speed = speed + 0.3f;
        }
    }
	// Finds all the targets in the level 
    GameObject FindClosestTarget()
    {
        GameObject[] target;
        target = GameObject.FindGameObjectsWithTag("DNA");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;

	//calulates the distance between the closes target and object position 
        foreach (GameObject go in target)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
            
        }
        dist = Vector3.Distance(closest.transform.position, transform.position);
        return closest;
        
    }
} 
     //translate to new point 
     //if new point is meet or a block by walls 
     //then it genrates a new location to go to 
     // i its near a dna it goes wasy.
     // rember to get the placing location 