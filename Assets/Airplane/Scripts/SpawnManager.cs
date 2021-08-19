using System.Collections;
using UnityEngine;

namespace Airplane.Scripts
{
    public class SpawnManager : MonoBehaviour
    {
        private GameManager _gameManagerScript;

        [SerializeField] private GameObject coinPrefab;
        [SerializeField] private GameObject bombPrefab;

        [SerializeField] private float waitTimeCoin = 3f;
        [SerializeField] private float startDelayCoin = 0f;
        [SerializeField] private float spawnRangeCoin = 18f;
        
        [SerializeField] private float waitTimeBomb = 6f;
        [SerializeField] private float startDelayBomb = 3f;
        [SerializeField] private float spawnRangeBomb = 18f;

        [SerializeField] private bool spawnCoin = true;
        [SerializeField] private bool spawnBomb = true;

        private void Awake()
        {
            _gameManagerScript = FindObjectOfType<GameManager>();
        }
            
        public void StartSpawn()
        {
            StartCoroutine(SpawnCoin());
            StartCoroutine(SpawnBomb());
        }        

        private IEnumerator SpawnCoin()
        {
            yield return new WaitForSeconds(startDelayCoin);
            
            while (_gameManagerScript.gameActive && spawnCoin)
            {
                Vector3 position = new Vector3(transform.position.x, Random.Range(-spawnRangeCoin, spawnRangeCoin), transform.position.z);
                Instantiate(coinPrefab, position, Quaternion.identity);

                yield return new WaitForSeconds(waitTimeCoin);
            }
        }

        private IEnumerator SpawnBomb()
        {
            yield return new WaitForSeconds(startDelayBomb);

            while (_gameManagerScript.gameActive && spawnBomb)
            {
                Vector3 position = new Vector3(transform.position.x, Random.Range(-spawnRangeBomb, spawnRangeBomb), transform.position.z);

                Instantiate(bombPrefab, position, Random.rotation);

                yield return new WaitForSeconds(waitTimeBomb);
            }
        }
    }
}
