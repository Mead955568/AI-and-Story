using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class AnimationSetUp : MonoBehaviour
{
    public Animator animator;

    public bool Start1;
    public bool Start2;
    public bool Start3;
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
        if (animator.GetBool("Leave") == true)
        {
            yarnInMemoryStorage.TryGetValue("$Start2", out Start2);
            Debug.Log(Start2);
            if (Start2 == true)
            {
                animator.SetBool("StartWalking", true);
                if (animator.GetBool("Leave") == true)
                {
                    yarnInMemoryStorage.TryGetValue("$Start3", out Start3);
                    Debug.Log(Start3);
                    if (Start3 == true)
                    {
                        animator.SetBool("StartWalking", true);
                    }
                }
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
}

