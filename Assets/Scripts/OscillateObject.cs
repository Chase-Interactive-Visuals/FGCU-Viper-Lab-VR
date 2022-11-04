/*
 * Notice:
 * This script was prepared by Chase Interactive Visuals, LLC, 
 * and is provided to FGCU for educational purposes only!
 * 
 * Class Summary:
 * Oscillates an object within a Vector3, at a specified Period
 */

using UnityEngine;

[DisallowMultipleComponent]
public class OscillateObject : MonoBehaviour
{
    //The vector in which the object will oscillate within
    [SerializeField] Vector3 MovementVector;

    //The time it takes for the oscillation to complete ONE time
    [SerializeField] float Period = 2f;

    [Range(0, 1)][SerializeField] float MovementFactor;

    //The transform.position the object starts at
    Vector3 StartingPos;

    //Boolean to activate/deactivate debugging for understanding code events
    [SerializeField] bool debuggingIsActive;

    // Start is called before the first frame update
    void Start()
    {
        //Sets the StartingPos variable as the objects transform.localPosition Vector3
        StartingPos = transform.localPosition;
    }
    //Update is called every frame
    void Update()
    {
        if (Period <= Mathf.Epsilon)
        {
            return;
        }

        float cycle = Time.time / Period;
        const float tau = Mathf.PI * 2f;
        float RawSinWave = Mathf.Sin(cycle * tau);
        MovementFactor = RawSinWave / 2f + 0.5f;
        //Calculates the offset; where the object should be in reference to the starting position
        Vector3 Offset = MovementFactor * MovementVector;

        //Sets the objects transform.localPosition as the new value each frame
        transform.localPosition = StartingPos + Offset;

        //Display Offset to console to see what value is being calculated
        if (debuggingIsActive)
        {
            Debug.Log("\nOffset Value: " + Offset);
        }
    }
}