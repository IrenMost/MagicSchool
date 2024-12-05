# MagicSchool


![wand](https://github.com/user-attachments/assets/208782ea-624e-4829-a146-e37bfab00a1b)



## Overview
MagicSchool is an interactive school management system designed to handle user roles, points allocation, and administrative tasks with a magical twist. This isn’t an ordinary school—this is a Magic School, inspired by the world-renowned works of J.K. Rowling's Harry Potter series.

The app caters to Students, Teachers, and even HouseElves, with the Ministry serving as the ultimate authority. The Director role has special privileges, including assigning Teachers as heads of houses.




## Usage

To explore the application, you can log in with the credentials of a teacher:
E-mail: rolanda.hooch@hogwarts.edu
Password: HoochPassword123!

After logging in, you can decide, which house deserves extra points and add points


## Table of Contents

- [Overview](#overview)
- [Usage](#usage)
- [Build With](#build-with)
- [Installation](#installation)
- [Features](#features)


## Built With

![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=csharp&logoColor=white)
![ASP.NET](https://img.shields.io/badge/ASP.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)
![MSSQL Server](https://img.shields.io/badge/Microsoft%20SQL%20Server-CC2927?style=for-the-badge&logo=microsoft%20sql%20server&logoColor=white)
![Vite](https://img.shields.io/badge/Vite-B73BFE?style=for-the-badge&logo=vite&logoColor=FFD62E)
![React](https://img.shields.io/badge/React-20232A?style=for-the-badge&logo=react&logoColor=61DAFB)
![JavaScript](https://img.shields.io/badge/JavaScript-323330?style=for-the-badge&logo=javascript&logoColor=F7DF1E)
![Docker](https://img.shields.io/badge/Docker-007FFF?style=for-the-badge&logo=docker&logoColor=white)




## Installation

Repo: https://github.com/IrenMost/MagicSchool

## Prerequisites:

### Node.js and npm
- Ensure that Node.js (which includes npm) is installed on your machine. You can download and install it from the [official Node.js website](https://nodejs.org/).

  ```bash
  # To check if Node.js and npm are installed and view their versions, run:
  node -v
  npm -v
  ```

### .NET SDK
- Install the .NET SDK to build and run the ASP.NET Core backend. You can download it from the [.NET SDK download page](https://dotnet.microsoft.com/download).

  ```bash
  # To check if the .NET SDK is installed and view its version, run:
  dotnet --version
  ```
 
## Backend:

### 1. Navigate to the Backend Directory
Go to the Backend directory from the root folder.

```bash
cd Backend
```

### 2. Install Backend Dependencies
Restore the dependencies for your ASP.NET Core project.

```bash
dotnet restore
```

### 3. Build the Backend
Build your ASP.NET Core backend project.

```bash
dotnet build
```

### 4. Run the Backend
Run your ASP.NET Core backend project.

```bash
dotnet run
```

### 4. Access the Frontend
Once the server is running, you can access your backend by navigation to [http://localhost:7079](http://localhost:7079) or the port displayed by the terminal.

## Frontend:

### 1. Navigate to the Frontend Directory
Go to the Frontend directory from the root folder.

```bash
 cd FrontendMagic/FrontendMagic
```

### 2. Install Frontend Dependencies
Install the required npm packages for your Vite React project.

```bash
npm install
  npm install react-router-dom
```

### 3. Run the Frontend Development Server
Start the Vite development server for your React frontend.

```bash
npm run dev
```

### 4. Access the Frontend
Once the development server is running, you can access your frontend by navigating to the URL displayed in your terminal, usually [https://localhost:5173](https://localhost:5173) or a similar port.

## Docker:

Currently, the database runs on Docker. Future iterations may include Docker support for the entire application stack.

## Features

Available Pages:
Home: An overview of the Magic School.
Login/Logout: Access control for various roles.
HouseList: Teachers can add or deduct points for houses.
TeacherList: View and update teacher data.

+ Role-based access control ensures that users have appropriate permissions.
+ Teachers can award or deduct points from houses in real time.
+ Directors have exclusive privileges to manage users and assign roles.


## Future features

+ Room Management:

List all rooms and assign students to specific rooms.
+ Freeing HouseElves:

Directors can free a house-elf through a magical procedure.
+ Advanced Role Assignment:

Assign or remove roles like Headmaster or House Head.
+ Course Selection:

Allow students to choose courses from a predefined list.



