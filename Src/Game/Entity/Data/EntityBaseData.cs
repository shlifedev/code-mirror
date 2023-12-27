using System;

namespace LD
{
    public abstract partial class EntityBase
    {
        public abstract record EntityBaseData
        {
            public int Id;
            public DateTime CreatedAt;
        }
    }
}