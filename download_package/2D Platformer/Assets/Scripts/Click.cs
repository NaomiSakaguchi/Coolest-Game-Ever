using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click : MonoBehaviour
{
    public AudioSource myAudio;
    public AudioClip click, closeClick;

    public void PlayClick()
    {
        myAudio.PlayOneShot(click);
    }

    public void CloseClick()
    {
        myAudio.PlayOneShot(closeClick);
    }
}
