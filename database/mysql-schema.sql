CREATE DATABASE IF NOT EXISTS pg_manager;
USE pg_manager;

CREATE TABLE properties (
    id CHAR(36) PRIMARY KEY,
    created_at_utc DATETIME NOT NULL,
    name VARCHAR(120) NOT NULL,
    city VARCHAR(80) NOT NULL,
    state_code CHAR(2) NOT NULL,
    zip_code VARCHAR(10) NOT NULL
);

CREATE TABLE rooms (
    id CHAR(36) PRIMARY KEY,
    created_at_utc DATETIME NOT NULL,
    property_id CHAR(36) NOT NULL,
    room_number VARCHAR(20) NOT NULL,
    monthly_rent_usd DECIMAL(10,2) NOT NULL,
    is_available BIT NOT NULL,
    CONSTRAINT fk_rooms_properties FOREIGN KEY (property_id) REFERENCES properties(id)
);

CREATE TABLE guests (
    id CHAR(36) PRIMARY KEY,
    created_at_utc DATETIME NOT NULL,
    full_name VARCHAR(120) NOT NULL,
    email VARCHAR(180) NOT NULL UNIQUE,
    phone_number VARCHAR(20) NOT NULL,
    move_in_date DATE NOT NULL,
    is_active BIT NOT NULL
);

CREATE TABLE guest_assignments (
    id CHAR(36) PRIMARY KEY,
    created_at_utc DATETIME NOT NULL,
    guest_id CHAR(36) NOT NULL,
    room_id CHAR(36) NOT NULL,
    start_date DATE NOT NULL,
    end_date DATE NULL,
    CONSTRAINT fk_assignments_guests FOREIGN KEY (guest_id) REFERENCES guests(id),
    CONSTRAINT fk_assignments_rooms FOREIGN KEY (room_id) REFERENCES rooms(id)
);

CREATE TABLE invoices (
    id CHAR(36) PRIMARY KEY,
    created_at_utc DATETIME NOT NULL,
    guest_id CHAR(36) NOT NULL,
    amount_usd DECIMAL(10,2) NOT NULL,
    billing_month DATE NOT NULL,
    due_date DATE NOT NULL,
    is_paid BIT NOT NULL,
    CONSTRAINT fk_invoices_guests FOREIGN KEY (guest_id) REFERENCES guests(id)
);
