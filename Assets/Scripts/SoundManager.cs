using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MO_HORROR
{
    public class SoundManager : Singleton<SoundManager>
    {
        // singleton
        protected SoundManager() { }

        private AudioSource audioSource;

        [Header("UI Sounds")]
        public AudioClip checkSound;
        [Range(0, 1)]
        public float checkSoundVolume;

        public SoundEffect check;

        private void OnValidate()
        {
            audioSource = transform.GetOrAddComponent<AudioSource>();
        }

        private void PlayOneShot(AudioClip audioClip, float volumeScale)
        {
            audioSource.PlayOneShot(audioClip, volumeScale);
        }
        public void PlayCheckSound()
        {
            PlayOneShot(check.audioClip, check.volume);
        }
    }
}
