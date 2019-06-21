using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class cameraFollow : MonoBehaviour
{
    public List<Transform> Players;

    public Vector3 Offset;
    public float smoothTime = 0.5f;
    public float minZoom;
    public float maxZoom;
    public float zoomLimit;

    private Vector3 Velocity;
    private Camera myCam;

    void Start()
    {
        myCam = GetComponent<Camera>();
    }

    void LateUpdate()
    {
        if (Players.Count == 0)
            return;

        MoveCamera();
        ZoomCamera();
    }

    void MoveCamera()
    {
        Vector3 centerPoint = GetCenterPoint();

        Vector3 newPosition = centerPoint + Offset;

        transform.position = Vector3.SmoothDamp(
                                    transform.position, 
                                    newPosition, 
                                    ref Velocity, 
                                    smoothTime);
    }

    Vector3 GetCenterPoint()
    {
        if (Players.Count == 1)
        {
            return Players[0].position;
        }

        var bounds = new Bounds(Players[0].position, Vector3.zero);
        for (int i = 0; i < Players.Count; i++)
        {
            bounds.Encapsulate(Players[i].position);
        }

        return bounds.center;
    }

    void ZoomCamera()
    {
        float NewZoom = Mathf.Lerp(minZoom, maxZoom, GetGreatestDistance() / zoomLimit);
        myCam.fieldOfView = Mathf.Lerp(myCam.fieldOfView, NewZoom, Time.deltaTime);
        Debug.Log(GetGreatestDistance());
    }

    float GetGreatestDistance()
    {
        var CameraBound = new Bounds(Players[0].position, Vector3.zero);
        for (int i = 0; i < Players.Count; i++)
        {
            CameraBound.Encapsulate(Players[i].position);
        }

        return CameraBound.size.x;
    }
}
