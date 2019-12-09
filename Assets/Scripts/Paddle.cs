using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{

    [SerializeField] double screenWidthUnits;
    [SerializeField] float screenMaxX;
    [SerializeField] float screenMinX;
    double widthFactor;
    GameStatus gameStatus;
    Ball ball;

    // Start is called before the first frame update
    void Start()
    {
        ball = FindObjectOfType<Ball>();
        gameStatus = FindObjectOfType<GameStatus>();
        widthFactor = screenWidthUnits / Screen.width;
    }

    // Update is called once per frame
    void Update()
    {
        float newXPos = Mathf.Clamp(getX(), screenMinX, screenMaxX);
        Vector2 paddlePos = new Vector2(newXPos, transform.position.y);
        transform.position = paddlePos;
    }

    private float getX()
    {
        if (gameStatus.getAutoPlay())
        {
            return ball.transform.position.x;
        }
        else
        {
            return (float) (Input.mousePosition.x * widthFactor);
        }
    }
}
