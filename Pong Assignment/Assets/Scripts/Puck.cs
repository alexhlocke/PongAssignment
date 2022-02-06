using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puck : MonoBehaviour
{
    public GameObject Scoring;
    public GameObject Trail;
    public float movementSpeed = 6.4f;

    private int xDirection = 1; //1 for right -1 for left
    private int yDirection = 1; //1 for up, -1 for down
    private float yAngle = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        yAngle = Random.Range(0.0f, 5.0f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (new Vector3(xDirection * movementSpeed * Time.deltaTime,  yDirection * yAngle * Time.deltaTime, 0.0f));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Left Goal"))
        {
            //xDirection *= -1;
            Scoring.GetComponent<Scoring>().makeGoal(global::Scoring.Side.right);
            resetPuck(-1);
        }
        else if (collision.gameObject.CompareTag("Right Goal"))
        {
            //xDirection *= -1;
            Scoring.GetComponent<Scoring>().makeGoal(global::Scoring.Side.left);
            resetPuck(1);
        }
        else if (collision.gameObject.CompareTag("Paddle"))
        {
            //Change x dir, increase speed, and randomize y angle
            xDirection *= -1;
            movementSpeed += (float)0.2;
            yAngle = Random.Range(0.0f, 5.0f);
            Debug.Log("Hit a paddle, movement speed now: " + movementSpeed);
        }
        else
        {
            yDirection *= -1;
        }
    }

    public void resetPuck(int xDir)
    {
        transform.position = Scoring.transform.position;
        movementSpeed = 6.4f;
        xDirection = xDir;
        yAngle = Random.Range(0.0f, 5.0f);
        Trail.GetComponent<TrailRenderer>().Clear();
    }
}
