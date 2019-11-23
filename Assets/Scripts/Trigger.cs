using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public AudioClip triggerSound; //this is defining an AudioClip and naming it triggerSound
    AudioSource audioSource; //this is defining the adudioSource and naming it audioSource

    //use this for initiallzation
    void Start () {
        audioSource = GetComponent<AudioSource>(); 
    }

    void Update (){

    }

    private void OnTriggerEnter(Collider other)
    {
        if (triggerSound != null)
        {
            audioSource.PlayOneShot(triggerSound, 0.7F);
        }
    } 
}



