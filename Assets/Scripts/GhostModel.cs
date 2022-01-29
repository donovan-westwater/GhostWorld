using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostModel : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    GhostModeController player;
    public float radius = 5f;

    private void Update()
    {
        if (player.justSpawned)
        {
            if (Vector3.Distance(transform.position, player.transform.position) > radius) player.justSpawned = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (player.justSpawned) return;
        player.playerGhostSwitch();
    }
}
