﻿using System.Collections.Generic;
namespace NetList
{
	public interface IListGroup
	{
		Dictionary<string, List<string>> ReadLists();

		void CreateList(string listId);
		List<string> ReadList(string listId);
		void DeleteList(string listId);

		void CreateListItem(string listId, string listItem);
		void DeleteListItem(string listId, string listItem);
	}
}
