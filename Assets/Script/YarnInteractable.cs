using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

//This is a script to run the dialog when the NPC walks up too the User

public class YarnInteractable : MonoBehaviour
{
    // internal properties exposed to editor
    [SerializeField] private string conversationStartNode;

    // internal properties not exposed to editor
    private DialogueRunner dialogueRunner;
    private bool interactable = true;
    private bool isCurrentConversation = false;
    private float defaultIndicatorIntensity;
    public Animator animator;



    public void Start()
    {
        dialogueRunner = FindObjectOfType<Yarn.Unity.DialogueRunner>();
        dialogueRunner.onDialogueComplete.AddListener(EndConversation);   
    }

    void OnTriggerEnter(Collider other)
    {
        //This is to make the NPC react when they get close to the player
        if (other.CompareTag("Player"))
        {
            animator.SetBool("StopWalking", true);
            Debug.Log("StartConvo");
            if (interactable && !dialogueRunner.IsDialogueRunning)
            {
                StartConversation();
                Debug.Log("StartConvo");
            }
        }
    }

    private void StartConversation()
    {
        Debug.Log($"Started conversation with {name}.");
        isCurrentConversation = true;
        dialogueRunner.StartDialogue(conversationStartNode);
    }

    private void EndConversation()
    {
        if (isCurrentConversation)
        {
            isCurrentConversation = false;
            Debug.Log($"Ended conversation with {name}.");
            animator.SetBool("Leave", true);
        }
    }

    //    [YarnCommand("disable")]
    public void DisableConversation()
    {
        interactable = false;
    }
}