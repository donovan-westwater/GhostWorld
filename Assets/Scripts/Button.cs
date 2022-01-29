using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
   ButtonTriggerible activateObject;
    bool depress = false;
    float dist = 0.1f;
    float curDist = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (depress)
        {
            if (curDist < dist)
            {
                transform.position += Vector3.down * Time.deltaTime;
                curDist += Time.deltaTime;

            }

        }
        else
        {
            if(curDist > 0)
            {
                transform.position -= Vector3.down * Time.deltaTime;
                curDist -= Time.deltaTime;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //depress
        depress = true;
        activateObject.setButtonPress(depress);
        //DoThing to object here
    }
    private void OnTriggerStay(Collider other)
    {
        depress = true;
        activateObject.setButtonPress(depress);
    }
    private void OnTriggerExit(Collider other)
    {
        //repress
        depress = false;
        activateObject.setButtonPress(depress);
        //DoThing to object here
    }
}
