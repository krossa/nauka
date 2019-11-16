using System;
using System.Collections.Generic;

public class CircularBuffer<T>
{
    Queue<T> buffer;
    int capacity;
    public CircularBuffer(int capacity)
    {
        buffer = new Queue<T>();
        this.capacity = capacity;
    }

    public T Read() => buffer.Dequeue();

    public void Write(T value)
    {
        if (buffer.Count == capacity)
            throw new InvalidOperationException();
        else
            buffer.Enqueue(value);
    }

    public void Overwrite(T value)
    {
        if (buffer.Count == capacity)
        {
            buffer.Dequeue();
            buffer.Enqueue(value);
        }
        else
            buffer.Enqueue(value);
    }

    public void Clear() => buffer.Clear();

}