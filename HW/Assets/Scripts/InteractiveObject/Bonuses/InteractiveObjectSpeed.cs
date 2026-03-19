using System;

namespace IntrctvObjcts.Bonuses
{
    public abstract class InteractiveObjectSpeed : InteractiveObject/*, ICloneable*/
    {
        public Action CaughtPlayer = delegate { };


        protected override void Interaction() => CaughtPlayer?.Invoke();
    }
}