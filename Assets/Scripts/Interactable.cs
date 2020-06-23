using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MO_HORROR
{
    public class Interactable : MonoBehaviour
    {

        public string text = "default text";

        private bool canInteract = false;
        private bool isClosing = false;

        // Update is called once per frame
        void Update()
        {
            if (canInteract)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    // Debug.Log("space pressed " + Time.deltaTime);
                    UIManager.Instance.TriggerTextBox(this);
                    canInteract = false;
                }
            }
            // can't interact on same frame as the UI closes,
            // because we get stuck opening it again instantly
            if (isClosing)
            {
                isClosing = false;
                canInteract = true;
                UIManager.Instance.SetCanInteractPrompt(true);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
                canInteract = true;
                UIManager.Instance.SetCanInteractPrompt(true);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.tag == "Player")
            {
                canInteract = false;
                UIManager.Instance.SetCanInteractPrompt(false);
            }
        }

        public void OnClose()
        {
            isClosing = true;
        }
    }
}
