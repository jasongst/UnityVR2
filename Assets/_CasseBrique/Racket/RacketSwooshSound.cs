using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RacketSwooshSound : MonoBehaviour
{
    private AudioSource racketSwoosh;

    public AudioClip racketSwooshClip;

    private bool swooshPlayed = false;

    public float minVelocity = 5f;

    // Start is called before the first frame update
    void Start()
    {
        initSources();
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody racketRb = gameObject.GetComponent<Rigidbody>();
        if (swooshPlayed == false && (racketRb.velocity.x > minVelocity || racketRb.velocity.y > minVelocity || racketRb.velocity.z > minVelocity))
        {
            racketSwoosh.Play();
            swooshPlayed = true;
        }

        if (swooshPlayed == true && (racketRb.velocity.x < 0.1f && racketRb.velocity.y < 0.1f && racketRb.velocity.z < 0.1f))
        {
            swooshPlayed = false;
        }
    }

    private void initSources()
    {

        racketSwoosh = gameObject.AddComponent<AudioSource>();
        racketSwoosh.clip = racketSwooshClip;
        racketSwoosh.loop = false;
        racketSwoosh.volume = 1.0f;

        Debug.Log(racketSwoosh.clip.name.ToString());
    }
}
