using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HitSideDetector : MonoBehaviour
{
    public XRBaseController racketController;
    private static readonly int TileColor = Shader.PropertyToID("_TileColor");

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            racketController.SendHapticImpulse(.5f, .5f);
            var renderer = collision.gameObject.GetComponent<MeshRenderer>();
            Debug.Log("hit");
            ContactPoint hit = collision.GetContact(0);
            float angle = Vector3.Angle(hit.normal, transform.forward);
            Debug.Log(angle);
            if (angle > 90)
            {
                Debug.Log("front");
                renderer.material.SetColor(TileColor, Color.blue);
            }
            else
            {
                Debug.Log("back");
                renderer.material.SetColor(TileColor, Color.red);
            }
        }
    }
}
