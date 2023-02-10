using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeMovement : MonoBehaviour
{
    private Vector3 startPos; 

    [SerializeField]
    private float frequency = 5f;

    [SerializeField]
    private float magnitude = 5f; 

    [SerializeField]
    private float offset = 0f;
    
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = startPos + transform.right * Mathf.Sin(Time.time * frequency + offset) * magnitude; 
    }
}
