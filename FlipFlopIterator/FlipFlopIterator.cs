using System.Collections.Generic;

public class FlipFlopIterator
{

    public FlipFlopIterator(int _startIndex, int _lowerBound, int _upperBound)
    {
        index = _startIndex;
        lowerBound = _lowerBound;
        upperBound = _upperBound;

        init = _startIndex;
        diff = 0;
        add = true;
        lockOp = false;

        // throw if invalid here
    }

    // the algoritm
    public int? Get()
    {
        // set index immediately
        index = init + diff;

        // if we've overstepped our bounds, course correct
        // and lock the operation
        if (index < lowerBound || index > upperBound)
        {
            // if we've set the lock, return null. we're done here.
            // i suppose you could also throw an exception, or
            // really anything that indicates that we're done
            if (lockOp)
                return null;

            // if we just added, check the opposite
            // if we just negated, check opposite + 1
            diff = !add ? -1 * diff : (-1 * diff) + 1;
                
            // set lock to only increment or decrement
            lockOp = true;

            // Advance to Go. Collect $200.
            return Get();
        }


        if (lockOp)
        {
            // just add or subtract, no more flip flopping
            diff = add ? diff + 1 : diff - 1;
        }
        else
        {
            // flip the sign and add one if add is true
            // also change direction for next time
            diff = add ? (-1 * diff) + 1 : -1 * diff;
            add = !add;
        }

        return index;
    }

    public void Reset()
    {
        index = init;
        diff = 0;
        add = true;
        lockOp = false;
    }

    protected int? index { get; set; }
    protected int lowerBound { get; set; }
    protected int upperBound { get; set; }

    protected readonly int init;
    protected int diff { get; set; }
    protected bool add { get; set; }
    protected bool lockOp { get; set; }
}

// same same, but for iterating types
public class FlipFlopIterator<T> : FlipFlopIterator
{
    public FlipFlopIterator(IList<T> _collection, T _startElement)
        : base (_collection.IndexOf(_startElement), 0, _collection.Count)
    {
        collection = _collection;
    }
        
    // returns the object at an index, rather than an index
    public IEnumerable<T> Iterate()
    {
        for (var i = 0; i < collection.Count; i++)
        {
            var index = Get();

            // this shouldnt happen because we're looping over
            // count, but just in case
            if (index == null) break;

            yield return collection[(int) index];
        }
    }

    private readonly IList<T> collection;
}