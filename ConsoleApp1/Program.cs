
using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Net.Http.Json;
using System.Text.Json;
using ConsoleApp1.Entities;

namespace DialogSplitterApp
{
	class Program
	{
		static void Main(string[] args)
		{

			// test ------------------------------------------------------------------------------------------------------------------------------
			string pathToCharacterCard = @"C:\Users\Admin\Desktop\Empty.json";
			CharacterCard? characterCard = ReadCharacterCard(pathToCharacterCard);
			if (characterCard == null)
			{
				Console.WriteLine("Char card is not properly configured abborting Export");
			}
		

			// test ------------------------------------------------------------------------------------------------------------------------------

			// Define the path to the file (change to the actual file path)
			string filePath = @"C:\Users\Admin\Desktop\ExportedChat.txt";
			string proccessedFilePath = @"C:\Users\Admin\Desktop\DialogProcessed.txt";
			string exportedFilePath = @"C:\Users\Admin\Desktop\ExportedFile.json";

			GenerateProcessedFile(filePath, proccessedFilePath);
			List<KeyValuePair<string, string>> chatHistory = DisplayProcessedFile(proccessedFilePath);
			ExportToCustomModel(exportedFilePath, characterCard, chatHistory);
		}


		public static CharacterCard? ReadCharacterCard(string pathToCharacterCard)
		{
			try
			{
				string content = File.ReadAllText(pathToCharacterCard);

				CharacterCard? characterCard = JsonSerializer.Deserialize<CharacterCard>(content);
				return characterCard;

			}
			catch (Exception ex)
			{
				;
				return null;
			}
		}

		public static void GenerateProcessedFile(string filePath, string proccessedFilePath)
		{

			try
			{
				// Read the content of the file
				string content = File.ReadAllText(filePath);

				// Remove the unwanted 'V' character before "Virk"
				if (content.StartsWith("undefined"))
					content = content["undefined".Length..];

				string processedContent = content.Replace("\nc.ai", string.Empty);


				// Write the processed content to a new file
				File.WriteAllText(proccessedFilePath, processedContent);
				return;
			}
			catch (Exception ex)
			{
				Console.WriteLine($"An error occurred: {ex.Message}");
			}


		}

		public static List<KeyValuePair<string, string>> DisplayProcessedFile(string proccessedFilePath)
		{
			try 
			{
				// Read the content of the file
				string[] lines = File.ReadAllLines(proccessedFilePath);
				// Define characters
				string characterOne = " Vikr : ";
				string characterTwo = " Higuchi Madoka : ";

				// Initialize dialogues for each character
				List<KeyValuePair<string, string>> chatHistory = new();

				// Determine the current speaker
				string currentSpeaker = characterOne; // Assuming character one starts the conversation

				foreach (var line in lines)
				{
					
					if (line.StartsWith(characterOne)){
						
						currentSpeaker = characterOne;
						//Console.WriteLine(currentSpeaker + " : " + line.Replace(currentSpeaker, string.Empty));
						Console.WriteLine(line);
					}
					else if (line.StartsWith(characterTwo))
					{

						currentSpeaker = characterTwo;
						//Console.WriteLine(currentSpeaker + " : " + line.Replace(currentSpeaker, string.Empty));
						Console.WriteLine(line);
					}
					else
					{
						Console.WriteLine(line);
					}

					if (currentSpeaker.Equals(characterOne)){
						chatHistory.Add(new (characterOne, line.Replace(characterOne, string.Empty)));
					}
					else
					{
						chatHistory.Add(new (characterTwo, line.Replace(characterTwo, string.Empty)));
					}


					// Output the dialogues
					//Console.WriteLine($"{characterOne}'s Dialogue:");
					//foreach (var dialogue in dialoguesCharacterOne)
					//	Console.WriteLine(dialogue);

					//Console.WriteLine($"\n{characterTwo}'s Dialogue:");
					//foreach (var dialogue in dialoguesCharacterTwo)
					//	Console.WriteLine(dialogue);
				}
				return chatHistory;


			}
			catch (Exception e)
			{
				Console.WriteLine("An error occurred: " + e.Message);
				return new List<KeyValuePair<string, string>> { new KeyValuePair<string, string>() };
			}
		} 

		public static void ExportToCustomModel(string exportedFilePath, CharacterCard characterCard, List<KeyValuePair<string, string>> chatHistory)
		{
			try
			{
				string currentCharacter = string.Empty;
				foreach(var item in chatHistory)
				{
					characterCard.actions ??= [];
					if(currentCharacter.Equals(item.Key))
					{
						characterCard.actions.Add(" \n " + item.Value);

					}
					else
					{
						currentCharacter = item.Key;
						characterCard.actions.Add("\n"+item.Key + item.Value);
					}
				}

				var options = new JsonSerializerOptions
				{
					Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
				};

				// Write the processed content to a new file
				string serializedCard = JsonSerializer.Serialize(characterCard, options);

				File.WriteAllText(exportedFilePath, serializedCard, System.Text.Encoding.Unicode);
			}
			catch(Exception ex)
			{
				;
			}
		}
	}
}
