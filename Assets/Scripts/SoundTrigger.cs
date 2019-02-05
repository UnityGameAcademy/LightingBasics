using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class SoundTrigger : MonoBehaviour
{
    [SerializeField]
    private AudioClip sound;
    private bool hasPlayed = false;

    private void OnTriggerEnter(Collider other)
    {
        if (sound != null && !hasPlayed)
        {
            AudioSource.PlayClipAtPoint(sound, transform.position);
            hasPlayed = true;
        }
    }



}
