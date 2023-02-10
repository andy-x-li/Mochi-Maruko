using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Clean_Music : MonoBehaviour
{

    public string current_tag;
    public string tag_to_delete;

    public string to_clean_1;
    public string to_clean_2;

    private void Awake()
    {
        if (GameObject.FindGameObjectWithTag(current_tag))
        {
            Destroy(GameObject.FindGameObjectWithTag(tag_to_delete));
        }
        Destroy(GameObject.Find(to_clean_1));
        Destroy(GameObject.Find(to_clean_2));
    }
 }
