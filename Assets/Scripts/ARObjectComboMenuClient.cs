using Lean.Touch;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[AddComponentMenu("ComboMenuClient")]
public class ARObjectComboMenuClient : MonoBehaviour
{
    public enum EditMode
    {
        Resize,
        Rotate
    }

    public EditMode currentEditMode;

    [SerializeField] private LeanPinchScale pinchScaleComponent;
    [SerializeField] private LeanDragTranslate dragTranslateComponent;
   // [SerializeField] private LeanManualRotate manualRotateComponent;
   // [SerializeField] private LeanMultiTwist multiTwistComponent;


    public void GetObjectSelected()
    {
        ARController.ARPlacementManager.isObjectSelected = true;
       // ARObjectComboMenu.ComboMenu.selectedObject = this;
       // ARObjectComboMenu.ComboMenu.UpdateMenuState();
    }

    public void GetObjectDeselected()
    {
        ARController.ARPlacementManager.isObjectSelected = false;
       // ARObjectComboMenu.ComboMenu.selectedObject = null;
      //  ARObjectComboMenu.ComboMenu.UpdateMenuState();
    }

    public void SwitchToResizeMode()
    {
        currentEditMode = EditMode.Resize;

        dragTranslateComponent.enabled = true;
        pinchScaleComponent.enabled = true;
       // manualRotateComponent.enabled = false;
      //  multiTwistComponent.enabled = false;
    }

    public void SwitchToRotateMode()
    {
        currentEditMode = EditMode.Rotate;

        dragTranslateComponent.enabled = false;
        pinchScaleComponent.enabled = false;
      //  manualRotateComponent.enabled = true;
      //  multiTwistComponent.enabled = true;
    }

    public void AssignComponents(LeanPinchScale leanPinchScale, LeanDragTranslate leanDragTranslate)
    {
        // args  , LeanManualRotate leanManualRotate, LeanMultiTwist leanMultiTwist
        pinchScaleComponent = leanPinchScale;
        dragTranslateComponent = leanDragTranslate;
       // manualRotateComponent = leanManualRotate;
      //  multiTwistComponent = leanMultiTwist;
    }
}
