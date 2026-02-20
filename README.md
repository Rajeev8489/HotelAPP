🏨 Stayvora – Hotel Booking Management System

A full-stack hotel booking management system built using ASP.NET Core Web API and MVC with clean architecture principles.
Stayvora allows users to securely register, browse rooms, and manage hotel bookings through a responsive modern interface.

🚀 Features

🔐 Authentication & Security

User registration and login

JWT-based authentication

Secure API communication

🏨 Hotel & Room Management

View available rooms

Room data handling with DTO mapping

Clean service-based architecture

📅 Booking System

Create, edit, and delete bookings

Booking confirmation workflow

Mobile-friendly booking interface

📱 Responsive UI

Desktop and mobile layouts

Bootstrap-powered design

Toast notifications and validation

🧱 Project Architecture

The solution follows a clean multi-layer architecture:

```text
HotelAPP Solution
│
├── HotelAPI (Backend)
│   ├── Controllers
│   ├── Services
│   ├── Models & DTOs
│   ├── Data & Migrations
│   └── JWT Authentication
│
├── HotelAppUI (Frontend)
│   ├── Razor Views
│   ├── Layouts (Desktop & Mobile)
│   ├── Booking & Auth Pages
│   └── Responsive UI
│
└── HotelApp-Utility
    └── Shared helpers & configurations
```
    
🛠 Tech Stack

Backend :

ASP.NET Core Web API

Entity Framework Core

SQL Server

JWT Authentication

AutoMapper

Frontend :

ASP.NET Core MVC

Razor Pages

Bootstrap

jQuery

Font Awesome

Architecture:

Clean Architecture

DTO Pattern

Service Layer Pattern

⚙️ Setup Instructions

Prerequisites

.NET SDK 7+

SQL Server

Visual Studio / VS Code

🔧 Backend Setup

Clone repository

git clone https://github.com/Rajeev8489/HotelAPP.git

Update connection string in appsettings.json

Apply migrations

Update-Database

Run API project

🎨 Frontend Setup

Set HotelAppUI as startup project

Run the application

📸 Screenshots

<img width="1879" height="863" alt="Screenshot 2026-02-20 124004" src="https://github.com/user-attachments/assets/71ad7915-51ad-4772-8033-5f9099d28a0d" />


<img width="1877" height="837" alt="Screenshot 2026-02-20 124040" src="https://github.com/user-attachments/assets/6660afd3-1d42-407c-ad9b-7450a9842aaf" />


<img width="1795" height="849" alt="Screenshot 2026-02-20 124057" src="https://github.com/user-attachments/assets/8ffcece7-8124-468b-8e9e-a54929b51d09" />



📈 Future Improvements

Payment gateway integration

Admin dashboard

Room availability calendar

Booking analytics

Email confirmations

🤝 Contributing

Pull requests are welcome.
For major changes, please open an issue first to discuss improvements.

📄 License

This project is open-source and available under the MIT License.

✨ Author

Rajeev
ASP.NET Developer | Backend Engineer
