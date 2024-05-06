# Firebase Demo Application
This is a simple Windows Forms application demonstrating CRUD (Create, Read, Update, Delete) operations using Firebase Realtime Database.

### Configuration
Make sure to replace the Firebase configuration values in the Form1.cs file with your own Firebase project credentials:
```
IFirebaseConfig config = new FirebaseConfig
{
    AuthSecret = "YOUR_AUTH_SECRET", // project settings > service accounts > database secrets 
    BasePath = "YOUR_FIREBASE_DATABASE_URL" // realtime url link
};
```
### Usage
Launch the application in Visual Studio.
Ensure that your Firebase Realtime Database is set up and accessible.
Use the provided UI to perform CRUD operations on the database.

### Functionality
- Add Data: Enter student information in the provided fields and click the "Add" button to insert it into the database.
- Retrieve Data: Enter a student number and click the "Retrieve" button to fetch the corresponding data from the database.
- Update Data: Enter a student number first then retrieve to Update the student information fields and click the "Update" button to modify the data in the database.
- Delete Data: Enter a student number and click the "Delete" button to remove the corresponding record from the database.
- Delete All Data: Click the "Delete All" button to delete all records stored under the "Information" node in the database.

### Dependencies
- .NET Framework
- FireSharp library for Firebase integration
