using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearSceneBtn : MonoBehaviour
{
    [SerializeField] GameObject _sceneHost;
    public void ClearARScene()
    {
       // AudioManager.PlaySound(AudioManager.SoundType.DeleteAllObjs);
        foreach (Transform child in _sceneHost.transform)
        {
            Destroy(child.gameObject);
        }
        ARController.ARPlacementManager.ResetCount();
    }


    public void DeleteTargetObject()
    {
       // GameObject.Destroy();
    }
}
