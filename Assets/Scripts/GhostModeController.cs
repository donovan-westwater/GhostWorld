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
    [SerializeField]
    private string GhostExitPath;
    [SerializeField]
    private string GhostEnterPath;
    
    // Start is called before the first frame update
    void Start()
    {
        mask = LayerMask.GetMask("Physical") | LayerMask.GetMask("Window");
        Physics.IgnoreLayerCollision(this.transform.gameObject.layer, 7,true);
        Physics.IgnoreLayerCollision(this.transform.gameObject.layer, 3, true);
        DollModel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        canReturn = Physics.Raycast(guide.transform.position, guide.transform.forward,out hit, 100000f, ~mask);
        if (hit.collider == null || hit.collider.tag != "Body") canReturn = false;
        if (Input.GetKeyDown(KeyCode.E))
        {    
            if(!ghostMode) playerGhostSwitch();
            else if(ghostMode && (Vector3.Distance(transform.position,DollModel.transform.position) < 1f || canReturn)) playerGhostSwitch();
        }
    }
    public bool playerGhostSwitch()
    {
        ghostMode = !ghostMode;
        if (DollModel) DollModel.SetActive(ghostMode);
        if (ghostMode)
        {
            FMODUnity.RuntimeManager.PlayOneShot(GhostExitPath, this.transform.position);
            DollModel.transform.position = this.transform.position;
        }
        else
        {
            FMODUnity.RuntimeManager.PlayOneShot(GhostEnterPath, this.transform.position);
            this.transform.position = DollModel.transform.position;
        }
        justSpawned = ghostMode;
        Physics.IgnoreLayerCollision(this.transform.gameObject.layer, 7, !ghostMode);
        Physics.IgnoreLayerCollision(this.transform.gameObject.layer, 6, ghostMode);
        activateModeSwitch?.Invoke();
        return ghostMode;
    }
}
