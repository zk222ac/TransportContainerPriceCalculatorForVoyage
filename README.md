# Transport Container Price Calculator For Voyage ( Mærsk challenge)

Running average
This document describes a backend homework challenge for candidates applying for positions within
Maersk's Service Delivery platform.

The goal is to see:
# How you approach a problem #
How you design, structure, implement, and deliver a complete solution that is adapted to the proposed
problem below This will be followed by a discussion with some of the software engineers in Service Delivery's hiring team.

# Handing in your solution #
Your code and other deliverables must be provided as a link to a private Git repository (VSTS, GitLab, GitHub, or Bitbucket)
Your solution must only be accessible to you and us; please make sure it is not available for a wider audience, especially not publicly. We would like to reuse the challenge - please help us keeping it fair!
The problem
# Case assignment #
Your assignment is to build an ASP.NET Core web API for an internal dashboard application to track container transport prices for specific geographical routes, referred to as voyages. More specifically, your API needs an endpoint that returns the last 10 prices for containers booked on a given voyage and an
endpoint through which you can register a new booking price.
The application should support at least 3 different currencies of your choice. You don't need to connect to an online service to get the latest currency rates - it is fine to use hard-coded exchange rates. Further, all data should be kept in memory. Endpoints The API should have the following two endpoints:

[POST] UpdatePrice(string voyageCode, decimal price, Currency currency, DateTimeOffset timestamp)
Example: UpdatePrice("451S", 109.5, Currency.Gbx, DateTimeOffset.Now)

[GET] GetAverage(string voyageCode, Currency currency)
Example: GetAverage("451S", Currency.Gbx) --> 152.35
We expect a lot of traffic, particularly for reads, so performance is important to keep in mind.
# Your solution #

Your delivery should:
Include a fully functional solution built using C#, ASP.NET Core, and .NET Core
Include the complete code needed to execute the solution
Include a suite of unit tests covering key components of your solution Contain logging functionality
If you use any third-party libraries, these must be referenced via NuGet
Contain a Readme file explaining how to build, test, and run your solution locally, plus any additional
details (e.g. architectural decisions) you might find relevant for us to know
Your solution should be self-contained and all data should be stored in memory for the sake of simplicity.
No external infrastructure should be needed to run the solution.
The requirements intentionally leave a lot of design decisions up to you, so use your solution to showcase
how you would approach the described problem from both a (technical) design and implementation point of
view.
Good Luck! We look forward to reviewing your solution.

# solution # 
I adopted the Repository # design Pattern architecture # to solve this challenge. 
Benefits of Repository Pattern

- It centralizes data logic or business logic and service logic.
- It gives a substitution point for the unit tests.
- Provides a flexible architecture.
- If you want to modify the data access logic or business access logic, you don’t need to change the repository logic.

![RepositoryDesignPattern](https://user-images.githubusercontent.com/11761314/170886974-2e4df624-878b-4417-99bf-ee8ea8390f58.png)


# Archtecture Design: 

![image](https://user-images.githubusercontent.com/11761314/170886909-21a1337a-55a7-42d4-9cee-9307ee34f01d.png)

In this diagram I have created different folders for their own responsibilties
> **Controller** : controller folder responsible for handling / fetching data from business layer via application abstract layer.
> **Data** : this folder is held responsible for creating and mainting Db context class.
> **Entities** : this folder represent application data model classes. 
> **Repositories** : abstraction layer between business and data access layer.

# DDL : .Net Dynamic link libraries
> Microsoft Entityframework Core 
> Microsoft Entityframework Core InMemory 
> Swash buckle Asp Net Core ( Web API UI interface)

# Core Application functionalities:

## Step no 1 : Application shows different container price with different currency 
once you downloded this application , you need to simply run the application as usual you run your application via Visual studio program. Click executable button.

![image](https://user-images.githubusercontent.com/11761314/170888081-98c4dcdb-e7c8-466c-9c89-d6cca159a1eb.png)

## Data schema :
![image](https://user-images.githubusercontent.com/11761314/170888116-f5f5ccf7-9cc2-4b1c-acb4-347d0a022cbe.png)

As you can see webAPI have four endpoints but two end points are the main requirements in this app.
> **GetVoyages**
> **Update Price**
> **Get Average Price**

## Step no : 2 --> Get all Voyages ( Show all containers with diffrent prices and currency)
![image](https://user-images.githubusercontent.com/11761314/170888442-0b309057-a049-438b-82ad-2d26f7fbd9fb.png)

## Step no : 3 --> Update Price ( Add new price with specified currency)
![image](https://user-images.githubusercontent.com/11761314/170890151-f35f7f3e-a16a-4104-b7a0-1b2f6c525ffa.png)

Above diagram explain how we send POST request , when we send it we dont need Id because it is system can generate Id automatically. after this we are able to register new price with new values. Below diagram show the API response and generated New item values.

## output :
![image](https://user-images.githubusercontent.com/11761314/170890712-4f352b5b-ac8b-4963-b4af-e7cb046f67df.png)

## Step no : 4 --> Get Average Price (returns the last 10 prices for containers booked on a given voyage)
![image](https://user-images.githubusercontent.com/11761314/171035173-4c1c8c44-4687-4650-8611-0524c3f8062a.png)

## output: 
![image](https://user-images.githubusercontent.com/11761314/171035438-1ad56f99-f0f0-4b61-b954-7517fc1a3266.png)




