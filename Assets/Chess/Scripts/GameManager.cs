using System;
using UnityEngine;

namespace Chess.Scripts
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private GameObject boxPrefab;

        [SerializeField] private Material materialBlack;
        
        private int _size = 8;
        
        private void Start()
        {
            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    GameObject newBox = Instantiate(boxPrefab, new Vector3(i, 0, j), Quaternion.identity);
            
                    if (i % 2 == 0 && j % 2 > 0 || i % 2 > 0 && j % 2 == 0)
                    {
                        newBox.GetComponent<Renderer>().material = materialBlack;
                    }
                }
            }
        }
    }
}
