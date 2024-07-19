using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float speed;
    public KeyCode moveUp;
    public KeyCode moveDown;

    void Update()
    {
        // if hit something, stop the paddle
        if (Input.GetKey(moveUp))
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up, 1f, LayerMask.GetMask("Wall"));
            if (!hit)
            {
                transform.Translate(Vector2.up * speed * Time.deltaTime);
            }
        }
        else if (Input.GetKey(moveDown))
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1f, LayerMask.GetMask("Wall"));
            if (!hit)
            {
                transform.Translate(Vector2.down * speed * Time.deltaTime);
            }
        }
    }
}
