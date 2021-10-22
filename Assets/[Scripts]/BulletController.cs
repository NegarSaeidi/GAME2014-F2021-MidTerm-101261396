/*
 *                    Midterm
 *                    Author: Negar Saeidi
 *                    Student number : 101261396
 *                    Date last modified: 10/21/2021
 *                    Rivision history: 1st version : changed bullets direction in order for them to go from left to right              
 *                    File: BulletController: controls simple movement of bullets
 *                    
 *                    
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour, IApplyDamage
{
    public float speed;
    public float Boundary;
    public BulletManager bulletManager;
    public int damage;
    
    // Start is called before the first frame update
    void Start()
    {
        bulletManager = FindObjectOfType<BulletManager>();
    }

    // Update is called once per frame
    void Update()
    {
        _Move();
        _CheckBounds();
    }
    /// <summary>
    /// move the bullet in x axis
    /// </summary>
    private void _Move()
    {
     
        transform.position += new Vector3(speed, 0.0f, 0.0f) * Time.deltaTime;
    }
    /// <summary>
    /// checks if the bullet is going out of the boundaries
    /// </summary>
    private void _CheckBounds()
    {
      
        if (transform.position.x > Boundary)
        {
            bulletManager.ReturnBullet(gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        bulletManager.ReturnBullet(gameObject);
    }

    public int ApplyDamage()
    {
        return damage;
    }
}
