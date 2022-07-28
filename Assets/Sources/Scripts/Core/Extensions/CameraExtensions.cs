using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CameraExtensions
{
    public static Ray GetRay(this Camera camera)
    {
        return new Ray(camera.transform.position, camera.transform.forward);
    }
}