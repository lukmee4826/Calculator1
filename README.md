💱 Currency Converter (THB ⇄ JPY via USD) – WinForms C# App
This is a simple desktop application built using C# WinForms that allows users to convert between Thai Baht (THB) and Japanese Yen (JPY) using real-time exchange rates fetched from the CurrencyFreaks API (USD as base currency).

Calculator1/
├── Form1.cs              # Main form (UI)
├── CurrencyConverter.cs  # Currency conversion logic (API)
├── Program.cs            # Entry point
├── Calculator1.csproj    # Project file
├── README.md             # Project documentation


🚀 Features
✅ Convert THB to JPY using real-time rates (via USD)

✅ Convert JPY to THB using the same method

✅ Simple, responsive UI using WinForms

✅ Error handling for network/API issues

✅ Clean separation between UI and logic

✅ Easily extendable to support more currencies

🛠️ Requirements
.NET Framework (4.7.2 or later) or .NET 6+ (WinForms App)

Visual Studio 2019/2022 or later

📦 Dependencies (via NuGet)
Install these packages in your project:

Install-Package RestSharp
Install-Package Newtonsoft.Json

🔑 Setup
Register for an API key at: https://currencyfreaks.com

Replace the API key in CurrencyConverter.cs:

private const string ApiKey = "YOUR_API_KEY_HERE";

🧠 How It Works
✅ THB → USD → JPY

// Step 1: THB → USD
decimal usd = bahtAmount / thbRate;

// Step 2: USD → JPY
decimal jpy = usd * jpyRate;

✅ JPY → USD → THB

// Step 1: JPY → USD
decimal usd = jpyAmount / jpyRate;

// Step 2: USD → THB
decimal thb = usd * thbRate;

The exchange rates are fetched in real-time from:
GET https://api.currencyfreaks.com/v2.0/rates/latest?apikey=YOUR_API_KEY

🧪 Example Usage
From Form1.cs

CurrencyConverter converter = new CurrencyConverter();
decimal jpy = converter.ConvertBahtToUsdAndUsdToJpy(1000);   // THB to JPY
decimal thb = converter.ConvertJpyToThb(10000);               // JPY to THB

🔒 License
This project is released under the MIT License.

🙋 Support / Contribution
PRs welcome! Feel free to fork and contribute.

If you'd like to add support for other currencies or async API calls, open an issue or suggestion.
