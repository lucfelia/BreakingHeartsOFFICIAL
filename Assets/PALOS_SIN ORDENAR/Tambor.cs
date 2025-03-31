using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tambor : MonoBehaviour
{
    public AudioClip hitSound; 
    private AudioSource audioSource;

    void Start()
    {
        
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Palo"))
        {
            Debug.Log("Drum Hit by Stick!");
            PlayHitSound();
            AnimateDrum();
        }
    }

    void PlayHitSound()
    {
        if (hitSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(hitSound);
        }
    }

    void AnimateDrum()
    {
       
        Debug.Log("Drum Animated!");
    }
}
