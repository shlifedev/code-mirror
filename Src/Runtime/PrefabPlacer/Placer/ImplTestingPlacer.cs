using System.Collections.Generic;
using UnityEditor;
using UnityEngine; 

namespace LD
{
    public class ImplTestingPlacer : BasePlacer
    {
        public List<ICommand> RedoList { get; }
        public List<ICommand> UndoList { get; }
    
        public ImplTestingPlacer(Camera camera) : base(camera)
        {
            
        }
        
        public void SelectPrefab(GameObject obj)
        {
            this.SelectedPrefab = obj; 
        }


        public override void Place()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit; 
            if (Physics.Raycast(ray, out hit))
            {
                var point = hit.point;
                var cmd = new PlaceCommand(SelectedPrefab, point, Quaternion.identity, Vector3.one);
                cmd.Execute();
            }
        }
        
        public override void Undo()
        {
            if (UndoList.Count > 0)
            {
                var cmd = UndoList[^1];
                cmd.Undo();
                RedoList.Add(cmd);
                UndoList.Remove(cmd); 
            }
        }

        public override void Redo()
        {
            var cmd = RedoList[^1];
            cmd.Redo();
            RedoList.Remove(cmd);
            UndoList.Add(cmd);
        }

        protected virtual void RenderPreview()
        {
            
        }
        public override void Tick(float dt)
        {
            RenderPreview();
        }

 
    }
}