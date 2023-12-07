using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RacketSoundEffects : MonoBehaviour
{
    private AudioSource ballHit;
    private AudioSource racketSwoosh;

    public AudioClip ballHitClip;
    public AudioClip racketSwooshClip;
    
    private bool firstPlayed = false;
    private bool swooshPlayed = false;

    // Start is called before the first frame update
    void Start()
    {
        initSources();
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody racketRb = gameObject.GetComponent<Rigidbody>();
        if( swooshPlayed == false && (racketRb.velocity.x > 0.7f || racketRb.velocity.y > 0.7f || racketRb.velocity.z > 0.7f) )
        {
            Debug.Log("Vitesse");
            racketSwoosh.Play();
            swooshPlayed = true;
        }

        if (swooshPlayed == true && (racketRb.velocity.x < 0.1f && racketRb.velocity.y < 0.1f && racketRb.velocity.z < 0.1f))
        {
            Debug.Log("Reset vitesse");
            swooshPlayed = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Ball"))
        {
            //Ignore first sound, Comment if not needed

            if(firstPlayed ==  false)
            {
                firstPlayed = true;
            }
            else
            {
                ballHit.Play();
            }
            
        }
    }

    private void initSources()
    {
        gameObject.AddComponent<AudioSource>();
        gameObject.AddComponent<AudioSource>();

        var audioSources = GetComponents<AudioSource>();

        ballHit = audioSources[0];
        ballHit.clip = ballHitClip;
        ballHit.loop = false;
        ballHit.volume = 1.0f;

        racketSwoosh = audioSources[1];
        racketSwoosh.clip = racketSwooshClip;
        racketSwoosh.loop = false;
        racketSwoosh.volume = 1.0f;

        Debug.Log(ballHit.clip.name.ToString());
        Debug.Log(racketSwoosh.clip.name.ToString());
    }
}
