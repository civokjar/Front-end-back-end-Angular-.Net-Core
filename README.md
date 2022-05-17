# Front-end-back-end-Angular-.Net-Core 4hrs constraint
# Introduction
The assessment is intended to be a platform for discussion with the engineering team.
With the assessment, the candidate gets an opportunity to showcase his/her knowledge and demonstrate his approach in software engineering.
The assignment is to build a web application using the following technologies:
- Microsoft Visual Studio solution.
- UI in Angular. 
- Backend in C#.
- SQL Server for persistence.
- Use raw SQL statements in data access layer.
- App is demonstrated locally. Optionally on Azure.
- The assignments deliveries are:
  - Git repository. Preferably private GitHub repository with shared access. Please share access only after when the assessment is complete.
  
 ## Checklist summary. 
- A demo of application. 
- Presentation of project, layers, architecture, code etc.
- Discussion.The assignment is generic and simple. The candidate will be in control of the design. 

Along with the specifics we will provide an optional list to consider with the design and implementation. 
This list represents topics that our team will be interested in to discuss with you.
Consider this as a platform of discussion.

### The process is
- Share the introduction. The candidate gets to prepare the necessary tools.
- The candidate chooses a time slot of maximum 4h to implement the assignment.
- Upon the agreed time, the candidate receives by email the specifics of the assignment.
- The candidate submits his work as we discussed within the valid time limit.Any presentation material can be prepared outside of the 4h window.
- The delivery is evaluated by our team.
- Follow up discussion to discuss the assignment.  

### Specifics
The web application allows users to work on lists.
<br/>The user experience is summarized as:
- A user can create/read/update/delete (CRUD) any of the lists. 
- A list has list items.
- Lists and list items are just text entries.
- In allUIscreens,a user can see the total number of list and items.The following is an optional list to use as direction with the design and implementation.
- Clear layer separation. UI/API/Business/DAL/UnitTests.
- FE uses API from backend.
- Responsive UI.
- Ability to switch between data access layers implemented with raw SQL or EF.
- Unit tests.
- Decouple the counting process from the CRUD operations. Consider the calculationas a relative “heavy” action that would presumably make the UI less responsive.  
- Basic documentation.
- Tracing.
- CI/CD. Preferably with Azure DevOPS but any other will do.•Hosted on Azure.
- Demonstrate a pull request. For example, consider a case where a list can have maximum 5 items.
