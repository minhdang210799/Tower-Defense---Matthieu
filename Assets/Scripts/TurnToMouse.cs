using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnToMouse : MonoBehaviour
{
    Camera cam;

    // Start is called before the first frame update
    void Awake()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 dir = mousePos - transform.position;
        float angle = Vector2.SignedAngle(Vector3.up, dir);

        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
