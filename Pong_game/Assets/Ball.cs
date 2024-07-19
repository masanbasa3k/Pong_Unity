using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed;
    public Vector2 direction;
    public Vector3 oldPos;
    public Vector3 nextPos;

    private LayerMask collisionMask;


    void Awake()
    {
        collisionMask = LayerMask.GetMask("Wall");
        float directionX = Random.value < 0.5f ? -1 : 1; // if random value is less than 0.5, directionX is -1; otherwise, 1
        float directionY = Random.Range(-1f, 1f); // directionY is a random value between -1 and 1

        direction = new Vector2(directionX, directionY).normalized; // direction is (directionX, directionY) normalized
        oldPos = transform.position;
    }

    void Update()
    {
        transform.position += (Vector3)direction * speed * Time.deltaTime;

        Vector3 rayCastDirection = (transform.position - oldPos).normalized;
        RaycastHit2D hit = Physics2D.Raycast(oldPos, rayCastDirection, Vector3.Distance(transform.position, oldPos), collisionMask);

        // if hit something, reflect the direction  
        if (hit)
        {
            transform.position = hit.point - direction * 0.01f;
            direction = Vector2.Reflect(direction, hit.normal);
        }

        oldPos = transform.position;
        nextPos = transform.position + (Vector3)direction;
    }
}