using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMove : MonoBehaviour
{
    private float speed = 10f; // sets player's speed
    private float jump = 10f; // sets player's jump amount
    private bool isGrounded; // checks if player is on the ground

    void Update()
    {
        // controls player's left/right movement
        float h = Input.GetAxis("Horizontal");
        Vector3 pos = GetComponent<Transform>().position;
        pos.x += h*speed*Time.deltaTime;
        transform.position = pos;

        // checks if player is on the ground
        if (Physics.Raycast(pos, Vector3.down, 0.5f))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        // controls player's jump movement
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up*jump, ForceMode.Impulse);
        }
    }
}
