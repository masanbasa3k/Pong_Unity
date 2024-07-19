using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("Game Objects")]
    [Tooltip("The left score zone")]
    public TMP_Text scoreTextLeft;
    private int scoreLeft; 
    [Tooltip("The right score zone")]
    public TMP_Text scoreTextRight;
    private int scoreRight;
    [Tooltip("The ball")]
    public GameObject ballPrefeb;
    private GameObject instantiatedBall;
    public LayerMask collisionMask;
    
    void Awake()
    {
        instantiatedBall = Instantiate(ballPrefeb);
    }
    
    void Update()
    {
        scoreTextLeft.text = scoreLeft.ToString();
        scoreTextRight.text = scoreRight.ToString();

        Ball ballComponent = instantiatedBall.GetComponent<Ball>();
        Vector3 oldPos = ballComponent.oldPos;
        Vector3 nextPos = ballComponent.nextPos;

        if (Physics2D.Raycast(oldPos, (nextPos - oldPos).normalized, Vector3.Distance(nextPos, oldPos), collisionMask))
        {
            if (nextPos.x < 0)
            {
                scoreRight++;
            }
            else
            {
                scoreLeft++;
            }

            instantiatedBall.transform.position = new Vector3(0, 0, 0);
            instantiatedBall.GetComponent<Ball>().direction = new Vector2(Random.Range(0, 2) == 0 ? 1 : -1, Random.Range(-1f, 1f));
        }
    }
}
