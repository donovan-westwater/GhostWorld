using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public delegate void GhostProjection(); //Delgate to switch mode
public class GhostModeController : MonoBehaviour
{
    public event GhostProjection activateModeSwitch;
    public bool ghostMode = false;
    public bool justSpawned = false;
    [SerializeField]
    GameObject DollModel;
    // Start is called before the first frame update
    void Start()
    {
        Physics.IgnoreLayerCollision(this.transform.gameObject.layer, 7,true);
        Physics.IgnoreLayerCollision(this.transform.gameObject.layer, 3, true);
        DollModel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if(!ghostMode) playerGhostSwitch();
            else if(ghostMode && Vector3.Distance(transform.position,DollModel.transform.position) < 2f) playerGhostSwitch();
        }
    }
    public bool playerGhostSwitch()
    {
        ghostMode = !ghostMode;
        if (DollModel) DollModel.SetActive(ghostMode);
        DollModel.transform.position = this.transform.position;
        justSpawned = ghostMode;
        Physics.IgnoreLayerCollision(this.transform.gameObject.layer, 7, !ghostMode);
        Physics.IgnoreLayerCollision(this.transform.gameObject.layer, 6, ghostMode);
        activateModeSwitch?.Invoke();
        return ghostMode;
    }
}
