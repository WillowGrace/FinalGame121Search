using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CareaControl : MonoBehaviour
{
    [SerializeField] private float _mouseMovement = 200;
    private Transform parent;
    private Camera _fpsCamera;



    void Start()
    {
        _fpsCamera = Camera.main;
        parent = transform.parent;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalRotation = Input.GetAxis("Mouse X") * _mouseMovement * Time.deltaTime; //horizontal rotation calculation   
        float verticalRotation = Input.GetAxis("Mouse Y") * _mouseMovement * Time.deltaTime; //vertical rotation calculation   
        parent.Rotate(0, horizontalRotation, 0); //rotate parent around the vertical axis-- horizontal movement   
        _fpsCamera.transform.Rotate(-verticalRotation, 0, 0); //rotate camera around the horizontal axis-- vertical movement
    }
}
