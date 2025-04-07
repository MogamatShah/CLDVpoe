-- DATABASE CREATION
USE master;
if exists (select * from sys.databases where name = 'EventEase')
create database EventEase;

use EventEase;
 
CREATE TABLE Venue (
    VenueID INT PRIMARY KEY,  
    VenueName VARCHAR(255) NOT NULL,
    Location VARCHAR(255),
    Capacity INT,
    ImageUrl VARCHAR(500)
);

--INSERTING DATA INTO TABLE Venue
INSERT INTO Venue (VenueID, VenueName, Location, Capacity, ImageUrl)
VALUES 
(5, 'Sandton Convention Centre', 'Sandton', 500, 'https://www.gauteng.net/wp-content/uploads/2022/05/94fb29355adfc5376d7ada39a2bfd975.jpg'),
(6, 'Northcliff Garden Venue', 'Northcliff', 1000, 'https://thegardenvenue.co.za/wp-content/uploads/2023/08/38-5.jpg');



-- Create Event table
CREATE TABLE Event (
    EventID INT PRIMARY KEY,
    VenueID INT NOT NULL,
    EventName VARCHAR(255) NOT NULL,
    EventDate DATE NOT NULL,
    Description TEXT,
    constraint FK_Event_Venue FOREIGN KEY (VenueID) REFERENCES Venue(VenueID)
);

--INSERTING DATA INTO TABLE Event
INSERT INTO Event (EventID, VenueID, EventName, EventDate, Description)
VALUES 
(101, 5, 'Tech Conference 2025', '2025-06-15', 'Annual tech conference for professionals.'),
(102, 6, 'Wedding Reception', '2025-12-10', 'Elegant wedding event for 200 guests.');



-- Create Booking table
CREATE TABLE Booking (
    BookingID INT PRIMARY KEY,
    EventID INT NOT NULL,
    VenueID INT NOT NULL,
    BookingDate DATE NOT NULL,
    CONSTRAINT FK_Booking_Event FOREIGN KEY (EventID) REFERENCES Event(EventID),
    CONSTRAINT FK_Booking_Venue FOREIGN KEY (VenueID) REFERENCES Venue(VenueID)
);

-- Insert sample data into Booking table
INSERT INTO Booking (BookingID, EventID, VenueID, BookingDate)
VALUES 
(201, 101, 5, '2025-06-01'),
(202, 102, 6, '2025-08-05');

select * 
from Venue;
select *
from Event;
select *
from Booking;


