/*
 * Notice:
 * This script was prepared by Chase Interactive Visuals, LLC, 
 * and is provided to FGCU for educational purposes only!
 * 
 * Class Summary:
 * Rotates an object at the center of the transform.position at x|y|z degrees per second (Time.deltaTime)
 */

using UnityEngine;

public class RotateObject : MonoBehaviour
{
    //Degrees to rotate object in the x, y, and z axis
    [SerializeField] float xAngle;
    [SerializeField] float yAngle;
    [SerializeField] float zAngle;

    //Boolean to activate/deactivate debugging for understanding code events
    [SerializeField] bool debuggingIsActive;

    // Update is called once per frame 
    void Update()
    {
        //Rotates the object by the x, y, and z degrees per second
        transform.Rotate(xAngle * Time.deltaTime, yAngle * Time.deltaTime, zAngle * Time.deltaTime);

        //Display Rotation to console to see what value is being calculated
        if (debuggingIsActive)
        {
            Debug.Log("\nObject Rotation: \n" + "X Axis: " + transform.eulerAngles.x + "\nY Axis: " + transform.eulerAngles.y + "\nZ Axis: " + transform.eulerAngles.z);
        }
    }
}