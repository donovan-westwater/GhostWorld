using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransparentWall : MonoBehaviour
{
    // Start is called before the first frame update
    
    void Start()
    {
        GameObject g = GameObject.FindGameObjectWithTag("Player");
        Physics.IgnoreCollision(this.GetComponent<BoxCollider>(), g.GetComponent<Collider>());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
