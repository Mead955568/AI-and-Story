using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class YarnVariableTest : MonoBehaviour
{
    public float NobleNumberYarn;
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
        yarnInMemoryStorage.TryGetValue("$Noble", out NobleNumberYarn);
        Debug.Log(NobleNumberYarn);
    }
}
