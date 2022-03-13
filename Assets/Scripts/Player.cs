using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefabs;
    [SerializeField] private GameObject _bulletFired;
    
    public int score = 0;
    public int bulletLeft = 2;
    
    public Text scoreBoard;
    public Text ammoLeft;
    
    public GameObject gameOverPanel;
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && bulletLeft >= 1)
        {
            Fire();
            
        }
    }

    private void Fire()
    {
        if (Input.GetMouseButtonDown(0) && bulletLeft >= 1)
        {
            Vector3 pointTargetPosition = Aim();
            if (pointTargetPosition != Vector3.zero)
            {
                _bulletFired = Instantiate(_bulletPrefabs, transform.position, transform.rotation);
                _bulletFired.GetComponent<Bullet>().player = this;
                _bulletFired.transform.LookAt(pointTargetPosition);
                _bulletFired.GetComponent<Rigidbody>().AddForce(_bulletFired.transform.forward * 1000f);

                bulletLeft--;
                ammoLeft.text = "Ammo Left = " + bulletLeft;

            }
        }
    }

    public void TargetHit()
    {
        bulletLeft = bulletLeft + 1;
        score++;
            
        scoreBoard.text = "Score = " + score;
        ammoLeft.text = "Ammo Left = " + bulletLeft;
        
    }


    private Vector3 Aim()
    {
        RaycastHit hit;
        Vector2 mousePosiiton = Input.mousePosition;

        Vector3 point = Camera.main.ScreenToWorldPoint(new Vector3(mousePosiiton.x,mousePosiiton.y,Camera.main.nearClipPlane));
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(mousePosiiton.x,mousePosiiton.y,Camera.main.nearClipPlane));
        if (Physics.Raycast(ray, out hit))
        {
            return hit.point;
        }
        return Vector3.zero;
    }
    
    
    
    
}



/*
    
    GameObject.tag = "Targets"

    public void TargetDestruction()
    {
        GameObject.CompareTag("Targets");
        Destroy(Target,10);
    }


    
*/