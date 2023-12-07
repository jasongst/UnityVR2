using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngleRandomizer : MonoBehaviour
{
    private Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Racket"))
        {
            rb.AddForce(-collision.contacts[0].normal + new Vector3(Random.Range(-1, 1), Random.Range(-1, 1), Random.Range(-1, 1)));
        }
    }
}
