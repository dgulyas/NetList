using System.Collections.Generic;

namespace NetList
{
	public class ListGroup : IListGroup
	{
		//This is where we store the lists. Lists is static, so that when this class is constructed by
		//nancy to fulfill the NancyModules needs, the same dictonary object is used, and our data persists.
		private static Dictionary<string, List<string>> Lists = new Dictionary<string, List<string>>();
		private object listsLock = new object();

		public void CreateList(string listId)
		{
			lock (listsLock)
			{
				if (!Lists.ContainsKey(listId))
				{
					Lists.Add(listId, new List<string>());
				}
			}
		}

		public void CreateListItem(string listId, string listItem)
		{
			lock (listsLock)
			{
				Lists[listId].Add(listItem);
			}
		}

		public void DeleteList(string listId)
		{
			lock (listsLock)
			{
				Lists.Remove(listId);
			}
		}

		public void DeleteListItem(string listId, string listItem)
		{
			lock (listsLock)
			{
				Lists[listId].Remove(listItem);
			}
		}

		public List<string> ReadList(string listId)
		{
			lock (listsLock)
			{
				return Lists[listId];
			}
		}

		public Dictionary<string, List<string>> ReadLists()
		{
			lock (listsLock)
			{
				return Lists;
			}
		}
	}
}
