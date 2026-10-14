using System.Collections;

namespace Verzekeringen.App;

public class MyCollection<T> : IEnumerable<T>
{
	private T[] _items;      // backing field
	public int Count { get; set; } = 0;

	public T this[int index]       // 😀 indexer
	{
		get
		{
			CheckBounds(index);
			return _items[index];
		}

		set
		{
			CheckBounds(index);
			_items[index] = value;
		}
	}

	// Use at your risk:
	//public Schade? this[string omschrijving]
	//{
	//	get
	//	{
	//		return _schades.FirstOrDefault(s => s.Omschrijving == omschrijving);
	//	}
	//}



	private void CheckBounds(int index)
	{
		if (index < 0 || index >= Count)
		{
			throw new IndexOutOfRangeException();
		}
	}

	public MyCollection(int capacity = 4)
	{
		_items = new T[capacity];
	}

	public void Add(T item)
	{
		if (Count >= _items.Length)
		{
			Array.Resize(ref _items, _items.Length * 2);
		}

		_items[Count++] = item;
	}

	public IEnumerator<T> GetEnumerator()
	{
		for (var i = 0; i < Count; i++)
		{
			yield return _items[i];
		}
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}
}
