using System;
using UnityEngine; 

namespace LD
{
    public class TestPlacer : MonoBehaviour
    {
        private IPlacer placer;

        private void Awake()
        {
            placer = new ImplTestingPlacer(Camera.main);
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                placer.Place();
            }
        }
    }
}