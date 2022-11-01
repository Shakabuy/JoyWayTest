using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public float sensitivity;
    public new Camera camera;
    public PlayerMovement playerMovement;

    float xRotation = 0f;

    private void Update()
    {
        Vector2 input = InputManager.GetMouseAxis() * sensitivity * Time.deltaTime;

        xRotation -= input.y;
        xRotation = Mathf.Clamp(xRotation, -90, 90);

        camera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerMovement.Rotate(Vector3.up * input.x);
    }
}
