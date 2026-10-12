namespace Verzekeringen.App;

public class SchadeCollection
{
    private Schade[] _schades;      // backing field
	public int Count { get; set; } = 0;

	public Schade this[int index]       // 😀 indexer
	{
		get 
		{
			CheckBounds(index);
			return _schades[index];
		}
		
		set 
		{
			CheckBounds(index);
            _schades[index] = value;
        }  
	}

	// Use at your risk:
	public Schade? this[string omschrijving]
	{
		get
		{
			return _schades.FirstOrDefault(s => s.Omschrijving == omschrijving);
		}
	}



    private void CheckBounds(int index)
    {
        if (index < 0 || index >= Count)
		{
			throw new IndexOutOfRangeException();
		}
    }

    public SchadeCollection(int capacity = 4)
	{
		_schades = new Schade[capacity];
	}

	public void Add(Schade schade)
	{
		if (Count >= _schades.Length)
		{
			Array.Resize(ref _schades, _schades.Length * 2);
		}

		_schades[Count++] = schade;
	}
}
