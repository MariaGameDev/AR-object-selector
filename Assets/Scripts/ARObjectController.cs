using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARObjectController : MonoBehaviour
{
    public GameObject targetObject;
   // public Texture2D quadTexture;
    //public GameObject userImagePlaceHolder;
   // public GameObject targetQuadPrefab;

    [SerializeField] private bool isChosen;

    public void PlaceTargetObject()
    {
        var targetObjectRotation = ARController.ARPlacementManager.placementPosition.rotation;
        targetObjectRotation.x = targetObject.transform.rotation.x;

        int currentObjectCount = ARController.ARPlacementManager.GetCurrentCountValue();

       // if (currentObjectCount < SettingsManager.CurrentSettings.settings.objectsOnSceneLimit)
        {
            if (isChosen == false)
            {
                //ARController.ARPlacementManager.placementIndicator = targetObject;
                isChosen = true;
                ARController.ARPlacementManager.HighlightPlacementIdicator(true);
            }
            else
            {
                Instantiate(targetObject, ARController.ARPlacementManager.placementPosition.position, targetObjectRotation, ARController.ARPlacementManager.objectHost.transform);
               // UIDebugManager._DebugManager.AddLog("Object placed. Position: " + ARController.ARPlacementManager.placementPosition.position);
                ARController.ARPlacementManager.IncrementObjectCount();
                isChosen = false;
                ARController.ARPlacementManager.HighlightPlacementIdicator(false);
            }
        }
       // else
       // {
           // ARController.ARPlacementManager.notificationManager.ShowNotification("Too many objects on the scene", 2f);
       // }
    }

    public void PlaceTargetQuad()
    {
        var targetObjectRotation = ARController.ARPlacementManager.placementPosition.rotation;

        int currentObjectCount = ARController.ARPlacementManager.GetCurrentCountValue();

      /*  if (currentObjectCount < SettingsManager.CurrentSettings.settings.objectsOnSceneLimit)
        {
            if (isChosen == false)
            {
                //ARController.ARPlacementManager.placementIndicator = targetObject;
                isChosen = true;
                ARController.ARPlacementManager.HighlightPlacementIdicator(true);
            }
            else
            {
                GameObject userImagePlaceHolder = Instantiate(targetQuadPrefab, ARController.ARPlacementManager.placementPosition.position, targetObjectRotation, ARController.ARPlacementManager.objectHost.transform);

                //_targetQuad = GameObject.CreatePrimitive(PrimitiveType.Quad);
                //_targetQuad.transform.position = Camera.main.transform.position + Camera.main.transform.forward * 2.5f;
                //_targetQuad.transform.forward = Camera.main.transform.forward;
                userImagePlaceHolder.transform.localScale = new Vector3(1f, quadTexture.height / (float)quadTexture.width, 1f);

                List<GameObject> sides = new List<GameObject>();
                sides.Add(userImagePlaceHolder.transform.GetChild(0).gameObject);
                sides.Add(userImagePlaceHolder.transform.GetChild(1).gameObject);

                foreach (GameObject side in sides)
                {
                    Material material = side.GetComponent<Renderer>().material;
                    if (!material.shader.isSupported) // happens when Standard shader is not included in the build     
                        material.shader = Shader.Find("Legacy Shaders/Diffuse");
                    material.mainTexture = quadTexture;
                }

                ARController.ARPlacementManager.IncrementObjectCount();

                isChosen = false;
                ARController.ARPlacementManager.HighlightPlacementIdicator(false);
            }
        } */
       // else
      //  {
           // ARController.ARPlacementManager.notificationManager.ShowNotification("Too many objects on the scene", 2f);
       // }
    }
}
