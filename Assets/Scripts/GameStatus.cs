using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour
{

    [Range(0.1f, 10f)] [SerializeField] float timeScale;

    [SerializeField] int pointsPerBlock = 3;
    [SerializeField] int currentScore = 0; //Serialized for debugging
    [SerializeField] bool isAutoPlay = false;

    [SerializeField] TextMeshProUGUI textComponent;

    public static void destroyAny()
    {
        foreach (GameStatus g in FindObjectsOfType<GameStatus>())
        {
            Destroy(g.gameObject);
        }
    }

    private void Awake()
    {
        GameStatus[] previous = FindObjectsOfType<GameStatus>();

        if (previous.Length == 1)
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = timeScale;
        textComponent.text = currentScore + "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncScore()
    {
        currentScore += pointsPerBlock;
        textComponent.text = currentScore + "";
    }

    public bool getAutoPlay()
    {
        return isAutoPlay;
    }
}
