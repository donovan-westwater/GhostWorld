using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrabber : MonoBehaviour
{
    //Taken from this Forum post: https://answers.unity.com/questions/1268357/pick-upthrow-object.html 
    public float speed = 10;
    public bool canHold = true;
    public GameObject grabbable;
    public Transform guide;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!canHold)
                throw_drop();
            else
                Pickup();
        }//mause If

        if (!canHold && grabbable)
            grabbable.transform.position = guide.position;

    }//update

    //We can use trigger or Collision
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Grabbable")
            if (!grabbable) // if we don't have anything holding
                grabbable = col.gameObject;
    }

    //We can use trigger or Collision
    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Grabbable")
        {
            if (canHold)
                grabbable = null;
        }
    }


    private void Pickup()
    {
        if (!grabbable)
            return;

        //We set the object parent to our guide empty object.
        grabbable.transform.SetParent(guide);

        //Set gravity to false while holding it
        grabbable.GetComponent<Rigidbody>().useGravity = false;

        //we apply the same rotation our main object (Camera) has.
        grabbable.transform.localRotation = transform.rotation;
        //We re-position the ball on our guide object 
        grabbable.transform.position = guide.position;

        canHold = false;
    }

    private void throw_drop()
    {
        if (!grabbable)
            return;

        //Set our Gravity to true again.
        grabbable.GetComponent<Rigidbody>().useGravity = true;
        // we don't have anything to do with our ball field anymore
        grabbable = null;
        //Apply velocity on throwing
        guide.GetChild(0).gameObject.GetComponent<Rigidbody>().velocity = transform.forward * speed;

        //Unparent our ball
        guide.GetChild(0).parent = null;
        canHold = true;
    }
}
