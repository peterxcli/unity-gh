using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class VikingCameraRotation : MonoBehaviour
{
    [SerializeField] float sensitivity = 10f;
    private Vector2 mD;
    private Transform myBody;
    private Transform myCamera;
    void Start()
    {
        // myBody = this.transform.parent;
        myBody = this.transform;
        myCamera = this.transform.GetChild(3);
        // Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        Vector2 mC = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")) * sensitivity;
        mD += mC;
        mD = new Vector2(mD.x, Math.Clamp(mD.y, -55, 30));
        myCamera.localRotation = Quaternion.AngleAxis(-mD.y, Vector3.right);

        myBody.localRotation = Quaternion.AngleAxis(mD.x, Vector3.up);

        // if (Input.GetMouseButtonDown(0))
    }
}
