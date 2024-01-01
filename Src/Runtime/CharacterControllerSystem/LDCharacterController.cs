using System;
using UnityEngine; 
namespace LD
{
    public class LDCharacterController : MonoBehaviour, ILDCharacterController
    {
        
        public bool IsFalling { get; set; }
        
        public bool IsGrounded { get; set; } 
        
        
        
        [System.Serializable]
        public class CharacterSizeModel
        {
            [Header("캐릭터 크기")]
            public float radius = 1.0f; 
            [Header("캐릭터 높이")] 
            public float height = 2.0f; 
        }

        public CharacterSizeModel CharacterSize;
        public CharacterControllerCollider Collider { get; set; }
        
        private Mesh _gizmosMesh;
 
        
        private void OnValidate()
        {
            if (!transform.Find("Graphics") || !transform.Find("Graphics"))
            {
                throw new Exception("Graphics 를 자식으로 가지고 있어야합니다.");
            }
            GameObject capsule = GameObject.CreatePrimitive(PrimitiveType.Capsule);
            capsule.hideFlags = HideFlags.DontSave | HideFlags.NotEditable | HideFlags.HideInHierarchy |
                                HideFlags.HideInInspector | HideFlags.DontSaveInBuild | HideFlags.DontSaveInEditor |
                                HideFlags.DontUnloadUnusedAsset | HideFlags.HideAndDontSave;
            _gizmosMesh = capsule.GetComponent<MeshFilter>().sharedMesh; 
            _gizmosMesh.Optimize();  
            Collider.UpdateCollider();
        }

        private void Awake()
        {
            this.Collider = new CharacterControllerCollider(this, CharacterControllerCollider.ColliderType.Capsule);
        }

 
        void OnDrawGizmosSelected()
        {  
            // Calculate the position of the capsule.
            UnityEngine.Vector3 position = transform.position;

            Gizmos.color = new Color(1, 1, 1, 0.25f);

            // Draw the capsule by using a capsule mesh
            Gizmos.DrawWireMesh(_gizmosMesh, position, transform.rotation, new UnityEngine.Vector3(CharacterSize.radius, CharacterSize.height/2, CharacterSize.radius));
        }

  
        public virtual void Move(UnityEngine.Vector3 position)
        {
          
        }

        public virtual void Velocity(UnityEngine.Vector3 dir)
        {
 
        }

        public void Jump(float power)
        {
             
        }
    }
}