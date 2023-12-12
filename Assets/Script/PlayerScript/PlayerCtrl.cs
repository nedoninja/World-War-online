using UnityEngine;

namespace Script.PlayerScript
{
    public class PlayerCtrl : MonoBehaviour
    {
        public CharacterController controller;
        public float speed = 10f;

        public float gravity = -9.8f;
        private Vector3 _velocity;
        public float jumpHeight = 3f;

        public Transform grndCheck;
        public float grndDist = 0.4f;
        public LayerMask grandMask;
        private bool _isGrand;

        private void Update()
        {
            _isGrand = Physics.CheckSphere(grndCheck.position, grndDist, grandMask);

            if (_isGrand && _velocity.y < 0)
            {
                _velocity.y = -2f;
            }

            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = transform.right * x + transform.forward * z;

            controller.Move(move * (speed * Time.deltaTime));

            if (Input.GetButtonDown("Jump") && _isGrand)
            {
                _velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
            }

            _velocity.y += gravity * Time.deltaTime;
            controller.Move(_velocity * Time.deltaTime);
        }
    }
}
