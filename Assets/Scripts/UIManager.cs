using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MO_HORROR
{
    public class UIManager : Singleton<UIManager>
    {

        // singleton
        protected UIManager() { }

        public GameObject interactionText;
        public GameObject descriptionText;

        private Interactable currentTextbox;

        // Use this for initialization
        void Start()
        {
            interactionText.SetActive(false);
            descriptionText.SetActive(false);
        }

        // Update is called once per frame
        void Update()
        {
            TextBoxUpdate();
        }

        public void SetCanInteractPrompt(bool status)
        {
            interactionText.SetActive(status);
        }

        public void TriggerTextBox(Interactable interactable)
        {
            SetCanInteractPrompt(false);
            descriptionText.SetActive(true);
            descriptionText.GetComponentInChildren<Text>().text = interactable.text;
            GameManager.Instance.SetPause(true);
            currentTextbox = interactable;

            SoundManager.Instance.PlayCheckSound();
        }

        private void TextBoxUpdate()
        {
            if (descriptionText.activeSelf)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    EndTextBox();
                }
            }
        }
        private void EndTextBox()
        {
            SetCanInteractPrompt(true);
            descriptionText.SetActive(false);
            GameManager.Instance.SetPause(false);
            currentTextbox.OnClose();
        }
    }
}