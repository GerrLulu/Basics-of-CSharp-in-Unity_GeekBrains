using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace HomeWorkLesson5
{
    public sealed class TaskWithList
    {
        public void CountingIntegers(List<int> list)
        {
            Dictionary<int, int> countNum = new Dictionary<int, int>();

            foreach (int num in list)
            {
                if (countNum.ContainsKey(num))
                    countNum[num]++;
                else
                    countNum[num] = 1;
            }

            Result(countNum);
        }

        public void CountingGeneralizedList<T>(List<T> list)
        {
            Dictionary<T, int> countForList = new Dictionary<T, int>();

            foreach (T item in list)
            {
                if (countForList.ContainsKey(item))
                    countForList[item]++;
                else
                    countForList[item] = 1;
            }

            Result(countForList);
        }

        public void ExampleLinq<T>(List<T> list)
        {
            Dictionary<T, int> result = list.GroupBy(res => res).ToDictionary(x => x.Key, x => x.Count());

            Result(result);
        }

        private void Result<T, K>(Dictionary<T, K> result)
        {
            foreach (var i in result)
                Debug.Log($"{i.Key} встречается {i.Value} раз");
        }
    }
}