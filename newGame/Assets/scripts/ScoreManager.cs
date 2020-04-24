using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

// Have track of the coins' and gem's score
public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public TextMeshProUGUI text, text1;
    int score = 0;
    public static bool haveGem = false;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
            instance = this;
    }

    public void ChangeScore(int coinValue)
    {
        score += coinValue;
        text.text = score.ToString() + "x";
    }

    public void ChangeGemScore()
    {
        haveGem = true;
        text1.text = "1x";
    }
}
