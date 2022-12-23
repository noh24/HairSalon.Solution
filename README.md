# Eau Claire's Salon

#### Tracks Eau Claire's Salon stylists and clients

#### By [Brian Noh](https://github.com/noh24)

## Technologies Used

- CSS
- HTML
- C#
- .NET 6.0
- ASP.Net
- Razor
- MySQL
- Workbench
- EF Core

## Description

Eau Claire's Salon lets owner to add and track her stylists and their clients.

## Setup/Installation Requirements

- Clone this repository to your Desktop:
  1. Your computer will need to have GIT installed. If you do not currently have GIT installed, follow [these](https://docs.github.com/en/get-started/quickstart/set-up-git) directions for installing and setting up GIT.
  2. Once GIT is installed, clone this repository by typing following commands in your command line:
     ```
     ~ $ cd Desktop
     ~/Desktop $ git clone https://github.com/noh24/HairSalon.Solution.git
     ~/Desktop $ cd HairSalon.Solution
     ```
- Install the [.NET 6 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)
- Install Packages for EF Core:
  ```
  ~/Desktop/HairSalon.Solution $ dotnet add package Microsoft.EntityFrameworkCore -v 6.0.0
  ~/Desktop/HairSalon.Solution $ dotnet add package Pomelo.EntityFrameworkCore.MySql -v 6.0.0
  ```
- Setup Database:
  - Install [MySQL Community Server and MySQL Workbench](https://www.learnhowtoprogram.com/c-and-net/getting-started-with-c/installing-and-configuring-mysql). Remember your PASSWORD.
  - Open MySQL Workbench and access Local instance 3306 under MySQL Connections
  - Click on the "Administration Tab", and select "Data Import/Restore" from the list
  - Select "Import from Self-Contained File" and find file named "brian_noh.sql" located at Desktop/HairSalon.Solution/brian_noh.sql
  - Start Import
- Create .gitignore file:
  ```
   ~/Desktop/HairSalon.Solution/ $ touch .gitignore
   ~/Desktop/HairSalon.Solution/ $ echo "*/obj/
   */bin/
   */appsettings.json" > .gitignore
  ```
- Create appsettings.json file:
  ```
   ~/Desktop/HairSalon.Solution $ cd HairSalon
   ~/Desktop/HairSalon.Solution/HairSalon $ touch appsettings.json
   ~/Desktop/HairSalon.Solution/HairSalon $ echo '{
      "ConnectionStrings": {
        "DefaultConnection": "Server=localhost;Port=3306;database=brian_noh;uid=root;pwd=[PASSWORD];"
      }
    }' > appsettings.json
  ```
  [PASSWORD] is your password
- Build the project:
  ```
   ~/Desktop/HairSalon.Solution/ $ dotnet build HairSalon/
  ```
- Run the project
  ```
   ~/Desktop/HairSalon.Solution/ $ dotnet watch run --project HairSalon/
  ```
- Visit [http://localhost:5000](http://localhost:5000) to try this application

## Known Bugs


## License

[MIT License](./license.txt)

Copyright (c) 12/23/2022 Brian Noh
