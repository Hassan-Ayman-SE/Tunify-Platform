# Tunify Platform

## Brief Description

Tunify is a comprehensive music streaming platform that allows users to create and manage playlists, explore a diverse library of songs, albums, and artists, and enjoy personalized recommendations based on their preferences. The platform supports multiple subscription types, catering to various user needs. Tunify aims to deliver an exceptional music experience through a user-friendly interface and robust backend infrastructure.

## Tunify ERD Diagram

![Tunify ERD](TunifyPlatform/images/Tunify.png)

## Overview of Relationships

The Tunify platform's database is designed with several entities to efficiently manage and store information related to users, subscriptions, playlists, songs, albums, and artists. Below is an overview of the relationships between these entities:

1. **Users and Subscriptions**
   - **Users** are linked to **Subscriptions** through a foreign key relationship. Each user has a `SubscriptionId` that references the `Id` of a subscription plan. This relationship ensures that each user is associated with a specific subscription type, which defines their access level and features on the platform.
   - **One-to-Many Relationship**: One subscription can have multiple users, but each user can only have one subscription.

2. **Users and Playlists**
   - **Users** can create multiple **Playlists**. Each playlist is linked to a user through a foreign key (`UserId`).
   - **One-to-Many Relationship**: One user can have multiple playlists, but each playlist is associated with one user.

3. **Playlists and Songs**
   - The relationship between **Playlists** and **Songs** is managed through a join table called `PlaylistSongs`. This table contains the foreign keys for both playlists and songs, allowing a many-to-many relationship.
   - **Many-to-Many Relationship**: One playlist can contain multiple songs, and one song can appear in multiple playlists.

4. **Songs and Albums**
   - Each **Song** belongs to an **Album**. The `AlbumId` in the Songs table references the `Id` in the Albums table.
   - **One-to-Many Relationship**: One album can have multiple songs, but each song belongs to one album.

5. **Songs and Artists**
   - Each **Song** is created by an **Artist**. The `ArtistId` in the Songs table references the `Id` in the Artists table.
   - **One-to-Many Relationship**: One artist can create multiple songs, but each song is created by one artist.

---


## Repository Design Pattern

### Overview
The Repository Design Pattern decouples data access logic from the business logic in the application, promoting modularity and testability.

### Implementation
In this project, repositories were created for managing data access for the `Users`, `Playlist`, `Song`, and `Artist` entities. These repositories encapsulate CRUD operations and any additional data access logic, making the application easier to maintain and extend.

### Benefits
- **Separation of Concerns**: Keeps data access logic separate from business logic.
- **Testability**: Allows for mocking data access during unit tests.
- **Flexibility**: Facilitates changes in data access strategy without affecting business logic.

---

## New Navigation and Routing Functionalities

We introduced advanced navigation and routing functionalities to improve the user experience within the **Tunify Platform**. These enhancements include:

- **Dynamic Routing**: Routes are dynamically generated based on user actions such as playlist creation or artist selection.
- **Nested Routing**: Certain pages, such as songs within a playlist or albums by an artist, use nested routes to keep the URL structure clean and meaningful.
- **Parameterized Routing**: Routes now accept dynamic parameters for accessing specific resources. For example:
  - `/playlists/:id/songs` for viewing songs in a playlist.
  - `/artists/:id/songs` for viewing songs by a particular artist.
- **Lazy Loading**: Implemented lazy loading for certain modules to improve performance, loading only the necessary components when they are needed.

---

## Addition of Swagger UI

We have added Swagger UI to our Tunify Platform. Swagger UI is a tool that allows us to visualize and interact with the API's resources without having any of the implementation logic in place. It's a powerful tool for API development and testing.

We have used Swashbuckle.AspNetCore to set up Swagger UI. Swashbuckle.AspNetCore is a NuGet package that seamlessly adds a Swagger to WebApi projects.

## How to access and use the Swagger UI

To access the Swagger UI, launch the application and navigate to the root URL. This will open the Swagger UI where you can see all the API endpoints documented.

You can use the Swagger UI to interact with the API endpoints and test their functionality. It provides a way to understand the capabilities of the API without diving into the code.

To use the Swagger UI, simply click on an API endpoint to expand it. You can see the details of the endpoint, including its parameters, responses, and even try it out by clicking the "Try it out" button. Fill in any required parameters and click "Execute" to see the response from the API.
