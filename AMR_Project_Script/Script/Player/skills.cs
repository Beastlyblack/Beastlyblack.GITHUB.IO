using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skills : MonoBehaviour {
    float Hcost = 0;
    float Hlevel = 0;
    public void HealthUpgrade(int level)
    {

        if (level == 1)
        {
            Playershealth.maxhealth = 125;
            level = level + 1;
            
        }
        else if (level == 2)
        {
            Playershealth.maxhealth = 150;
          
        }
        else if (level == 3)
        {
            Playershealth.maxhealth = 175;
            
        }
        else if (level == 4)
        {
            Playershealth.maxhealth = 200; 
        }
        
    }
}
