using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoring : MonoBehaviour
{
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

        if (side == Side.left)
        {
            lScore++;
            Debug.Log("Left Scores, Score: " + lScore.ToString() + " " + rScore.ToString());
            leftText.GetComponent<TMPro.TextMeshProUGUI>().text = lScore.ToString();
            if (lScore >= 11)
                gameWon(Side.left);
        } else
        {
            rScore++;
            Debug.Log("Right Scores, Score: " + lScore.ToString() + " " + rScore.ToString());
            rightText.GetComponent<TMPro.TextMeshProUGUI>().text = rScore.ToString();
            if (rScore >= 11)
                gameWon(Side.right);
        }

        //After the score gets to 2, delete the winner message
        if (lScore >=  2 || rScore >= 2)
        {
            winnerText.GetComponent<TMPro.TextMeshProUGUI>().text = "";
        }
    }

    /*public void resetPuck(Side scoredOn)
    {
        Debug.Log("Resetting Puck");
        //Reset Position
        Rigidbody2D puckRb = puck.GetComponent<Rigidbody2D>();
        puckRb.position = Vector3.zero;
        //Reset Velocity
        Puck puckScript = puck.GetComponent<Puck>();

    }*/

    public void gameWon(Side side)
    {
        lScore = 0;
        rScore = 0;

        if (side == Side.left)
        {
            Debug.Log("-----Left Wins!!!-----");
            winnerText.GetComponent<TMPro.TextMeshProUGUI>().text = "Left side wins!";
            winnerText.GetComponent<TMPro.TextMeshProUGUI>().color = Color.blue;
        } else
        {
            Debug.Log("-----Right Wins!!!-----");
            winnerText.GetComponent<TMPro.TextMeshProUGUI>().text = "Right side wins!";
            winnerText.GetComponent<TMPro.TextMeshProUGUI>().color = Color.red;
        }

        //Reset score texts
        leftText.GetComponent<TMPro.TextMeshProUGUI>().text = lScore.ToString();
        rightText.GetComponent<TMPro.TextMeshProUGUI>().text = rScore.ToString();
    }
}
