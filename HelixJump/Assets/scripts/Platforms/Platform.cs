using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private float _bounceForce = 50;
    [SerializeField] private float _bounceRadius = 50;

    public void Break()
    {
        PlatformSegment[] platformSegments= GetComponentsInChildren<PlatformSegment>();

        foreach (var segment in platformSegments)
        {
            segment.Bounce(_bounceForce, transform.position, _bounceRadius);
        }
    }
        
}
