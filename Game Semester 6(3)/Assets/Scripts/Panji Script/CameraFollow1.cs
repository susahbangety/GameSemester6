using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow1 : MonoBehaviour
{
    #region Singleton

    public static CameraFollow1 Instance { get; private set; }

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }else if(Instance != this)
        {
            Destroy(gameObject);
        }
    }

    #endregion

    [SerializeField] private float minDistanceForZoom = 10f;
    [SerializeField] private float maxPossibleZoom = 50f;
    [SerializeField] private float Smooth = 0.5f;
    [SerializeField] private float minY = 10f;
    [SerializeField] private float maxY = 40f;

    [SerializeField] private List<Transform> Players = new List<Transform>();

    private Vector3 Velocity;

    private void LateUpdate()
    {
        if(Players.Count == 0)
        {
            return;
        }

        Move();
        Zoom();
    }

    private void Move()
    {
        Vector3 centerPoint = GetCenterPoint();

        centerPoint.y = transform.position.y;

        transform.position = Vector3.SmoothDamp(transform.position, centerPoint, ref Velocity, Smooth);
    }

    private void Zoom()
    {
        float greatestDistance = GetGreatestDistance();

        if(greatestDistance < minDistanceForZoom)
        {
            greatestDistance = 0f;
        }

        float newY = Mathf.Lerp(minY, maxY, greatestDistance / maxPossibleZoom);

        transform.position = new Vector3(
            transform.position.x, 
            Mathf.Lerp(transform.position.y, newY, Time.deltaTime), 
            transform.position.z);
    }

    private float GetGreatestDistance()
    {
        Bounds bounds = EncapsulateTargets();
        
        return bounds.size.x > bounds.size.z ? bounds.size.x : bounds.size.z;
    }

    private Vector3 GetCenterPoint()
    {
        if(Players.Count == 0)
        {
            return Players[0].position;
        }

        Bounds bounds = EncapsulateTargets();

        Vector3 center = bounds.center;
        center.y = 0f;
        return center;
    }

    private Bounds EncapsulateTargets()
    {
        Bounds bounds = new Bounds(Players[0].position, Vector3.zero);

        foreach(Transform target in Players)
        {
            bounds.Encapsulate(target.position);
        }

        return bounds;
    }
}
