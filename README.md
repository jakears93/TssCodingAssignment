# TSS Code Assignment
An MVC web application to demonstrate knowledge in .NET development.

Youtube Demonstration Link: https://youtu.be/DPWN9vH0vtc

## Getting Started
------------
1)	Clone the git repo to your local machine
2)	Run the createDatabase sql script in the sql folder (Choose to run using the MSSQLLocalDb)
3)	Populate the database with the populateDatabase sql script (Choose to run using the MSSQLLocalDb)
4)	Build the project
5)	Run the project using IIS Express
-	**Note** When switching from my desktop to laptop, I had to build, clean then rebuild the project before I could run it.  However, I'm not sure if this is an issue with my Visual Studio install.  The error message I initially get is that the ..\bin\roslyn\csc.exe is missing.

## Application Usage
------------
-	Products can be added via a login page.  Two accounts exist.  "Username: Admin Password: Password" and "Username: Jacob Password: Arsenault"
-	Only the admin user can modify the product database


## Completed
------------
-	Data is provided by a backing database
-	Display a listing of products
-	Admin can create a new product listing
-	Admin can edit or remove a product listing
-	User can view product listing for more details
-	User can add products to a cart and view the cart