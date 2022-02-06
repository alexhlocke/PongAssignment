using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftPaddle : MonoBehaviour
{
    public float movementSpeed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        bool up = Input.GetKey(KeyCode.S);
        bool down = Input.GetKey(KeyCode.D);

        if (down)
        {
            transform.position -= new Vector3(0.0f, movementSpeed * Time.deltaTime, 0.0f);
        }

        if (up)
        {
            transform.position += new Vector3(0.0f, movementSpeed * Time.deltaTime, 0.0f);
        }
    }
}
