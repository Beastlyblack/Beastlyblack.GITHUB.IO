using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Win : MonoBehaviour {

    bool touched = false;
    public GameObject player;
	private Renderer state; 

   
	void Start()
	{
		state = GetComponent<Renderer>();
		player = GameObject.Find ("playermodel");
    }
	// increments the amount of checkpoints that the player has touched
    void OnTriggerEnter(Collider hit)
    {
		if (hit.gameObject.Equals(player) && touched == false )
        {//&& touched == false
			state.material.color = Color.gray ; 
			LevelManager.currentsave = LevelManager.currentsave +1;
            touched = true;
			Debug.Log ("HIT");
        }
    }
}
// stuff to do 
//need to stop the player from entering multiple times
