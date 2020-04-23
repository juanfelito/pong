using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPaddle : MonoBehaviour {
    public float speed = 30;
    public Ball ball;
    public float adjust;

    private Rigidbody2D rigidBody;

    void Start() {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate() {
        if (ball.transform.position.y > transform.position.y) {
            rigidBody.velocity = Vector2.Lerp(rigidBody.velocity, new Vector2(0, 1).normalized * speed, adjust * Time.deltaTime);
        } else if (ball.transform.position.y < transform.position.y) {
            rigidBody.velocity = Vector2.Lerp(rigidBody.velocity, new Vector2(0, -1).normalized * speed, adjust * Time.deltaTime);
        } else {
            rigidBody.velocity = Vector2.Lerp(rigidBody.velocity, new Vector2(0, 0).normalized * speed, adjust * Time.deltaTime);
        }
    }
}
