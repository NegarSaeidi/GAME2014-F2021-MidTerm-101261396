/*
 *                    Midterm
 *                    Author: Negar Saeidi
 *                    Student number : 101261396
 *                    Date last modified: 10/21/2021
 *                    Rivision history: 1st version : changed player;s movemnt direction to be able to go up and down              
 *                    File: PlayerController: controls simple movement of player by touch input and getAxis
 *                    
 *                    
 */

using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public BulletManager bulletManager;
   
   

    [Header("Boundary Check")]
    public float Boundary;

    [Header("Player Speed")]
    public float speed;
    public float maxSpeed;
    public float TValue;

    [Header("Bullet Firing")]
    public float fireDelay;


    // Private variables
    private Rigidbody2D m_rigidBody;
    private Vector3 m_touchesEnded;

    // Start is called before the first frame update
    void Start()
    {
        m_touchesEnded = new Vector3();
        m_rigidBody = GetComponent<Rigidbody2D>();
  
    }

    // Update is called once per frame
    void Update()
    {
        _Move();
        _CheckBounds();
        _FireBullet();
      
    }

    private void _FireBullet()
    {
        // delay bullet firing 
        if (Time.frameCount % 60 == 0 && bulletManager.HasBullets())
        {
            bulletManager.GetBullet(transform.position);
        }
    }
    /// <summary>
    /// player movement by touch and getting input.getAxis
    /// </summary>
    private void _Move()
    {
        float direction = 0.0f;

        // touch input support
        foreach (var touch in Input.touches)
        {
            var worldTouch = Camera.main.ScreenToWorldPoint(touch.position);

            if (worldTouch.y > transform.position.y)
            {
                // direction is positive
                direction = 1.0f;
            }

            if (worldTouch.y < transform.position.y)
            {
                // direction is negative
                direction = -1.0f;
            }
            m_touchesEnded = worldTouch;

        }

     
        if (Input.GetAxis("Vertical") >= 0.1f)
        {
            // direction is positive
            direction = 1.0f;
        }

        if (Input.GetAxis("Vertical") <= -0.1f)
        {
            // direction is negative
            direction = -1.0f;
        }

        if (m_touchesEnded.y != 0.0f)
        {
            transform.position = new Vector2(transform.position.x, Mathf.Lerp(transform.position.y, m_touchesEnded.y, TValue));
        }
        else
        {
            Vector2 newVelocity = m_rigidBody.velocity + new Vector2(0.0f, direction * speed);
            m_rigidBody.velocity = Vector2.ClampMagnitude(newVelocity, maxSpeed);
            m_rigidBody.velocity *= 0.99f;
        }
    }
    /// <summary>
    /// checks if the player is going out of the boundaries
    /// </summary>
    private void _CheckBounds()
    {
        // check right bounds
        if (transform.position.y >= Boundary)
        {
            transform.position = new Vector3(transform.position.x, Boundary, 0.0f);
        }

        // check left bounds
        if (transform.position.y <= -Boundary)
        {
            transform.position = new Vector3(transform.position.x, -Boundary, 0.0f);
        }

    }
}
