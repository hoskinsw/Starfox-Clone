using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public int score = 0;
    public Text scoreNumber;

    public void SetScoreNumber(int num)
    {
        score += num;
        scoreNumber.text = score + "";
        //scoreNumber.text = GameObject.Find("Full_Level").transform.ToString();
    }
}
