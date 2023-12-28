using UnityEngine;

namespace LD
{
    public class LiveEntity : EntityBase, IHasGraphic
    {
        public GameObject Graphic => Root.transform.Find("Graphic").gameObject;
    }
}