using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class footStep : MonoBehaviour
{
    public static footStep sndMan;
    public AudioSource audioSrc;
    private Rigidbody rigidB;
    public AudioClip[] grassAudioClips;

    // Start is called before the first frame update
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
        rigidB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (StrafeMovement.onGround == true && rigidB.velocity.magnitude > 2 && audioSrc.isPlaying == false)
        {
            playRandomGrass();

        }
    }

    void playRandomGrass()
    {
        audioSrc.clip = grassAudioClips[Random.Range(0, grassAudioClips.Length)];
        audioSrc.Play();
    }
        

    
}
