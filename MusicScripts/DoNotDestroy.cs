using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoNotDestroy : MonoBehaviour
{

    private AudioSource AudioSource;

    private float MusicVolume = 0f;

    public string tag;
    
    // Start is called before the first frame update
    private void Awake()
    {
        if (GameObject.FindGameObjectsWithTag(tag) != null)
        {
            GameObject[] musicObj = GameObject.FindGameObjectsWithTag(tag);
            if (musicObj.Length > 1)
            {
                Destroy(this.gameObject);
            }
            DontDestroyOnLoad(this.gameObject);
        }
    }
}

