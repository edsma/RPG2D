using UnityEngine;
using static Assets.Scripts.Common.Constants;

public class WaypointMovement : MonoBehaviour
{
    [SerializeField] protected MovementDirection direction;
    [SerializeField] private float speed;
    protected Waypoint _waypoint;
    protected int actualPointIndex;
    protected Vector3 lastPosition;
    protected Animator _animator;
    public Vector3 pointForMove => _waypoint.ObtainPositionMovement(actualPointIndex);

    // Start is called before the first frame update
    void Start()
    {
        actualPointIndex= 0;
        _animator= GetComponent<Animator>();
        _waypoint= GetComponent<Waypoint>();    
    }

    // Update is called once per frame
    void Update()
    {
        MoveCharacter();
        RotateCharacter();
        if (CheckActualPoint())
        {
            UpdateIndexMovement();
        }
    }

    private void UpdateIndexMovement()
    {
        if (actualPointIndex == _waypoint.Points.Length - 1) 
        {
            actualPointIndex= 0;
        }
        else
        {
            if (actualPointIndex < _waypoint.Points.Length - 1)
            {
                actualPointIndex++;
            }
        }
    }

    private bool CheckActualPoint()
    {
        float distanceToActualPoint = (transform.position - pointForMove).magnitude;
        if (distanceToActualPoint < 0.1f)
        {
            lastPosition = transform.position;
            return true;
        }
        return false;
    }

    private void MoveCharacter()
    {
        transform.position = Vector3.MoveTowards(transform.position, pointForMove, speed*Time.deltaTime);
    }


    protected virtual void RotateCharacter()
    {
        if (direction != MovementDirection.Horizontal)
        {
            return;
        }

        if (pointForMove.x > lastPosition.x)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    protected virtual void RotateVerticalCharacter()
    {
        if (direction != MovementDirection.Horizontal)
        {
            return;
        }

        if (pointForMove.x > lastPosition.x)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
}
