using UnityEngine;

namespace Script.PlayerScript
{
    public class CameraCtrl : MonoBehaviour
    {
        public float sens = 600f;
        public Transform player;

        private float _xRot = 0f;

        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        private void Update()
        {
            float mX = Input.GetAxis("Mouse X") * sens * Time.deltaTime;
            float mY = Input.GetAxis("Mouse Y") * sens * Time.deltaTime;

            _xRot -= mY;
            _xRot = Mathf.Clamp(_xRot, -90f, 90f);

            transform.localRotation = Quaternion.Euler(_xRot, 0f, 0f);
            player.Rotate(Vector3.up * mX);
        }
    }
}
