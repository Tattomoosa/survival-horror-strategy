using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MO_HORROR
{
    public class GameManager : Singleton<GameManager>
    {

        // singleton
        protected GameManager() { }

        // is debug mode enabled?
        public bool isDebugMode = false;

        // is game paused?
        public bool gameplayPaused = false;
        // is game manager initialized?
        public bool isInitialized = false;
        // reference to the player
        public Horror_Player player;

        private void Start()
        {
            DebugLog("GameManager initialized");
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Horror_Player>();

            isInitialized = true;
        }

        public float GameplayDeltaTime
        {
            get
            {
                if (!gameplayPaused)
                    return Time.deltaTime;
                else
                    return 0.0f;
            }
        }

        public void SetPause(bool value)
        {
            gameplayPaused = value;
        }

        /*
        // disables all cameras that render to a texture
        public void DisableAllRenderToTextureCameras()
        {
            // allCameras only returns enabled cameras
            // so this just shuts off any enabled cameras that render to a texture
            foreach (Camera c in Camera.allCameras)
            {
                // if camera has a rendertexture
                if (c.activeTexture != null)
                    c.enabled = false;
            }
        }
        */

        // disables all Horror_Camera s
        public void DeactivateAllHorror_Cameras()
        {
            foreach (Camera c in Camera.allCameras)
            {
                Horror_Camera hc = c.gameObject.GetComponentInParent<Horror_Camera>();
                if (hc != null)
                    hc.Deactivate();
            }
        }

        public void DebugLog(string str)
        {
            if (isDebugMode)
                Debug.Log("[" + Time.timeSinceLevelLoad + "] " + str);
        }

    }
}
