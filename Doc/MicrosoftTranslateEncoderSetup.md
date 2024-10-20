# Microsoft Translator API

## Setup

- Create a RapidAPI account and subscribe to the translator API
  at [this link](https://rapidapi.com/gatzuma/api/deep-translate1)
- Get the API key from the RapidAPI dashboard
- Make sure you have dotNet cli installed on your machine
- In the EncoderHub solution's root directory, run the following command:
   ```bash
   dotnet user-secrets set "MsTranslate:ApiKey" "<YOUR-API-KEY>"
   ```
