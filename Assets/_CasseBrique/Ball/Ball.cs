using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("collison with ball");
        GameObject otherObject = other.gameObject;
        if (otherObject.CompareTag("Brick"))
        {
            Destroy(otherObject, 1);
            Debug.Log("Destroyed cube");
        }
    }
}
