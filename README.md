# StarshipsCalculator
A little application to calculate the number of stops on a given distance for Swapi.com's Starships

# What It Does?
The application will take a mega light distance in input and will give you the number of stops required to cover that distance for the Starships from SWAPI's API (https://swapi.co/).

# Requirements
<ul>
  <li>The application is developed with .NET Framework 4.6.1, that you  can find here https://www.microsoft.com/en-ca/download/details.aspx?id=49981</li>
  <li> As the app relies on some API you also need to have internet connection to run the application and download the informations about the starships. </li>
  </ul>

# Designing
When we design an application of course, there are many preliminary steps to do.
<ol type="1">
  <li>We need to choose technologies to use, in this case it's not a complex project, but in every case I decided to go with .NET Framework</li>
  <li> After the technologies, naturally we need an environment to develop the app, in this case I choose Visual Studio 2017 Express Edition</li>
  <li>Last but not least we need to understand the problems and then make our implementations. The problem can be see in the "What it does?" section of this documentation.
  I'll have a distance to be covered in MegaLights (MGLT) and I need to calculate how much a starship can cover without resupplying, for the technical details and all the functions please check the next section</li>
</ol>

# Implementation
When an application is designed one of the best practices is to write clean and clear code and also if this is a "simple" and "small" application, I tried to write the code in a good way.

The application is then divided in areas (the best coding practices tell to us to use different libraries in Visual Studio for example but for this project I created only new folders inside the solution to avoid too much complexity).

<h3>AREAS</h3>

<h4>Constants</h4>
In this area I defined (like the good practices suggest), two classes with strings that we will use for every purpose, in this case we have ApiError.cs and Messages.cs
<h4>Interfaces</h4>
Here we have the interfaces IApiService, ILogger and IStarshipService where we defined the methods to implement in the class that will implement the interfaces, this is one of the best practices of OOP Programming, particularly here we're calling the factory pattern where we defined the methods but we will leave the implementation to the classes that will implement them.

<h4>Models</h4>
Here we have two folders, Enumerators and Starships.
On the first one we defined the Enumerator "EnumDaysForString" that allow us to map the information about consumables for the starships and convert it to a defined amount of days (e.g year -> 365 days), I defined also some extensions (that I don't used) to get the maximum from enumerators (usually I always make something that I know will be useful for the future) but they're not used.
The second folders is "Starships" where we have all the models needed to process our data from the API, there are 3 Models, the <b>ResultDTO</b> that is for saving final informations about the problem (Starship's name and Number of Stops), <b>StarshipDTO</b> that is the single Starship and will be also inside the <b>StarshipsListDTO</b> that is used to "serialize" the data from the API, in fact this one will be the same as the response from the API.

<h4>Services</h4>
Here we have the classes that will implement the interface from the Interfaces Area, and as best pratices suggest they'll handle the various operation on data.
<b>ApiService</b> is the one that will make the query to the API, while <b>StarshipService</b> will "use" ApiService and will represent the data in the format that we want, in this case it will process all the data from the API, here we have also some reference to a few parameters in the app config, they are <b>Starships.URL</b> that will set the URL needed to download data from API and <b>Starships.Api.ElementsPerPage</b> because as we saw in API's documentation and test, the response will be divided in pages.
<h4>General</h4>
<h5><b>Program.cs</b></h5>
This is the "main" of the application (the one that will be executed first), here we take the input of the user (forcing him to put a number), then we process it to make our calculation and we will display the result on the screen. There is also an exception handling to prevents strange behaviours.

<h4><b>Logger.cs</b></h4>
This is a class that we use in the Program.cs and that implements the interface ILogger to log errors, basically it prints on screen the errors that can happen.

<h4><b>OperationResult.cs</b></h4>
This is a generic class that it's used application wide to give result from various methods, for example on the main we will use it to notify errors if something went wrong, but we use it also on ApiService.cs to make the api call.

<h4><b>CalculateStops.cs</b></h4>
This is the class that will process data and will give to use the results that we want from the Starships.
It will process all the starships, particularly it will take care of the distance that they can cover, it will check the consumables and of course will calculate the stops that a starship needs.

And that's it!

# UnitTest
There is also another part for the solution, and that is the one about UnitTest. Here we have the class StarshipCalculatorTests properly decorated with [TestClass] attribute, and it has 4 test methods (also them decorated with a particular attribute, in this case [TestMethod].
The 4 methods are:
<ul>
  <li>SampleTest, this method will look if the Starships that we have on the coding challenge will be in the results</li>
  <li>IsOutputTheSame, this method will look if the Starships that we have on the coding challenge are the only results possible</li>
  <li>NoKeyInConfig, this method will test the absence of some configuration data</li>
  <li>ZeroElementsPerPage, this method will test the wrong setting for the elements on a page </li>
 </ul>

# Improvements
There is always room for improvement.
The Exception Handling could be better because in case of strange behaviours we will display everything on the Console, but of course this is not ideal for the user, we need to put everything in a log file and display a generic message. This could be achieved with an extension of the ILogger and its implementation.
The services that we used are not injected via other objects (for example the APIService used in StarshipService) but they're an instance of the class, of course with could achieve the injection with Depedency Injection Pattern.
In the end also the tests are a great area where there is plenty of improvements, especially with some API fails.

# FAQ
# How can I run the app?
You can install it with the setup that you can find under the "Executable" folder, or you can directly run it through the StarshipDistanceCalculator.exe that you can find on the "Portable" folder.
You can also download the .sln file and make everything through Visual Studio
