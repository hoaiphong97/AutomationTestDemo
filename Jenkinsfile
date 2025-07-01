pipeline {
    agent any

    stages {
        stage('Build') { 
            steps {
                bat 'dotnet restore'
                bat 'dotnet build --no-restore' 
            }
        }

        stage('Run EXE') {
            steps {
                bat '''
                echo Running MyApp.exe...
                start "" "C:\\Path\\To\\YourApp\\MyApp.exe"
                '''
            }
        }
    }
}
