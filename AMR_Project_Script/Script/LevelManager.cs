using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {


	float totalsave;
	public static float currentsave = 0;
	bool touched = false;
	public GameObject player= null;
	public GameObject goal= null;
	public GameObject notificationmenu= null;
	private Renderer state= null;
	public Text Notificationtext = null;
	public Text Points_left= null;

	void Start()
	{
		player = GameObject.Find ("playermodel");
		goal = GameObject.FindWithTag ("goal");
		notificationmenu = GameObject.Find ("Notification_Board");
		Notificationtext = GameObject.Find ("Notificationtext").GetComponent<Text>();
		Points_left = GameObject.Find("Pointsleft").GetComponent<Text>();
	}
	void Update()
	{
		if (Points_left != null) 
		{
			check ();
		}
		Debug.Log (currentsave);
		Debug.Log(totalsave);
	}



	// checks if the player has touch all checkpoints
	void check()
	{
		totalsave = GameObject.FindGameObjectsWithTag("savepoint").Length;
		Points_left.text = "Gatepaths left: "+ (totalsave-currentsave);

		if (currentsave == totalsave)
		{
			goal.SetActive(true);
			notificationmenu.SetActive(true);
			Notificationtext.text = "Next level avalible";


			//currentsave++;
		}
		else
		{
			goal.SetActive(false);
			notificationmenu.SetActive(false);
		}
	}





	public void LoadScenebyIndex(int loadIndex)
    {
		// Load the next Scene(level)
        SceneManager.LoadScene(loadIndex);
    }
}
