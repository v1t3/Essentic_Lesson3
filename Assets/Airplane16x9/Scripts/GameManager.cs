using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Airplane.Scripts
{
    public class GameManager : MonoBehaviour
    {
        private SpawnManager _spawnManagerScript;
        private FlyControl _flyControlScript;

        [SerializeField] private TextMeshProUGUI coinText;
        [SerializeField] private TextMeshProUGUI lifeText;

        [SerializeField] private GameObject helloPanel;
        [SerializeField] private GameObject gameOverPanel;
        [SerializeField] private GameObject infoPanel;

        private AudioSource _audioSource;
        [SerializeField] private AudioClip backgroundPlaySound;
        [SerializeField] private AudioClip gameOverSound;

        [SerializeField] private float level2Start;
        [SerializeField] private float level3Start;
        public float worldSpeed;
        private float _timer;

        [SerializeField] private int lifeCount = 3;
        private int _coinCount = 0;
        private int _currentLevel;

        public bool gameActive;

        private void Awake()
        {
            _spawnManagerScript = FindObjectOfType<SpawnManager>();
            _flyControlScript = FindObjectOfType<FlyControl>();
            _audioSource = GetComponent<AudioSource>();
        }

        private void Start()
        {
            UpdateLifeCount(0);
        }

        private void Update()
        {
            if (!gameActive) return;

            _timer += Time.deltaTime;
            
            Debug.Log(_timer);

            if (2 > _currentLevel && 0 < level2Start && _timer > level2Start)
            {
                SetLevelTwo();
            }
            else if (3 > _currentLevel && 0 < level3Start && _timer > level3Start)
            {
                SetLevelThree();
            }
        }

        public void UpdateCoinCount(int value)
        {
            _coinCount += value;
            coinText.text = "x " + _coinCount;
        }

        public void UpdateLifeCount(int value)
        {
            lifeCount += value;
            lifeText.text = "x " + lifeCount;

            if (lifeCount <= 0)
            {
                GameOver();
            }
        }

        public void GameStart()
        {
            SetLevelOne();
            helloPanel.SetActive(false);
            gameActive = true;
            _spawnManagerScript.StartSpawn();
            _audioSource.clip = backgroundPlaySound;
            _audioSource.Play();
        }

        public void GameRestart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        private void GameOver()
        {
            gameActive = false;
            gameOverPanel.SetActive(true);

            _audioSource.Stop();
            _audioSource.loop = false;
            _audioSource.clip = gameOverSound;
            _audioSource.Play();

            FindObjectOfType<FlyControl>().GetComponent<Rigidbody>().velocity = Vector3.zero;
        }

        private void SetLevelOne()
        {
            //World
            worldSpeed = 5;
            _audioSource.pitch = 1;
            _currentLevel = 1;

            //Player
            _flyControlScript.SetFastSpeed(60);
            _flyControlScript.SetSlowSpeed(50);
        }

        private void SetLevelTwo()
        {
            //World
            worldSpeed = 10f;
            _audioSource.pitch = 1.1f;
            _currentLevel = 2;

            //Player
            _flyControlScript.SetFastSpeed(70);
            _flyControlScript.SetSlowSpeed(60);
        }

        private void SetLevelThree()
        {
            //World
            worldSpeed = 20f;
            _audioSource.pitch = 1.2f;
            _currentLevel = 3;

            //Player
            _flyControlScript.SetFastSpeed(80);
            _flyControlScript.SetSlowSpeed(70);
        }

        public void ToggleInfoPanel()
        {
            infoPanel.SetActive(!infoPanel.activeSelf);
        }
    }
}