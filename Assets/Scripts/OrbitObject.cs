/*
 * Notice:
 * This script was prepared by Chase Interactive Visuals, LLC, 
 * and is provided to FGCU for educational purposes only!
 * 
 * Class Summary:
 * Orbits the object around another selected object
 */

using UnityEngine;

public class OrbitObject : MonoBehaviour
{
    //Assign a GameObject in the Inspector to rotate around
    [SerializeField] GameObject targetObject;

    //object orbiting speed; default is 20
    [SerializeField] float orbitSpeed = 20f;

    //The vectore that controls the orbit vector
    [SerializeField] Vector3 orbitVector;

    //Boolean to activate/deactivate debugging for understanding code events
    [SerializeField] bool debuggingIsActive;

    void Update()
    {
        // Orbit the object around the target at x degrees/second.
        transform.RotateAround(targetObject.transform.position, orbitVector, orbitSpeed * Time.deltaTime);

        //Display Rotation and Position to console to see what value is being calculated
        if (debuggingIsActive)
        {
            Debug.Log("\nObject Rotation: \n" + "X Axis: " + transform.eulerAngles.x + "\nY Axis: " + transform.eulerAngles.y + "\nZ Axis: " + transform.eulerAngles.z);
            Debug.Log("\nObject Position: \n" + "X Axis: " + transform.position.x + "\nY Axis: " + transform.position.y + "\nZ Axis: " + transform.position.z);
        }
    }
}