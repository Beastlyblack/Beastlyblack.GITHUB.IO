using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evolution : MonoBehaviour {

    public static float countfunds = 0;
	// a counter to count the current skill level of a skill its used in upgrademenu 
    void skillcost()
    {
        int cost = 0;
        int skilllevel = 0;
        if (countfunds >= cost)
        {
            if (skilllevel < 1)
            {
                countfunds = countfunds - cost;
            }
        }
        if (skilllevel == 1)
        {
            cost = cost * 2;
            countfunds = countfunds - cost;

          
        }
        if (skilllevel == 2)
        {
            cost = cost * 2;
            countfunds = countfunds - cost;
           
        }
        if (skilllevel == 3)
        {
           cost = cost * 2;
           countfunds = countfunds - cost;
          
        }
        if (skilllevel == 4)
        {
            cost = cost * 2;
            countfunds = countfunds - cost;
            
        }
    }

} 
       

