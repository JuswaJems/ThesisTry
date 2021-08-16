using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class playerMovement : MonoBehaviour
{

    public Weapons currentweapon;
    public GameObject bullet;
    public GameObject throwButton;
    public GameObject pickupButton;
    public GameObject canvas;
    public GameObject namecanvas;
    public GameObject cam;
    public Text playername;
    PhotonView view;

    public Animator animator;
    private Rigidbody2D rb;
    private bool moveLeft;
    private bool moveRight;
    private bool jump;
    private bool canJump;
    private bool attack;
    private bool Throw;
    private bool PickUp;
    private float horizontalMove;
    private float verticalMove;
    private float jumpSpeed = 10;
    public float speed = 5;
    public float minX, maxX;

    // Start is called before the first frame update

    void OnCollisionEnter2D(Collision2D collision)
    {
        canJump = true;
        animator.SetBool("isJump", false);
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        moveLeft = false;
        moveRight = false;
        jump = false;
        attack = false;
        view = GetComponent<PhotonView>();
        if (view.IsMine)
        {
            playername.text = PhotonNetwork.NickName;
        }
        else
        {
            playername.text = view.Owner.NickName;
        }
    }

    public void PointerDownLeft()
    {
        moveLeft = true;
    }

    public void PointerUpLeft()
    {
        moveLeft = false;
    }

    public void PointerDownRight()
    {
        moveRight = true;
    }

    public void PointerUpRight()
    {
        moveRight = false;
    }

    public void PointerDownJump()
    {
        jump = true;
    }

    public void PointerUpJump()
    {
        jump = false;
    }

    public void PointerDownAttack()
    {
        attack = true;
    }

    public void PointerUpAttack()
    {
        attack = false;
    }

    public void PointerDownPickUp()
    {
        PickUp = true;
    }

    public void PointerUpPickUp()
    {
        PickUp = false;
    }

    public void PointerDownThrow()
    {
        Throw = true;
    }

    public void PointerUpThrow()
    {
        Throw = false;
    }


    // Update is called once per frame
    void Update()
    {
        if (view.IsMine)
        {
            canvas.SetActive(true);
            cam.SetActive(true);
        }
        else
        {
            canvas.SetActive(false);
            cam.SetActive(false);
        }
        MovementPlayer();
        rb.velocity = new Vector2(horizontalMove, rb.velocity.y);
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
    }

    private void MovementPlayer()
    {
        if (moveLeft)
        {
            if (transform.position.x >= minX)
            {
                horizontalMove = -speed;
                GetComponent<SpriteRenderer>().flipX = true;
                namecanvas.transform.rotation = Quaternion.identity;
            }
            else
            {
                horizontalMove = 0;
            }
        }
        else if (moveRight)
        {
            if (transform.position.x <= maxX)
            {
                horizontalMove = speed;
                GetComponent<SpriteRenderer>().flipX = false;
                namecanvas.transform.rotation = Quaternion.identity;
            }
            else
            {
                horizontalMove = 0;
            }
        }
        else
        {
            horizontalMove = 0;
        }
        if (jump && canJump)
        {
            rb.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
            animator.SetBool("isJump", true);
            jump = false;
            canJump = false;
        }
        if (attack)
        {
            if (currentweapon == null)
            {
                animator.SetBool("isAttacking", true);
            }
            else 
            {
                PhotonNetwork.Instantiate(bullet.name, transform.position, Quaternion.identity);
            }
        }
        else
        {
            animator.SetBool("isAttacking", false);
        }
        //if (Throw && currentweapon != null)
        //{
        //    Instantiate(bullet, transform.position, Quaternion.identity);
        //    currentweapon = null;
        //    transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = null;
        //    canvas.SetActive(false);
        //}
        if (PickUp)
        {
            Physics2D.IgnoreLayerCollision(8, 9, false);
            Physics2D.IgnoreLayerCollision(9, 10, false);
            animator.SetBool("isPickUp", true);
            if (currentweapon != null)
            {
                animator.SetBool("isPickUp", false);
                throwButton.SetActive(true);
                pickupButton.SetActive(false);
                if (Throw)
                {
                    animator.SetBool("isPickUp", false);
                }
            }
        }
        else
        {
            Physics2D.IgnoreLayerCollision(8, 9, true);
            Physics2D.IgnoreLayerCollision(9, 10, true);
            animator.SetBool("isPickUp", false);
        }
        if (Throw && currentweapon != null)
        {
            PhotonNetwork.Instantiate(bullet.name, transform.position, Quaternion.identity);
            currentweapon = null;
            transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = null;
            throwButton.SetActive(false);
            pickupButton.SetActive(true);
            PickUp = false;
        }
    }
}