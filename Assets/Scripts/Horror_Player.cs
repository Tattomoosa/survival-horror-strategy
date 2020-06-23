using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MO_HORROR
{
    public class Horror_Player : Horror_Actor
    {
        [Header("Player Class")]
        public float rotateSpeed = 50.0f;
        public float moveForwardSpeed = 5.0f;
        public float strafeSpeed = 4.0f;
        public float moveBackwardSpeed = 2.0f;
        public AudioClip flashlightClickSound;

        public GameObject lookingAt;
        public GameObject flashlight;

        bool isHoldingFlashlight = false;
        public bool hasFlashlight = true;

        public AudioClip footstepSound;


        private new void Start()
        {
            base.Start();
            flashlight.SetActive(false);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.F))
                ToggleFlashlight();
            if (Input.GetKeyDown(KeyCode.R))
                Attack();
        }

        new void OnValidate()
        {
            base.OnValidate();
        }

        new void FixedUpdate()
        {
            base.FixedUpdate();

            float rotateAmount = 0;
            float moveAmount = 0;
            float strafeAmount = 0;
            float dt = GameManager.Instance.GameplayDeltaTime;

            if (Input.GetKey(KeyCode.A))
                rotateAmount = -1;
            if (Input.GetKey(KeyCode.D))
                rotateAmount = 1;

            if (Input.GetKey(KeyCode.W))
                moveAmount = 1 * moveForwardSpeed;
            if (Input.GetKey(KeyCode.S))
                moveAmount = -1 * moveBackwardSpeed;

            if (Input.GetKey(KeyCode.E))
                strafeAmount = 1 * strafeSpeed;
            if (Input.GetKey(KeyCode.Q))
                strafeAmount = -1 * strafeSpeed;

            transform.Rotate(0, rotateAmount * rotateSpeed * dt, 0);
            transform.Translate(Vector3.forward * moveAmount * dt);
            transform.Translate(Vector3.right * strafeAmount * dt);
            animator.SetFloat("speed", Mathf.Max(
                Mathf.Abs(moveAmount),
                Mathf.Abs(strafeAmount)
                ));
            animator.SetFloat("rotateAmount", rotateAmount);
        }

        private void ToggleFlashlight()
        {
            isHoldingFlashlight = !isHoldingFlashlight;
            animator.SetBool("isHoldingFlashlight", isHoldingFlashlight);
            flashlight.SetActive(isHoldingFlashlight);
            audioSource.PlayOneShot(flashlightClickSound);
        }

        public void TriggerFootstepSound()
        {
            audioSource.PlayOneShot(footstepSound);
        }

        private void OnDrawGizmos()
        {
        }

        private void Attack()
        {
            animator.SetTrigger("startAttack");
        }
    }
}
