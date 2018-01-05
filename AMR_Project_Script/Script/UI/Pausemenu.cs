using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pausemenu : MonoBehaviour
{
    public GameObject pausemenu;
    public GameObject exitmenu;

	// Pauses Time while the pause button is pressed 
    public void pause(bool state)
    {
        if (state == true)
        {
            Time.timeScale = 0;
            pausemenu.SetActive(true);
        }
        else if (state == false)
        {
            Time.timeScale = 1;
            pausemenu.SetActive(false);
        }
    }
	// Allows the player to quit mid game.
    public void exitconfirm(string confirm)
    {
        pausemenu.SetActive(false);
        exitmenu.SetActive(true);
        if (confirm == "yes")
        {
            Application.Quit();
        }
        else if (confirm == "no")
        {
            exitmenu.SetActive(false);
            pausemenu.SetActive(true);
        }



    }
}
