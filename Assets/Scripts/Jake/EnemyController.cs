using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using UnityEngine.EventSystems;


public class EnemyController : MonoBehaviour
{

    public Transform[] points; // array of transforms - different points on the patrol path
    private int destPoint = 0;
    private EnemyController _enemy;
    private Vector3 _enemyVelocity;
    public float speed = 1f;
    public float distance;
    private Vector3 targetPosition;

    void Start()
    {
        _enemy = GetComponent<EnemyController>();
        GotoNextPoint();
    }

    void GotoNextPoint()
    {
        if (points.Length == 0)
            return;
        // returns if no points have been set up

        targetPosition = points[destPoint].position; // sets the enemy's next point to go to
        destPoint = (destPoint + 1) % points.Length; // sets the next point in the array as the destination
        // cycles back to the start of the array after the last point
    }

    void Update()
    {

        Vector3 currentPosition = _enemy.transform.position;
        //first, check to see if we're close enough to the target
        distance = Vector3.Distance(currentPosition, targetPosition);
        if (distance > 0.5f)
        {
            Vector3 directionOfTravel = targetPosition - currentPosition;
            //now normalize the direction, since we only want the direction information
            directionOfTravel.Normalize();
            //scale the movement on each axis by the directionOfTravel vector components
            _enemy.transform.Translate(
                (directionOfTravel.x * speed * Time.deltaTime),
                (directionOfTravel.y * speed * Time.deltaTime),
                (directionOfTravel.z * speed * Time.deltaTime),
                Space.World);
        }
        else
        {
            GotoNextPoint();
        }

    }
}
