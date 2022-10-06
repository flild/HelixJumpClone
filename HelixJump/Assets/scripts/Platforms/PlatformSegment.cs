using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlatformSegment : MonoBehaviour
{
    private float DelayForDestroy = 3f; 
    public void Bounce(float force, Vector3 centre, float radius)
    {
        if(TryGetComponent(out Rigidbody rigidbody))
        {
            rigidbody.isKinematic = false;

            rigidbody.AddExplosionForce(force, centre, radius);
            this.Wait(DelayForDestroy, DestroyGameObject);
        }


    }

    void DestroyGameObject()
    {
        Destroy(gameObject);
    }


}


