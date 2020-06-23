using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundEffects : MonoBehaviour {
    public AudioClip footStepSound;
    public AudioSource source;
    public void TriggerFootstepSound()
    {
        source.PlayOneShot(footStepSound);
    }
}
