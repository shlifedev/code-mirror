using UnityEngine;

namespace LD
{
    public class LinePlacer : BasePlacer
    { 
        public enum Mode
        {
            None,
            SelectPoints,
            Confirm,
            Execute
        }

        
        private Mode State { get; set; }
        public LinePlacer(Camera camera) : base(camera)
        {
        }
 
        public override void Undo()
        {
             
        }

        public override void Redo()
        {
            
        }

        public override void Place()
        {
             
        }

        public override void Tick(float dt)
        {
            if (State == Mode.None)
            {
                return;
            }

            if (State == Mode.SelectPoints)
            {
                
            }

            if (State == Mode.Confirm)
            {
                
            }

            if (State == Mode.Execute)
            {
                Place();
                State = Mode.None;
            }
        }
    }
}