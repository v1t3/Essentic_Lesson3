using System.Collections;
using UnityEngine;

namespace Airplane.Scripts
{
    public class SpawnManager : MonoBehaviour
    {
        private GameManager _gameManagerScript;

        [SerializeField] private GameObject coinPrefab;
        [SerializeField] private GameObject bombPrefab;
        [SerializeField] private GameObject starPrefab;

        [SerializeField] private float waitTimeCoin = 3f;
        [SerializeField] private float startDelayCoin = 0f;
        [SerializeField] private float spawnRangeCoin = 18f;
        
        [SerializeField] private float waitTimeBomb = 6f;
        [SerializeField] private float startDelayBomb = 3f;
        [SerializeField] private float spawnRangeBomb = 18f;
        
        [SerializeField] private float waitTimeStar = 0.1f;
        [SerializeField] private float startDelayStar = 0;
        [SerializeField] private float spawnRangeStar = 18f;

        [SerializeField] private bool spawnCoin = true;
        [SerializeField] private bool spawnBomb = true;
        [SerializeField] private bool spawnStar = true;

        private void Awake()
        {
            _gameManagerScript = FindObjectOfType<GameManager>();
        }
            
        public void StartSpawn()
        {
            StartCoroutine(SpawnCoin());
            StartCoroutine(SpawnBomb());
            StartCoroutine(SpawnStar());
        }        

        private IEnumerator SpawnCoin()
        {
            yield return new WaitForSeconds(startDelayCoin);
            
            while (_gameManagerScript.gameActive && spawnCoin)
            {
                Vector3 position = new Vector3(transform.position.x, Random.Range(-spawnRangeCoin, spawnRangeCoin), transform.position.z);
                Destroy(Instantiate(coinPrefab, position, Quaternion.identity), 30f);

                yield return new WaitForSeconds(waitTimeCoin);
            }
        }

        private IEnumerator SpawnBomb()
        {
            yield return new WaitForSeconds(startDelayBomb);

            while (_gameManagerScript.gameActive && spawnBomb)
            {
                Vector3 position = new Vector3(transform.position.x, Random.Range(-spawnRangeBomb, spawnRangeBomb), transform.position.z);

                Destroy(Instantiate(bombPrefab, position, Random.rotation), 30f);

                yield return new WaitForSeconds(waitTimeBomb);
            }
        }

        private IEnumerator SpawnStar()
        {
            yield return new WaitForSeconds(startDelayStar);

            while (spawnStar)
            {
                Vector3 position = new Vector3(
                    transform.position.x, 
                    Random.Range(-spawnRangeStar, spawnRangeStar),
                    Random.Range(0, spawnRangeStar)
                );

                Destroy(Instantiate(starPrefab, position, Quaternion.identity), 30f);

                yield return new WaitForSeconds(waitTimeStar);
            }
        }
    }
}
