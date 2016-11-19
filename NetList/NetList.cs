using Nancy;
using Newtonsoft.Json;
using System.IO;
using System.Text.RegularExpressions;

namespace NetList
{
	public class NetList : NancyModule
	{
		
		public NetList(IListGroup listGroup)
		{
			Get["/"] = parameters => "The collection of lists can be found at /lists";

			//see all the lists that are in the system
			Get["/lists"] = para =>
			{
				return "These are all the lists:" + System.Environment.NewLine + 
						JsonConvert.SerializeObject(listGroup.ReadLists());
			};

			//see the contents of one list
			Get["/lists/{listId}"] = para =>
			{
				return JsonConvert.SerializeObject(listGroup.ReadList(para.listId));
			};

			//add a list to the system. List name is in request body.
			Post["/lists"] = para =>
			{
				var reader = new StreamReader(this.Request.Body);
				var listName = reader.ReadToEnd();
				if (!Regex.IsMatch(listName, @"^[\w]+$"))
				{
					return "List names can only be letters/numbers/underscores";
				}

				listGroup.CreateList(listName);

				return $"New List created at /lists/{listName}";
			};

			//add an item to a list. Item string is in the request body.
			Post["/lists/{listId}"] = para =>
			{
				var reader = new StreamReader(this.Request.Body);
				//lists[para.list].Add(reader.ReadToEnd());

				listGroup.CreateListItem(para.listId, reader.ReadToEnd());

				return JsonConvert.SerializeObject(listGroup.ReadList(para.listId));
			};

			//delete a list from the system. Name of list to delete is in the request body.
			Delete["/lists"] = para =>
			{
				var reader = new StreamReader(this.Request.Body);
				var listName = reader.ReadToEnd();
				listGroup.DeleteList(listName);
				return $"List at /lists/{listName} was deleted.";
			};

			//delete an item from the system. Item string to delete is in the request body.
			Delete["/lists/{listId}"] = para =>
			{
				var reader = new StreamReader(this.Request.Body);
				var listItem = reader.ReadToEnd();

				listGroup.DeleteListItem(para.listId, listItem);

				return JsonConvert.SerializeObject(listGroup.ReadList(para.listId));
			};

		}
	}
}
