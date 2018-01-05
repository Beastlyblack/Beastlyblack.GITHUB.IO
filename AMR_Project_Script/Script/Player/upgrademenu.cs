using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class upgrademenu : MonoBehaviour
{
	// 
    public GameObject menu;
    float countfunds;
    float hcost = 1;
    int hlevel=0;

	//only allows access to the menu if the player has a point to spend
    public void Menuacesse(bool state)
    {
        if (state == true)
        {

            menu.SetActive(true);
        }
        else if (state == false)
        {
           menu.SetActive(false);
        }
    }

// incresse the players health every skill level
public void Hpupgrade()
    {
// calls the variable from Evolution
       countfunds = Evolution.countfunds;
            Debug.Log(countfunds);
          if (hlevel <= 1 && skillcost(hlevel, hcost) == true)
            { 
                Playershealth.maxhealth = Playershealth.maxhealth+25;
                    hlevel = 2;
                
            }
            else if (hlevel == 2 && skillcost(hlevel, hcost) == true)
            {
                
                    Playershealth.maxhealth = Playershealth.maxhealth + 25;
                    hlevel = 3;
                
            }
            else if (hlevel == 3 && skillcost(hlevel, hcost) == true)
            {
                    Playershealth.maxhealth = Playershealth.maxhealth + 25;
                    hlevel = 4;   
            }
            else if (hlevel == 4 && skillcost(hlevel, hcost) == true)
            {
                {
                    Playershealth.maxhealth = Playershealth.maxhealth + 25;
                }
            }
            else
                {
                    Debug.Log("not enough DNA");
                }
    }

	// sets 
    public bool skillcost(int skilllevel,float cost)
    {
bool buy = false;

        if (skilllevel <= 1)
        {
            
            if (countfunds >= cost)
            {
                countfunds = countfunds - cost;
                buy=true;

            }

        }
        else if (skilllevel == 2)
        {
            cost = cost * 2;
            if (countfunds >= cost)
            {
                countfunds = countfunds - cost;
                buy = true; 
            }


        }
        else if (skilllevel == 3)
        {
            cost = cost * 3;
            if (countfunds >= cost)
            {
                countfunds = countfunds - cost;
                buy = true; 
            }


        }
        else if (skilllevel == 4)
        {
            cost = cost * 4;
            if (countfunds >= cost)
            {
                countfunds = countfunds - cost;
                buy = true;
            }

        }
        else
        {
            buy = false;
			Debug.Log("not enough DNA");
        }

        Evolution.countfunds = countfunds;
        return buy;
    }

}
