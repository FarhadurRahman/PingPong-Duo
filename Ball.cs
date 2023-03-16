using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour
{
    
    public float speed;
    Vector2 direction;
    float ballHeight;

    // Start is called before the first frame update
    void Start()
    {
        
        //randomize ball direction
        int rand = Random.Range(0, 4);
        if (rand == 0 )
        {
            direction = Vector2.one;
        }
        else if (rand == 1 ) 
        {
            direction = new Vector2(-1, -1);
        }
        else if (rand == 2)
        {
            direction = new Vector2(1, -1);
        }
        else 
        {
            direction = new Vector2(-1, 1);
        }
        ballHeight = transform.localScale.x;

        
        
     

        
    }

    // Update is called once per frame
    void Update()
    {
        //move the ball
        transform.Translate(direction * speed * Time.deltaTime);

        //ball controller up
        if(transform.position.y > GameManager.topRight.y - ballHeight/2 &&
            direction.y > 0)
        {
            direction.y = -direction.y;
        }
        //ball controller down
        if (transform.position.y < GameManager.bottomLeft.y + ballHeight / 2 &&
           direction.y < 0)
        {
            direction.y = -direction.y;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Paddle")
        {
            direction.x = -direction.x;
            speed += 0.5f;

            //tweak the direction
            int rand = Random.Range(0, 2);
            if (rand < 0 )
            {
                direction.y = -direction.y;
            }

        }
        if(collision.tag == "ScoreRight")
        {
            print("Right player scored");
            Score.rightPlayerScoreNum++;
            //create new ball
            GameManager.instance.Replay();
            //destroy ball
            Destroy(gameObject);
        }

        if (collision.tag == "ScoreLeft")
        {
            print("Left player scored");
            Score.leftPlayerScoreNum++;
            //create new ball
            GameManager.instance.Replay();
            //destroy ball
            Destroy(gameObject);
        }

    }
}
