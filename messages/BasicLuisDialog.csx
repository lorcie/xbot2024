using System;
using System.Threading.Tasks;

using Microsoft.Bot.Builder.Azure;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;

// For more information about this template visit http://aka.ms/azurebots-csharp-luis
[Serializable]
public class BasicLuisDialog : LuisDialog<object>
{
	//Utils.GetAppSetting("LuisAppId"),Utils.GetAppSetting("LuisAPIKey") // "<AppId>","<APIKey>"
	public BasicLuisDialog() : base(new LuisService(new LuisModelAttribute(Utils.GetAppSetting("LuisAppId"),Utils.GetAppSetting("LuisAPIKey"))))
    {
    }

    [LuisIntent("None")]
    public async Task NoneIntent(IDialogContext context, LuisResult result)
    {
        await context.PostAsync($"None intent. You said: {result.Query}. What can I do for you?"); //
        context.Wait(MessageReceived);
    }

    // Go to https://luis.ai and create a new intent, then train/publish your luis app.
    // Finally replace "MyIntent" with the name of your newly created intent in the following handler
    [LuisIntent("MyIntent")]
    public async Task MyIntent(IDialogContext context, LuisResult result)
    {
        await context.PostAsync($"MyIntent intent. You said: {result.Query}. What can I do for you?"); //
        context.Wait(MessageReceived);
    }
}