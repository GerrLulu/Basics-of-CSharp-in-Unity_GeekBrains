using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace HomeWorkLesson5
{
    public sealed class FragmentOfTheProgram : MonoBehaviour
    {
        private void Start()
        {
            Dictionary<string, int> dict = new Dictionary<string, int>()
            {
                {"four",4 },
                {"two",2 },
                { "one",1 },
                {"three",3 },
            };

            var d = dict.OrderBy(delegate (KeyValuePair<string, int> pair) { return pair.Value; });

            foreach (var pair in d)
            {
                Debug.Log($"{pair.Key} - {pair.Value}");
            }

            //а.Свернуть обращение к OrderBy с использованием лямбда - выражения =>.
            var varA = dict.OrderBy(pair => pair.Value);

            foreach (var pair in varA)
            {
                Debug.Log($"{pair.Key} - {pair.Value}");
            }

            //b. * Развернуть обращение к OrderBy с использованием делегата
            Func<KeyValuePair<string, int>, int> delegateVarB = delegate (KeyValuePair<string, int> pair) { return pair.Value; };
            var varB = dict.OrderBy(delegateVarB);

            foreach (var pair in varB)
            {
                Debug.Log($"{pair.Key} - {pair.Value}");
            }
        }
    }
}