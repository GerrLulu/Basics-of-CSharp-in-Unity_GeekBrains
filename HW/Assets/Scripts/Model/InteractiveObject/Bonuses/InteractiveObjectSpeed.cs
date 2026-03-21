using System;

namespace Model.IntrctvObjcts.Bonuses
{
    public abstract class InteractiveObjectSpeed : InteractiveObject
    {
        public Action CaughtPlayer = delegate { };


        protected override void Interaction() => CaughtPlayer?.Invoke();
    }
}