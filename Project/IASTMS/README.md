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


### M08 - Ticket Management Actions

Update type: Learning milestone + feature update + project improvement  
Product version: Not yet v0.1.0

Concepts applied:

- List index
- `for` loop with index
- `foreach` search
- `RemoveAt()`
- Search logic
- Update logic
- Delete logic
- Input validation for list positions

Features / Improvements:

- Added ticket search by subject
- Added ticket status update
- Added ticket deletion
- Added numbered ticket display
- Added invalid ticket number checking
- Improved ticket management flow

### M09 - OOP Console Prototype

Update type: Project refactor + feature improvement  
Product version: Not yet v0.1.0

Concepts applied:

- Object-Oriented Programming
- Classes and objects
- Constructors
- `List<Ticket>`
- Service class structure
- Reusable methods
- Private helper methods
- `for` loop with index
- Search, update, and delete logic
- Input validation using `TryParse`
- Case-insensitive search using `StringComparison.OrdinalIgnoreCase`

Features / Improvements:

- Added `TicketService` class to handle ticket actions
- Added `Ticket` model with constructor
- Added `GetPriorityLabel()` method inside the `Ticket` class
- Added reusable ticket display through `DisplayTicket()`
- Added create ticket action
- Added view all tickets action
- Added search ticket action
- Added update ticket status action
- Added delete ticket action
- Added ticket count display
- Improved ticket menu flow
- Improved input validation for menu options, ticket count, severity, device age, date, and damaged status
- Improved search by allowing case-insensitive subject matching
- Reduced repeated ticket display logic
- Improved separation between ticket data and ticket actions

Current status:

- M09 is completed as an OOP console prototype milestone.
- The project is not yet tagged as `v0.1.0`.
- Further cleanup can still be done before the first prototype release.

### M09 Cleanup - OOP Console Prototype Review

Update type: Project cleanup + refactor improvement  
Product version: v0.1.0 candidate, not final release yet

Cleanup completed:

- Moved app title display into `TicketService`
- Moved menu display into `TicketService`
- Moved status notification logic into `TicketService`
- Moved device action logic into `TicketService`
- Moved urgency message logic into `TicketService`
- Moved role access message logic into `TicketService`
- Added menu option validation to only accept options from 1 to 7
- Improved ticket count validation to prevent zero or negative ticket creation
- Removed active test data from the program flow by commenting out sample tickets
- Added empty-list checking before updating tickets
- Added empty-list checking before deleting tickets
- Improved search result message when no ticket is found
- Improved year validation by preventing years below 2000
- Fixed spelling from `Occurence` to `Occurrence`
- Fixed display text spacing in ticket count output
- Cleaned up old commented menu option code
- Improved comments for validation and program flow

### v0.1.0 Candidate Preparation

Update type: Product version preparation + cleanup  
Product version: v0.1.0 candidate

Focus:

- Reviewed the M09 OOP console prototype
- Tested create, view, search, update, delete, and count ticket actions
- Checked menu input validation
- Checked ticket count validation
- Checked empty-list handling for update and delete actions
- Confirmed that test data is not active in the program flow
- Prepared the project for the first console prototype version

Small improvements:

- Improved ticket number message by using the current ticket count
- Improved app title formatting
- Reviewed README documentation for release readiness

Current status:

- IASTMS is ready to be reviewed as a `v0.1.0` candidate.
- The project has a working OOP console prototype.
- The project is not yet tagged as `v0.1.0`.

v0.1.0 candidate features:

- Create tickets
- Store multiple tickets using `List<Ticket>`
- View all tickets
- Search tickets by subject
- Update ticket status
- Delete tickets
- View ticket count
- Validate user input
- Use `Ticket` model
- Use `TicketService` class
- Use constructors and reusable methods

Next planned step:

- Final review and release `IASTMS v0.1.0 - Console Prototype`

### v0.1.0 - Console Prototype Release

Release type: Product version release  
Version: v0.1.0  
Status: Released

Summary:

IASTMS v0.1.0 is the first usable console prototype of the IT Asset & Support Ticket Management System. This version focuses on core ticket management features using C# console programming and basic object-oriented programming.

Included features:

- Create tickets
- Store multiple tickets using `List<Ticket>`
- View all tickets
- Search tickets by subject
- Update ticket status
- Delete tickets
- View ticket count
- Validate user input
- Display dynamic ticket numbers
- Use `Ticket` model
- Use `TicketService` class
- Use constructors and reusable methods

