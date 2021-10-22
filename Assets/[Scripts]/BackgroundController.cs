/*
 *                    Midterm
 *                    Author: Negar Saeidi
 *                    Student number : 101261396
 *                    Date last modified: 10/21/2021
 *                    Rivision history: 1st version : applied changes to have a right to left scroller bg              
 *                    File: BackgroundController: controls movement and transition  of backgrounds
 *                    
 *                    
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    public float verticalSpeed;
    public float horizontalSpeed;
    public float verticalBoundary;
    public float horizontalBoundary;

    // Update is called once per frame
    void Update()
    {
        _Move();
        _CheckBounds();
    }
    /// <summary>
    /// reseting bg game object to the original position
    /// </summary>
    private void _Reset()
    {
     
        transform.position = new Vector3(horizontalBoundary, 0.0f);
    }
    /// <summary>
    /// bg movement from right to left
    /// </summary>
    private void _Move()
    {
       
        transform.position -= new Vector3(horizontalSpeed, 0) * Time.deltaTime;
    }
    /// <summary>
    /// checks if bg is going out of the boundaries
    /// </summary>
    private void _CheckBounds()
    {
       
        if (transform.position.x <= -horizontalBoundary)
        {
            _Reset();
        }
    }
}
