pipeline {
    agent any

    stages {
        stage('Build') { 
            steps {
                bat 'dotnet restore'
                bat 'dotnet build --no-restore' 
            }
        }

        stage('Open Notepad') {
          steps {
            bat 'start "" notepad.exe C:\temp\Demo.txt'
          }
        }
    }
}