Concepts demonstrated:

- C# console input/output
- Variables and data types
- Conditional statements
- Logical operators
- `while` loops
- `for` loops
- `List<T>`
- Classes and objects
- Constructors
- Methods
- Service class structure
- Basic OOP refactoring

Known limitations:

- Tickets are not saved after the program closes
- Ticket numbers are based on the current list count only
- Classes are still inside `Program.cs`
- Fixed values such as status, role, and device brand are still written as strings
- No database or file storage yet
- No authentication or user accounts yet

### M10 - Separated Class Files

Update type: Project refactor + structure improvement  
Product version: After v0.1.0

Learning scope:

- Multi-file C# project structure
- Class separation
- Code organization
- Model class file
- Service class file
- Cleaner `Program.cs`
- Separation of responsibilities

Files added:

- `Ticket.cs`
- `TicketService.cs`

Features / Improvements:

- Moved `Ticket` class into `Ticket.cs`
- Moved `TicketService` class into `TicketService.cs`
- Reduced the size of `Program.cs`
- Improved project readability
- Improved separation between app flow, ticket data, and ticket actions
- Preserved existing ticket management behavior

### M11 - Constants for Fixed Values

Update type: Project refactor + maintainability improvement  
Product version: After v0.1.0

Learning scope:

- Constants
- Fixed values
- Magic strings
- Safer string comparison
- Maintainability
- Cleaner validation logic

Concepts applied:

- `const`
- `private const string`
- Reusable fixed values
- Role validation method
- Status validation cleanup
- Device brand validation cleanup

Features / Improvements:

- Added constants for ticket statuses
- Added constants for user roles
- Added constants for device brands
- Reduced repeated hardcoded strings
- Improved status checking logic
- Improved device validation logic
- Added reusable role validation through `IsValidRole()`
- Improved code maintainability
- Reduced risk of spelling-related bugs
- Added empty-list validation before searching tickets
- Added user notification when no tickets are available for search

### M12 - Input Validation Helper Methods

Update type: Project refactor + validation improvement  
Product version: After v0.1.0

Learning scope:

- Helper methods
- Input validation
- `TryParse`
- Reusable validation logic
- Method responsibility
- Cleaner console input flow

Concepts applied:

- Reusable number validation method
- Reusable boolean validation method
- Range checking
- Early return through valid input
- Reduced repeated validation loops

Features / Improvements:

- Added `GetValidNumber()` helper method
- Added `GetValidBoolean()` helper method
- Refactored menu option validation
- Refactored ticket count validation
- Refactored device age validation
- Refactored severity validation
- Refactored date validation
- Reduced repeated `while` and `TryParse` blocks
- Improved readability of `Program.cs`
- Improved readability of `CreateTicket()`

### M12 - Input Validation Helper Methods

Update type: Project refactor + validation improvement  
Product version: After v0.1.0

Learning scope:

- Helper methods
- Input validation
- `TryParse`
- Required text validation
- Reusable validation logic
- Range checking
- Cleaner menu handling
- Early return patternls
- Method responsibility
- Code maintainability

Concepts applied:

- `GetValidNumber()`
- `GetValidBoolean()`
- `GetValidStatus()`
- `GetValidDeviceBrand()`
- `GetValidRole()`
- `GetRequiredText()`
- `switch` statement for menu actions
- `return` for stopping a method early
- `StringComparison.OrdinalIgnoreCase` for case-insensitive search
- `Contains()` for partial subject search

Features / Improvements:

- Added reusable number validation through `GetValidNumber()`
- Added reusable boolean validation through `GetValidBoolean()`
- Added reusable required text validation through `GetRequiredText()`
- Added reusable ticket status validation through `GetValidStatus()`
- Added reusable device brand validation through `GetValidDeviceBrand()`
- Added reusable role validation through `GetValidRole()`
- Refactored menu option validation
- Refactored ticket count validation
- Refactored role input validation
- Refactored device brand validation
- Refactored ticket status validation
- Refactored device age validation
- Refactored severity validation
- Refactored date validation
- Prevented blank input for ticket subject, description, affected user, search subject, role, status, and device brand
- Improved search by allowing partial subject matching
- Added empty-list validation before searching tickets
- Added empty-list validation before updating tickets
- Added empty-list validation before deleting tickets
- Removed unnecessary `else` blocks after `return`
- Replaced long `if/else if` menu handling with a cleaner `switch` statement
- Reduced repeated `while` and `TryParse` validation blocks
- Improved readability of `Program.cs`
- Improved readability of `TicketService.cs`
- Improved separation between menu flow and validation logic

