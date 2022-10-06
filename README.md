# CUBE-Developer-App-Creation-Assessment
CUBE Full Stack Developer App Creation Assessment

This application has been created for the CUBE Full Stack Developer App Creation Assessment.
It has been developed using the .NET Framework version 4.7.2

The purpose of this application is as a simple programming assessment, to demonstrate coding style, structure and problem solving, in the style of an MVP.
This application is not considered to be production strength. For production strength, additional validation, error handling and unit testing would have been included.
Some assumptions were made around the requirements for the assignment, which I’m happy to explain during the interview. Had this of been a real word project, all requirements would have been clarified and confirmed as part of the development process.

The solution has been configured with two start up projects (UI & WebAPI), for convenience, both hosted via IIS Express.
Before running, within the solution's properties, check the solution is set to 'Multiple startup projects', with the following projects set to 'Start':

CubeGlobal.TemperatureConverter.UI
CubeGlobal.TemperatureConverter.WebAPI

The UI project allows users to undertake the conversion via a browser via the URL: http://localhost:19697
The WebAPI project provides an API to allow the customer to integrate the service into their own products via the URL: http://localhost:41139
The WebAPI can also be run and tested via a browser using the provided Swagger documentation page, which is provided via the URL: http://localhost:41139/Swagger