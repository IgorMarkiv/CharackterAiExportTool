
using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace DialogSplitterApp
{
	class Program
	{
		static void Main(string[] args)
		{

			// Define the path to the file (change to the actual file path)
			string filePath = @"C:\Users\Admin\Desktop\ExportedChat.txt";
			string proccessedFilePath = @"C:\Users\Admin\Desktop\DialogProcessed.txt";

			GenerateProcessedFile(filePath, proccessedFilePath);
			DisplayProcessedFile(proccessedFilePath);
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

		public static void DisplayProcessedFile(string proccessedFilePath)
		{
			try 
			{
				// Read the content of the file
				string[] lines = File.ReadAllLines(proccessedFilePath);
				// Define characters
				string characterOne = "Vikr : ";
				string characterTwo = "Higuchi Madoka : ";

				// Initialize dialogues for each character
				List<string> dialoguesCharacterOne = new List<string>();
				List<string> dialoguesCharacterTwo = new List<string>();

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
						dialoguesCharacterTwo.Add(line);
					}
					else
					{
						dialoguesCharacterOne.Add(line);
					}

					// Output the dialogues
					//Console.WriteLine($"{characterOne}'s Dialogue:");
					//foreach (var dialogue in dialoguesCharacterOne)
					//	Console.WriteLine(dialogue);

					//Console.WriteLine($"\n{characterTwo}'s Dialogue:");
					//foreach (var dialogue in dialoguesCharacterTwo)
					//	Console.WriteLine(dialogue);
				}


			}
			catch (Exception e)
			{
				Console.WriteLine("An error occurred: " + e.Message);
			}
		}
	}
}
