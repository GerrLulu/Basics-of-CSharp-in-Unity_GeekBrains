using InteractiveObjectNS.Bonuses.Points;
using System;
using Object = UnityEngine.Object; 

namespace Test
{
    public sealed class TestListBonuses<T>
    {
        private GoodBonus[] _goodBonuses;
        private BadBonus[] _badBonuses;
        private T[] _testListBonuses;

        public int Count => _testListBonuses.Length;


        public TestListBonuses()
        {
            _goodBonuses = Object.FindObjectsOfType<GoodBonus>();
            Array.Sort(_goodBonuses);

            _badBonuses = Object.FindObjectsOfType<BadBonus>();
            Array.Sort(_badBonuses);
        }


        public T this [int index]
        {
            get => _testListBonuses[index];
            set => _testListBonuses[index] = value;
        }
    }
}