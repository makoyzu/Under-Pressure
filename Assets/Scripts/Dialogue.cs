using UnityEngine;

[CreateAssetMenu(fileName ="NewNPCDialogue", menuName ="NPC Dialogue")]

public class Dialogue : ScriptableObject
{
    public Sprite npcOne, npcTwo;
    public string[] dialogueLines;
    public float typingSpeed = 0.05f;
    public AudioClip voiceSound;
    public AudioClip endVoiceSound;
    public float voicePitch = 1f;
    public Dialogue nextDialogue;
    public string endCommand;
}

