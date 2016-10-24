Refit is really useful; it automatically generates the implementation for the interface defining an API.

To understand how Refit works, I developed a global API which calls a fake online API called [JSONPlaceholder](http://jsonplaceholder.typicode.com). I also used swagger for documenting my global API and Windsor Castle for the IOC. You can find, in this document, the defition and the link to the official documentation for all of them.

Usually, you need to create a service that use HttpClient to communicate with an API. With Refit, you don't need to create it. Instead, you must create the interface defining the API and let Refit generates it for you.

Here the diffirent steps you need to communicate wth an API:
- Define the interface for the API you want to communicate with
```C#
public interface IJsonPlaceHolderApiService
{
    [Get("/posts/{id}")]
    Task<Post> GetPost(int id);
}
```

- Specify the root url of the API for the interface by using RestService
```C#
RestService.For<IJsonPlaceHolderApiService>("http://jsonplaceholder.typicode.com")
```

# Refit
Refit is a library generating an implementation of your API interface by using HttpClient. It allows to just be focused on the contract itself and not on the implementation itself.

Here the official documentation of refit [Refit official](https://github.com/paulcbetts/refit)

# Swagger
Swagger is a specification for defining the interface of a RESTful API.

Here the official documentation of refit [Swagger official](http://swagger.io/)

# Windsor Castle
Castle Windsor is an Inversion of Control container available for .NET and Silverlight. 

Here the official documentation of refit [Windsor Castle official](https://github.com/castleproject/Windsor/blob/master/docs/README.md)
