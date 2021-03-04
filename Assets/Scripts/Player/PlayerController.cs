using System;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerController : MonoBehaviour
    {
        [Header("Player Properties")]
        [Tooltip("How fast the player moves.")] [SerializeField] private float playerSpeed = 5.0f;
        
        [Space(5)]
        
        [Tooltip("How high the player jumps.")] [SerializeField] private float playerJumpHeight = 0.0f;
        
        [Range(-100, 0)] [SerializeField] private float gravityForce = -5.0f;
        [SerializeField] private float velocityMultiplier = 1.0f;
        
        private CharacterController _controller;
        
        private bool _isGrounded;
        private Vector3 _playerVelocity;


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
        }

        private void VerticalMovement()
        {
            Debug.Log($"isGrounded: {_isGrounded}");
            
            if (_isGrounded && _playerVelocity.y < 0)
            {
                _playerVelocity.y = 0;
            }
            
            if (Input.GetButtonDown("Jump") && _isGrounded)
            {
                _playerVelocity.y += Mathf.Sqrt(playerJumpHeight * -3.0f * gravityForce);
            }

            _playerVelocity.y += gravityForce * velocityMultiplier * Time.deltaTime;
            _controller.Move(_playerVelocity * Time.deltaTime);
            
            //Debug.Log($"Y Velocity: {_playerVelocity.y}");
        }
        

#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            var position = transform.position;
            Gizmos.DrawSphere(new Vector3(position.x + Input.GetAxis("Horizontal"), position.y, position.z + Input.GetAxis("Vertical")), 0.5f);
        }
#endif
    }
}