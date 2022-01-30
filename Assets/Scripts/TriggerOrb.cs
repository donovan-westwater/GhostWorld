using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerOrb : MonoBehaviour
{
    public bool puzzleDone = false;
    public bool endGameTrigger = false;
    GhostModeController player;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<GhostModeController>();
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Fuck yes you did it champ. Good for you. yep. So good. Fuck yes. Uh huh. yes . great. yep");
        if (!player.ghostMode)
        {
            puzzleDone = true;
            FMODUnity.RuntimeManager.PlayOneShot("event:/PuzzleDone", this.transform.position);
            this.transform.gameObject.GetComponent<Collider>().enabled = false;
            this.transform.gameObject.GetComponent<MeshRenderer>().enabled = false;
            if (endGameTrigger)
            {
                Application.Quit(0);
            }
        }
    }
}
