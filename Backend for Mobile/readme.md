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

Consume a RESTful Web Service

    05/28/2020
    8 minutes to read

Download Sample Download the sample

Integrating a web service into an application is a common scenario. This article demonstrates how to consume a RESTful web service from a Xamarin.Forms application.

Representational State Transfer (REST) is an architectural style for building web services. REST requests are made over HTTP using the same HTTP verbs that web browsers use to retrieve web pages and to send data to servers. The verbs are:

    GET – this operation is used to retrieve data from the web service.
    POST – this operation is used to create a new item of data on the web service.
    PUT – this operation is used to update an item of data on the web service.
    PATCH – this operation is used to update an item of data on the web service by describing a set of instructions about how the item should be modified. This verb is not used in the sample application.
    DELETE – this operation is used to delete an item of data on the web service.

Web service APIs that adhere to REST are called RESTful APIs, and are defined using:

    A base URI.
    HTTP methods, such as GET, POST, PUT, PATCH, or DELETE.
    A media type for the data, such as JavaScript Object Notation (JSON).

RESTful web services typically use JSON messages to return data to the client. JSON is a text-based data-interchange format that produces compact payloads, which results in reduced bandwidth requirements when sending data. The sample application uses the open source NewtonSoft JSON.NET library to serialize and deserialize messages.

The simplicity of REST has helped make it the primary method for accessing web services in mobile applications.