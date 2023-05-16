using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatrixGraphs
{
	public class PriorityQueue<T>
	{
		private SortedDictionary<int, Queue<T>> _dictionary;

		public int Count { get; private set; }

		public PriorityQueue()
		{
			_dictionary = new SortedDictionary<int, Queue<T>>();
			Count = 0;
		}

		public void Enqueue(T item, int priority)
		{
			if (!_dictionary.ContainsKey(priority))
			{
				_dictionary[priority] = new Queue<T>();
			}

			_dictionary[priority].Enqueue(item);
			Count++;
		}
		public T Dequeue()
		{
			if (Count == 0)
			{
				throw new InvalidOperationException("PriorityQueue is empty.");
			}

			var priority = _dictionary.First().Key;
			var item = _dictionary[priority].Dequeue();
			if (_dictionary[priority].Count == 0)
			{
				_dictionary.Remove(priority);
			}
			Count--;

			return item;
		}
	}
}