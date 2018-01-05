using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Interaction : MonoBehaviour
{
    public GameObject other;
    public GameObject dna;
    public GameObject goal;
   

//When a non player cell gets touch, it deletes itself and spawn DNA fund.
    void OnTriggerEnter(Collider hit)
    {
        //Vector3 location = this.gameObject.transform.position;
        if (hit.gameObject.CompareTag("enemy"))
        {
            Instantiate(dna,this.gameObject.transform.position, Quaternion.identity);
            Spawn.count = Spawn.count - 1;
            Destroy(this.gameObject);
        }
   
    }
}//StartCoroutine(Playershealth.hurt(0.00001f));