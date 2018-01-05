using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Playershealth : MonoBehaviour
{
    // player settings
	public Material material;
	public Renderer rend;
	public Renderer Prerend;
    public static float maxhealth = 100; // health at the start of the game 
    public static float currenthealth; // players current health
   
	// Players statues 
    bool isDead;
    float tick;
    bool healthcheck = false;
    bool damaged;
    //_bool healing;
    bool invunarable;
	// level check 
	public int lvlcount = 1;

    // UI 
    public Text health;
	public GameObject gameover;
    public Text dnafunds;

    void Start()
    {
        //Get this object colour 
        rend = GetComponent<Renderer>();
        rend.enabled = true;
		Prerend = rend; 
		//gameover = GameObject.Find("Gameover");
		// set player starting stats 
        currenthealth = maxhealth;
        SetCounthealth();
		// set gameobject to false
		gameover.SetActive(false);

    }
	void Update()
	{
		health.text = "Health: " + currenthealth.ToString("0") + "/"+maxhealth+" HP";
		dnafunds.text = "DNA Funds: " + Evolution.countfunds;

	}

	// done at the start of the player save file 
    void SetCounthealth()
    {
		// Sets up health at the start of a level 

        health.text = "Health: " + currenthealth.ToString("0") + "/" + maxhealth + " HP";
        Mutation();
        Debug.Log(tick);
        dnafunds.text = "DNA Funds: " + Evolution.countfunds;

    }
    
	// checks what the object has hit and reacts to it. 
    void OnTriggerStay(Collider Other)
    {
		

        // Get damage by enemy per sec touching
        if (Other.gameObject.CompareTag("enemy"))
        {

            // while (damaged == true) // just for test,rember that other script controlls the damage setting 
            {
                StartCoroutine(hurt(0.00001f));
            }
        }
		// heal 1 hp per sec in contact  
        if (Other.gameObject.CompareTag("savepoint"))
        {
            StartCoroutine(healing(0.00001f));
        }
		// Adds DNA funds to player
        if (Other.gameObject.CompareTag("DNA"))
        {

            dnafunds.text = "DNA Funds: " + Evolution.countfunds;
        }
		// Moves to the next level 
        if (Other.gameObject.CompareTag("goal"))
        {
			if(SceneManager.GetSceneByName("Level" +(lvlcount+1)).IsValid())
			{
				SceneManager.LoadScene("Level" +(lvlcount+1));
			}
			else 
			{

				SceneManager.LoadScene ("Winscene");
			}
        }
    }
// destroy the player object
void death()
    {
       // if (currenthealth == 0)
        //{

		Destroy(this.gameObject);
            //return;        
        //}
    }
// checks the players HP and responces to certain levels 
    IEnumerator hurt(float time)
    {
        float damage = 1;
        yield return new WaitForSeconds(time * Time.deltaTime);

        
        if (currenthealth > 0 * (Time.deltaTime))
        {
			// does damage by secend called 
            currenthealth = currenthealth - (damage/10); // damage = GetComponent<>(); figger out how to get other enemy damage data
            
			// when less then 50 hp player object shows yellow
			if (currenthealth >= 50 || currenthealth <= 25)
            {
                rend.material.color = Color.yellow;
			// when less then 25 hp player shows red
                if (currenthealth <= 25)
                {
                    rend.material.color = Color.red;

					// calls the death function if player hp reachs zero
                    if (currenthealth <= 0)
                    {
						gameover.SetActive(true);
                        death();
                    }

                }
                else
                {
					rend = Prerend;
                }
            }
           // updates health UI 
            SetCounthealth();
            
        }
    }
    IEnumerator healing(float time)
    {
		
        float damage = 1;
        //while (damaged == true) 
        yield return new WaitForSeconds(time * Time.deltaTime);
		// heals player per sec
        if (currenthealth > maxhealth * (Time.deltaTime) && currenthealth <= maxhealth)
        {
            currenthealth = currenthealth + (damage / 10); // damage = GetComponent<>(); figger out how to get other enemy damage data
			// Player health between 25 and 50 show yellow on player object
			if (currenthealth >= 25 && currenthealth <50)
			{
				rend.material.color = Color.yellow;
				// player health over 50 show player normal colour
				if (currenthealth >= 50)
				{
					rend.material = Prerend.material; 
                }
            }
			// Update UI 
            SetCounthealth();
        }
    }
	// Give player a chance of a boast in max hp 
    void Mutation()
    {
       
		//every time player hp reachs 80hp twice
        if (currenthealth == 80  )
        {
            tick =tick+1;
            if (tick == 2 )
           {
                if (Random.Range(1, 10) <= 10)
                {
                maxhealth = maxhealth + 30;
                healthcheck = true;
                }
                else
                {
                    tick = 0;
                }
         }
                
        }
             
    }
}

