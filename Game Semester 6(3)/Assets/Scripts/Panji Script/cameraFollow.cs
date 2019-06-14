using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class cameraFollow : MonoBehaviour
{
    public List<Transform> Players;

    public Vector3 Offset;
    public float smoothTime = .5f;

    public float minZoom;
    public float maxZoom;
    public float zoomLimiter;

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

        Move();
        Zoom();
    }

    void Zoom()
    {
        float newZoom = Mathf.Lerp(maxZoom, minZoom, GetGratestDistance() / zoomLimiter);
        myCam.fieldOfView = Mathf.Lerp(myCam.fieldOfView, newZoom, Time.deltaTime);
    }

    void Move()
    {
        Vector3 centerPoint = GetCenterPoint();

        Vector3 newPosition = centerPoint + Offset;

        transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref Velocity, smoothTime);
    }

    float GetGratestDistance()
    {
        var bounds = new Bounds(Players[0].position, Vector3.zero);
        for(int i = 0; i < Players.Count; i++)
        {
            bounds.Encapsulate(Players[i].position);
        }

        return bounds.size.x;
    }

    Vector3 GetCenterPoint()
    {
        if(Players.Count == 1)
        {
            return Players[0].position;
        }

        var bounds = new Bounds(Players[0].position, Vector3.zero);
        for(int i = 0; i < Players.Count; i++)
        {
            bounds.Encapsulate(Players[i].position);
        }
        return bounds.center;
    }
}
