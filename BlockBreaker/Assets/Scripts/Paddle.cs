using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    //Configuration Parameters
    [SerializeField] private float screenWidthInUnits = 16;
    [SerializeField] private float Min_Clamp = 1;
    [SerializeField] private float Max_Clamp = 15;

    private void Update()
    {
        //Debug.Log(Input.mousePosition.x / Screen.width * screenWidthInUnits);
        float MousePositionInX = Mathf.Clamp(Input.mousePosition.x / Screen.width * screenWidthInUnits,Min_Clamp,Max_Clamp);
        Vector2 PaddlePos = new Vector2(MousePositionInX, transform.position.y);
        transform.position = PaddlePos;
    }
}
