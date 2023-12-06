using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Events;

public class Ball : MonoBehaviour
{
    public UnityEvent breakBrickCallbacks;

    public float timeBeforeDestroy = 0.150f;

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
}
