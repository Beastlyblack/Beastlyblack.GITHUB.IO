using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermovment : MonoBehaviour {

    public float speed;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
		// controls for keyboard 
        playermovmentKB();

		// Controls for Mobile touch 
        playermovmentTI();
		// Tilt Controls for mobile
        playermovmentTiltI();
    }
    void playermovmentKB()
    {
        if (gameObject != null)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

            rb.AddForce(movement * speed);


        }
        else
        {
            return;
        }
    }
    void playermovmentTI()
        
    {
        
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            // Get movement of the finger since last frame
            Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;

            // Move object across XY plane
            rb.transform.Translate(-touchDeltaPosition.x * speed,0, -touchDeltaPosition.y * speed, 0);
        }
    }
    void playermovmentTiltI()
    {
		// Get the input from mobile accelerometer and translate the gameObject base on the distance from normal stance. 
         rb.transform.Translate(Input.acceleration.x, 0, -Input.acceleration.z);
    }
   
}
