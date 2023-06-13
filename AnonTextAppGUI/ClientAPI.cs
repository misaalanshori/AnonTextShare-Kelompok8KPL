using System;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Encodings;
using Newtonsoft.Json;

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

		public static async Task<string> createDocument(string title, string content, string password)
		{
			TextDocument newDoc = new TextDocument(title, content);
			if (password != null)
			{
				response = await client.PostAsJsonAsync("http://localhost:5152/api/TextDocument?pass=" + password, newDoc);
			}
			else
			{
				response = await client.PostAsJsonAsync("http://localhost:5152/api/TextDocument", newDoc);
			}
			return response.Content.ReadAsStringAsync().Result;
		}

		public static async Task changeTitle(string id, string password, string newTitle)
		{
            var requestUrl = $"http://localhost:5152/api/TextDocument/{id}/title?pass={password}";
            var requestContent = new StringContent($"\"{newTitle}\"", Encoding.UTF8, "application/json-patch+json");

            var request = new HttpRequestMessage(HttpMethod.Patch, requestUrl);
            request.Content = requestContent;

            response = await client.SendAsync(request);
            Console.WriteLine(response);
            Console.WriteLine("Title Updated");
        }

        public static async Task updateContent(string id, string password, string content)
        {
            var requestUrl = $"http://localhost:5152/api/TextDocument/{id}/contents?pass={password}";
            var requestContent = new StringContent($"\"{content}\"", Encoding.UTF8, "application/json-patch+json");

            var request = new HttpRequestMessage(HttpMethod.Patch, requestUrl);
            request.Content = requestContent;

            response = await client.SendAsync(request);
            Console.WriteLine(response);
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
			if (password != null)
			{
				response = await client.PostAsJsonAsync($"http://localhost:5152/api/TextCollection?title={title}&pass={password}", contents);
			}
			else
			{
				response = await client.PostAsJsonAsync($"http://localhost:5152/api/TextCollection?title={title}", contents);
			}
			return response.Content.ReadAsStringAsync().Result;
		}

		public static async Task changeCollectionsTitle(string id, string password, string newTitle)
		{
            var requestUrl = $"http://localhost:5152/api/TextCollection/{id}/title?pass={password}";
            var requestContent = new StringContent($"\"{newTitle}\"", Encoding.UTF8, "application/json-patch+json");

            var request = new HttpRequestMessage(HttpMethod.Patch, requestUrl);
            request.Content = requestContent;

            response = await client.SendAsync(request);
            Console.WriteLine(response);
            Console.WriteLine("Title Updated");
        }

		public static async Task AddContents(string id, string password, string textID)
		{
            var requestUrl = $"http://localhost:5152/api/TextCollection/{id}/contents?pass={password}";
            var requestContent = new StringContent($"\"{textID}\"", Encoding.UTF8, "application/json-patch+json");

            var request = new HttpRequestMessage(HttpMethod.Patch, requestUrl);
            request.Content = requestContent;

            response = await client.SendAsync(request);
            Console.WriteLine(response);
            Console.WriteLine("Content Added");
        }

		public static async Task deleteContent(string id, string password, string textID)
		{
            response = await client.DeleteAsync($"http://localhost:5152/api/TextCollection/{id}/contents/{textID}?pass={password}");
            Console.WriteLine("Content Deleted");
        }
    }
}

