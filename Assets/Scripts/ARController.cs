/*
 * Singleton class for controlling object placement and doodling on AR Scene
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR;
using System;
using UnityEngine.XR.ARSubsystems;

public class ARController : MonoBehaviour
{
    static List<ARRaycastHit> rcHits = new List<ARRaycastHit>();

   // public NotificationManager notificationManager;
    private static ARController _arController;
    private ARRaycastManager _arRaycastManager;

    [HideInInspector] public GameObject placementIndicator;

    [SerializeField] private GameObject _placementIndicator;
    [SerializeField] private GameObject _planeDetectionNotification;
    [SerializeField] private GameObject _placementIndicatorHighlighted;

    [SerializeField] private ARPlaneManager _arPlaneManager = null;
    //[SerializeField] private UnityEvent OnInitialized = null;
    //private bool Initialized { get; set; }

    [SerializeField] private bool _isDetectionEnabled;
    public bool isPlacementValid;
    public bool isRecording;
    public bool isObjectSelected;
    public bool isDoodlingEnabled;
    public Pose placementPosition;

    public GameObject objectHost;
    [SerializeField] private int _objectsOnSceneCount;


    #region Singleton init
    public static ARController ARPlacementManager
    {
        get
        {
            if (_arController == null)
            {
                GameObject newARControllerGO = new GameObject("ARPlacementManager");
                ARController component = newARControllerGO.AddComponent<ARController>();
                _arController = component;
            }
            return _arController;
        }
    }
    private void Awake()
    {
        if (_arController == null)
        {
            _arController = this;
        }
        else
        {
            Destroy(gameObject);
        }

        /*_arPlaneManager.planesChanged += PlanesChanged;

        #if UNITY_EDITOR
            OnInitialized?.Invoke();
            Initialized = true;
            _arPlaneManager.enabled = false;
        #endif*/
    }
    #endregion

    void Start()
    {
        _arRaycastManager = FindObjectOfType<ARRaycastManager>();
        placementIndicator = _placementIndicator;
        isRecording = false;
        isObjectSelected = false;
        isDoodlingEnabled = false;
        _isDetectionEnabled = false;

        ResetCount();
    }

    private void Update()
    {
        if (!isDoodlingEnabled && _isDetectionEnabled && !isObjectSelected)
        {
            UpdatePlacementPosition();
            SetPlacementIndicator();
        }
        else
        {
            placementIndicator.SetActive(false);
            _planeDetectionNotification.SetActive(false);
        }
    }

    private void UpdatePlacementPosition()
    {
        _planeDetectionNotification.SetActive(true);
        var screenCenter = Camera.main.ViewportToScreenPoint(new Vector3(.5f, .5f));

        _arRaycastManager.Raycast(screenCenter, rcHits, TrackableType.PlaneWithinPolygon);

        isPlacementValid = rcHits.Count > 0;
        if (isPlacementValid)
        {
            placementPosition = rcHits[0].pose;

            var cameraForward = Camera.main.transform.forward;
            var cameraBearing = new Vector3(cameraForward.x, 0, cameraForward.z).normalized;
            placementPosition.rotation = Quaternion.LookRotation(cameraBearing);
        }
    }

    private void SetPlacementIndicator()
    {
        if (isPlacementValid && !isRecording && !isObjectSelected)
        {
            _planeDetectionNotification.SetActive(false);
            placementIndicator.SetActive(true);
            placementIndicator.transform.SetPositionAndRotation(placementPosition.position, placementPosition.rotation);
        }
        else
        {
            placementIndicator.SetActive(false);
        }
    }

    public void HighlightPlacementIdicator(bool isHighlight)
    {
        if (isHighlight == true)
        {
            _placementIndicator.SetActive(false);
            placementIndicator = _placementIndicatorHighlighted;
            _placementIndicatorHighlighted.SetActive(true);
        }
        else if (isHighlight == false)
        {
            _placementIndicatorHighlighted.SetActive(false);
            placementIndicator = _placementIndicator;
            _placementIndicator.SetActive(true);
        }
    }

    public void ToggleRaycasting(bool isRaycasting)
    {
        _isDetectionEnabled = isRaycasting;
    }

    public void IncrementObjectCount()
    {
        _objectsOnSceneCount++;
    }

    public void DecrementObjectCount()
    {
        _objectsOnSceneCount--;
    }

    public void ResetCount()
    {
        _objectsOnSceneCount = 0;
    }

    public int GetCurrentCountValue()
    {
        return _objectsOnSceneCount;
    }

    /*void PlanesChanged(ARPlanesChangedEventArgs args)
    {
        if (!Initialized)
        {
            Activate();
        }
    }

    private void Activate()
    {
        OnInitialized?.Invoke();
        Initialized = true;
        _arPlaneManager.enabled = false;
    }*/
}
