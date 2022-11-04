/*
 * Notice:
 * This script was prepared by Chase Interactive Visuals, LLC, 
 * and is provided to FGCU for educational purposes only!
 * 
 * Class Summary:
 * Controls Changing this GameObjects material between its default and a new material 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeObjectColor : MonoBehaviour
{
    MeshRenderer _objectMeshRenderer;

    Material _defaultMaterial;

    bool _isColorChanged = false;
    // Start is called before the first frame update
    void Start()
    {
        _objectMeshRenderer = this.transform.GetComponent<MeshRenderer>();
        _defaultMaterial = _objectMeshRenderer.material;
    }

    public void AlternateGameObjectColor(Material newMaterial)
    {
        if (!_isColorChanged)
        {
            _isColorChanged = true;
            _objectMeshRenderer.material = newMaterial;
        }
        else
        {
            _isColorChanged = false;
            _objectMeshRenderer.material = _defaultMaterial;
        }
        
    }
    public void SetGameObjectNewColor(Material newMaterial)
    {
        _objectMeshRenderer.material = newMaterial;
    }
    public void SetGameObjectDefaultColor()
    {
        _objectMeshRenderer.material = _defaultMaterial;
    }
}