### M13 - Debugging Practice

Update type: Learning milestone + debugging practice  
Product version: After v0.1.0

Learning scope:

- Debugging in VS Code
- Breakpoints
- Conditional Breakpoints
- Step Over
- Step Into
- Variable Panel inspection
  - Locals
  - Watch
  - Call Stack
  - Breakpoints
- Runtime investigation
- Ticket creation flow tracing
- List index debugging
- Update and delete flow debugging

Concepts practiced:

- Pausing code execution using breakpoints
- Inspecting variable values while the program is running
- Stepping into helper methods
- Watching `tickets.Count` change after creating and deleting tickets
- Checking how `ticketNumber - 1` converts user input into a list index
- Verifying validation flow through `GetValidNumber()`
- Verifying object creation before adding to `List<Ticket>`

### M14 - Null Handling and Defensive Coding

Update type: Project refactor + input safety improvement  
Product version: After v0.1.0

Learning scope:

- Null handling
- Empty string handling
- Whitespace validation
- Defensive coding
- `Console.ReadLine()`
- Null-coalescing operator `??`
- `string.IsNullOrWhiteSpace()`
- `.Trim()`
- Required text validation

Concepts applied:

- Used `?? ""` to protect against possible null values from `Console.ReadLine()`
- Used `GetRequiredText()` to prevent blank input
- Used `string.IsNullOrWhiteSpace()` to reject empty or whitespace-only text
- Used `.Trim()` to remove extra spaces before validating input
- Reused required text validation in role, status, device, search, and ticket creation input
- Simplified device brand input by relying on `GetValidDeviceBrand()`

### M15 - Method Responsibility Refactor

Update type: Project refactor + code quality improvement  
Product version: After v0.1.0

Learning scope:

- Method responsibility
- Refactoring
- Helper methods
- Cleaner method structure
- Reducing method size
- Preserving existing behavior
- Code readability
- Maintainability
- Tuple
- `var` keyword
- Returning multiple values from a method

Concepts applied:

- Reviewed large methods in `TicketService`
- Identified that `CreateTicket()` was handling many responsibilities
- Added helper methods for ticket text input
- Added a helper method for ticket date input
- Grouped related date validation into `GetTicketDate()`
- Used a tuple to return multiple related values from `GetTicketDate()`
- Used `var` to store the returned tuple from `GetTicketDate()`
- Accessed tuple values using named fields such as `ticketDate.month`, `ticketDate.day`, and `ticketDate.year`
- Reduced unnecessary upfront variable declarations
- Improved readability of `CreateTicket()`

### M16 - Data Persistence | Save Tickets to text file

Update type: Feature update + data persistence improvement  
Product version: After v0.1.0

Learning scope:

- Data persistence
- File writing
- Text file storage
- `File.WriteAllLines()`
- `List<string>`
- Saving object data as readable text
- `try-catch` for file operations
- Early return validation
- Menu option update

Concepts applied:

- Reviewed why `List<Ticket>` only stores data while the app is running
- Converted `List<Ticket>` data into readable text lines
- Used `List<string>` to prepare file content before saving
- Used `File.WriteAllLines()` to write ticket details into `tickets.txt`
- Added validation to prevent saving when no tickets are available
- Used `try-catch` to handle possible file writing errors
- Added a new menu option for saving tickets
- Updated the exit option after adding the save feature

Features / Improvements:

- Added `SaveTicketsToTextFile()` method
- Added text file generation using `tickets.txt`
- Added menu option to save tickets to a text file
- Saved ticket number, subject, description, affected user, device, technician, priority, status, and occurrence date
- Added user notification when no tickets are available to save
- Added basic error handling for file saving
- Preserved existing create, view, search, update, delete, and count actions

## Planned Product Versions

- v0.1.0: Console prototype
- v0.2.0: OOP console app
- v0.3.0: Database-backed version
- v0.4.0: ASP.NET Core Web API version
- v0.5.0: Frontend dashboard prototype
- v1.0.0: Complete MVP