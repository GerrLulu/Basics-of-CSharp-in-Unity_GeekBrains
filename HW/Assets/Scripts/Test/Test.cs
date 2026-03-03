using InteractiveObjectNS.Bonuses.Points;
using UnityEngine;


namespace Test
{
    public sealed class Test : MonoBehaviour
    {
        private void Start()
        {
            var goodObjects = new TestListBonuses<GoodBonus>();
            for (int i = 0; i <= goodObjects.Count; i++)
            {
                print($"{goodObjects[i]}");
            }

            var badObjects = new TestListBonuses<BadBonus>();
            for (int i = 0; i < badObjects.Count; i++)
            {
                print($"{badObjects[i]}");
            }
        }
    }
}