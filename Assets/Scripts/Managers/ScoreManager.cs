using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public enum HitType
{
    simpleHit = 10,
    appleHit  = 20,
    shieldFinalHit = 50
}

public class ScoreManager : MonoBehaviour
{
    public Text m_scoreText;
    public int m_score;
    int zeroCount = 5;

    public void Score(HitType hitType)
    {
        int currentScore=0;

        switch (hitType)
        {
            case HitType.simpleHit:
                currentScore += 10;
                break;

            case HitType.appleHit:
                currentScore += 20;
                break;

            case HitType.shieldFinalHit:
                currentScore += 50;
                break;
        }

        m_score += currentScore;
        RefreshScore();
    }

    void RefreshScore()
    {
        m_scoreText.text = padZero(m_score, zeroCount);
    }

    private void Start()
    {
        m_score = 0;
    }

    string padZero(int n, int padDigits)
    {
        string str = n.ToString();

        while (str.Length < padDigits + 1)
            str = "0" + str;

        return str;
    }

}
