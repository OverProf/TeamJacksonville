using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2 : MonoBehaviour
{
    CharacterController characterController;

    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    private Vector3 moveDirection = Vector3.zero;
    public BoxCollider Enemy1;
    public BoxCollider Enemy2;
    public BoxCollider Enemy3;
    public BoxCollider Enemy4;
    public BoxCollider Enemy5;
    public BoxCollider Enemy6;
    public BoxCollider Enemy7;
    const float buffsize = 5f;

    public GameObject sword;
    

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (characterController.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            moveDirection *= speed;
        
            if(Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
        }

        
        moveDirection.y -= gravity * Time.deltaTime;

        characterController.Move(moveDirection * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("Powerup"))
        {
            other.gameObject.SetActive(false);
           Enemy1.size = new Vector3(buffsize, Enemy1.size.y, buffsize);
            Enemy2.size = new Vector3(buffsize, Enemy2.size.y, buffsize);
            Enemy3.size = new Vector3(buffsize, Enemy3.size.y, buffsize);
            Enemy4.size = new Vector3(buffsize, Enemy4.size.y, buffsize);
            Enemy5.size = new Vector3(buffsize, Enemy5.size.y, buffsize);
            Enemy6.size = new Vector3(buffsize, Enemy6.size.y, buffsize);
            Enemy7.size = new Vector3(buffsize, Enemy7.size.y, buffsize);
            sword.SetActive(true);
        }
        if (other.gameObject.CompareTag("Bullet"))
        {
            gameObject.SetActive(false);
        }
    }

   

}
