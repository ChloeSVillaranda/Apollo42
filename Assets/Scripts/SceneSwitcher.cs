using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneSwitcher : MonoBehaviour
{
    public void OpenScene(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }
    public void QuitGame() {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false; // Stops Play Mode in the Editor
        #else
                Application.Quit(); // Quits the application in a build
        #endif
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
