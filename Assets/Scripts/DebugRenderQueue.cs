using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class DebugRenderQueue : MonoBehaviour
{
    public int renderQueue;

    void OnEnable()
    {
        UpdateRenderQueue();
    }

    void Update()
    {
        UpdateRenderQueue();
    }

    void UpdateRenderQueue()
    {
        renderQueue = 0;
        var rendererObj = GetComponent<Renderer>();
        if (null != rendererObj)
        {
            renderQueue = rendererObj.sharedMaterial.renderQueue;
        }
        else
        {
            var panel = GetComponent<UIPanel>();
            if (null != panel)
            {
                if (0 < panel.drawCalls.Count)
                {
                    renderQueue = panel.drawCalls[0].dynamicMaterial.renderQueue;
                }
            }
        }
    }
}
