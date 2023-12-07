using System.Collections;
using System.Collections.Generic;
using _CasseBrique;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HitSideDetector : MonoBehaviour
{
    public XRBaseController racketController;
    private static readonly int TileColor = Shader.PropertyToID("_TileColor");

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
            if (angle > 90)
            {
                Debug.Log("front");
                Debug.Log(ball);
                // front of the racket
                ball.applyGraphics(new BallGraphicsParams(Color.blue, Color.cyan));
                
            }
            else
            {
                Debug.Log("back");

                // back of the racket
                ball.applyGraphics(new BallGraphicsParams(Color.red, Color.magenta));
            }
        }
    }
}
