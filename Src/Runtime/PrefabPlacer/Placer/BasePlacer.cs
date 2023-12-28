using System.Collections.Generic;
using UnityEngine;

namespace LD
{
    public abstract class BasePlacer : IPlacer, ITickable
    {       
        protected List<ICommand> RedoList { get; }
        protected List<ICommand> UndoList { get; }
        public abstract void Undo();
        public abstract void Redo();
        
        protected GameObject SelectedPrefab { get; set; } 
        protected Camera RefCamera { get; set; }

        public BasePlacer(Camera camera)
        { 
            var samplePrefab = GameObject.CreatePrimitive(PrimitiveType.Cube);
            samplePrefab.AddComponent<BoxCollider>();
            this.SelectedPrefab = GameObject.CreatePrimitive(PrimitiveType.Cube);
            this.RefCamera = camera;
        }
        public abstract void Place();
        public abstract void Tick(float dt);
    }
}