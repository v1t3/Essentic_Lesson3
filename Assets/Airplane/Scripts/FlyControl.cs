using UnityEngine;

namespace Airplane.Scripts
{
    public class FlyControl : MonoBehaviour
    {
        private GameManager _gameManagerScript;

        [SerializeField] private Rigidbody rb;

        [SerializeField] private float speedMultiplier = 1;
        private float _fastSpeed= 1;
        private float _slowSpeed = 1;
        [SerializeField] private float turnSpeed = 1;

        private bool _isWall;
        
        private void Awake()
        {
            _gameManagerScript = FindObjectOfType<GameManager>();
        }
        
        private void Start()
        {
            Vector3 centerOfMass = rb.centerOfMass;
            centerOfMass.z -= 0.5f;
            rb.centerOfMass = centerOfMass;
        }

        private void FixedUpdate()
        {
            if (!_gameManagerScript.gameActive) return;

            float speed = _gameManagerScript.worldSpeed * speedMultiplier;
            
            rb.AddForce(Vector3.right * speed * Time.deltaTime, ForceMode.Impulse);

            speed = speedMultiplier;
            
            if (!_isWall && Input.GetKey(KeyCode.W))
            {
                speed += _fastSpeed;

                rb.AddForce(transform.forward * speed * Time.deltaTime, ForceMode.Impulse);
            }

            if (Input.GetKey(KeyCode.S))
            {
                speed -= _slowSpeed;

                rb.AddForce(transform.forward * speed * Time.deltaTime, ForceMode.Impulse);
            }

            float turn = Input.GetAxis("Horizontal");

            if (0 != turn)
            {
                rb.AddTorque(transform.right * turnSpeed * turn * Time.deltaTime, ForceMode.Impulse);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("StartWall"))
            {
                rb.velocity = Vector3.zero;
            }
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Wall"))
            {
                _isWall = true;
            }
        }

        private void OnCollisionExit(Collision other)
        {
            if (other.gameObject.CompareTag("Wall"))
            {
                _isWall = false;
            }
        }

        public void SetFastSpeed(int value)
        {
            _fastSpeed = value;
        }

        public void SetSlowSpeed(int value)
        {
            _slowSpeed = value;
        }
    }
}