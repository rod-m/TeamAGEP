using System;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerController : MonoBehaviour, IPowerUpEffect
    {
        /*
 * 
 * Please be aware the the CharacterController has its own capsule collider,
 * PlayerMesh Capsule CCollider conflicts with the isGrounded property
 */

        #region Propertis
        //Adam, add regions. Very good start, see comments for tips
        [Header("Player Properties")] [Tooltip("How fast the player moves.")] [SerializeField]
        private float playerSpeed = 5.0f;

        [Space(5)]
        // Adam, set a useful default value please!
        [Tooltip("How high the player jumps.")]
        [SerializeField]
        private float playerJumpHeight = 0.0f;

        [Range(-100, 0)] [SerializeField] private float gravityForce = -5.0f;
        [SerializeField] private float velocityMultiplier = 1.0f;

        private CharacterController _controller;

        private bool _isGrounded;
        private Vector3 _playerVelocity;

        #endregion

        private void Awake()
        {
            _controller = GetComponent<CharacterController>();
        }

        private void Update()
        {
            _isGrounded = _controller.isGrounded;

            Movement();
            VerticalMovement();
        }

        private void Movement()
        {
            var xAxis = Input.GetAxisRaw("Horizontal");
            var zAxis = Input.GetAxisRaw("Vertical");

            var move = new Vector3(xAxis, 0.0f, zAxis);

            //move.normalized - prevents accelerated movement when player is holding both forward/side buttons.
            _controller.Move(transform.TransformDirection(move.normalized) * (playerSpeed * Time.deltaTime));
            // you are calling Move twice in same frame!
        }

        private void VerticalMovement()
        {
            // Debug.Log($"isGrounded: {_isGrounded}"); // house keep!, comment out logs once finished debugging
            // no one else wants to see your log dumps!

            if (_isGrounded && _playerVelocity.y < 0)
            {
                _playerVelocity.y = 0;
            }

            if (Input.GetButtonDown("Jump") && _isGrounded)
            {
                // why -3.0 ?, the math for this should be -2
                // also this can be calculated once on start
                _playerVelocity.y += Mathf.Sqrt(playerJumpHeight * -2.0f * gravityForce);
            }

            // what is velocityMultiplier for?
            _playerVelocity.y += gravityForce * velocityMultiplier * Time.deltaTime;
            _controller.Move(_playerVelocity * Time.deltaTime); // you are calling Move twice in same frame!

            //Debug.Log($"Y Velocity: {_playerVelocity.y}");
        }


#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            /*
 * Adam, add a comment about what this is for
 */
            Gizmos.color = Color.red;
            var position = transform.position;
            Gizmos.DrawSphere(
                new Vector3(position.x + Input.GetAxis("Horizontal"), position.y,
                    position.z + Input.GetAxis("Vertical")), 0.5f);
        }
#endif
        public void PowerUpEffects(float _boostBy)
        {
          Debug.Log($"!!! powerup {_boostBy}");
          playerSpeed *= _boostBy;
        }
    }
}