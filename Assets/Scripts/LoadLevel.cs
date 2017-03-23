using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour {

    public void LoadScene()
    {
        SceneManager.LoadScene("MainLevel");
    }
}
