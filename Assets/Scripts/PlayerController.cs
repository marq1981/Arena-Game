using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private Animator playerAnim;
    private float moveFowardSpeed = 3;
    private float moveBackSpeed = 2;
    private Vector2 turn;
    private float sensitivity = 2;
    private float moveLeftAndRightSpeed = 2;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
    }

   
    void FixedUpdate()
    {
        MoveFoward();
        MoveBack();
        MoveLeft();
        MoveRight();
        RotateWithMouse();
        Block();
        Attack();
    }

    private void MoveFoward()
    {
        if (Input.GetKey(KeyCode.W))
        {
            //playerRb.velocity = (Vector3.forward * moveFowardSpeed);
            float movmentFowardRealSpeed = (moveFowardSpeed * Time.fixedDeltaTime);
            transform.Translate(Vector3.forward * movmentFowardRealSpeed);
            playerAnim.SetBool("foward", true);
        }
        else
        {
            transform.Translate(Vector3.zero);
            playerAnim.SetBool("foward", false);
        }
    }
    private void MoveBack()
    {
        if (Input.GetKey(KeyCode.S))
        {
            //playerRb.velocity = (Vector3.back * moveBackSpeed);
            float movmentBackRealSpeed = (moveBackSpeed * Time.fixedDeltaTime);
            transform.Translate(Vector3.back * movmentBackRealSpeed);
            playerAnim.SetBool("backward", true);
        }
        else
        {
            transform.Translate(Vector3.zero);
            playerAnim.SetBool("backward", false);
        }
    }
    private void RotateWithMouse()
    {
        turn.x += Input.GetAxis("Mouse X") * sensitivity;
        transform.localRotation = Quaternion.Euler(0, turn.x, 0);
    }
    private void MoveLeft()
    {
        if (Input.GetKey(KeyCode.A))
        {
            float movmentLeftRealSpeed = (moveLeftAndRightSpeed * Time.fixedDeltaTime);
            transform.Translate(Vector3.left * movmentLeftRealSpeed);
            playerAnim.SetBool("left", true);
        }
        else
        {
            transform.Translate(Vector3.zero);
            playerAnim.SetBool("left", false);
        }
    }
    private void MoveRight()
    {
        if (Input.GetKey(KeyCode.D))
        {
            float movmentRightRealSpeed = moveLeftAndRightSpeed * Time.fixedDeltaTime;
            transform.Translate(Vector3.right * movmentRightRealSpeed);
            playerAnim.SetBool("right", true);
        }
        else
        {
            transform.Translate(Vector3.zero);
            playerAnim.SetBool("right", false);
        }
    }
    private void Attack()
    {
        if (Input.GetMouseButton(0))
        {
            playerAnim.SetBool("attack", true);
        }
        else
        {
            playerAnim.SetBool("attack", false);
        }
    }
    private void Block()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            playerAnim.SetBool("block", true);
        }
        else
        {
            playerAnim.SetBool("block", false);
        }
    }
}
