using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundController : MonoBehaviour
{
    private AudioSource audioSource;

    public AudioClip swipe, land;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void playSwipeClip()
    {
        if(audioSource.enabled)
            audioSource.PlayOneShot(swipe, 0.5f);
    }

    public void playLandClip()
    {
        if (audioSource.enabled)
            audioSource.PlayOneShot(land, 0.08f);
    }

    public void SoundOnOrOff()
    {
        if (audioSource.enabled)
            audioSource.enabled = false;
        else if(!audioSource.enabled)
            audioSource.enabled = true;
    }
}
