using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class RandomEnemyMovement : MonoBehaviour
{
    private float speed = 15;
    public float directoinalChangeInterval = 15;
    public Vector2 movementRange = new Vector2 (5,5);
    private Vector2 movementDirection;
    private Vector2 minPosition;
    private Vector2 maxPosition;

    // Start is called before the first frame update
    void Start()
    {
       minPosition = (Vector2)transform.position-movementRange * 0.5f;
       maxPosition = (Vector2)transform.position + movementDirection * 0.5f;
        InvokeRepeating("ChangeDirection", 0f, directoinalChangeInterval);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    private void ChangeDirection()
    {
        movementDirection = new Vector2(Random.Range(-1f,1f),Random.Range(-1f,1f)).normalized;

    }
    private void Move()
    {
        transform.Translate(movementDirection * speed * Time.deltaTime);
        MoveLimit();
    }
    private void MoveLimit()
    {
        
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minPosition.x, maxPosition.x), 
        Mathf.Clamp(transform.position.y, minPosition.y, maxPosition.y), 
        transform.position.z
        );        
    }
}
