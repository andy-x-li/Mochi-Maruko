using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
 public class YParallaxBackground : MonoBehaviour
 {
   public YParallaxCamera YparallaxCamera;
   List<YParallaxLayer> YparallaxLayers = new List<YParallaxLayer>();
  
   void Start()
   {
       if (YparallaxCamera == null)
         YparallaxCamera = Camera.main.GetComponent<YParallaxCamera>();
       if (YparallaxCamera != null)
         YparallaxCamera.onCameraTranslate += Move;
       SetLayers();
   }
  
   void SetLayers()
   {
       YparallaxLayers.Clear();
       for (int i = 0; i < transform.childCount; i++)
       {
           YParallaxLayer layer = transform.GetChild(i).GetComponent<YParallaxLayer>();
  
           if (layer != null)
           {
               layer.name = "Layer-" + i;
               YparallaxLayers.Add(layer);
           }
       }
     }
     void Move(float delta)
     {
         foreach (YParallaxLayer layer in YparallaxLayers)
       {
           layer.Move(delta);
       }
   }
 }