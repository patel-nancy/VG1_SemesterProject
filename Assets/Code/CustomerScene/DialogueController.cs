using TMPro;
using UnityEngine;

    public class DialogueController : MonoBehaviour
    {
        [SerializeField] TMP_Text dialogueText;

        void Start()
        {
            // Debug.Log("[DialogueController] Start");
            if (dialogueText != null)
            {
                dialogueText.text = "Hello, I want a potion!";
                // Debug.Log("[DialogueController] Initial line set");
            }
        }

        public void SetLine(string line)
        {
            if (dialogueText != null)
            {
                dialogueText.text = line;
                // Debug.Log($"[DialogueController] SetLine: {line}");
            }
            else
            {
                // Debug.LogWarning("[DialogueController] SetLine called but dialogueText is null");
            }
        }
    }
