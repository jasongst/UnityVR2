using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitSideDetector : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            var renderer = collision.gameObject.GetComponent<MeshRenderer>();
            Debug.Log("hit");
            ContactPoint hit = collision.GetContact(0);
            float angle = Vector3.Angle(hit.normal, transform.forward);
            Debug.Log(angle);
            if (angle > 90)
            {
                Debug.Log("front");
                renderer.material.color = Color.red;
            }
            else
            {
                Debug.Log("back");
                renderer.material.color = Color.blue;
            }
        }
    }
}
