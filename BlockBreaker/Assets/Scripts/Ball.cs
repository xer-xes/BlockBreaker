using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    //Configuration Parameters
    [SerializeField] Paddle Paddle;
    [SerializeField] float X_Velocity = 2f;
    [SerializeField] float Y_Velocity = 12f;
    [SerializeField] AudioClip[] BallClips;
    //State
    Vector2 PaddleToBall;
    bool Launched = false;
    //Cached Component References
    AudioSource AudioSource;
    
    void Start()
    {
        PaddleToBall = transform.position - Paddle.transform.position;
        AudioSource = GetComponent<AudioSource>();
    }
 
    void Update()
    {
        if (!Launched)
        {
            LockBallToPaddle();
            LaunchOnMouseClick();
        }
    }

    private void LaunchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Launched = true;
            GetComponent<Rigidbody2D>().velocity = new Vector2(X_Velocity,Y_Velocity);
        }
    }

    private void LockBallToPaddle()
    {
        Vector2 PaddlePos = new Vector2(Paddle.transform.position.x, Paddle.transform.position.y);
        transform.position = PaddlePos + PaddleToBall;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Launched)
        {
            AudioClip audioClip = BallClips[Random.Range(0, BallClips.Length)];
            AudioSource.PlayOneShot(audioClip);
        }
    }
}
