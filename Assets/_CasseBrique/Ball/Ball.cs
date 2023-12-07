using System;
using System.Collections;
using System.Collections.Generic;
using _CasseBrique;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Events;

public class Ball : MonoBehaviour
{
    public UnityEvent breakBrickCallbacks;

    public GameObject graphicsGameObject;
    
    public float timeBeforeDestroy = 0.150f;
    
    private static readonly int TileColor = Shader.PropertyToID("_TileColor");
    private static readonly int GridColor = Shader.PropertyToID("_GridColor");

    private void Start()
    {
        Assert.IsTrue(breakBrickCallbacks.GetPersistentEventCount() > 0, "[BALL] breakBrickCallbacks is unset !");
    }

    private void OnCollisionEnter(Collision other)
    {
        GameObject otherObject = other.gameObject;
        if (otherObject.CompareTag("Brick"))
        {
            Destroy(otherObject, timeBeforeDestroy);
            Invoke(nameof(invokeCallbacks), timeBeforeDestroy);
        }
    }

    private void invokeCallbacks()
    {
        breakBrickCallbacks.Invoke();
    }

    public void applyGraphics(BallGraphicsParams newGraphicsParams)
    {
        Debug.Log("applyGraphics");
        // Set the particles around the ball
        var ballParticleSystem = graphicsGameObject.GetComponent<ParticleSystem>().main;
        ballParticleSystem.startColor = newGraphicsParams.ballColor;
        
        // Set the trail color
        TrailRenderer ballTrail = graphicsGameObject.GetComponent<TrailRenderer>();
        ballTrail.startColor = newGraphicsParams.ballColor;
        ballTrail.endColor = newGraphicsParams.ballColor;

        MeshRenderer ballMeshRenderer = this.GetComponent<MeshRenderer>();
        
        // Set the ball color
        ballMeshRenderer.material.SetColor(TileColor, newGraphicsParams.ballColor);
        
        // Set the ball's grid color
        ballMeshRenderer.material.SetColor(GridColor, newGraphicsParams.gridColor);
        
    }
}