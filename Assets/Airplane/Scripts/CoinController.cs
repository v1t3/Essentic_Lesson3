using System;
using UnityEngine;

namespace Airplane.Scripts
{
    public class CoinController : MonoBehaviour
    {
        private GameManager _gameManagerScript;

        [SerializeField] private GameObject coinAudioPrefab;

        private void Awake()
        {
            _gameManagerScript = FindObjectOfType<GameManager>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                _gameManagerScript.UpdateCoinCount(1);

                Transform selfTransform = gameObject.transform;
                Destroy(Instantiate(coinAudioPrefab, selfTransform.position, selfTransform.rotation), 0.5f);
                
                Destroy(gameObject);
            }
        }
    }
}
