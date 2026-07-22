# IASTMS - IT Asset & Support Ticket Management System

IASTMS is a learning project that applies C#, Git, SQL, Web API, and frontend development concepts into a practical IT support system.

## Project Goal

To build a system inspired by managed services and IT support workflows.

## Planned Features

- Create support tickets
- Assign tickets to technicians
- Track ticket priority and urgency
- Track ticket status
- Manage IT assets/devices
- Identify device health
- Apply role-based access logic
- Store data in a databasecd 
- Build a Web API
- Build a frontend dashboard

## Learning Milestones

### M01 - Console Ticket Basics

Concepts applied:

- Console input/output
- Variable declarations

Features:

- Input/Output console for Ticket information
- Severity indicator
- Filed date tracking

### M02 - Ticket Decision Logic

Concepts applied:

- Console input/output
- Variable declarations
- if / else if / else 
- Logical operators
- && / || / !
- Combined decision-making

Features:

- Input/Output console for Ticket information
- Severity Indicator
- Filed date tracking
- Technician Assignor based on Device affected
- Ticket Priority Indicator
- Identify device health
- Identify and notify ticket urgency
- Identify role based access

### M03 - Menu Driven Ticket Manager

Concepts applied:

- `while` loop for repeated menu navigation
- `while (true)` loop with `break` for input validation
- Boolean flags for program control
  - `isExit` controls when the program stops
  - `hasTicket` checks if a ticket already exists
- Variable declaration, initialization, and assignment
- Console input and output
- Data conversion using `Convert.ToInt32`
- Manual boolean conversion from string input
- Conditional statements using `if`, `else if`, and `else`
- Logical operators using `&&` and `||`
- Nested conditionals for role-based ticket progress messages
- Basic input validation for role, device, and damaged status
- Basic menu-driven application flow
- Basic ticket state checking before viewing or checking urgency

Features:

- Repeating main menu
- Create a support ticket
- View latest ticket only if a ticket exists
- Check ticket urgency/progress only if a ticket exists
- Prevent viewing empty ticket details using `hasTicket`
- Exit the ticket tracker using menu option 4
- Validate role input: Admin, Technician, or Viewer
- Validate affected device input: Lenovo, MacBook, or HP
- Validate damaged status input: True or False
- Verify validity of input severity and status
- Input ticket subject and description
- Input affected user
- Input affected device
- Input device age
- Input device damage status
- Input ticket severity
- Input ticket status
- Input date of issue occurrence
- Display ticket creation confirmation
- Display ticket status notification
- Recommend replacement or troubleshooting based on device condition
- Identify urgent active tickets using severity and status
- Identify urgent but already resolved tickets
- Identify regular tickets
- Assign technician based on affected device
- Display ticket priority label based on severity
- Display latest ticket details
- Display role-based ticket progress messages for Admin, Technician, and Viewer

### M04 - Reusable Ticket Actions

Concepts applied:

- Methods
- `void` methods
- Return methods
- Method parameters
- Method return values
- Code refactoring
- Reusable decision logic

Features:

- Added reusable app title display
- Added reusable menu display
- Moved technician assignment logic into a method
- Moved priority label logic into a method
- Moved device action logic into a method
- Moved urgency message logic into a method
- Moved role access message logic into a method
- Improved readability of the ticket manager
- Reduced repeated conditional logic

### M05 - Ticket and Asset Models

Concepts applied:

- Classes
- Objects
- Properties
- Object creation using `new`
- Dot notation
- Basic data modeling

Features / Improvements:

- Added `Ticket` model
- Added `Asset` model
- Added `User` model
- Added `Technician` model
- Grouped related ticket information into a `Ticket` object
- Grouped related device information into an `Asset` object
- Grouped related user information into a `User` object
- Grouped related user information into a `Technician` object
- Improved project organization by reducing loose variables

### M06 - Cleaner Object Initialization

Update type: Learning milestone + project structure improvement  
Product version: Not yet v0.1.0

Concepts applied:

- Constructors
- Object initialization
- Constructor parameters
- Property assignment inside constructors
- Cleaner object creation
- Methods in Class

Features / Improvements:

- Added constructor to Ticket model
- Added constructor to Asset model
- Added constructor to User model
- Added constructor to Tehcnician model
- Transferred GetPriorityLabel method inside Ticket model
- Improved object creation by passing values directly into objects
- Reduced repeated property assignment after object creation

### M07 - Multiple Ticket Storage

Update type: Learning milestone + feature update + project improvement  
Product version: Not yet v0.1.0

Concepts applied:

- `List<T>`
- `List<Ticket>`
- `Add()`
- `Count`
- `foreach`
- Multiple object storage
- Empty list checking

Features / Improvements:

- Added multiple ticket storage
- Replaced single-ticket tracking with `List<Ticket>` to store more tickets
- Consolidated other classes into single class (Ticket) for better utilization of foreach loop
- Added ability to create multiple tickets
- Added ability to view all tickets
- Added ticket count display
- Improved project realism by supporting more than one support ticket
- Improved ticket checking by utilizing ticket.Count rather than using a bool hasTicket

## Planned Product Versions

- v0.1.0: Console prototype
- v0.2.0: OOP console app
- v0.3.0: Database-backed version
- v0.4.0: ASP.NET Core Web API version
- v0.5.0: Frontend dashboard prototype
- v1.0.0: Complete MVP

