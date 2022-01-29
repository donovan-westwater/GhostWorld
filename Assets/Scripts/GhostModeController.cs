using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public delegate void GhostProjection(); //Delgate to switch mode
public class GhostModeController : MonoBehaviour
{
    public event GhostProjection activateModeSwitch;
    public bool ghostMode = false;
    LayerMask mask;
    bool canReturn = false;
    public bool justSpawned = false;
    [SerializeField]
    GameObject DollModel;
    [SerializeField]
    GameObject guide;
    // Start is called before the first frame update
    void Start()
    {
        mask = LayerMask.GetMask("Physical");
        Physics.IgnoreLayerCollision(this.transform.gameObject.layer, 7,true);
        Physics.IgnoreLayerCollision(this.transform.gameObject.layer, 3, true);
        DollModel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        canReturn = Physics.Raycast(guide.transform.position, guide.transform.forward, 100000f, ~mask);
        if (Input.GetKeyDown(KeyCode.E))
        {    
            if(!ghostMode) playerGhostSwitch();
            else if(ghostMode && (Vector3.Distance(transform.position,DollModel.transform.position) < 2f || canReturn)) playerGhostSwitch();
        }
    }
    public bool playerGhostSwitch()
    {
        ghostMode = !ghostMode;
        if (DollModel) DollModel.SetActive(ghostMode);
        if(ghostMode) DollModel.transform.position = this.transform.position;
        else this.transform.position = DollModel.transform.position;
        justSpawned = ghostMode;
        Physics.IgnoreLayerCollision(this.transform.gameObject.layer, 7, !ghostMode);
        Physics.IgnoreLayerCollision(this.transform.gameObject.layer, 6, ghostMode);
        activateModeSwitch?.Invoke();
        return ghostMode;
    }
}
