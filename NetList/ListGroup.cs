using System.Collections.Generic;

namespace NetList
{
	public class ListGroup : IListGroup
	{
		//This is where we store the lists. It's static, so that when this class is constructed by
		//nancy to fulfill the NancyModules needs, the same dictonary object is used, and our data persists.
		public static Dictionary<string, List<string>> Lists = new Dictionary<string, List<string>>();

		public void CreateList(string listId)
		{
			Lists.Add(listId, new List<string>());
		}

		public void CreateListItem(string listId, string listItem)
		{
			Lists[listId].Add(listItem);
		}

		public void DeleteList(string listId)
		{
			Lists.Remove(listId);
		}

		public void DeleteListItem(string listId, string listItem)
		{
			Lists[listId].Remove(listItem);
		}

		public List<string> ReadList(string listId)
		{
			return Lists[listId];
		}

		public Dictionary<string, List<string>> ReadLists()
		{
			return Lists;
		}
	}
}
