IEnumerable list = new ListOfInt(new int[] { 1, 2, 3, 4, 5 });
var implementation = list.GetEnumerator();
while (implementation.MoveNext())
{
    System.Console.WriteLine(implementation.Current);
}

public class ListOfInt : IEnumerable
{
    private int[] _list;
    public ListOfInt(int[] list)
    {
        _list = list;
    }

    public IEnumerator GetEnumerator()
    {
        return new SecondEnumeratorImplementation(_list);
    }
}

public interface IEnumerable
{
    IEnumerator GetEnumerator();
}

public interface IEnumerator
{
    public object Current { get; }
    public bool MoveNext();
    public void Reset();
}

public class SingleEnumeratorImplementation : IEnumerator
{
    private int[] _list;
    private int _index;
    public SingleEnumeratorImplementation(int[] list)
    {
        _list = list;
        _index = -1;
    }

    public object Current => _list[_index];

    public bool MoveNext()
    {
        return _index++ < _list.Length - 1 ? true : false;
    }

    public void Reset()
    {
        _index = -1;
    }
}

public class SecondEnumeratorImplementation : IEnumerator
{
    private int[] _list;
    private int _index;
    public SecondEnumeratorImplementation(int[] list)
    {
        _list = list;
        _index = -2;
    }

    public object Current => _list[_index];

    public bool MoveNext()
    {
        _index += 2;
        return _index <= _list.Length - 1 ? true : false;
    }

    public void Reset()
    {
        _index = -1;
    }
}