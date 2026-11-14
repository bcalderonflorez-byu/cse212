/// <summary>
/// This queue is circular. When people are added via AddPerson,
/// they are added to the back of the queue (FIFO).
/// When GetNextPerson is called, the next person is removed
/// and returned. They are placed back into the queue if they
/// still have turns remaining.
///
/// A turns value of 0 or less means infinite turns.
/// If a person has no more turns, they are not added back.
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
    /// Get the next person in the queue and return them.
    /// People with remaining turns are added back to the queue.
    /// A turns value of 0 or less represents infinite turns.
    /// An exception is thrown if the queue is empty.
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
            // Infinite turns: keep the original value.
            _people.Enqueue(person);
        }
        else
        {
            // Decrease the remaining turns.
            person.Turns--;

            // Re-enqueue only if turns remain.
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
