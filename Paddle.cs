using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    float paddleWidth;
    float paddleHeight;
    public float speed;
    string input;

    // Start is called before the first frame update
    void Start()
    {
        paddleHeight = transform.localScale.y; //paddle height
    }

    // Update is called once per frame
    void Update()
    {
        //get axis returns value btween -1 and 1
        float move = Input.GetAxis(input) * speed * Time.deltaTime;

        //paddle controlo up
        if (transform.position.y > GameManager.topRight.y - paddleHeight/2 && move > 0)
        {
            move = 0;
        }
        //paddle contrlo down
        if (transform.position.y < GameManager.bottomLeft.y+ paddleHeight / 2 && move <0)
        {
            move = 0;
        }
        transform.Translate(Vector2.up * move);
    }

    public void InitPaddle(bool isRight)
    {
        paddleWidth = transform.localScale.x; //set the widht of paddle

        if (isRight == true) 
        {
            //right paddle
            transform.position = new Vector2(GameManager.topRight.x - paddleWidth, 0);
            input = "RightPaddle";
        }
        else
        {
            //left paddle
            transform.position = new Vector2(GameManager.bottomLeft.x + paddleWidth, 0);
            input = "LeftPaddle";
        }
    }
}
