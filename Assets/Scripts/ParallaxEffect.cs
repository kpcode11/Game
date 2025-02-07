using System;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    public Camera cam; // Camera used for the parallax effect
    public Transform followTarget; // Target the object will follow

    private Vector2 startingPosition; // Starting position of the object
    private float startingZ; // Starting Z position of the object

    // Calculates how much the camera has moved since the start
    private Vector2 CamMoveSinceStart => (Vector2)cam.transform.position - startingPosition;

    // Distance in the Z-axis between this object and the follow target
    private float ZDistanceFromTarget => transform.position.z - followTarget.position.z;

    // Calculate the clipping plane based on the Z-distance
    private float ClippingPlane => Mathf.Abs(cam.transform.position.z + (ZDistanceFromTarget > 0 ? cam.farClipPlane : cam.nearClipPlane));

    // Parallax factor determines how strong the parallax effect is
    private float ParallaxFactor => Mathf.Abs(ZDistanceFromTarget) / ClippingPlane;

    void Start()
    {
        // Assign Main Camera if not manually assigned
        if (cam == null)
        {
            cam = Camera.main;
            if (cam == null)
            {
                Debug.LogError("No camera found for ParallaxEffect. Please assign one.");
                return;
            }
        }

        // Ensure followTarget is assigned
        if (followTarget == null)
        {
            Debug.LogError("No follow target assigned to ParallaxEffect. Please assign one.");
            return;
        }

        // Initialize starting positions
        startingPosition = transform.position;
        startingZ = transform.position.z;
    }

    void Update()
    {
        if (cam == null || followTarget == null)
            return;

        // Calculate the new position using parallax effect
        Vector2 newPosition = startingPosition + CamMoveSinceStart * ParallaxFactor;

        // Apply the new position to the object
        transform.position = new Vector3(newPosition.x, newPosition.y, startingZ);
    }
}
