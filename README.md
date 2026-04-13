# Paying Guest Management System (USA-focused Starter)

This repository now includes a clean, modular starter for a **Paying Guest (PG) management product** aligned with your requested stack:

- **Backend:** ASP.NET Core Web API (`.NET 8`)
- **Database:** MySQL
- **Web + SPA:** Angular
- **Android app:** Jetpack Kotlin

## Folder Structure

- `backend/PayingGuest.Api` → ASP.NET Core API with EF Core + MySQL.
- `database/mysql-schema.sql` → SQL schema bootstrap script.
- `web/angular-spa` → Angular single-page app starter dashboard.
- `android/PgManagerApp` → Jetpack Kotlin Android app starter (MVVM basics).

## Backend Highlights

- Domain models for property, room, guest, room assignment, and invoice.
- REST endpoints:
  - `GET/POST /api/properties`
  - `GET/POST /api/rooms`
  - `GET/POST /api/guests`
- EF Core persistence with Pomelo MySQL provider.
- Swagger enabled in development.

### Run Backend

```bash
cd backend/PayingGuest.Api
dotnet restore
dotnet run
```

## Angular SPA Highlights

- Standalone component architecture.
- Dashboard page with service-driven metrics.
- Router + HttpClient providers wired.

### Run Web App

```bash
cd web/angular-spa
npm install
npm start
```

## Android App Highlights

- Kotlin + Gradle KTS setup.
- MVVM starter (`MainViewModel`, repository, domain model).
- Basic dashboard summary screen.

### Run Android App

Open `android/PgManagerApp` in Android Studio and run on emulator/device.

## Database

Use `database/mysql-schema.sql` to initialize MySQL schema before connecting the API.

## Next Recommended Iterations

1. Authentication + RBAC (Super Admin, Building Admin, Staff, Guest).
2. Billing/payment gateway integration (Stripe/PayPal/ACH).
3. Visitor and complaint workflows.
4. Tenant/guest mobile notifications (FCM + email/SMS providers).
