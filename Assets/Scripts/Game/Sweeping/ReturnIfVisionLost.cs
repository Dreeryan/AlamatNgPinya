using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnIfVisionLost : MonoBehaviour
{
    // Detects manually if object is seen by the camera

    [SerializeField] private GameObject objectToSnapback;
    [SerializeField] private Collider2D objectCollider;

    public bool isSeen;
    Camera cam;
    Plane[] planes;

    void Start()
    {
        cam = Camera.main;
        planes = GeometryUtility.CalculateFrustumPlanes(cam);
        objectCollider = GetComponent<Collider2D>();
    }

    void Update()
    {
        if (GeometryUtility.TestPlanesAABB(planes, objectCollider.bounds))
        {
            isSeen = true;
        }
        else
        {
            isSeen = false;
        }
    }
}
