using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{

    [SerializeField] int numBlocks = 0; //for debug
    SceneLoader loader;

    private void Start()
    {
        loader = FindObjectOfType<SceneLoader>();
    }

    public void IncNumBlocks()
    {
        numBlocks++;
    }

    public void DecNumBlocks()
    {
        numBlocks--;
    }

    // Update is called once per frame
    void Update()
    {
        if (numBlocks == 0)
        {
            loader.LoadNextScene();
        }
    }
}
