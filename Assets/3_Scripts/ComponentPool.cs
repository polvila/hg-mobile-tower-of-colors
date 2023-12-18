using System.Collections.Generic;
using UnityEngine;

public class ComponentPool<T> where T : Component
{
	static ComponentPool<T> m_instance;
	public static ComponentPool<T> Instance
	{
		get
		{
			if (m_instance == null)
				m_instance = new ComponentPool<T>();
			return m_instance;
		}
	}

	Dictionary<T, List<T>> poolDict;

	ComponentPool()
	{
		poolDict = new Dictionary<T, List<T>>();
	}

	public void EnsureQuantity(T prototype, int count)
	{
		if (!poolDict.ContainsKey(prototype))
		{
			poolDict.Add(prototype, new List<T>());
		}
		int prevCount = poolDict[prototype].Count;
		for (int i = 0; i < count - prevCount; i++)
		{
			T newObj = Object.Instantiate(prototype);
			newObj.gameObject.SetActive(false);
			Object.DontDestroyOnLoad(newObj.gameObject);
			poolDict[prototype].Add(newObj);
		}
	}

	public T GetPooled(T prototype, Vector3 position, Quaternion rotation, Transform parent = null)
	{
		if (!poolDict.ContainsKey(prototype))
		{
			poolDict.Add(prototype, new List<T>());
		}
		T unused = poolDict[prototype].Find(x => !x.gameObject.activeSelf);
		if (unused == null)
		{
			unused = Object.Instantiate(prototype, position, rotation, parent);
			poolDict[prototype].Add(unused);
			Object.DontDestroyOnLoad(unused.gameObject);
		}
		else
		{
			unused.transform.position = position;
			unused.transform.rotation = rotation;
			if (unused.transform.parent != parent)
				unused.transform.parent = parent;
			unused.gameObject.SetActive(true);
		}
		return unused;
	}
}