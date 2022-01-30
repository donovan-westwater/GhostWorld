using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDoor : MonoBehaviour
{
    // Start is called before the first frame update
    public TriggerOrb[] keys;
    bool allKeysActive = false;
    float curDist = 0;
    Vector3 curAngle = new Vector3(0, 0, 0);
    public float moveDist = 5f;
    public Vector3 moveDir = new Vector3(0, 1, 0);
    //public float rotateAngle = 0;
    public Vector3 rotateAngle = new Vector3(0, 0, 0);
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        int count = 0;
        foreach(TriggerOrb o in keys)
        {
            if (o.puzzleDone) count++;
        }
        if (count >= 4)
        {
            if (curDist < moveDist)
            {
                this.transform.position += moveDir * Time.deltaTime;
                curDist += Time.deltaTime;
            }
            if (curAngle.x < rotateAngle.x || curAngle.y < rotateAngle.y || curAngle.z < rotateAngle.z)
            {
                this.transform.Rotate(rotateAngle * Time.deltaTime);
                curAngle += rotateAngle * Time.deltaTime;
            }
        }
        else
        {
            if (curDist > 0)
            {
                this.transform.position -= moveDir * Time.deltaTime;
                curDist -= Time.deltaTime;
            }
            if (curAngle.x > 0 || curAngle.y > 0 || curAngle.z > 0)
            {
                this.transform.Rotate(-rotateAngle * Time.deltaTime);
                curAngle -= rotateAngle * Time.deltaTime;
            }
        }
    }
}
