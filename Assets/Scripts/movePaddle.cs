using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePaddle : MonoBehaviour {
    public float speed = 30;

    void FixedUpdate() {
        float keyPress = Input.GetAxisRaw("Vertical");
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, keyPress) * speed;
    }
}
