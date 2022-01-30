using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Window : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject player;
    public GameObject guide;
    public GameObject exitOrb;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (player) player.GetComponent<GhostModeController>().activateModeSwitch += this.OnModeSwitch;
        exitOrb.SetActive(false);
    }


    void OnModeSwitch()
    {
        RaycastHit[] raycastHits = Physics.RaycastAll(player.transform.position, -guide.transform.forward, 1000, LayerMask.GetMask("Window"));
        if (player.GetComponent<GhostModeController>().ghostMode == false)
        {
            if (raycastHits.Length == 3)
            {
                exitOrb.SetActive(true);
            }
        }
    }
}
