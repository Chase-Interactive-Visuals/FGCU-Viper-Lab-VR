/*
 * Notice:
 * This script was prepared by Chase Interactive Visuals, LLC, 
 * and is provided to FGCU for educational purposes only!
 * 
 * Class Summary:
 * Triggers PUBLIC script methods/functions with UI Events 
 */

using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] PhysicalButtonVRManager _physicalButtonVRManager;
    [SerializeField] GameObjectManager _gameObjectManager;

    [SerializeField] TextMeshProUGUI _spawnedObjectCounterText;

    private void Start()
    {
        
    }
    private void OnEnable()
    {
        foreach (GameObject go in _physicalButtonVRManager._vrButtonsList)
        {
            go.GetComponentInChildren<PhysicalButtonVR>()._onVRButtonPress.AddListener(SetSpawnsedObjectCounterText);
        }
    }
    private void OnDisable()
    {
        foreach (GameObject go in _physicalButtonVRManager._vrButtonsList)
        {
            go.GetComponentInChildren<PhysicalButtonVR>()._onVRButtonPress.RemoveListener(SetSpawnsedObjectCounterText);
        }
    }

    private void SetSpawnsedObjectCounterText()
    {
        _spawnedObjectCounterText.text = "Active Game Objects: " + _gameObjectManager._instantiatedGameObjectsList.Count.ToString();
    }
}
