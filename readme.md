# Health&Med Scheduling Service - Hackathon Project

## Overview

This project is part of the Health&Med Hackathon, focused on developing a backend service to manage the scheduling of medical consultations. The Scheduling Service is built in .NET Core and is responsible for handling doctor availability, patient appointments, and real-time conflict resolution.

### Main Objective
To provide a robust and scalable system that allows doctors to manage their availability and patients to book consultations. The service ensures real-time validation of appointment availability and avoids scheduling conflicts.

### Key Features
- Manage doctor availability (add/edit time slots)
- Real-time conflict validation for scheduling
- Appointment booking by patients

## Non-Functional Requirements
1. **Concurrent Scheduling Support**
   - The system must handle multiple simultaneous access requests, ensuring that only one booking is made per available time slot.
   
2. **Real-Time Conflict Validation**
   - The system checks in real-time to avoid double-booking or overlapping appointments.

## Tech Stack
- **.NET Core** for backend service
- **RabbitMQ** for message queueing, used for sending asynchronous tasks like notifications to doctors
- **PostgreSQL** for database management
- **Docker** for containerization and deployment
- **Entity Framework Core** for data access
- **FluentValidation** for input validation
- **MediatR** for managing requests and command/query separation

## Features

### 1. Manage Doctor Availability
Doctors can manage their availability through API endpoints by adding or editing available time slots for appointments.

### 2. Appointment Booking (Patient)
Patients can book a consultation by selecting a doctor and an available time slot. The system ensures that each time slot is available before confirming the booking.

### 3. Conflict Validation
The system checks for scheduling conflicts in real-time to ensure that no overlapping appointments occur.

### 4. RabbitMQ Integration
The service publishes messages to RabbitMQ for notifying doctors when a new appointment is booked.

## Setup & Installation

### Prerequisites
- .NET 6 SDK
- Docker & Docker Compose
- RabbitMQ
- PostgreSQL

### Steps to Run

1. **Clone the repository:**
   ```bash
   git clone https://github.com/hackathon-POSTECH/SchedulingService.git
   ```

2. **Set up environment variables:**
   Create a `.env` file based on the provided `.env.example` file, and configure the RabbitMQ and PostgreSQL settings.

3. **Run the application using Docker Compose:**
   ```bash
   docker-compose up --build
   ```

4. **Database migration:**
   After the containers are up, run the database migrations:
   ```bash
   dotnet ef database update
   ```

5. **Access the API:**
   The API will be accessible at `http://localhost:5000`.

## CI/CD Pipeline
The CI/CD pipeline automates testing and deployment. Integration with a CI service such as GitHub Actions runs automated tests and builds on every push.

## Testing
Unit tests cover core functionalities like scheduling validation and availability management.

Run the tests:
```bash
dotnet test
```

## Contributors
- Health&Med Hackathon Team (FIAP SOAT students)

## License
This project is licensed under the MIT License.
