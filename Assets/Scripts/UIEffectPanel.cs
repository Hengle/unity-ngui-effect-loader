using UnityEngine;
using System.Collections;

public class UIEffectPanel : UIPanel
{
    int oldRenderQueue;

    protected override void OnEnable()
    {
        renderQueue = RenderQueue.Automatic;
        oldRenderQueue = startingRenderQueue;
        UpdateRenderQueue();
        base.OnEnable();
    }

    [ContextMenu("UpdateRenderQueue")]
    public void UpdateRenderQueue()
    {
        var Renderers = transform.GetComponentsInChildren<Renderer>();

        if (null != Renderers)
        {
            for (int i = 0; i < Renderers.Length; ++i)
            {
                Renderers[i].sharedMaterial.renderQueue = this.startingRenderQueue;
            }
        }
    }

	protected override void OnUpdate()
    {
        if (oldRenderQueue != startingRenderQueue)
        {
            oldRenderQueue = startingRenderQueue;
            UpdateRenderQueue();
        }
        base.OnUpdate();
    }
}
