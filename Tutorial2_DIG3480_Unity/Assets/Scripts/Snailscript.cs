using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snailscript : MonoBehaviour
{
   // Start is called before the first frame update
    public Vector2 destination;
    public Vector2 startposn;
    public float speed = 2f;

    // Update is called once per frame
    void Update()
    {
        float time = Mathf.PingPong(Time.time * speed, 1);
        transform.position = Vector2.Lerp(startposn, destination, time);
        
    }
}
