https://docs.microsoft.com/en-us/aspnet/core/mobile/native-mobile-backend?view=aspnetcore-3.1

Create backend services for native mobile apps with ASP.NET Core

    12/05/2019
    8 minutes to read
        +4 

By Steve Smith

Mobile apps can communicate with ASP.NET Core backend services. For instructions on connecting local web services from iOS simulators and Android emulators, see Connect to Local Web Services from iOS Simulators and Android Emulators.

The Sample Native Mobile App

This tutorial demonstrates how to create backend services using ASP.NET Core MVC to support native mobile apps. It uses the Xamarin Forms ToDoRest app as its native client, which includes separate native clients for Android, iOS, Windows Universal, and Window Phone devices. You can follow the linked tutorial to create the native app (and install the necessary free Xamarin tools), as well as download the Xamarin sample solution. The Xamarin sample includes an ASP.NET Web API 2 services project, which this article's ASP.NET Core app replaces (with no changes required by the client).

Xamarin Forms ToDoRest app is at:
https://docs.microsoft.com/en-us/xamarin/xamarin-forms/data-cloud/web-services/rest