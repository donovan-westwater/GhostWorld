using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullscreenShader : MonoBehaviour
{
    [SerializeField]
    GhostModeController player;
    public Shader awesomeShader = null;
    public RenderTexture camText;
    private Material m_renderMaterial;
    private Material m_RenderTextureMaterial;
    public bool ghostVision = false;

    void Start()
    {
        if (awesomeShader == null)
        {
            Debug.LogError("no awesome shader.");
            m_renderMaterial = null;
            return;
        }
        if (player) player.activateModeSwitch += this.activateGhostVision;
        m_renderMaterial = new Material(awesomeShader);
        
    }

    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {        
        if(ghostVision) Graphics.Blit(source, destination, m_renderMaterial);
        else
        {
            //source.width = source.width / 2;
            //source.height = source.height / 2;
            Graphics.Blit(camText, destination);
        }
    }
    void activateGhostVision()
    {
        ghostVision = !ghostVision;
    }
}
