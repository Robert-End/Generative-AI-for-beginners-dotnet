using System.ClientModel;
using Azure.AI.OpenAI;
using Microsoft.Extensions.AI;
using Azure;
using Azure.AI.Inference;
using Microsoft.Extensions.AI;

var deploymentName = "gpt-4o-mini"; // e.g. "gpt-4o-mini"
var endpoint = new Uri("https://ai-rkaistart496109111713.openai.azure.com/"); // e.g. "https://< your hub name >.openai.azure.com/"
var apiKey = new ApiKeyCredential(Environment.GetEnvironmentVariable("AZURE_AI_SECRET"));

IChatClient client = new AzureOpenAIClient(
    endpoint,
    apiKey)
.AsChatClient(deploymentName);

// here we're building the prompt
StringBuilder prompt = new StringBuilder();
prompt.AppendLine("You will analyze the sentiment of the following product reviews. Each line is its own review. Output the sentiment of each review in a bulleted list and then provide a generate sentiment of all reviews. ");
prompt.AppendLine("I bought this product and it's amazing. I love it!");
prompt.AppendLine("This product is terrible. I hate it.");
prompt.AppendLine("I'm not sure about this product. It's okay.");
prompt.AppendLine("I found this product based on the other reviews. It worked for a bit, and then it didn't.");

// send the prompt to the model and wait for the text completion
var response = await client.GetResponseAsync(prompt.ToString());

// display the repsonse
Console.WriteLine(response.Message);