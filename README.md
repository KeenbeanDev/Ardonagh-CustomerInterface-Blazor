
# Customer Data Application

This application has been written for a technical interview for The Ardonagh Group, following the specifications listed on the provided document.

## Summary

This application contains a single page displaying a read-only grid of customer data. 
Included are options to Add new customers, or Edit existing customers through a pop-up dialog. Each field receives validation to ensure data quality is met (see interview document for ruleset)

Upon loading the application, it will generate two pre-set customers to demonstrate the grid. If the page is refreshed, any additional customers that have been created will be loaded in post-render. Closing the application will delete these customer entries.

# Interview Questions

This section covers the 5 questions asked by The Ardonagh Group on the technical interview document.

### 1 - How long have you spent working on this exercise?
I have spent 2 hours and 45 minutes on this exercise. The majority of the code implementation lasted for 2h 15m, and I decided to take an extra 30m to tidy up the code, test functionality thoroughly and neaten up the styling used with the application.

### 2 - Choice of Front-end Technology
For the purpose of this exercise, I have opted to use the Blazor Web App framework. 
Due to the requirement being lightweight in nature, this made the implementation significantly faster to operate and negates the requirement of using a direct API to  handle data transfer. Should there be any increased specifications or larger traffic required within the scope, a dedicated front-end client would be a more stable choice.

### 3 - Design Decisions Taken
Primarily, I have used the MudBlazor and FluentValidation packages available on NuGet Package Manager to assist in my development. 
- MudBlazor was used due to the increased versatility in creating and managing data grids, forms and dialog component options. 
- FluentValidation was also included to add a processing-level validation step on the data, since not all validation can be captured within the InputFields directly.

Cosmetically, I have also opted for a few tweaks to the spec;
- I have opted to use the 'Edit' feature within the MudBlazor DataGrid to handle editing entries despite having a dedicated 'Add' button. This made it easier to develop the application by removing the need for a second dialog component for editing, or having to integrate one dialog to handle both 'Add' and 'Edit' functionality.
- Instead of "OK" buttons on the dialog components, I have chosen to use "Submit", as I personally felt it made more sense when handling data submission.

### 4 - Any Issues Found
One of the major problems when developing the system was ensuring the validators worked on the 'Edit' dialog, due to it being a built-in dialog with no disabling functionality. This primarily affected the Postcode parameter. To remedy this, I created a specific Postcode Validator separate from FluentValidator to ensure all checks were met, ordering their execution my speed (The Regex Match was handled last for efficiency in the method.)

### 5 - What would be your next steps to further improve your work?
I would focus mostly on implementing a relational database into the system, as relying solely on local storage is not a sustainable means for storing data permanently. Should more data fields also be required, I would also like to re-work the grid to have 'Dropdown' functionality, which when expanding the row can display additional data about a customer.

Thank you for considering me for this interview, and I hope all points are covered to your satisfaction within this code base.