using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatueBehavoir : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject player;
    // Update is called once per frame
    void Update()
    {
        RaycastHit ray;
        int mask = LayerMask.GetMask("Phyiscal") | LayerMask.GetMask("Ghost");
        mask = ~mask;
        bool t = Physics.Raycast(this.transform.position, player.transform.position - transform.position, out ray, 100f,mask) && player.GetComponent<GhostModeController>().ghostMode;
        if (t && ray.collider.tag == "Player")
        {
            float angleBetween = Vector3.Angle(player.transform.position - transform.position, transform.right);
            float s = -Input.GetAxis("Horizontal");
            this.transform.Rotate(Vector3.up, Mathf.Sign(s)*angleBetween * Time.deltaTime);
        }
        
    }
}
