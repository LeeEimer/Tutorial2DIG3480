using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTeleport : MonoBehaviour
{
    public GameObject Start; 

    // Update is called once per frame
    void Teleport(GameObject Player)
    {
        Player.transform.position = Start.transform.position;
    }

    void OnTriggerEnter2D(Collider2D coll){
        if(coll.gameObject.tag == "Player"){
            Teleport(coll.gameObject);
        }
    }
}
