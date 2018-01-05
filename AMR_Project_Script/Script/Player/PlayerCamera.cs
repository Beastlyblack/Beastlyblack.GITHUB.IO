using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour {

    // Use this for initialization
    public GameObject playermodel;

    private Vector3 offset;

    void Start()
    {
		// gives the diffrenct between the player object and cam posistion
        offset = transform.position - playermodel.transform.position;
    }

    void LateUpdate()
    {
        follow();
    }

	// follows the player object, offect is used to keep the cam from being inside the player object.
    void follow()
    {
        if (playermodel != null)
        {
            transform.position = playermodel.transform.position + offset;
            return;
        }
    }
}

