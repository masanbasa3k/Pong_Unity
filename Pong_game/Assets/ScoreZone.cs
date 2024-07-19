using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreZone : MonoBehaviour
{
    public GameManager gameManager;
    public LayerMask m_LayerMask;
    // check the ball trigger
    // void Update()
    // {
    //     Collider[] hitColliders = Physics.OverlapBox(gameObject.transform.position, transform.localScale / 2, Quaternion.identity, m_LayerMask);
    //     if (hitColliders.Length > 0)
    //     {
    //        Debug.Log("Hit");
    //     }

    // }
    // private void OnTriggerEnter2D(Collider2D other)
    // {
    //     gameManager.Score(gameObject);
    // }
}
