```csharp
using System;

/// <summary>
/// This queue is circular. When people are added via AddPerson, they are
/// added to the back of the queue following FIFO rules. When GetNextPerson
/// is called, the next person is returned and placed back into the queue
/// if they have turns remaining or have infinite turns.
/// </summary>
public class TakingTurnsQueue
{
    private readonly PersonQueue _people = new();

    public int Length => _people.Length;

    /// <summary>
    /// Add new people to the queue with a name and number of turns.
    /// </summary>
    /// <param name="name">Name of the person</param>
    /// <param name="turns">Number of turns remaining</param>
    public void AddPerson(string name, int turns)
    {
        var person = new Person(name, turns);
        _people.Enqueue(person);
    }

    /// <summary>
    /// Get the next person and return them. Re-enqueue the person if
    /// they have turns remaining or an infinite number of turns.
    /// Throw an exception if the queue is empty.
    /// </summary>
    public Person GetNextPerson()
    {
        if (_people.IsEmpty())
        {
            throw new InvalidOperationException("No one in the queue.");
        }

        Person person = _people.Dequeue();

        if (person.Turns <= 0)
        {
            // Zero or negative turns means an unlimited number of turns.
            _people.Enqueue(person);
        }
        else
        {
            // Use one of the person's remaining turns.
            person.Turns--;

            // Return the person to the queue only if turns remain.
            if (person.Turns > 0)
            {
                _people.Enqueue(person);
            }
        }

        return person;
    }

    public override string ToString()
    {
        return _people.ToString();
    }
}
```
