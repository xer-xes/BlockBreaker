using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour
{
    //Config Parameters
    [Range(0.1f,10f)][SerializeField] float GameSpeed = 1f;
    [SerializeField] int Points_Per_Block = 1;
    [SerializeField] TextMeshProUGUI Score_Text;
    [SerializeField] bool isAutoPlayEnabled;
    //State Variables
    [SerializeField] int Current_Score = 0;

    private void Awake()
    {
        int GameStatusCount = FindObjectsOfType<GameStatus>().Length;
        if(GameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        Score_Text.text = Current_Score.ToString();
    }

    void Update()
    {
        Time.timeScale = GameSpeed;
    }

    public void AddScore()
    {
        Current_Score += Points_Per_Block;
        Score_Text.text = Current_Score.ToString();
    }

    public void Reset_Score()
    {
        Destroy(gameObject);
    }

    public bool IsAutoPlayEnabled()
    {
        return isAutoPlayEnabled;
    }
}
