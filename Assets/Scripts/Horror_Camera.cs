using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MO_HORROR {
    public class Horror_Camera : MonoBehaviour {

        public bool lookAtTargetEnabled = true;

        private bool isInitialized = false;

        // child camera, used while player is in targetArea
        new Camera camera;
        Quaternion lookTarget;
        Horror_Player player;
        AudioListener listener;

        private void Start()
        {
            listener.enabled = false;
            camera.enabled = false;
            StartCoroutine("DelayedStart");
        }

        IEnumerator DelayedStart()
        {
            if (GameManager.Instance.isInitialized)
            {
                player = GameManager.Instance.player;
                isInitialized = true;
                GameManager.Instance.DebugLog("initialized = " + isInitialized);
            }
            else
            {
                yield return new WaitForFixedUpdate();
                StartCoroutine("DelayedStart");
            }
        }

        private void LateUpdate()
        {
            if (isInitialized)
            {
                if (lookAtTargetEnabled)
                {
                    lookTarget = Quaternion.LookRotation(player.lookingAt.transform.position - camera.transform.position);
                    // camera.transform.LookAt(player.transform);
                    camera.transform.rotation = lookTarget;
                }
            }
        }

        private void OnValidate()
        {
            camera = GetComponentInChildren<Camera>();
            listener = camera.gameObject.GetComponent<AudioListener>();

            if (camera == null)
                camera = Instantiate(new Camera());
            if (listener == null)
                camera.gameObject.AddComponent<AudioListener>();
            listener.enabled = false;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
                Activate();
            }
        }

        // disables all other rendertotexture cameras
        private void Activate()
        {
            GameManager.Instance.DeactivateAllHorror_Cameras();
            camera.enabled = true;
            listener.enabled = true;
        }

        public void Deactivate()
        {
            camera.enabled = false;
            listener.enabled = false;
        }


    }
}