

# OpenWeatherAPI ![C#](https://img.shields.io/badge/C%23-8.0-green) ![IHttpClientFactory](https://img.shields.io/badge/IHttpClientFactory-blue) ![License](https://img.shields.io/github/license/zeecorleone/OpenWeatherAPI)

## Introduction
Welcome to the **OpenWeatherAPI** repository! This project demonstrates how to call a third-party API (OpenWeather API in this case) using the three approaches of `IHttpClientFactory` in .NET: simple/classic, named, and typed clients.

## Features
- **IHttpClientFactory**: Use the factory to manage `HttpClient` instances effectively.
- **Three Approaches**: Learn the basic/classic `IHttpClientFactory` client in controller, the "named" HTTP client, and the "typed" HTTP client.
- **OpenWeather API Integration**: Fetch weather data using the OpenWeather API.

## Medium Article
I have written a [Medium article](https://todo.abc) on this topic: **Use IHttpClientFactory Right Way!**. In this article, I discuss the benefits of using `IHttpClientFactory`, the problems it solves (e.g., socket exhaustion), and the three approaches to use `HttpClient` with code examples just like in this repository.

## Getting Started

### Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) ![Download .NET 8](https://img.shields.io/badge/Download-.NET%208-blue)
- [OpenWeather API Key](https://openweathermap.org/api) ![Get API Key](https://img.shields.io/badge/Get%20API%20Key-OpenWeather-orange)

### Installation
1. **Clone the repository**
    ```bash
    git clone https://github.com/zeecorleone/OpenWeatherAPI.git
    cd OpenWeatherAPI
    ```

2. **Restore dependencies**
    ```bash
    dotnet restore
    ```

3. **Set up your OpenWeather API key**
   - Set your OpenWeather API Key in environment variable named `OPENWEATHER_API_KEY`

4. **Run the application**
    ```bash
    dotnet run
    ```

## Usage
Once the application is running, you can use endpoints (mentioned below) to fetch weather data from the OpenWeather API.

### Example Endpoints:
- **Without Using HttpClientFactory:** `https://localhost:7272/weatherforecast/GetOpenWeather` 
- **Using HttpClientFacotry (simple):** `https://localhost:7272/weatherforecast/GetOpenWeatherV1` 
- **Using HttpClientFacotry (named):** `https://localhost:7272/weatherforecast/GetOpenWeatherV2`
- **Using HttpClientFacotry (typed):** `https://localhost:7272/weatherforecast/GetOpenWeatherV3`

## Future Plans
I plan to extend this example in future articles. Potential topics include:
- Handling third-party API call failures.
- Implementing retry policies.

## Contributing
Contributions are welcome! Please submit a pull request or open an issue to discuss what you would like to change.

## License
This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for more details.

