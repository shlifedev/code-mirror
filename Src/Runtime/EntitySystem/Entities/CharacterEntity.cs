using System;
using Lightbug.CharacterControllerPro.Core;
using Lightbug.CharacterControllerPro.Implementation;
using UnityEngine;

namespace LD
{
    public class CharacterEntity : LiveEntity
    {
        public CharacterActor actor;

        protected override void Awake()
        {
            base.Awake();
            this.actor = GetComponent<CharacterActor>();
        }
        

        public override void Move(Vector3 direction)
        {
            // actor.Velocity = new Vector3(direction.x, actor.Velocity.y, direction.z);
            // actor.Forward =  new Vector3(direction.x, 0, direction.z); 
        }  
          
    }
}