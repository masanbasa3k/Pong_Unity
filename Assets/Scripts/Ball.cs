using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public GameManager gameManager;
    public Rigidbody2D rb2d;
    public float maxInitalAngle = 0.67f;
    public float moveSpeed = 4f;
    public float maxStartY = 4f;

    private float startX = 0f;

    private void Start()
    {
        InitialPush();
    }

    private void InitialPush()
    {
        Vector2 dir = Random.value < 0.5f ? Vector2.left : Vector2.right;
        dir.y = Random.Range(-maxInitalAngle, maxInitalAngle);
        rb2d.velocity = dir * moveSpeed;
    }

    private void ResetBall()
    {
        float posY = Random.Range(-maxStartY, maxStartY);
        Vector2 position = new Vector2(startX, posY);
        transform.position = position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ScoreZone scoreZone = collision.GetComponent<ScoreZone>();
        if (scoreZone)
        {
            gameManager.OnScoreZoneReached(scoreZone.id);
            moveSpeed = 4f;
            ResetBall();
            InitialPush();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Paddle")
        {
            moveSpeed += 1f;
            rb2d.velocity = rb2d.velocity.normalized * moveSpeed;
        }
    }
}
