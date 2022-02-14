using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoring : MonoBehaviour
{
    //public GameObject scoringAudio;
    public GameObject leftText;
    public GameObject rightText;
    public GameObject winnerText;
    public GameObject puck;
    public int lScore = 0;
    public int rScore = 0;

    public enum Side
    {
        left,
        right
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void makeGoal(Side side)
    {
        //Debug.Log("Goal!!!");
        FindObjectOfType<AudioManager>().playSound("goal");
        int niceShotChance = Random.Range(0, 10);
        if (niceShotChance > 5) 
            FindObjectOfType<AudioManager>().playSound("niceShot");

        if (side == Side.left)
        {
            lScore++;
            //Debug.Log("Left Scores, Score: " + lScore.ToString() + " " + rScore.ToString());
            leftText.GetComponent<TMPro.TextMeshProUGUI>().text = lScore.ToString();
            leftText.GetComponent<TMPro.TextMeshProUGUI>().fontSize += 2;
            rightText.GetComponent<TMPro.TextMeshProUGUI>().fontSize -= 2;
            if (lScore >= 11)
                gameWon(Side.left);
        } else
        {
            rScore++;
            //Debug.Log("Right Scores, Score: " + lScore.ToString() + " " + rScore.ToString());
            rightText.GetComponent<TMPro.TextMeshProUGUI>().text = rScore.ToString();
            rightText.GetComponent<TMPro.TextMeshProUGUI>().fontSize += 2;
            leftText.GetComponent<TMPro.TextMeshProUGUI>().fontSize -= 2;
            if (rScore >= 11)
                gameWon(Side.right);
        }

        ////Change text color based on score
        //if (lScore > rScore)
        //{
        //    leftText.GetComponent<TMPro.TextMeshProUGUI>().color = new Color(110f, 198f, 230f, 228f);
        //    rightText.GetComponent<TMPro.TextMeshProUGUI>().color = new Color(255f, 255f, 255f, 228f);
        //} else if (rScore > lScore)
        //{
        //    rightText.GetComponent<TMPro.TextMeshProUGUI>().color = new Color(110f, 198f, 230f, 228f);
        //    leftText.GetComponent<TMPro.TextMeshProUGUI>().color = new Color(255f, 255f, 255f, 228f);
        //} else
        //{
        //    rightText.GetComponent<TMPro.TextMeshProUGUI>().color = new Color(255f, 255f, 255f, 228f);
        //    leftText.GetComponent<TMPro.TextMeshProUGUI>().color = new Color(255f, 255f, 255f, 228f);
        //}

        //After the score gets to 1, delete the winner message
        if (lScore >=  1 || rScore >= 1)
        {
            winnerText.GetComponent<TMPro.TextMeshProUGUI>().text = "";
        }
    }

    public void gameWon(Side side)
    {
        FindObjectOfType<AudioManager>().playSound("win");
        FindObjectOfType<AudioManager>().playSound("cheering");
        lScore = 0;
        rScore = 0;

        if (side == Side.left)
        {
            Debug.Log("-----Left Wins!!!-----");
            winnerText.GetComponent<TMPro.TextMeshProUGUI>().text = "Left side wins!";
            winnerText.GetComponent<TMPro.TextMeshProUGUI>().color = new Color(125f, 208f, 237f, 255f);
        } else
        {
            Debug.Log("-----Right Wins!!!-----");
            winnerText.GetComponent<TMPro.TextMeshProUGUI>().text = "Right side wins!";
            winnerText.GetComponent<TMPro.TextMeshProUGUI>().color = new Color(125f, 208f, 237f, 255f);
        }

        //Reset score texts
        leftText.GetComponent<TMPro.TextMeshProUGUI>().text = lScore.ToString();
        rightText.GetComponent<TMPro.TextMeshProUGUI>().text = rScore.ToString();
        leftText.GetComponent<TMPro.TextMeshProUGUI>().fontSize = 78.3f;
        rightText.GetComponent<TMPro.TextMeshProUGUI>().fontSize = 78.3f;
    }
}
