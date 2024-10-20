# Microsoft Translator API

## Setup

- Create a RapidAPI account and subscribe to the Microsoft Translator API
  at https://rapidapi.com/microsoft-azure-org-microsoft-cognitive-services/api/microsoft-translator-text/
- Get the API key from the RapidAPI dashboard
- Make sure you have dotNet cli installed on your machine
- In the EncoderHub solution's root directory, run the following command:
   ```bash
   dotnet user-secrets set "MsTranslate:ApiKey" "<YOUR-API-KEY>"
   ```