using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class splashScreen : MonoBehaviour {
    public string sceneToLoad;
    public int secondsToWait;

    void Start() {
        Invoke("OpenNextScene", secondsToWait);
    }

    void OpenNextScene() {
        SceneManager.LoadScene(sceneToLoad);
    }
}
