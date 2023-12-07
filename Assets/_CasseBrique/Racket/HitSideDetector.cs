using System.Collections;
using System.Collections.Generic;
using _CasseBrique;
using _CasseBrique.Racket;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HitSideDetector : MonoBehaviour
{
    public XRBaseController racketController;

    private void OnCollisionEnter(Collision collision)
    {
        GameObject gameObject = collision.gameObject;
        if (gameObject.CompareTag("Ball"))
        {
            racketController.SendHapticImpulse(.5f, .5f);
            
            var renderer = gameObject.GetComponent<MeshRenderer>();
            ContactPoint hit = collision.GetContact(0);
            float angle = Vector3.Angle(hit.normal, transform.forward);
            
            Ball ball = gameObject.GetComponent<Ball>();
            ball.racketHit(angle > 90 ? RacketHitSide.Front : RacketHitSide.Back);
                
        }
    }
}
