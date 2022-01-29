using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostObject : MonoBehaviour
{
    //Used to trigger animations and other effects
    public GhostModeController player;
    public Material ghost;
    public Material physical;
    float timer = 0;
    float diss = 0;
    public bool ghostObject = false;
    bool ghostMode = false;
    // Start is called before the first frame update

    void Start()
    {
        if (player) player.activateModeSwitch += this.OnActivateModeSwitch;
        if (ghostObject)
        {
            this.transform.gameObject.GetComponent<MeshRenderer>().material = ghost;
            ghostMode = ghostObject;
        }

    }
    private void Update()
    {
        timer += Time.deltaTime;
        if (ghostMode)
        {
            if (diss < .5f)
            {
                ghost.SetFloat("_DissolveAmount", Mathf.Sin(timer / 4f));
                diss = Mathf.Sin(timer / 4f);
            }
            else ghost.SetFloat("_DissolveAmount", diss+ 0.1f*Mathf.Sin(timer / 4f));
            
        }
    }
    public void OnActivateModeSwitch()
    {
        Debug.Log("Mode switch at: " + this.transform.position);
        ghostMode = !ghostMode;
        if (ghostMode)
        {
            this.transform.gameObject.GetComponent<MeshRenderer>().material = ghost;
            ghost.SetFloat("_DissolveAmount", 1);
        }
        else this.transform.gameObject.GetComponent<MeshRenderer>().material = physical;
        timer = 0;
    }
}
