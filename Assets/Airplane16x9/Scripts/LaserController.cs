using UnityEngine;

namespace Airplane.Scripts
{
    public class LaserController : MonoBehaviour
    {
        [SerializeField] private AudioSource raySound;
        [SerializeField] private GameObject rayPrefab;
        [SerializeField] private float raySpeed = 50f;
        [SerializeField] private float shotDelay = 0.15f;
        private float _timer;

        private void Update()
        {
            _timer += Time.deltaTime;
        
            if (Input.GetKey(KeyCode.LeftShift) && _timer > shotDelay)
            {
                Shoot();
                _timer = 0;
            }
        }

        private void Shoot()
        {
            GameObject newRay = Instantiate(rayPrefab, transform.position, transform.rotation);
            newRay.GetComponent<Rigidbody>().velocity = transform.right * raySpeed;
            raySound.pitch = Random.Range(0.8f, 1.2f);
            raySound.Play();
        
            Destroy(newRay, 2f);
        }
    }
}