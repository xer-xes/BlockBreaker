using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    //Configuration Parameters
    [SerializeField] Paddle Paddle;

    //State
    Vector2 PaddleToBall;
    // Start is called before the first frame update
    void Start()
    {
        PaddleToBall = transform.position - Paddle.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 PaddlePos = new Vector2(Paddle.transform.position.x, Paddle.transform.position.y);
        transform.position = PaddlePos + PaddleToBall;
    }
}
