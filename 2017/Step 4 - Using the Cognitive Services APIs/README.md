# Goal
Analyze the sentiment of the text entered by the user to see if it’s positive or negative by sending it to a REST API that will analyze it and also detect the language used by the user.  For doing that, we'll modify the function already created by calling the Text Analytics API of the Microsoft Cognitive Services.
We'll be making two API calls.  The first one will return the language of the sentence entered by the user and the second call will return the sentiment of the sentence as a number between 0 and 1 (0 meaning negatitve and 1 meaning positive).

Have the audience type what they feel about the local team making it to this year's finals.  This should be fun  :-)

# Reference
https://www.microsoft.com/cognitive-services

Head to https://www.microsoft.com/cognitive-services/en-us/text-analytics-api
Use the demo in the middle of the page to demonstrate the use of the API.  Make sure you show the JSON being returned.

# Let's code!
## Add the Text Analytics API
In the Azure portal, click on new and search for "Cognitive". 

![alt text][img1]


Create a Cognitive Service APIs by making sure to select the Text Analytics API in the API type dropdown.

Grab the key and store it in the Function's App Settings.

## Add the required usings
Ask the attendees to open the file 1.txt in the Code Snippets folder.  Copy an paste the code in the function editor.

## Add the detect language code
Ask the attendees to open the file 2.txt in the Code Snippets folder.  Modify the Run task to add code to detect the language that the sentence is written in.
Ask the attendees to open the file 3.txt in the Code Snippets folder.  Add the DetectLanguage() function below the Run task.

## Add the detect sentiment code
Ask the attendees to open the file 4.txt in the Code Snippets folder.  Add the DetectSentiment() function below the DetectLanguage() function.
In the Run task, add a call to the DectectSentiment() function below the call to the DetectLanguage() function.
```
var _Sentiment = await DetectSentiment(comment, BaseUrl, AccountKey);
```

[img1]: https://raw.githubusercontent.com/alainvezina/GlobalAzureBootcamp/master/2017/Step%204%20-%20Using%20the%20Cognitive%20Services%20APIs/Media/2017-04-07%2013_33_47-New%20-%20Microsoft%20Azure.png "Search for Cognitive"
