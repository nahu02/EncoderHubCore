# Microsoft Translator API

## Setup

- Create a RapidAPI account and subscribe to the translator API
  at [this link](https://rapidapi.com/gatzuma/api/deep-translate1)
- Get the API key from the RapidAPI dashboard

### Using dotnet user-secrets

- Make sure you have dotnet cli installed on your machine
- In the EncoderHub solution's root directory, run the following command:
   ```bash
   dotnet user-secrets set "MsTranslate:ApiKey" "<YOUR-API-KEY>"
   ```


### Using environment variables

- Set the environment variable `MsTranslate__ApiKey` to your API key