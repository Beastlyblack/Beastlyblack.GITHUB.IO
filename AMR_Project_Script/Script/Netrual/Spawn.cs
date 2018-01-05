using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Spawn : MonoBehaviour {
    public GameObject cell ;
    public GameObject other;
    public Text Remaininggerms;

    public int totalcells;
    public static float count= 0 ;  

	// Spawns in germs into level
	void Start () {
        spawanin(1);
        //totalcells = GameObject.FindGameObjectsWithTag("germ").Length+1; // there is a better way for this 
        //count = totalcells -1;
	}
	
	//updates how many other germs are there in UI 
	void Update () {
       
		totalcells = GameObject.FindGameObjectsWithTag("germ").Length+1; // there is a better way for this 
		count = totalcells-1;
        Remaininggerms.text = "Remaining germs "+ count;
    

    }
    // creates a dna when a cell dies 
    void spawanin(int k)
    {
        for (int i = 1; i<k;i++)
            Instantiate(cell,new Vector3(i*2.0f,0,2.0f),Quaternion.identity);
    }
}
