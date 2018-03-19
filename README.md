# Purplebricks Developer Test

The aim of this test is to give us an idea about how you approach the development and maintenance of web applications. You will work from a GitHub repository which contains an existing web application. The UI should be functional, but there is no expectation that you modify the brand theme. We are looking for a solution that shows how you build maintainable, scalable and secure software. The test is based on an overly simplified version of our business domain.

The existing web application supports two types of customer. Sellers are able to upload information about a property and list the property for sale. Buyers can search for a property and make an offer. When an offer has been placed on a property the seller should be able to accept or reject the offer.

## Test Objectives

### Objective 1 - Extend an existing feature

We need you to extend the offer functionality of the web application so that when a seller accepts an offer the buyer that placed the offer can see that their offer has been accepted.

**User Story:** *As a buyer I want to see when my offer has been accepted so that I can proceed with the property purchase.*

### Objective 2 – Add a new feature

We need you to add the ability for a buyer to book a viewing. It’s unlikely a customer would want to make an offer on a property without booking a viewing.

**User Story:** *As a buyer I want to book a viewing appointment at a property so that I can determine whether I would like to make an offer.*

### Objective 3 - Review the existing code

Write a short review of the existing sample codebase. Let us know what you think is good or bad about it. Feel free to fix any problems and commit these changes to the solution.

#### Deliverables

Your submission should be delivered in as a Visual Studio solution compatible with Visual Studio 2015. The solution should compile. For data persistence please use the existing Entity Framework model with SQL. Feel free to add migrations if you need to. 
We would prefer that the solution is delivered via GitHub. If you are not able to fork this original repository publically then please fork to a private repository and then provide us with the zip file from the download option in GitHub.

Good luck!

## FAQs

* Should I show my commit history?
    * Showing your commit history is recommended so that we can see your approach.

* How long should I spend working on the assignment?
    * You can take as long as you need to complete the assignment. But do remember that this is throwaway code and the aim is to demonstrate your approach rather than build a complete system.

* Do I need to deploy the application?
    * If you wish to demonstrate your working app then you may deploy it to Azure on a free trial account. This is not mandatory.

## Results

### Objective 1 - Extend an existing feature

A new link at the top of the page has been added to allow a buyer to view all offers made on any number of properties.  This is approach enables buy to let users to easily see the status of many offers at one.

### Objective 2 – Add a new feature

Along side the make offer button for a property a new button has been added to allow a user to create an appointment to view the property.  There is no way of seeing the appointment to confirm it to manage conflicts or the seller to reject an appointment if not convienent in a similar process to making and rejecting an offer. This approach had been started but is not completed.

### Objective 3 - Review the existing code

The sample codebase is clearly based upon the default Visual Studio project so its aim of advertising the ease at which an MVC website can be created may not meet the specific needs of a business.

Since each business' needs differ it can be difficult to accurately comment on whether the project meets it requirements.  Requirements such as scalability, performance and mantainability will vary based on business's infrastructure, team, growth plans and ulitmately budget.

This leaves the code itself to comment upon and some general suggestions with could be used depending on the requirements.

#### Security

* Security can always be improved.  Given that the project is from 2015, its components required updating to incorporate the latest security fixes available.

* The project did not consistently implement anti forgery measures.

* The project did not have any Content Security Policies in place.

* The password complexity strength has been weakend by the View Model class.  It was not restored to ease development.

* The web server's attack surface was too great, it has been reduced by disabling web server features in the web.config file. 

#### Performance

* Apart from the Asp.net Identity classes there is no other use of async and await operations or use of the TPL library.  Using async in code helps improves the use of a server's resources.

* The search feature uses Entity Framework's text search which is slow.  It should be replaced with Elastic Search or Azure search.

* The entire project renders its pages on the server side.  Some efficiencies could be gained with the use of AJAX.

* Output caching could be used to improve performance.

* Entity Framework 

#### Scalability

* Scalability can be achieved through the infrastructure it runs on as well as the project's architecture.  Ensuring the architecture can help the software scale means some trade off from scaling through infrastruture can be mitigated, such as unbalanced loads.

* The project as it stands can be scaled up running it on a server using as much resources as possible.  This means that although the project may be able to perform faster the resources will not be target and bottlenecks in the sofwtare will remain.

* It could also be scaled out across several servers using load balancing tools such as sticky IP routers.  However it would mean that servers would unevely balance a load.

#### Maintainbility.

* Given there are unit tests, there was low code coverage.


##### Design

* Classes should be be loosely coupled and use interfaces along with dependency injection to help achieve it.  In addition using a service bus or stream processor that supports a publish and subscribe model could help decouple the classes.  The classes could be grouped into functions of domain specific services as move towards microservices.

* As the project grows classes within Entity Framework's will grow too degrdaing performance.  This can be stemmed by using a Domain Driven Design to split the classes across many more Entity Framework models.

* The database design may not be suitable for any reporting or business intelligence needs.


##### Production

* There was no error handling
* There is no logging to record errors if this code made it into production

