using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public AudioSource dialogueSound;
    public Dialogue dialogueData;
    public GameObject dialoguePanel;
    public GameObject instructions;
    public TextMeshProUGUI dialogueText;
    public Image portraitImage;

    public BlackFadeOut blackFadeOut;

    private int dialogueIndex;
    private bool isTyping, isDialogueActive;
    private bool isStarted = false;
    private void Start()
    {
        StartDialogue();
    }
    private void OnMouseDown()
    {
        if (dialogueData == null || !isStarted)
            return;

        if (isDialogueActive)
        {
            NextLine();
        }
        else
        {
            StartDialogue();
        }
    }

    void StartDialogue()
    {
        if (!isStarted)
        {
            isStarted = true;
        }

        isDialogueActive = true;
        dialogueIndex = 0;

        dialoguePanel.SetActive(true);
        if (dialogueData.npcOne)
        {
            portraitImage.gameObject.SetActive(true);
        }

        StartCoroutine(TypeLine());

        StartCoroutine(NPCFrame());
    }

    void NextLine()
    {
        if (isTyping)
        {
            StopAllCoroutines();
            dialogueText.SetText(dialogueData.dialogueLines[dialogueIndex]);
            isTyping = false;
        }
        else if (++dialogueIndex < dialogueData.dialogueLines.Length)
        {
            StartCoroutine(TypeLine());
            StartCoroutine(NPCFrame());
        }
        else
        {
            EndDialogue();
            if (dialogueData.endCommand == "showInstructions")
            {
                instructions.SetActive(true);
            }

            if (dialogueData.nextDialogue)
            {
                dialogueData = dialogueData.nextDialogue;
                StartDialogue();
            }
        }
    }

    IEnumerator TypeLine()
    {
        isTyping = true;
        dialogueText.SetText("");
        dialogueSound.pitch = dialogueData.voicePitch;

        foreach (char letter in dialogueData.dialogueLines[dialogueIndex])
        {
            dialogueText.text += letter;
            if (dialogueText.text.Length == dialogueData.dialogueLines[dialogueIndex].Length && dialogueData.endVoiceSound)
            {
                dialogueSound.PlayOneShot(dialogueData.endVoiceSound);
            }
            else
            {
                dialogueSound.PlayOneShot(dialogueData.voiceSound);
            }
            yield return new WaitForSeconds(dialogueData.typingSpeed);
        }

        isTyping = false;
    }

    public void EndDialogue()
    {
        StopAllCoroutines();
        isDialogueActive = false;
        dialogueText.SetText("");
        dialoguePanel.SetActive(false);
        portraitImage.gameObject.SetActive(false);
    }

    private IEnumerator NPCFrame()
    {
        while (isTyping)
        {
            portraitImage.sprite = dialogueData.npcOne;
            yield return new WaitForSeconds(0.2f);
            portraitImage.sprite = dialogueData.npcTwo;
            yield return new WaitForSeconds(0.2f);
        }
    }
}
