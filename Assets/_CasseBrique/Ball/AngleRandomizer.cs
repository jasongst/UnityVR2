using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngleRandomizer : MonoBehaviour
{
    private Rigidbody rb;
    public float addedForce;
    public float randomRange;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Racket"))
        {
            Vector3 normal = collision.contacts[0].normal;
            Vector3 vel = rb.velocity;


            Vector3 reflect = Vector3.Reflect(vel, normal);
            Vector3 reflectNormalized = reflect.normalized;
            float reflectMagnitude = reflect.magnitude;

            reflectNormalized.x += Random.Range(-randomRange, randomRange);
            reflectNormalized.y += Random.Range(-randomRange, randomRange);
            reflectNormalized.z += Random.Range(-randomRange, randomRange);

            rb.velocity = reflectNormalized * reflectMagnitude;
        }
    }
}
