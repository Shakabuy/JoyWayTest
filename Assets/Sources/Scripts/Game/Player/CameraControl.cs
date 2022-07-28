using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public float Sensitivity;
    public Camera Camera;
    public PlayerMovement PlayerMovement;

    float xRotation = 0f;

    private void Update()
    {
        Vector2 input = InputManager.GetMouseAxis() * Sensitivity * Time.deltaTime;

        xRotation -= input.y;
        xRotation = Mathf.Clamp(xRotation, -90, 90);

        Camera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        PlayerMovement.Rotate(Vector3.up * input.x);
    }
}
