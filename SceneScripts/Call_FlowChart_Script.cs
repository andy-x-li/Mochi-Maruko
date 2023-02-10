using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Call_FlowChart_Script : MonoBehaviour
{
    private void Awake()
    {
        Fungus.Flowchart.BroadcastFungusMessage("hello");
    }
}
