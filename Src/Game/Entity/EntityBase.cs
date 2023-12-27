using UnityEngine;

namespace LD
{
    public abstract partial class EntityBase : MonoBehaviour
    {
        public int Id => Data.Id;
        public Vector3 Position => transform.position;
        public Vector3 PositionXZ => new Vector3(this.transform.position.x, 0, this.transform.position.z);
        public bool HasRoot => transform.Find("Root") != null;
        public GameObject Root => transform.Find("Root").gameObject;
        public EntityBaseData Data; 
        

        protected virtual void Awake()
        {
            
        }
    }
    
}