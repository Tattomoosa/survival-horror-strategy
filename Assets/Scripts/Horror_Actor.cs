using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MO_HORROR
{
    public class Horror_Actor : MonoBehaviour
    {
        [Header("Base Class")]
        [System.NonSerialized]
        public AudioSource audioSource;
        public Animator animator;

        // Use this for initialization
        public void Start()
        {
        }

        public void OnValidate()
        {
            audioSource = transform.GetOrAddComponent<AudioSource>();
        }

        public void FixedUpdate()
        {
            // if game is paused
            if (GameManager.Instance.gameplayPaused)
            {
                animator.enabled = false;
            }
            else
            {
                animator.enabled = true;
            }
        }
    }
}
