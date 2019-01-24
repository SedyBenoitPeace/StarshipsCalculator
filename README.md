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

# FAQ
# How can I run the app?
You can install it with the setup that you can find under the "Executable" folder, or you can directly run it through the exe that you can find on the "Portable" folder.
