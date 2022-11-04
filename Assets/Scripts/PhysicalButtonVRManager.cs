using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicalButtonVRManager : MonoBehaviour
{
    [SerializeField] public List<GameObject> _vrButtonsList = new List<GameObject>();
    [HideInInspector]
    public List<PhysicalButtonVR> _physicalButtonVRList = new List<PhysicalButtonVR>();
    [SerializeField] GameObjectManager _gameObjectManager;
    [SerializeField] UIManager _uiManager;

    private void Awake()
    {
        // loop through all of the VR Button gameobjects and store a reference to the
        // PhysicalButtonVR Script attached to it
        foreach (GameObject go in _vrButtonsList)
        {
            _physicalButtonVRList.Add(go.GetComponentInChildren<PhysicalButtonVR>());
        }
    }
    /// <summary>
    /// Adds an Event Listener to the event _onVRButtonRelease that belongs to the current instance of the class PhysicalButtonVR
    /// </summary>
    private void OnEnable()
    {
        // Whenever the _onVRButtonRelease event is triggered, SpawnObject() will be called
        foreach (PhysicalButtonVR pbvr in _physicalButtonVRList)
        {
            pbvr._onVRButtonRelease.AddListener(VRButtonLogic);

            // To add an Event Listener for _onVRButtonPress, use
            //pbvr._onVRButtonPress.AddListener(VRButtonLogic);
        }
    }
    /// <summary>
    /// Removes an Event Listener to the event _onVRButtonRelease that belongs to the current instance of the class PhysicalButtonVR
    /// </summary>
    private void OnDisable()
    {
        foreach (PhysicalButtonVR pbvr in _physicalButtonVRList)
        {
            pbvr._onVRButtonRelease.RemoveListener(VRButtonLogic);

            //pbvr._onVRButtonPress.RemoveListener(VRButtonLogic);;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="functionIndex">"Controls which function the button triggers</param>
    private void VRButtonLogic(int functionIndex)
    {

        switch(functionIndex)
        {
            case 0:
                _gameObjectManager.SpawnObject();
                break;
            case 1:
                _gameObjectManager.DestroyAllGameObjects();
                break;
            default:
                _gameObjectManager.SpawnObject();
                break;
        }
    }
}
