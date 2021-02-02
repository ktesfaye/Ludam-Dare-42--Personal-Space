using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
     
public class Start : MonoBehaviour {
     
    public void StartGame() {
        SceneManager.LoadScene("Level Design"); // loads current scene
    }
     
}
