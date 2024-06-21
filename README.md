<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>README</title>
</head>
<body>
    <h1>Slidely_Task2_DesktopApp</h1>
    
    <h3>Task Description</h3>
    <p>The SlidelyAI Task 2 Desktop App is a Windows desktop application built using Visual Basic in Visual Studio. The app allows users to create, view, and edit submissions. It features:</p>
    <ul>
        <li>Create Submission Form: Users can enter their Name, Email, Phone Number, GitHub link, and record a stopwatch time. The data is then submitted and stored in a backend server.</li>
        <li>View Submissions Form: Users can navigate through the list of submissions using "Previous" and "Next" buttons. The fields are displayed as read-only.</li>
        <li>The backend server is built using Express.js and TypeScript, and it stores submissions in a db.json file.</li>
    </ul>
    
    <h3>Prerequisites</h3>
    <ul>
        <li>Visual Studio</li>
        <li>Node.js</li>
        <li>Git</li>
    </ul>
    
    <h3>Clone the repository</h3>
    <pre><code>git clone https://github.com/parimalthakre01/SlidelyAI_Task2_DesktopApp.git</code></pre>
    
    <h3>Get to the directory</h3>
    <pre><code>cd SlidelyAI_Task2_DesktopApp</code></pre>
    
    <h3>Usage</h3>
    <h4>Create Submission</h4>
    <ul>
        <li>Fill in the fields: Name, Email, Phone Number, GitHub link.</li>
        <li>Use the stopwatch to record time (start, pause, resume).</li>
        <li>Click the "Submit" button to save the submission.</li>
    </ul>
    
    <h4>View Submissions</h4>
    <ul>
        <li>Click on the "View Submissions" button.</li>
        <li>Navigate through submissions using "Previous" and "Next" buttons.</li>
        <li>Click "Edit Submission" to enable editing of the read-only fields.</li>
    </ul>
    
    <h3>Run</h3>
    <p>Run the desktop app:</p>
    <ol>
        <li>In Visual Studio, set the project as the startup project.</li>
        <li>Press F5 or click on the "Start" button to run the application.</li>
    </ol>
</body>
</html>
