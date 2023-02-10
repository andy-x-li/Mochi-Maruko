using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeScript : MonoBehaviour
{
    public CanvasGroup myUIGroup;

    public void ShowUI()
    {
        myUIGroup.alpha = 1;
    }    
    public void HideUI()
    {
        myUIGroup.alpha = 0;
    }
}
