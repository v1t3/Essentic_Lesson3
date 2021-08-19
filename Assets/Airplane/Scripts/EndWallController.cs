using UnityEngine;

namespace Airplane.Scripts
{
    public class EndWallController : MonoBehaviour
    {
        private void OnTriggerExit(Collider other)
        {
            if (
                other.gameObject.CompareTag("Coin")
                || other.gameObject.CompareTag("Bomb")
                || other.gameObject.CompareTag("Star")
            )
            {
                Destroy(other.gameObject);
            }
        }
    }
}