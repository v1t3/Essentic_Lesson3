using System;
using UnityEngine;

namespace Airplane.Scripts
{
    public class EnvironmentController : MonoBehaviour
    {
        private GameManager _gameManagerScript;
        
        private void Awake()
        {
            _gameManagerScript = FindObjectOfType<GameManager>();
        }

        public void FixedUpdate()
        {
            if (_gameManagerScript.gameActive)
            {
                transform.Translate(transform.right * _gameManagerScript.worldSpeed * Time.deltaTime);
            }
        }
    }
}