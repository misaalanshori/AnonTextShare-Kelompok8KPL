using System;
namespace AnonTextAppConsoleUI
{
	public static class ClientAPI
	{
		static HttpClient client = new HttpClient();
        static HttpResponseMessage response;

		public static async Task<TextDocument> getDocument(string id)
		{
			response = await client.GetAsync("http://localhost:5152/api/TextDocument/" + id);
			if (response.IsSuccessStatusCode)
			{
				TextDocument doc = await response.Content.ReadAsAsync<TextDocument>();
				//Console.WriteLine($"Title: {doc.title}");
				//Console.WriteLine($"Views: {doc.views}");
				//Console.WriteLine("Content:");
				//Console.WriteLine(doc.contents);
				//Console.WriteLine("Comments:");
				//if(doc.comments.Count != 0 && doc.comments != null)
				//{
				//	for(int i = 0; i < doc.comments.Count; i++)
				//	{
				//		Console.WriteLine($"{i + 1}: {doc.comments[i]}");
				//	}
				//}
				//else
				//{
				//	Console.WriteLine("No Comment Yet");
				//}
				return doc;
			}
			return null;
		}

		public static async Task deleteDocument(string id, string password)
		{
			response = await client.DeleteAsync($"http://localhost:5152/api/TextDocument/{id}?pass={password}");
			if (response.IsSuccessStatusCode)
			{
				Console.WriteLine("Delete Success");
			}
			else
			{
				Console.WriteLine("Document Not Found");
			}
		}

		public static async Task createDocument(string title, string content, string password)
		{
			TextDocument newDoc = new TextDocument(title, content);
			if(password != null)
			{
				response = await client.PostAsJsonAsync("http://localhost:5152/api/TextDocument?pass=" + password, newDoc);
			}
			else
			{
				response = await client.PostAsJsonAsync("http://localhost:5152/api/TextDocument", newDoc);
			}
			Console.WriteLine($"Your document id is {response.Content.ReadAsStringAsync()}");
		}

		public static async Task changeTitle(string id, string password, string newTitle)
		{
			response = await client.PatchAsync($"http://localhost:5152/api/TextDocument/{id}/title?pass={password}", new StringContent(newTitle));
			Console.WriteLine("Tile Updated");
		}

        public static async Task updateContent(string id, string password, string content)
        {
            response = await client.PatchAsync($"http://localhost:5152/api/TextDocument/{id}/contents?pass={password}", new StringContent(content));
            Console.WriteLine("Contents Updated");
        }


		public static async Task<TextCollection> getCollection(string id)
		{
			response = await client.GetAsync("http://localhost:5152/api/TextCollection/" + id);
			if (response.IsSuccessStatusCode)
			{
				TextCollection collection = await response.Content.ReadAsAsync<TextCollection>();
				return collection;
			}
			return null;
		}

		public static async Task deleteCollections(string id, string password)
		{
			response = await client.DeleteAsync($"http://localhost:5152/api/TextCollection/{id}?pass={password}");
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Delete Success");
            }
            else
            {
                Console.WriteLine("Collection Not Found");
            }
        }

		public static async Task<string> createCollection(string title, string password, List<string> contents)
		{
			TextCollection newCollection = new TextCollection(title, contents);
			if (password != null)
			{
				response = await client.PostAsJsonAsync($"http://localhost:5152/api/TextCollection?title={title}&pass={password}", newCollection);
			}
			else
			{
				response = await client.PostAsJsonAsync($"http://localhost:5152/api/TextCollection?title={title}", newCollection);
			}
			return response.Content.ReadAsStringAsync().Result;
		}

		public static async Task changeCollectionsTitle(string id, string password, string newTitle)
		{
            response = await client.PatchAsync($"http://localhost:5152/api/TextCollection/{id}/title?pass={password}", new StringContent(newTitle));
            Console.WriteLine("Tile Updated");
        }

		public static async Task updateContents(string id, string password, string textID)
		{
			response = await client.PatchAsync($"http://localhost:5152/api/TextCollection/{id}/contents?pass={password}", new StringContent(textID));
			Console.WriteLine("Content Updated");
        }
    }
}

