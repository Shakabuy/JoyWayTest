using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public CharacterController controller;

    private void Update()
    {
        Vector2 input = InputManager.GetMovementAxis();

        Vector3 move = transform.right * input.x + transform.forward * input.y;

        Move(move * speed * Time.deltaTime);
    }


    public void Move(Vector3 move)
    {
        controller.Move(move);
    }

    public void Rotate(Vector3 v)
    {
        transform.Rotate(v);
    }
}
