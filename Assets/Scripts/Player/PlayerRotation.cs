using System;
using UnityEngine;

namespace Player
{
    public class PlayerRotation : MonoBehaviour
    {
        [Tooltip("How fast the player rotates.")] [SerializeField] private float playerRotationSpeed = 5.0f;

        private void Update()
        {
            RotateToDirection();
        }

        private void RotateToDirection()
        {
            var direction = new Vector3(transform.position.x + Input.GetAxis("Horizontal"), transform.position.y, transform.position.z + Input.GetAxis("Vertical")) - transform.position;
            var step = playerRotationSpeed * Time.deltaTime;

            var newDirection = Vector3.RotateTowards(transform.forward, direction, step, 0.0f);

            if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
            {
                transform.rotation = Quaternion.LookRotation(newDirection);
            }
        }
    }
}
