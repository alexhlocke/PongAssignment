using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleManager : MonoBehaviour
{
    public GameObject lPaddle;
    public GameObject rPaddle;
    public float movementSpeed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        lMove();
        rMove();
    }

    void lMove()
    {
        bool up = Input.GetKey(KeyCode.S);
        bool down = Input.GetKey(KeyCode.D);

        if (down)
        {
            lPaddle.transform.position -= new Vector3(0.0f, movementSpeed * Time.deltaTime, 0.0f);
        }

        if (up)
        {
            lPaddle.transform.position += new Vector3(0.0f, movementSpeed * Time.deltaTime, 0.0f);
        }
    }

    void rMove()
    {
        bool up = Input.GetKey(KeyCode.K);
        bool down = Input.GetKey(KeyCode.J);

        if (down)
        {
            rPaddle.transform.position -= new Vector3(0.0f, movementSpeed * Time.deltaTime, 0.0f);
        }

        if (up)
        {
            rPaddle.transform.position += new Vector3(0.0f, movementSpeed * Time.deltaTime, 0.0f);
        }
    }
}
