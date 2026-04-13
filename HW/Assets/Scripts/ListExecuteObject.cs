using Interface;
using MinMap;
using Model.IntrctvObjcts;
using System;
using System.Collections;
using Object = UnityEngine.Object;

namespace Geekbrains
{
    public sealed class ListExecuteObject : IEnumerator, IEnumerable
    {
        private int _index = -1;
        private InteractiveObject _current;
        private InteractiveObject[] _interObjects;
        private Radar _radar;
        private IExecute[] _interactiveObjects;


        public int Length => _interactiveObjects.Length;
        public object Current => _interactiveObjects[_index];
        public InteractiveObject[] InteractiveObjects { get { return _interObjects; } }
        public IExecute this[int index]
        {
            get => _interactiveObjects[index];
            private set => _interactiveObjects[index] = value;
        }


        public ListExecuteObject()
        {
            _interObjects = Object.FindObjectsOfType<InteractiveObject>();
            for (var i = 0; i < _interObjects.Length; i++)
            {
                if (_interObjects[i] is IExecute interactiveObject)
                    AddExecuteObject(interactiveObject);
            }

            _radar = Object.FindObjectOfType<Radar>();
            AddExecuteObject(_radar);
        }


        public void AddExecuteObject(IExecute execute)
        {
            if (_interactiveObjects == null)
            {
                _interactiveObjects = new[] { execute };
                return;
            }
            Array.Resize(ref _interactiveObjects, Length + 1);
            _interactiveObjects[Length - 1] = execute;
        }

        public bool MoveNext()
        {
            if (_index == _interactiveObjects.Length - 1)
            {
                Reset();
                return false;
            }

            _index++;
            return true;
        }

        public void Reset() => _index = -1;

        public IEnumerator GetEnumerator()
        {
            return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}