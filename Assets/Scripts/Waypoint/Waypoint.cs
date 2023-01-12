using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] private Vector3[] points;
    public Vector3[] Points => points;
    public Vector3 actualPosition { get; set; }
    private bool startGame;


    private void Start()
    {
        startGame= true;
        actualPosition= transform.position;
    }

    public Vector3 ObtainPositionMovement(int index)
    {
        return actualPosition + points[index];
    }

    private void OnDrawGizmos()
    {
        if (!startGame && transform.hasChanged)
        {
            actualPosition = transform.position;
        }

        if (points == null || points.Length <= 0)
        {
            return;
        }

        for (int i = 0; i < points.Length; i++)
        {
            Gizmos.color= Color.blue;
            Gizmos.DrawWireSphere(points[i] + actualPosition, 0.5f);
            if (i < points.Length - 1)
            {
                Gizmos.color = Color.gray;
                Gizmos.DrawLine(points[i] + actualPosition, points[i + 1] + actualPosition);
            }
        }
    }
}
