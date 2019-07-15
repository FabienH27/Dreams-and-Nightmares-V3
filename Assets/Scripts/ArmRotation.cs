using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmRotation : MonoBehaviour {


    private PauseMenu pause;

    private void Start()
    {
        pause = GameObject.Find("Manager").GetComponent<PauseMenu>();
        
    }

    // Update is called once per frame
    void Update () {

        if(pause.GameIsPaused == false)
        {
            Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            difference.Normalize();
            difference = new Vector3(Mathf.Abs(difference.x), difference.y, difference.z);
            float ClampAngle = 20;
            float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            rotZ = Mathf.Clamp(rotZ, -ClampAngle, ClampAngle);

            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 toMouse = mousePosition - (Vector2)transform.position;
            Vector2 forward = transform.right;
            float dot = Vector2.Dot(forward, toMouse);
            bool inFrontOfWeapon = dot > 0;

            if (!inFrontOfWeapon)
                rotZ = -rotZ;

            transform.rotation = Quaternion.Euler(0, 0, rotZ);
        }

    }
}
