# How to use the nuGet package in your own project

1. Create a github account
2. Create a Classic personal access token with `read:packages` access! [More details on GitHub's documentation page.](https://docs.github.com/en/authentication/keeping-your-account-and-data-secure/managing-your-personal-access-tokens)
3. Add my github packages as a nuGet source using the following command: 
   ```
   dotnet nuget add source --username YOUR-GITHUB-USERNAME --password YOUR-ACCESS-TOKEN --store-password-in-clear-text --name github "https://nuget.pkg.github.com/nahu02/index.json"
   ```
   Make sure to insert your own github username and your access token where needed!
4. Add the package as a dependency to your project using
   ```
   dotnet add package EncoderHub
   ```
   


