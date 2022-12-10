using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class AnimationSetUp : MonoBehaviour
{
    public Animator animator;

    public bool Start1;
    public InMemoryVariableStorage yarnInMemoryStorage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    [YarnCommand("CheckYarnVariable")]
    public void CheckYarnVariable()
    {
        yarnInMemoryStorage.TryGetValue("$Start1", out Start1);
        Debug.Log(Start1);
        if (Start1 == true)
        {
            animator.SetBool("StartWalking", true);
        }
      
    }
    //private void OnTriggerEnter(Collider other)
    //{
    //    Debug.Log("StopWalking");
    //    if (other.CompareTag("Player"))
    //    {
    //        animator.SetBool("StopWalking", true);
    //    }
    //}
}
