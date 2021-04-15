using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetMaterialTransparency : MonoBehaviour
{
    private void Start()
    {
        SetMeshRendererTransparency();
    }

    private void OnTransformChildrenChanged()
    {
        SetMeshRendererTransparency();
    }

    private void SetMeshRendererTransparency()
    {
        var meshRenderers = GetComponentsInChildren<MeshRenderer>();
        foreach (var meshRenderer in meshRenderers)
        {
            meshRenderer.material.SetInt("_SurfaceType", 1);
            //meshRenderer.material.SetInt("_RendererQueueType", 4);
            var newColor = meshRenderer.material.color;
            newColor.a = 0.5f;
            meshRenderer.material.color = newColor;
        }
    }

    private void Update()
    {
        SetMeshRendererTransparency();
    }
}
