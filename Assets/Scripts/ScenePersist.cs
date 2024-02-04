using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenePersist : MonoBehaviour
{
    //Singleton
    void Awake()
    {
        // FindObjectsOfType create of array 
        int numScenePersist = FindObjectsOfType<ScenePersist>().Length;

        //Awake is started when this class is brought to life, when we push play button and then dye
        if (numScenePersist > 1)
        {
            //we destroy on load if there is two objects of GameSession and we destroy newest
            Destroy(gameObject);
        }
        else
        {
            //stick around when we dye or level changes
            DontDestroyOnLoad(gameObject);
        }
    }

    public void ResetScenePersist()
    {
        Destroy(gameObject);
    }
}
