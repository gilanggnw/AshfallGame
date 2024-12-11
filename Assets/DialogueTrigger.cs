using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class DialogueTrigger : MonoBehaviour
{
    public NPCConversation TextConversation;

    public void Start()
    {
        ConversationManager.Instance.StartConversation(TextConversation);
    }

}
