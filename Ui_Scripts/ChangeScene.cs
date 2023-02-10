using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // This adds Unity's "Scene Management" functions for us to use

public class ChangeScene : MonoBehaviour
{

    public string levelToLoad; // This adds a field in the inspector where you list the level (Case and space sensitive)

    public void OnMouseClick()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
