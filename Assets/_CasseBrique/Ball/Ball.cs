using System;
using System.Collections;
using System.Collections.Generic;
using _CasseBrique;
using _CasseBrique.Brick;
using _CasseBrique.Racket;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class Ball : MonoBehaviour
{
    public UnityEvent breakBrickCallbacks;

    public GameObject graphicsGameObject;
    public GameObject brickParticles;
    public GameObject rippleParticles;

    public AudioClip brickDestroyedClip;
    private AudioSource brickDestroyedSource;
    
    public float timeBeforeDestroy = 0.150f;
    
    private static readonly int TileColor = Shader.PropertyToID("_TileColor");
    private static readonly int GridColor = Shader.PropertyToID("_GridColor");

    public RacketHitSide racketHitSide;

    public BallGraphicsParams frontSideHitGraphics = new BallGraphicsParams(Color.blue, Color.cyan);
    public BallGraphicsParams backSideHitGraphics = new BallGraphicsParams(Color.red, Color.magenta);
    
    private void Start()
    {
        Assert.IsTrue(breakBrickCallbacks.GetPersistentEventCount() > 0, "[BALL] breakBrickCallbacks is unset !");

        brickDestroyedSource = gameObject.AddComponent<AudioSource>();
        brickDestroyedSource.loop = false;
        brickDestroyedSource.clip = brickDestroyedClip;
        brickDestroyedSource.volume = 1.0f;
        brickDestroyedSource.pitch = 1.0f;
    }

    private void OnCollisionEnter(Collision other)
    {
        GameObject otherObject = other.gameObject;
        if (otherObject.CompareTag("Brick"))
        {
            Brick brick = other.gameObject.GetComponent<Brick>();
            
            if (
                (this.racketHitSide == RacketHitSide.Front && brick.type == BrickType.FrontRacket) 
                || (this.racketHitSide == RacketHitSide.Back && brick.type == BrickType.BackRacket)
                )
            {
                GameObject brickDestroyedParticles = Instantiate(brickParticles, otherObject.transform.position, Quaternion.identity);
                brickDestroyedParticles.GetComponent<ParticleSystem>().Play();

                brickDestroyedSource.Play();
                Destroy(otherObject, timeBeforeDestroy);
                Invoke(nameof(invokeCallbacks), timeBeforeDestroy);
            }
        }
        else if (otherObject.CompareTag("WallSide"))
        {
            GameObject rippleEffect = Instantiate(rippleParticles, new Vector3(otherObject.transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            rippleEffect.transform.Rotate(new Vector3(0, 90, 0));
            rippleEffect.GetComponent<ParticleSystem>().Play();
        }
    }

    private void invokeCallbacks()
    {
        breakBrickCallbacks.Invoke();
    }

    public void racketHit(RacketHitSide hitSide)
    {
        racketHitSide = hitSide;
        applyGraphics(racketHitSide == RacketHitSide.Front ? frontSideHitGraphics : backSideHitGraphics);
    }

    private void applyGraphics(BallGraphicsParams newGraphicsParams)
    {
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