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

    public bool HappyWalk;
    public bool SadWalk;
    public bool AngryCrowd;
    public bool OkCrowd;
    public bool HappyCrowd;
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
        //This part is for making the NPC start the convo and activating annimation
        if (yarnInMemoryStorage.TryGetValue("$Start1", out Start1) && Start1 == true)
        {
            Debug.Log(Start1);
            animator.SetBool("StartWalking", true);
        }
        if (animator.GetBool("Leave") == true && yarnInMemoryStorage.TryGetValue("$Start2", out Start2) && Start2 == true)
        {
            Debug.Log(Start2);
            animator.SetBool("StartWalking", true);
            if (animator.GetBool("Leave") == true && yarnInMemoryStorage.TryGetValue("$Start3", out Start3) && Start3 == true)
            {
                Debug.Log(Start3);
                animator.SetBool("StartWalking", true);
            }
        }
        //This is about how the NPC leave the convo and annimation
        yarnInMemoryStorage.TryGetValue("$HappyWalk", out HappyWalk);
          if (HappyWalk == true)
          {
            Debug.Log(HappyWalk);
            animator.SetBool("HappyWalking", true);

        }
          yarnInMemoryStorage.TryGetValue("$AngryWalk", out SadWalk);
          if (SadWalk == true)
          {
            Debug.Log(SadWalk);
            animator.SetBool("SadWalking", true);
          }
          yarnInMemoryStorage.TryGetValue("$AngryClap", out AngryCrowd);

        //This part is about how the Crowd NPC react and annimation
          if (AngryCrowd == true)
          {
            Debug.Log(AngryCrowd);
            animator.SetBool("Stop", false);
            animator.SetBool("Angry", true);
            StartCoroutine(Delay1(_time));
        }
        yarnInMemoryStorage.TryGetValue("$OkClap", out OkCrowd);

        if (OkCrowd == true)
        {
            Debug.Log(OkCrowd);
            animator.SetBool("Stop", false);
            animator.SetBool("ok", true);
            StartCoroutine(Delay2(_time));
        }
        yarnInMemoryStorage.TryGetValue("$HappyClap", out HappyCrowd);

        if (HappyCrowd == true)
        {
            Debug.Log(HappyCrowd);
            animator.SetBool("Stop", false);
            animator.SetBool("Good", true);
            StartCoroutine(Delay3(_time));
        }
    }
    private Renderer _renderer;
    [SerializeField] private float _time = 10f;
    //This is a delay system for the Crowds
    public IEnumerator Delay1(float t)
    {
        yield return new WaitForSeconds(t);

        animator.SetBool("Angry", false);
        animator.SetBool("Stop", true);
    }
    public IEnumerator Delay2(float t)
    {
        yield return new WaitForSeconds(t);

        animator.SetBool("ok", false);
        animator.SetBool("Stop", true);
    }
    public IEnumerator Delay3(float t)
    {
        yield return new WaitForSeconds(t);

        animator.SetBool("Good", false);
        animator.SetBool("Stop", true);
    }
}

