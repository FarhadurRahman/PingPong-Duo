using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Score : MonoBehaviour
{
    public Text rightPlayerScore;
    public Text leftPlayerScore;
    public static int rightPlayerScoreNum;
    public static int leftPlayerScoreNum;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rightPlayerScore.text = rightPlayerScoreNum.ToString();
        leftPlayerScore.text = leftPlayerScoreNum.ToString();
    }
}
