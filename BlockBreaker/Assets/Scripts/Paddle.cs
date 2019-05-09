using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    //Configuration Parameters
    [SerializeField] private float screenWidthInUnits = 16;
    [SerializeField] private float Min_Clamp = 1;
    [SerializeField] private float Max_Clamp = 15;

    Ball Ball;
    GameStatus GameStatus;

    private void Start()
    {
        Ball = FindObjectOfType<Ball>();
        GameStatus = FindObjectOfType<GameStatus>();
    }

    private void Update()
    {
        Vector2 PaddlePos = new Vector2(transform.position.x, transform.position.y);
        PaddlePos.x = Mathf.Clamp(GetXPos(), Min_Clamp, Max_Clamp);
        transform.position = PaddlePos;
    }

    private float GetXPos()
    {
        if (GameStatus.IsAutoPlayEnabled())
        {
            return Ball.transform.position.x;
        }
        else
        {
            return Input.mousePosition.x / Screen.width * screenWidthInUnits;
        }
    }
}
