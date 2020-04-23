using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundMusic : MonoBehaviour {
    void Update() {
        DontDestroyOnLoad(gameObject);
    }
}
