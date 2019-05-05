# SUBMISSION INSTRUCTIONS

To run and test this API, it's required of the user to:

1. Run the API
2. Populate the in-memory database with the data provided in the spreadsheets
3. Query for the shortest route through HTTP requests

## Running the API

To run the API, you need .NET Core installed in your machine - sorry, didn't have the time to containerize it with Docker :(

The API can be started manually through Visual Studio or VS Code, or through the `Run.bat` file provided in the root folder. The bat file automatically builds and starts the application through the `dotnet` command.

The application will run at the URL `http://localhost:[YOUR PORT]/` and the port will vary depending of the method you chose. If you ran it from the bat file, the default value for the port should be `5000`, but if have done it manually through Visual Studio, it probably assigned a differente one. You need to check it's value in order to successfully send requests to the API.

The API methods are not authenticated.

## Populating the Database

I have created an in-memory database with Entity Framework that needs to be populated before performing any queries. To do that, you must send a `POST` request to the endpoint responsible for performing this. No parameters are required, so you don't need to pass anything.

The endpoint is: `http://localhost:[YOUR PORT]/api/routes/populate`

## Data Inconsistencies

I have found some inconsistencies with the data in the spreadsheets. There are some airport codes in the routes.csv file that doesn't exist in the airports.csv. Since I only saw this quite a while after finishing the models, I handled these cases by not uploading them to the database.

## Querying for the Shortest Route

To query for the shortest route between two airports, you must send a `GET` request to the method responsible for this. The `origin` and `destination` parameters are required and you must inform Airport's IATA 3 codes for both of them.

The endpoint is: `http://localhost:[YOUR PORT]/api/routes?origin=[AIRPORT CODE]&destination=[AIRPORT CODE]`

For example, to search for the shortest route between Brussels Airport and Pearson International Airport, the endpoint would be: `http://localhost:[YOUR PORT]/api/routes?origin=BRU&destination=YYZ`

