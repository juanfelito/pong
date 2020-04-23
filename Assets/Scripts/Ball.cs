using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour {
    public float speed = 30;

    private Rigidbody2D rigidBody;
    private AudioSource audioSource;

    void Start() {
        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.velocity = Vector2.right * speed;
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.name == "rightPaddle" || col.gameObject.name == "leftPaddle") {
            handlePaddleHit(col);
        }

        if (col.gameObject.name == "topWall" || col.gameObject.name == "bottomWall") {
            SoundManager.Instance.PlayASound(SoundManager.Instance.wallBloop);
        }

        if (col.gameObject.name == "leftWall" || col.gameObject.name == "rightWall") {
            SoundManager.Instance.PlayASound(SoundManager.Instance.goalBloop);
            transform.position = new Vector2(0,0);

            if (col.gameObject.name == "leftWall") {
                UpdateScore("RightScoreUI");
            } else {
                UpdateScore("LeftScoreUI");
            }
        }
    }

    void handlePaddleHit(Collision2D col) {
        float y = (transform.position.y - col.transform.position.y) / col.collider.bounds.size.y;

        float x = 0;
        if (rigidBody.velocity.x < 0) {
            x = 1;
        } else {
            x = -1;
        }

        rigidBody.velocity = new Vector2(x, y).normalized * speed;

        SoundManager.Instance.PlayASound(SoundManager.Instance.paddleBloop);
    }

    void UpdateScore(string textUIName) {
        var textComp = GameObject.Find(textUIName).GetComponent<Text>();

        int score = int.Parse(textComp.text);

        score += 1;

        textComp.text = score.ToString();
    }
}
