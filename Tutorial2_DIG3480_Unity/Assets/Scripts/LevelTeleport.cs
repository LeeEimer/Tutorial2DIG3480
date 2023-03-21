using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTeleport : MonoBehaviour {
 
    public GameObject DoorExit;
 
    void Teleport(GameObject Player)
    {
        Player.transform.position = DoorExit.transform.position;
    }
 
    void OnTriggerEnter2D(Collider2D coll) {
        if (coll.gameObject.tag == "Player")
            Teleport (coll.gameObject);
    }
 
}