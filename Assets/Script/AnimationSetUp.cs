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

            animator.SetBool("ok",true);

        yarnInMemoryStorage.TryGetValue("$Start1", out Start1);
        if (Start1 == true)
        {
            Debug.Log(Start1);
            animator.SetBool("StartWalking", true);
        }
        if (animator.GetBool("Leave") == true)
        {
            yarnInMemoryStorage.TryGetValue("$Start2", out Start2);
            if (Start2 == true)
            {
                Debug.Log(Start2);
                animator.SetBool("StartWalking", true);
                if (animator.GetBool("Leave") == true)
                {
                    yarnInMemoryStorage.TryGetValue("$Start3", out Start3);
                    if (Start3 == true)
                    {
                        Debug.Log(Start3);
                        animator.SetBool("StartWalking", true);
                    }
                }
            }
        }

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

          if (AngryCrowd == true)
          {
            Debug.Log(AngryCrowd);
            animator.SetBool("Angry", true);
            StartCoroutine(Delay(_time));
        }
         yarnInMemoryStorage.TryGetValue("$GoodClap", out OkCrowd);

         if (OkCrowd == true)
          {
            Debug.Log(OkCrowd);
            //animator.SetBool("ok", true);
            //StartCoroutine(Delay(_time));
            //animator.SetBool("ok", false);
            //animator.SetBool("Stop", true);
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
    private Renderer _renderer;
    [SerializeField] private float _time = 3f;

    public IEnumerator Delay(float t)
    {
        yield return new WaitForSeconds(t);
    }
}

