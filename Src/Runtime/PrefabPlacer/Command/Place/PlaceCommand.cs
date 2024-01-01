using System.Linq;
using UnityEngine;

namespace LD
{
    public class PlaceCommand : ICommand
    {
        private GameObject Prefab { get; }
        private Vector3 Point { get; }
        private Quaternion Rotation { get; }
        private Vector3 Scale { get; }

        private GameObject _instantiated = null;

        private bool _isExecuted = false;

        private BasePlacer _cachedPlacer;

        public PlaceCommand(GameObject prefab, Vector3 point, Quaternion rotation, Vector3 scale)
        {
            Prefab = prefab;
            Point = point;
            Rotation = rotation;
            Scale = scale;
        }

        public void Execute()
        {
            var op = GameObject.Instantiate(Prefab);
            _instantiated = op;
            _instantiated.transform.position = this.Point;
            _instantiated.transform.rotation = this.Rotation;
            _instantiated.transform.localScale = this.Scale;
            _isExecuted = true;
        }

        public void Undo()
        {
            GameObject.DestroyImmediate(_instantiated);
        }

        public void Redo()
        {
            var op = GameObject.Instantiate(Prefab);

            _instantiated = op;
            _instantiated.transform.position = this.Point;
            _instantiated.transform.rotation = this.Rotation;
            _instantiated.transform.localScale = this.Scale;
            _isExecuted = true;
        }
    }
}