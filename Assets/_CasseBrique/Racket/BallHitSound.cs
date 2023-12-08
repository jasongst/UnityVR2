using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BallHitSound : MonoBehaviour
{
    private AudioSource ballHit;

    public AudioClip ballHitClip;
    
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
        ballHit = gameObject.AddComponent<AudioSource>();
        ballHit.clip = ballHitClip;
        ballHit.loop = false;
        ballHit.volume = 1.0f;

        Debug.Log(ballHit.clip.name.ToString());
    }
}
