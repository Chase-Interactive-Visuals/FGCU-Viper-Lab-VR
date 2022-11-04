/*
 * Notice:
 * This script was prepared by Chase Interactive Visuals, LLC, 
 * and is provided to FGCU for educational purposes only!
 * 
 * Class Summary:
 * Manages Specific GameObjects in the scene
 */

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GameObjectManager : MonoBehaviour
{
    [SerializeField] GameObject _prefabToInstantiate;
    [SerializeField] Material _newObjectColor;
    [SerializeField] Vector3 _positionToInstantiate = new Vector3(0, .5f, 0);
    [SerializeField] Quaternion _rotationToInstantiate = new Quaternion(0, 0, 0, 0);

    public List<GameObject> _instantiatedGameObjectsList = new List<GameObject>();
    List<ChangeObjectColor> _changeObjectColorList = new List<ChangeObjectColor>();
    List<XRGrabInteractable> _xrGrabInteractableList = new List<XRGrabInteractable>();

    //Boolean to activate/deactivate debugging for understanding code events
    [SerializeField] bool debuggingIsActive;

    

    // Start is called before the first frame update
    void Start()
    {
        if (FindObjectOfType<ChangeObjectColor>() != null)
        {
            // To Add a single ChangeObjectColor instance, use
            // _changeObjectColorList.Add(FindObjectOfType<ChangeObjectColor>());

            // Finds all ChangeObjectColor instances in the scene and adds them to the list
            _changeObjectColorList.AddRange(FindObjectsOfType<ChangeObjectColor>());
        }
    }
    

    /// <summary>
    /// Instantiate an object with a predefined position and rotation (set in editor)
    /// </summary>
    public void SpawnObject()
    {
        // Instantiate a clone of _prefabToInstantiate and store a temporary reference to it as a new var, newGo
        var newGO = Instantiate(_prefabToInstantiate, _positionToInstantiate, _rotationToInstantiate);

        // Add newGo to the List of GameObjects
        _instantiatedGameObjectsList.Add(newGO);
        newGO.name = _prefabToInstantiate.name + " " + _instantiatedGameObjectsList.Count.ToString();

        // If newGo has an XRGrabInteractable component, add it to the xrGrabInteractable List
        if (newGO.GetComponent<XRGrabInteractable>() != null)
        {
            // create a temporary reference so that you can extend this without having to call GetComponent<>() multiple times
            var xrGrabInteractiable = newGO.GetComponent<XRGrabInteractable>();
            _xrGrabInteractableList.Add(xrGrabInteractiable);

        }

        // If newGo has an ChangeObjectColor component, add it to the ChangeObjectColor List
        if (newGO.GetComponent<ChangeObjectColor>() != null)
        {
            // create a temporary reference so that you can extend this without having to call GetComponent<>() multiple times
            var changeObjectColor = newGO.GetComponent<ChangeObjectColor>();    
            _changeObjectColorList.Add(changeObjectColor);
        }
    }

    public void DestroyAllGameObjects()
    {
        // loop through all objects inside _instantiatedGameObjectsList
        foreach (GameObject go in _instantiatedGameObjectsList)
        {
            // Destroys the current go in the loop
            // PLEASE NOTE: Any lists this object is in needs to have that index cleared as it will now say null.
            Destroy(go);
        }
        // Clear all entries in all the lists
        _instantiatedGameObjectsList.Clear();
        _xrGrabInteractableList.Clear();
        _changeObjectColorList.Clear();
    }

    public void ChangeAllObjectsColor()
    {
        // Loop through each object in _changeObjectColorList and call AlternayeGameObjectColor()
        foreach (ChangeObjectColor coc in _changeObjectColorList)
        {
            coc.AlternateGameObjectColor(_newObjectColor);
        }
    }
}
