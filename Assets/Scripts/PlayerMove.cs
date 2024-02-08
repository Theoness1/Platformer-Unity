using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Rigidbody Rigidbody;
    public float MoveSpeed;
    public float JumpSpeed;
    public float Friction;
    public bool Grounded;

    public float MaxSpeed;

    public Transform ColliderTransform;
    public Transform AimTransform;

    private int _jumpFrameCounter; // ����� ������ ���������� ������� �������.

    private void Update()
    {
        Compression();
        if (Input.GetKeyDown(KeyCode.Space) && Grounded == true)
        {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        Rigidbody.AddForce(0f, 0f, 0f, ForceMode.VelocityChange);

        float speedMultiplier = 1f;

        if(Grounded == false)
        {
            speedMultiplier = 0.2f;

            if(Rigidbody.velocity.x > MaxSpeed && Input.GetAxis("Horizontal") > 0)
            {
                speedMultiplier = 0;
            }
            if (Rigidbody.velocity.x < -MaxSpeed && Input.GetAxis("Horizontal") < 0)
            {
                speedMultiplier = 0;
            }
        }

        Rigidbody.AddForce(Input.GetAxis("Horizontal") * MoveSpeed * speedMultiplier, 0, 0, ForceMode.VelocityChange);

        if (Grounded)
        {
            Rigidbody.AddForce(-Rigidbody.velocity.x * Friction, 0, 0, ForceMode.VelocityChange);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.identity, Time.deltaTime * 15f);
        }

        _jumpFrameCounter += 1;
        if(_jumpFrameCounter == 2)
        {
            Rigidbody.freezeRotation = false;
            Rigidbody.AddRelativeTorque(0f, 0f, 10f, ForceMode.VelocityChange);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        float angle = Vector3.Angle(collision.contacts[0].normal, Vector3.up);
        if(angle < 45f)
        {
            Grounded = true;
            Rigidbody.freezeRotation = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        Grounded = false;
    }

    private void Compression() //������ �������
    {
        if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.S) || Grounded == false)
        {
            ColliderTransform.localScale = Vector3.Lerp(ColliderTransform.localScale, new Vector3(1f, 0.7f, 1f), Time.deltaTime * 15f);
        }
        else
        {
            ColliderTransform.localScale = Vector3.Lerp(ColliderTransform.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 25f);
        }
    }

    public void Jump()
    {
        Rigidbody.AddForce(0f, JumpSpeed, 0f, ForceMode.VelocityChange);
        _jumpFrameCounter = 0;
    }
}
