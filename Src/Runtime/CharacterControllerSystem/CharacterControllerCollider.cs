 
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

namespace LD
{
    public class CharacterControllerCollider
    {
        public enum ColliderType { Capsule, Sphere, Box } 
        private readonly LDCharacterController _controller;
        private readonly ColliderType _colliderType; 
        public Collider collider;
        
        public CharacterControllerCollider(LDCharacterController controller,  ColliderType colliderType)
        {
            _controller = controller;
            _colliderType = colliderType;
            var obj = new GameObject();
            obj.transform.SetParent(this._controller.transform.transform); 
            obj.gameObject.name = "Collider Instance";
            obj.hideFlags = HideFlags.DontSaveInEditor | HideFlags.NotEditable | HideFlags.DontSave;
            CreateCollider(obj, colliderType);
            /* Collider */
            this.collider = obj.GetComponent<Collider>();


            PostProcessColliderSetting(this.collider);
        }

        private void PostProcessColliderSetting(Collider col)
        {
            switch (_colliderType)
            {
                case ColliderType.Capsule:
                    var capsule = collider as CapsuleCollider;
                    capsule.radius = _controller.CharacterSize.radius / 2;
                    capsule.height = _controller.CharacterSize.height;
                    break;
                case ColliderType.Box:
                    var box = collider as BoxCollider;
                    box.size = new Vector3(_controller.CharacterSize.radius, _controller.CharacterSize.height,
                        _controller.CharacterSize.radius);
                    break;
            }
        }
        
        
        public void UpdateCollider()
        {
            PostProcessColliderSetting(collider);
        }
        
        private void CreateCollider(GameObject obj, ColliderType type)
        {
            // Remove existing colliders
            foreach (var coll in obj.GetComponents<Collider>()) GameObject.Destroy(coll);
        
            // Add new collider
            switch (type)
            {
                case ColliderType.Capsule:
                    obj.AddComponent<CapsuleCollider>();
                    break;
                case ColliderType.Sphere:
                    obj.AddComponent<SphereCollider>();
                    break;
                case ColliderType.Box:
                    obj.AddComponent<BoxCollider>();
                    break;
                default:
                    Debug.LogError("Invalid collider type");
                    break;
            }
        }

    }
}