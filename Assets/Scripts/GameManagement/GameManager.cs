using Assets.Scripts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.GameManagement
{
    public class GameManager: MonoBehaviour
    {
        public GameManager Instance { get; private set; }

        private List<IMoveable> moveables;

        private List<IRotatable> rotatables;

        public void Initialize()
        {
            if (Instance != null) { throw new Exception("Instance is already exists"); }

            Instance = this;
            moveables = new List<IMoveable>();
            moveables = FindObjectsOfType<MonoBehaviour>().OfType<IMoveable>().ToList();

            rotatables = new();
            rotatables = FindObjectsOfType<MonoBehaviour>().OfType<IRotatable>().ToList();

        }

        public void Start()
        {
            Initialize();
            Debug.Log(moveables.Count);
        }

        private void Update()
        {
            
        }




    }
}
