using System.Collections.Generic;
using UnityEngine;

public class Pool<T>
{
    private readonly Dictionary<int, T> _objects;

    public Pool()
    {
        _objects = new Dictionary<int, T>();
    }

    public T First => GetFirst();
    public T[] AllObjects => GetObjects();

    public int Add(T obj)
    {
        if (_objects.ContainsValue(obj) == false)
        {
            var index = GetRandomIndex();
            _objects.Add(index, obj);
            return index;
        }
        return -1;
    }

    public void AddWithSpecificIndex(int index, T obj)
    {
        if (_objects.ContainsKey(index) == false && _objects.ContainsValue(obj) == false)
        {
            _objects.Add(index, obj);
        }
    }


    public void RemoveByIndex(int index)
    {
        if (_objects.ContainsKey(index))
        {
            _objects.Remove(index);
        }
        else
        {
            throw new System.Exception($"There's no index {index}");
        }
    }

    public T GetByIndex(int index)
    {
        return _objects[index];
    }


    public bool Exist(int index)
    {
        if (_objects.ContainsKey(index))
        {
            return true;
        }
        return false;
    }

    private int GetRandomIndex()
    {
        var index = Random.Range(0, int.MaxValue);
        if (_objects.ContainsKey(index) == false)
        {
            return index;
        }
        else
        {
            index = GetRandomIndex();
        }
        return index;
    }
    private T[] GetObjects()
    {
        T[] objects = new T[_objects.Count];
        _objects.Values.CopyTo(objects, 0);
        return objects;
    }

    private T GetFirst()
    {
        T[] objects = new T[_objects.Count];
        _objects.Values.CopyTo(objects, 0);
        if (objects.Length == 0)
        {
            throw new System.Exception("No objects in Pool");
        }
        return objects[0];
    }



}

