/*
 *                    Midterm
 *                    Author: Negar Saeidi
 *                    Student number : 101261396
 *                    Date last modified: 10/21/2021
 *                    Rivision history: 1st version : changed the rotation of enemies, and their direction               
 *                    File: EnemyController: controls simple movement of enemies
 *                    
 *                    
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed;
    public float Boundary;
    public float direction;

    // Update is called once per frame
    void Update()
    {
        _Move();
        _CheckBounds();
    }
    /// <summary>
    /// move the enemy in y axis
    /// </summary>
    private void _Move()
    {
        
        transform.position += new Vector3(0.0f,speed * direction * Time.deltaTime, 0.0f);
    }
    /// <summary>
    /// checks if the enemy is going out of the boundaries
    /// </summary>
    private void _CheckBounds()
    {
       
        // check upper boundary
        if (transform.position.y >= Boundary)
        {
            direction = -1.0f;
        }

        // check bottom boundary
        if (transform.position.y <= -Boundary)
        {
            direction = 1.0f;
        }
    }
}
