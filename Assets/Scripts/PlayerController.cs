using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float torqueAmount = 1f;
    [SerializeField] private float boostSpeed = 20f;
    [SerializeField] private float baseSpeed = 10f;

    private Rigidbody2D rb = null;
    private bool canMove = true;
    SurfaceEffector2D surfaceEffector = null;

    private void Awake()
    {
        canMove = true;
        rb = GetComponent<Rigidbody2D>();
        surfaceEffector = FindObjectOfType<SurfaceEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            RotatePlayer();
            RespondToBoost();
        }

        void RotatePlayer()
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                rb.AddTorque(torqueAmount);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                rb.AddTorque(-torqueAmount);
            }
        }

        void RespondToBoost()
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                surfaceEffector.speed = boostSpeed;
            }
            else
            {
                surfaceEffector.speed = baseSpeed;
            }
        }
    }

    public void DisableControls()
    {
        canMove = false;
    }
}
