using UnityEngine;

namespace LD
{
    public class LiveEntity : EntityBase, IHasGraphic
    {
        public GameObject Graphic => Root.transform.Find("Graphic").gameObject;

        public virtual void Move(Vector3 direction)
        {
            this.transform.position += direction * Time.deltaTime;
        }
    }
}