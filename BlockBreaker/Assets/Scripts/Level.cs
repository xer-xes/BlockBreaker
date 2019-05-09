using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    [SerializeField] int BreakableBlocks;
    //Cached Reference
    SceneLoader SceneLoader;

    private void Start()
    {
        SceneLoader = FindObjectOfType<SceneLoader>();
    }

    public void CountBreakableBlocks()
    {
        BreakableBlocks++;
    }

    public void BlockDestroyed()
    {
        BreakableBlocks--;
        if(BreakableBlocks <= 0)
        {
            SceneLoader.LoadNextScene();
        }
    }
}
