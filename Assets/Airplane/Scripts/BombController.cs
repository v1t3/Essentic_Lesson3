using UnityEngine;

namespace Airplane.Scripts
{
    public class BombController : MonoBehaviour
    {
        private GameManager _gameManagerScript;
        
        [SerializeField] private GameObject explosionPrefab;
        [SerializeField] private GameObject explosionAudioPrefab;
        
        [SerializeField] private float mineSpeed = 1;

        private void Awake()
        {
            _gameManagerScript = FindObjectOfType<GameManager>();
        }
        
        private void OnTriggerStay(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                MoveToPlayer(other.gameObject);
            }
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                _gameManagerScript.UpdateLifeCount(-1);
                
                Transform selfTransform = gameObject.transform;
                Destroy(Instantiate(explosionPrefab, selfTransform.position, selfTransform.rotation), 2f);
                Destroy(Instantiate(explosionAudioPrefab, selfTransform.position, selfTransform.rotation), 1f);
                
                Destroy(gameObject);
            }
        }

        private void MoveToPlayer(GameObject player)
        {
            gameObject.transform.position = Vector3.MoveTowards(
                gameObject.transform.position,
                player.transform.position, 
                mineSpeed * Time.deltaTime
            );
        }
    }
}